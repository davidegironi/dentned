#region License
// Copyright (c) 2015 Davide Gironi
//
// Please refer to LICENSE file for licensing information.
#endregion

using DG.DentneD.Helpers;
using DG.DentneD.Model;
using DG.DentneD.Model.Entity;
using DG.UI.GHF;
using SMcMaster;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DG.DentneD.Forms
{
    public partial class FormReportsrun : DGUIGHFForm
    {
        private DentneDModel _dentnedModel = null;
        private DataTable _datatableReportsParameters = null;
        private SqlConnection _sqlConnection = new SqlConnection();

        private bool _isPasswordLogged = false;

        /// <summary>
        /// Constructor
        /// </summary>
        public FormReportsrun()
        {
            InitializeComponent();
            (new TabOrderManager(this)).SetTabOrder(TabOrderManager.TabScheme.AcrossFirst);

            Initialize(Program.uighfApplication);

            _dentnedModel = new DentneDModel();
            _dentnedModel.LanguageHelper.LoadFromFile(Program.uighfApplication.LanguageFilename);

            //get the connection string
            using (var context = (DbContext)Activator.CreateInstance(_dentnedModel.ContextType, _dentnedModel.ContextParameters))
            {
                _sqlConnection.ConnectionString = context.Database.Connection.ConnectionString;
            }
        }
        
        /// <summary>
        /// Add components language
        /// </summary>
        public override void AddLanguageComponents()
        {
            //main
            LanguageHelper.AddComponent(this);
            LanguageHelper.AddComponent(label_reports);
            LanguageHelper.AddComponent(button_execute);
        }

        /// <summary>
        /// Form language dictionary
        /// </summary>
        public class FormLanguage : IDGUIGHFLanguage
        {
            public string reportsPasswordInputMessage = "Insert password:";
            public string reportsPasswordInputTitle = "Password";
            public string reportsPasswordErrorMessage = "Wrong password.";
            public string reportsPasswordErrorTitle = "Error";
        }
        
        /// <summary>
        /// Form language
        /// </summary>
        public FormLanguage language = new FormLanguage();

        /// <summary>
        /// Loader
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormReportsrun_Load(object sender, EventArgs e)
        {
            _datatableReportsParameters = new DataTable();
            _datatableReportsParameters.Columns.Add("Name", Type.GetType("System.String"));
            _datatableReportsParameters.Columns.Add("Value", Type.GetType("System.String"));

            dataGridView_reportsparameters.DataSource = _datatableReportsParameters;
            dataGridView_reportsparameters.Columns[0].Width = 150;
            dataGridView_reportsparameters.Columns[0].ReadOnly = true;
            dataGridView_reportsparameters.Columns[1].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridView_reportsparameters.Columns[1].ReadOnly = false;

            advancedDataGridView_main.DataSource = null;

            textBox_info.Text = "";

            PreloadView();
        }

        /// <summary>
        /// Form is shown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormReportsrun_Shown(object sender, EventArgs e)
        {
            //reset password logged status
            _isPasswordLogged = false;
        }

        /// <summary>
        /// Preload reports
        /// </summary>
        private void PreloadView()
        {
            IsBindingSourceLoading = true;

            //load filter doctors
            comboBox_reports.DataSource = (new[] { new { name = "", reports_id = -1 } }).Concat(_dentnedModel.Reports.List().Select(r => new { name = r.reports_name, r.reports_id }).OrderBy(r => r.name)).ToArray();
            comboBox_reports.DisplayMember = "name";
            comboBox_reports.ValueMember = "reports_id";

            IsBindingSourceLoading = false;
        }

        /// <summary>
        /// Select a report
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox_reports_SelectedIndexChanged(object sender, EventArgs e)
        {
            advancedDataGridView_main.DataSource = null;
            _datatableReportsParameters.Clear();
            textBox_info.Text = "";

            if (comboBox_reports.SelectedIndex != -1 && comboBox_reports.SelectedIndex != 0)
            {
                int reports_id = Convert.ToInt32(comboBox_reports.SelectedValue);
                reports report = _dentnedModel.Reports.Find(reports_id);

                if (!String.IsNullOrEmpty(report.reports_infotext))
                    textBox_info.Text = report.reports_infotext;

                string query = report.reports_query;
                List<string> pl = Regex.Matches(query, @"(?<!\@)\@\w+").Cast<Match>().Select(m => m.Value).ToList();
                List<string> pinserted = new List<string>();
                foreach (string p in pl)
                {
                    if (!pinserted.Contains(p.ToString()) && !p.StartsWith("@NOT"))
                    {
                        pinserted.Add(p.ToString());
                        DataRow dr = _datatableReportsParameters.NewRow();
                        dr["Name"] = p.ToString();
                        _datatableReportsParameters.Rows.Add(dr);
                    }
                }
            }
        }

        /// <summary>
        /// Run a report
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_execute_Click(object sender, EventArgs e)
        {
            if (comboBox_reports.SelectedIndex != -1 && comboBox_reports.SelectedIndex != 0)
            {
                DataTable dt = new DataTable();

                int reports_id = Convert.ToInt32(comboBox_reports.SelectedValue);
                reports report = _dentnedModel.Reports.Find(reports_id);

                if (report.reports_ispasswordprotected && !_isPasswordLogged)
                {
                    string input = null;
                    if (InputBox.ShowPassword(language.reportsPasswordInputMessage, language.reportsPasswordInputTitle, ref input) == DialogResult.OK)
                    {
                        if (input == ConfigurationManager.AppSettings["formspassword"])
                        {
                            _isPasswordLogged = true;
                        }
                        else
                        {
                            MessageBox.Show(language.reportsPasswordErrorMessage, language.reportsPasswordErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else
                    {
                        return;
                    }
                }

                string query = report.reports_query;

                if (!OpenSQLConnection(_sqlConnection))
                    return;

                try
                {
                    //check for user in group
                    SqlCommand sql_cm1 = null;
                    SqlDataReader sql_rd1 = null;

                    sql_cm1 = new SqlCommand();
                    sql_cm1.Connection = _sqlConnection;
                    sql_cm1.CommandType = CommandType.Text;
                    sql_cm1.CommandText = query;
                    foreach (DataRow dr in _datatableReportsParameters.Rows)
                    {
                        SqlParameter param = new SqlParameter();
                        param.ParameterName = dr["Name"].ToString();
                        param.Value = dr["Value"].ToString();
                        sql_cm1.Parameters.Add(param);
                    }
                    sql_rd1 = sql_cm1.ExecuteReader();
                    
                    for (int i = 0; i < sql_rd1.FieldCount; i++)
                    {
                        dt.Columns.Add(sql_rd1.GetName(i), Type.GetType("System.String"));
                    }
                    while (sql_rd1.Read())
                    {
                        DataRow dr = dt.NewRow();
                        for (int i = 0; i < sql_rd1.FieldCount; i++)
                        {
                            dr[sql_rd1.GetName(i)] = sql_rd1[sql_rd1.GetName(i)].ToString();
                        }
                        dt.Rows.Add(dr);
                    }
                    sql_rd1.Close();

                    sql_rd1.Dispose();
                    sql_cm1.Dispose();
                }
                catch (Exception ex)
                {
                    dt.Columns.Add("Errors", Type.GetType("System.String"));
                    DataRow dr = dt.NewRow();
                    dr["Errors"] = ex.Message;
                    dt.Rows.Add(dr);
                }
                finally
                {
                    _sqlConnection.Close();
                }

                advancedDataGridView_main.DataSource = dt;
                for (int i = 0; i < advancedDataGridView_main.Columns.Count; i++)
                {
                    advancedDataGridView_main.Columns[i].AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
                }
            }
        }

        /// <summary>
        /// Open an SqlConnection
        /// </summary>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        private static bool OpenSQLConnection(SqlConnection sqlConnection)
        {
            bool ret = false;

            try
            {
                if (sqlConnection != null)
                {
                    if (sqlConnection.State == ConnectionState.Closed || sqlConnection.State == ConnectionState.Broken)
                        sqlConnection.Open();

                    if (sqlConnection.State == ConnectionState.Open)
                    {
                        return true;
                    }
                }
            }
            catch { }

            return ret;
        }
        
    }
}
