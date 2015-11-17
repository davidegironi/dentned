#region License
// Copyright (c) 2015 Davide Gironi
//
// Please refer to LICENSE file for licensing information.
#endregion

using DG.Data.Model.Helpers;
using DG.DentneD.Forms.Objects;
using DG.DentneD.Helpers;
using DG.DentneD.Model;
using DG.DentneD.Model.Entity;
using DG.UI.GHF;
using SMcMaster;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Windows.Forms;
using Zuby.ADGV;

namespace DG.DentneD.Forms
{
    public partial class FormReports : DGUIGHFForm
    {
        private DentneDModel _dentnedModel = null;

        private TabElement tabElement_tabReports = new TabElement();

        /// <summary>
        /// Constructor
        /// </summary>
        public FormReports()
        {
            InitializeComponent();
            (new TabOrderManager(this)).SetTabOrder(TabOrderManager.TabScheme.AcrossFirst);

            Initialize(Program.uighfApplication);

            _dentnedModel = new DentneDModel();
            _dentnedModel.LanguageHelper.LoadFromFile(Program.uighfApplication.LanguageFilename);
        }

        /// <summary>
        /// Add components language
        /// </summary>
        public override void AddLanguageComponents()
        {
            //main
            LanguageHelper.AddComponent(this);
            LanguageHelper.AddComponent(reportsidDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(nameDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            //tabAddressesTypes
            LanguageHelper.AddComponent(tabPage_tabReports);
            LanguageHelper.AddComponent(button_tabReports_new);
            LanguageHelper.AddComponent(button_tabReports_edit);
            LanguageHelper.AddComponent(button_tabReports_delete);
            LanguageHelper.AddComponent(button_tabReports_save);
            LanguageHelper.AddComponent(button_tabReports_cancel);
            LanguageHelper.AddComponent(reports_idLabel);
            LanguageHelper.AddComponent(reports_nameLabel);
            LanguageHelper.AddComponent(reports_ispasswordprotectedCheckBox);
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
        /// Initialize TabElements
        /// </summary>
        protected override void InitializeTabElements()
        {
            //set Readonly OnSetEditingMode for Controls
            DisableReadonlyCheckOnSetEditingModeControlCollection.Add(typeof(DataGridView));
            DisableReadonlyCheckOnSetEditingModeControlCollection.Add(typeof(AdvancedDataGridView));

            //set Main BindingSource
            BindingSourceMain = vReportsBindingSource;
            GetDataSourceMain = GetDataSource_main;

            //set Main TabControl
            TabControlMain = tabControl_main;

            //set Main Panels
            PanelFiltersMain = panel_filters;
            PanelListMain = panel_list;
            PanelsExtraMain = null;

            //set tabReports
            tabElement_tabReports = new TabElement()
            {
                TabPageElement = tabPage_tabReports,
                ElementItem = new TabElement.TabElementItem()
                {
                    PanelData = panel_tabReports_data,
                    PanelActions = panel_tabReports_actions,
                    PanelUpdates = panel_tabReports_updates,

                    ParentBindingSourceList = vReportsBindingSource,
                    GetParentDataSourceList = GetDataSource_main,

                    BindingSourceEdit = reportsBindingSource,
                    GetDataSourceEdit = GetDataSourceEdit_tabReports,
                    AfterSaveAction = AfterSaveAction_tabReports,

                    AddButton = button_tabReports_new,
                    UpdateButton = button_tabReports_edit,
                    RemoveButton = button_tabReports_delete,
                    SaveButton = button_tabReports_save,
                    CancelButton = button_tabReports_cancel,

                    Add = Add_tabReports,
                    Update = Update_tabReports,
                    Remove = Remove_tabReports
                }
            };

            //set Elements
            TabElements.Add(tabElement_tabReports);
        }

        /// <summary>
        /// Loader
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormReports_Load(object sender, EventArgs e)
        {
            IsBindingSourceLoading = true;
            advancedDataGridView_main.SortASC(advancedDataGridView_main.Columns[1]);
            IsBindingSourceLoading = false;

            ReloadView();
        }

        /// <summary>
        /// Form is shown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormReports_Shown(object sender, EventArgs e)
        {
            bool isPasswordLogged = false;
            string input = null;
            if (InputBox.ShowPassword(language.reportsPasswordInputMessage, language.reportsPasswordInputTitle, ref input) == DialogResult.OK)
            {
                if (input == ConfigurationManager.AppSettings["formspassword"])
                {
                    isPasswordLogged = true;
                }
                else
                {
                    MessageBox.Show(language.reportsPasswordErrorMessage, language.reportsPasswordErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (!isPasswordLogged)
                this.Close();
        }

        /// <summary>
        /// Get main list DataSource
        /// </summary>
        /// <returns></returns>
        private object GetDataSource_main()
        {
            IEnumerable<VReports> vReports =
                _dentnedModel.Reports.List().Select(
                r => new VReports
                {
                    reports_id = r.reports_id,
                    name = r.reports_name
                }).ToList();

            return DGDataTableUtils.ToDataTable<VReports>(vReports);
        }

        /// <summary>
        /// Main Datagrid filter handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void advancedDataGridView_main_FilterStringChanged(object sender, EventArgs e)
        {
            vReportsBindingSource.Filter = advancedDataGridView_main.FilterString;
        }

        /// <summary>
        /// Main Datagrid sort handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void advancedDataGridView_main_SortStringChanged(object sender, EventArgs e)
        {
            vReportsBindingSource.Sort = advancedDataGridView_main.SortString;
        }


        #region tabReports

        /// <summary>
        /// Load the tab DataSource
        /// </summary>
        /// <returns></returns>
        private object GetDataSourceEdit_tabReports()
        {
            return DGUIGHFData.LoadEntityFromCurrentBindingSource<reports, DentneDModel>(_dentnedModel.Reports, vReportsBindingSource, new string[] { "reports_id" });
        }

        /// <summary>
        /// Do actions after Save
        /// </summary>
        /// <param name="item"></param>
        private void AfterSaveAction_tabReports(object item)
        {
            DGUIGHFData.SetBindingSourcePosition<reports, DentneDModel>(_dentnedModel.Reports, item, vReportsBindingSource);
        }

        /// <summary>
        /// Add an item
        /// </summary>
        /// <param name="item"></param>
        private void Add_tabReports(object item)
        {
            DGUIGHFData.Add<reports, DentneDModel>(_dentnedModel.Reports, item);
        }

        /// <summary>
        /// Update an item
        /// </summary>
        /// <param name="item"></param>
        private void Update_tabReports(object item)
        {
            DGUIGHFData.Update<reports, DentneDModel>(_dentnedModel.Reports, item);
        }

        /// <summary>
        /// Remove an item
        /// </summary>
        /// <param name="item"></param>
        private void Remove_tabReports(object item)
        {
            DGUIGHFData.Remove<reports, DentneDModel>(_dentnedModel.Reports, item);
        }

        #endregion

    }
}
