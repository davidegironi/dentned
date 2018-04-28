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
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Zuby.ADGV;

namespace DG.DentneD.Forms
{
    public partial class FormInvoices : DGUIGHFForm
    {
        private DentneDModel _dentnedModel = null;

        private TabElement tabElement_tabInvoices = new TabElement();
        private TabElement tabElement_tabInvoicesLines = new TabElement();

        private const int MaxRowValueLength = 60;
        private readonly bool _addToothsToDocumentDescription = false;
        private readonly bool _invoicesIsPaidDefault = false;
        private readonly bool _autoincrementInvoicesEstimatesNumber = false;

        /// <summary>
        /// Constructor
        /// </summary>
        public FormInvoices()
        {
            InitializeComponent();
            (new TabOrderManager(this)).SetTabOrder(TabOrderManager.TabScheme.AcrossFirst);

            Initialize(Program.uighfApplication);

            _dentnedModel = new DentneDModel();
            _dentnedModel.LanguageHelper.LoadFromFile(Program.uighfApplication.LanguageFilename);

            panel_listtotal.Visible = Convert.ToBoolean(ConfigurationManager.AppSettings["showInvoicesEstimatesTotal"]);
            _addToothsToDocumentDescription = Convert.ToBoolean(ConfigurationManager.AppSettings["addToothsToDocumentDescription"]);
            _invoicesIsPaidDefault = Convert.ToBoolean(ConfigurationManager.AppSettings["invoicesIsPaidDefault"]);
            _autoincrementInvoicesEstimatesNumber = Convert.ToBoolean(ConfigurationManager.AppSettings["autoincrementInvoicesEstimatesNumber"]);
        }

        /// <summary>
        /// Add components language
        /// </summary>
        public override void AddLanguageComponents()
        {
            //main
            LanguageHelper.AddComponent(this);
            LanguageHelper.AddComponent(label_filterDoctors);
            LanguageHelper.AddComponent(label_filterYears);
            LanguageHelper.AddComponent(totalnetLabel);
            LanguageHelper.AddComponent(totalgrossLabel);
            LanguageHelper.AddComponent(totaldueLabel);
            LanguageHelper.AddComponent(totalduepaidLabel);
            LanguageHelper.AddComponent(numberDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(dateDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(patientDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(ispaidDataGridViewCheckBoxColumn, this.GetType().Name, "HeaderText");
            //tabInvoices
            LanguageHelper.AddComponent(tabPage_tabInvoices);
            LanguageHelper.AddComponent(button_tabInvoices_new);
            LanguageHelper.AddComponent(button_tabInvoices_edit);
            LanguageHelper.AddComponent(button_tabInvoices_delete);
            LanguageHelper.AddComponent(button_tabInvoices_save);
            LanguageHelper.AddComponent(button_tabInvoices_cancel);
            LanguageHelper.AddComponent(button_tabInvoices_print);
            LanguageHelper.AddComponent(button_tabInvoices_setpaid);
            LanguageHelper.AddComponent(invoices_idLabel);
            LanguageHelper.AddComponent(invoices_numberLabel);
            LanguageHelper.AddComponent(invoices_totalnetLabel);
            LanguageHelper.AddComponent(invoices_totalgrossLabel);
            LanguageHelper.AddComponent(invoices_totaldueLabel);
            LanguageHelper.AddComponent(invoices_dateLabel);
            LanguageHelper.AddComponent(invoices_doctorLabel);
            LanguageHelper.AddComponent(invoices_patientLabel);
            LanguageHelper.AddComponent(invoices_paymentLabel);
            LanguageHelper.AddComponent(invoices_footerLabel);
            LanguageHelper.AddComponent(invoices_deductiontaxrateLabel);
            LanguageHelper.AddComponent(invoices_ispaidCheckBox);
            //tabInvoicesLines
            LanguageHelper.AddComponent(tabPage_tabInvoicesLines);
            LanguageHelper.AddComponent(codeDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(descriptionDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(quantityDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(unitpriceDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(taxrateDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(totalpriceDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(button_tabInvoicesLines_new);
            LanguageHelper.AddComponent(button_tabInvoicesLines_edit);
            LanguageHelper.AddComponent(button_tabInvoicesLines_delete);
            LanguageHelper.AddComponent(button_tabInvoicesLines_save);
            LanguageHelper.AddComponent(button_tabInvoicesLines_cancel);
            LanguageHelper.AddComponent(invoiceslines_idLabel);
            LanguageHelper.AddComponent(patientstreatments_idLabel);
            LanguageHelper.AddComponent(invoiceslines_codeLabel);
            LanguageHelper.AddComponent(invoiceslines_quantityLabel);
            LanguageHelper.AddComponent(invoiceslines_unitpriceLabel);
            LanguageHelper.AddComponent(invoiceslines_taxrateLabel);
            LanguageHelper.AddComponent(invoiceslines_descriptionLabel);
            LanguageHelper.AddComponent(treatments_idLabel);
            LanguageHelper.AddComponent(computedlines_idLabel);
            LanguageHelper.AddComponent(invoiceslines_istaxesdeductionsableCheckBox);
            LanguageHelper.AddComponent(groupBox_tabInvoicesLines_filler);
        }

        /// <summary>
        /// Form language dictionary
        /// </summary>
        public class FormLanguage : IDGUIGHFLanguage
        {
            public string doctorselectMessage = "Please select a Doctor.";
            public string doctorselectTitle = "Warning";
            public string paidrequestMessage = "Set this item as paid?";
            public string paidrequestTitle = "Paid";
            public string printmodelerrorMessage = "Can not instantiate the print model.";
            public string printmodelerrorTitle = "Error";
            public string printmodelerrorNone = "No print model available";
            public string printmodelselectMessage = "Select a print template:";
            public string printmodelselectTitle = "Print template";
            public string printcreatefoldererrorMessage = "Can not create destination folder '{0}'.";
            public string printcreatefoldererrorTitle = "Error";
            public string printvalidfilenameerrorMessage = "Can not found a valid filename.";
            public string printvalidfilenameerrorTitle = "Error";
            public string printoverwritefilenamewarningMessage = "The file '{0}' already exists, press 'Yes' to overwrite it, 'No' to open that file, 'Cancel' to exit.";
            public string printoverwritefilenamewarningTitle = "Warning";
            public string printbuildpdferrorMessage = "Can not build the PDF file '{0}'.";
            public string printbuildpdferrorTitle = "Error";
            public string printopenfilenameMessage = "File '{0}' built successful.";
            public string printopenfilenameTitle = "Info";
            public string savewarningnumberMessage = "The selected number is not consistent with the one proposed. Do you want to continue?";
            public string savewarningnumberTitle = "Warning";
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
            BindingSourceMain = vInvoicesBindingSource;
            GetDataSourceMain = GetDataSource_main;

            //set Main TabControl
            TabControlMain = tabControl_main;

            //set Main Panels
            PanelFiltersMain = panel_filters;
            PanelListMain = panel_list;
            PanelsExtraMain = null;

            //set tabInvoices
            tabElement_tabInvoices = new TabElement()
            {
                TabPageElement = tabPage_tabInvoices,
                ElementItem = new TabElement.TabElementItem()
                {
                    PanelData = panel_tabInvoices_data,
                    PanelActions = panel_tabInvoices_actions,
                    PanelUpdates = panel_tabInvoices_updates,

                    ParentBindingSourceList = vInvoicesBindingSource,
                    GetParentDataSourceList = GetDataSource_main,

                    BindingSourceEdit = invoicesBindingSource,
                    GetDataSourceEdit = GetDataSourceEdit_tabInvoices,
                    AfterSaveAction = AfterSaveAction_tabInvoices,

                    AddButton = button_tabInvoices_new,
                    IsAddButtonDefaultClickEventAttached = false,
                    UpdateButton = button_tabInvoices_edit,
                    IsUpdateButtonDefaultClickEventAttached = false,
                    RemoveButton = button_tabInvoices_delete,
                    SaveButton = button_tabInvoices_save,
                    IsSaveButtonDefaultClickEventAttached = false,
                    CancelButton = button_tabInvoices_cancel,

                    Add = Add_tabInvoices,
                    Update = Update_tabInvoices,
                    Remove = Remove_tabInvoices
                }
            };

            //set tabInvoicesLines
            tabElement_tabInvoicesLines = new TabElement()
            {
                TabPageElement = tabPage_tabInvoicesLines,
                ElementListItem = new TabElement.TabElementListItem()
                {
                    PanelFilters = null,
                    PanelList = panel_tabInvoicesLines_list,

                    PanelData = panel_tabInvoicesLines_data,
                    PanelActions = panel_tabInvoicesLines_actions,
                    PanelUpdates = panel_tabInvoicesLines_updates,

                    BindingSourceList = vInvoicesLinesBindingSource,
                    GetDataSourceList = GetDataSourceList_tabInvoicesLines,

                    BindingSourceEdit = invoiceslinesBindingSource,
                    GetDataSourceEdit = GetDataSourceEdit_tabInvoicesLines,
                    AfterSaveAction = AfterSaveAction_tabInvoicesLines,

                    AddButton = button_tabInvoicesLines_new,
                    IsAddButtonDefaultClickEventAttached = false,
                    UpdateButton = button_tabInvoicesLines_edit,
                    IsUpdateButtonDefaultClickEventAttached = false,
                    RemoveButton = button_tabInvoicesLines_delete,
                    SaveButton = button_tabInvoicesLines_save,
                    CancelButton = button_tabInvoicesLines_cancel,

                    Add = Add_tabInvoicesLines,
                    Update = Update_tabInvoicesLines,
                    Remove = Remove_tabInvoicesLines
                }
            };

            //set Elements
            TabElements.Add(tabElement_tabInvoices);
            TabElements.Add(tabElement_tabInvoicesLines);
        }

        /// <summary>
        /// Loader
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormInvoices_Load(object sender, EventArgs e)
        {
            IsBindingSourceLoading = true;
            advancedDataGridView_main.SortDESC(advancedDataGridView_main.Columns[1]);
            advancedDataGridView_main.SortDESC(advancedDataGridView_main.Columns[0]);
            IsBindingSourceLoading = false;

            PreloadView();

            //select an invoice on load invoice
            int invoices_id = -1;
            invoices invoice = null;
            foreach (Form form in this.MdiParent.MdiChildren)
            {
                if (form.GetType() == typeof(FormPatients))
                {
                    invoices_id = ((FormPatients)form).invoices_id_toload;
                    ((FormPatients)form).invoices_id_toload = -1;
                }

                if (invoices_id != -1)
                {
                    IsBindingSourceLoading = true;
                    invoice = _dentnedModel.Invoices.Find(invoices_id);
                    if (invoice != null)
                    {
                        if (invoice.doctors_id != null)
                            comboBox_filterDoctors.SelectedValue = invoice.doctors_id;
                        else
                            comboBox_filterDoctors.SelectedIndex = -1;
                    }
                    comboBox_filterYears.SelectedValue = invoice.invoices_date.Year;
                    IsBindingSourceLoading = false;
                    break;
                }
            }

            ReloadView();

            //select an invoice on load invoice
            if (invoice != null)
            {
                DGUIGHFData.SetBindingSourcePosition<invoices, DentneDModel>(_dentnedModel.Invoices, invoice, vInvoicesBindingSource);
                tabControl_main.SelectedTab = tabPage_tabInvoices;
            }
        }

        /// <summary>
        /// Preload View
        /// </summary>
        private void PreloadView()
        {
            IsBindingSourceLoading = true;

            //load doctors
            doctors_idComboBox.DataSource = _dentnedModel.Doctors.List().OrderBy(r => r.doctors_surname).ThenBy(r => r.doctors_name).Select(r => new { name = r.doctors_surname + " " + r.doctors_name, r.doctors_id }).ToArray();
            doctors_idComboBox.DisplayMember = "name";
            doctors_idComboBox.ValueMember = "doctors_id";
            doctors_idComboBox.SelectedIndex = -1;

            //load patients
            patients_idComboBox.DataSource = _dentnedModel.Patients.List().OrderBy(r => r.patients_surname).ThenBy(r => r.patients_name).Select(r => new { name = r.patients_surname + " " + r.patients_name, r.patients_id }).ToArray();
            patients_idComboBox.DisplayMember = "name";
            patients_idComboBox.ValueMember = "patients_id";
            patients_idComboBox.SelectedIndex = -1;

            //load payments
            invoices_paymentComboBox.DataSource = _dentnedModel.PaymentsTypes.List().OrderBy(r => r.paymentstypes_name).Select(r => new { name = r.paymentstypes_name, r.paymentstypes_id }).ToArray();
            invoices_paymentComboBox.DisplayMember = "name";
            invoices_paymentComboBox.ValueMember = "paymentstypes_id";
            invoices_paymentComboBox.SelectedIndex = -1;

            //load footers
            invoices_footerComboBox.DataSource = _dentnedModel.InvoicesFooters.List().OrderBy(r => r.invoicesfooters_name).Select(r => new { name = r.invoicesfooters_name, r.invoicesfooters_id }).ToArray();
            invoices_footerComboBox.DisplayMember = "name";
            invoices_footerComboBox.ValueMember = "invoicesfooters_id";
            invoices_footerComboBox.SelectedIndex = -1;

            //load deduction taxes
            invoices_deductiontaxrateComboBox.DataSource = _dentnedModel.TaxesDeductions.List().OrderBy(r => r.taxesdeductions_name).Select(r => new { name = r.taxesdeductions_name, r.taxesdeductions_id }).ToArray();
            invoices_deductiontaxrateComboBox.DisplayMember = "name";
            invoices_deductiontaxrateComboBox.ValueMember = "taxesdeductions_id";
            invoices_deductiontaxrateComboBox.SelectedIndex = -1;

            //load tax rates
            invoiceslines_taxrateComboBox.DataSource = _dentnedModel.Taxes.List().OrderBy(r => r.taxes_name).Select(r => new { name = r.taxes_name, r.taxes_id }).ToArray();
            invoiceslines_taxrateComboBox.DisplayMember = "name";
            invoiceslines_taxrateComboBox.ValueMember = "taxes_id";
            invoiceslines_taxrateComboBox.SelectedIndex = -1;

            //load treatments
            treatments_idComboBox.DataSource = _dentnedModel.Treatments.List().OrderBy(r => r.treatments_code).ThenBy(r => r.treatments_name).Select(r => new { name = r.treatments_code + " - " + r.treatments_name, r.treatments_id }).ToArray();
            treatments_idComboBox.DisplayMember = "name";
            treatments_idComboBox.ValueMember = "treatments_id";
            treatments_idComboBox.SelectedIndex = -1;

            //load computed lines
            computedlines_idComboBox.DataSource = _dentnedModel.ComputedLines.List().OrderBy(r => r.computedlines_name).Select(r => new { name = r.computedlines_name, r.computedlines_id }).ToArray();
            computedlines_idComboBox.DisplayMember = "name";
            computedlines_idComboBox.ValueMember = "computedlines_id";
            computedlines_idComboBox.SelectedIndex = -1;

            //load filter doctors
            comboBox_filterDoctors.DataSource = (new[] { new { name = "", doctors_id = -1 } }).Concat(_dentnedModel.Doctors.List().OrderBy(r => r.doctors_surname).ThenBy(r => r.doctors_name).Select(r => new { name = r.doctors_surname + " " + r.doctors_name, r.doctors_id })).ToArray();
            comboBox_filterDoctors.DisplayMember = "name";
            comboBox_filterDoctors.ValueMember = "doctors_id";
            comboBox_filterDoctors.SelectedIndex = -1;
            if (comboBox_filterDoctors.Items.Count == 2)
                comboBox_filterDoctors.SelectedIndex = 1;

            IsBindingSourceLoading = false;

            //load filter years
            ReloadFilterYears();
        }

        /// <summary>
        /// Reset all the tab datagrid
        /// </summary>
        private void ResetTabsDataGrid()
        {
            IsBindingSourceLoading = true;
            advancedDataGridView_tabInvoicesLines_list.CleanFilterAndSort();
            advancedDataGridView_tabInvoicesLines_list.SortASC(advancedDataGridView_tabInvoicesLines_list.Columns[1]);
            IsBindingSourceLoading = false;
        }

        /// <summary>
        /// Reload Years filter
        /// </summary>
        private void ReloadFilterYears()
        {
            IsBindingSourceLoading = true;
            int currentSelectedIndex = comboBox_filterYears.SelectedIndex;
            List<int> years = new List<int>();
            foreach (invoices a in _dentnedModel.Invoices.List().OrderBy(r => r.invoices_date))
            {
                if (!years.Contains(a.invoices_date.Year))
                    years.Add(a.invoices_date.Year);
            }
            comboBox_filterYears.DataSource = years.Select(r => new { name = r.ToString(), year = r }).ToArray();
            comboBox_filterYears.DisplayMember = "name";
            comboBox_filterYears.ValueMember = "year";

            if (currentSelectedIndex == -1)
                comboBox_filterYears.SelectedIndex = comboBox_filterYears.Items.Count - 1;
            else
            {
                if (currentSelectedIndex > comboBox_filterYears.Items.Count - 1)
                    comboBox_filterYears.SelectedIndex = comboBox_filterYears.Items.Count - 1;
                else
                    comboBox_filterYears.SelectedIndex = currentSelectedIndex;
            }
            IsBindingSourceLoading = false;
        }

        /// <summary>
        /// Get main list DataSource
        /// </summary>
        /// <returns></returns>
        private object GetDataSource_main()
        {
            ResetTabsDataGrid();

            int doctors_id = -1;
            if (comboBox_filterDoctors.SelectedIndex != -1)
            {
                doctors_id = Convert.ToInt32(comboBox_filterDoctors.SelectedValue);
            }
            int year = -1;
            if (comboBox_filterYears.SelectedIndex != -1)
            {
                year = Convert.ToInt32(comboBox_filterYears.SelectedValue);
            }

            totalnetTextBox.Text = "0";
            totalgrossTextBox.Text = "0";
            totaldueTextBox.Text = "0";
            totalduepaidTextBox.Text = "0";

            //reset list total
            SetListTotal(year);

            Hashtable patientsnames = new Hashtable();
            foreach (patients patient in _dentnedModel.Patients.List())
            {
                patientsnames[patient.patients_id] = patient.patients_surname + " " + patient.patients_name;
            }
            IEnumerable<VInvoices> vInvoices = _dentnedModel.Invoices.List(r => r.invoices_date.Year == year && r.doctors_id == (doctors_id == -1 ? null : (Nullable<int>)doctors_id)).Select(
                r => new VInvoices
                {
                    invoices_id = r.invoices_id,
                    date = r.invoices_date,
                    ispaid = r.invoices_ispaid,
                    number = r.invoices_number,
                    patient = (r.patients_id != null ? (patientsnames.ContainsKey(r.patients_id) ? patientsnames[r.patients_id].ToString() : "") : "")
                }).ToList();

            return DGDataTableUtils.ToDataTable<VInvoices>(vInvoices);
        }

        /// <summary>
        /// Main Datagrid filter handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void advancedDataGridView_main_FilterStringChanged(object sender, EventArgs e)
        {
            vInvoicesBindingSource.Filter = advancedDataGridView_main.FilterString;
        }

        /// <summary>
        /// Main Datagrid sort handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void advancedDataGridView_main_SortStringChanged(object sender, EventArgs e)
        {
            vInvoicesBindingSource.Sort = advancedDataGridView_main.SortString;
        }

        /// <summary>
        /// Doctors filter handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox_filterDoctors_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsBindingSourceLoading)
                return;

            ReloadView();
        }

        /// <summary>
        /// Years filter handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox_filterYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsBindingSourceLoading)
                return;

            ReloadView();
        }

        /// <summary>
        /// Set the main list total
        /// </summary>
        /// <param name="year"></param>
        private void SetListTotal(int year)
        {
            int doctors_id = -1;
            if (comboBox_filterDoctors.SelectedIndex != -1)
            {
                doctors_id = Convert.ToInt32(comboBox_filterDoctors.SelectedValue);
            }

            totalnetTextBox.Text = Math.Round(_dentnedModel.Invoices.List(r => r.doctors_id == doctors_id && r.invoices_date.Year == year).Sum(r => r.invoices_totalnet), 2).ToString();
            totalgrossTextBox.Text = Math.Round(_dentnedModel.Invoices.List(r => r.doctors_id == doctors_id && r.invoices_date.Year == year).Sum(r => r.invoices_totalgross), 2).ToString();
            totaldueTextBox.Text = Math.Round(_dentnedModel.Invoices.List(r => r.doctors_id == doctors_id && r.invoices_date.Year == year).Sum(r => r.invoices_totaldue), 2).ToString();
            totalduepaidTextBox.Text = Math.Round(_dentnedModel.Invoices.List(r => r.doctors_id == doctors_id && r.invoices_date.Year == year && r.invoices_ispaid).Sum(r => r.invoices_totaldue), 2).ToString();
        }


        #region tabInvoices

        /// <summary>
        /// Load the tab DataSource
        /// </summary>
        /// <returns></returns>
        private object GetDataSourceEdit_tabInvoices()
        {
            return DGUIGHFData.LoadEntityFromCurrentBindingSource<invoices, DentneDModel>(_dentnedModel.Invoices, vInvoicesBindingSource, new string[] { "invoices_id" });
        }

        /// <summary>
        /// Do actions after Save
        /// </summary>
        /// <param name="item"></param>
        private void AfterSaveAction_tabInvoices(object item)
        {
            DGUIGHFData.SetBindingSourcePosition<invoices, DentneDModel>(_dentnedModel.Invoices, item, vInvoicesBindingSource);
        }

        /// <summary>
        /// Add an item
        /// </summary>
        /// <param name="item"></param>
        private void Add_tabInvoices(object item)
        {
            DGUIGHFData.Add<invoices, DentneDModel>(_dentnedModel.Invoices, item);

            //load filter years
            ReloadFilterYears();

            if (comboBox_filterYears.SelectedIndex != -1)
            {
                if (((invoices)item).invoices_date.Year != Convert.ToInt32(comboBox_filterYears.SelectedValue))
                {
                    ReloadView();
                    comboBox_filterYears.SelectedIndex = comboBox_filterYears.Items.Count - 1;
                }
            }
        }

        /// <summary>
        /// Update an item
        /// </summary>
        /// <param name="item"></param>
        private void Update_tabInvoices(object item)
        {
            DGUIGHFData.Update<invoices, DentneDModel>(_dentnedModel.Invoices, item);

            //load filter years
            ReloadFilterYears();

            if (comboBox_filterYears.SelectedIndex != -1)
            {
                if (((invoices)item).invoices_date.Year != Convert.ToInt32(comboBox_filterYears.SelectedValue))
                {
                    ReloadView();
                    comboBox_filterYears.SelectedIndex = comboBox_filterYears.Items.Count - 1;
                }
            }
        }

        /// <summary>
        /// Remove an item
        /// </summary>
        /// <param name="item"></param>
        private void Remove_tabInvoices(object item)
        {
            DGUIGHFData.Remove<invoices, DentneDModel>(_dentnedModel.Invoices, item);

            //load filter years
            ReloadFilterYears();
        }

        /// <summary>
        /// New button handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_tabInvoices_new_Click(object sender, EventArgs e)
        {
            if (comboBox_filterDoctors.SelectedIndex == -1 || comboBox_filterDoctors.SelectedIndex == 0)
            {
                MessageBox.Show(language.doctorselectMessage, language.doctorselectTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            IsBindingSourceLoading = true;
            if (AddClick(tabElement_tabInvoices))
            {
                //set default values
                int doctors_id = Convert.ToInt32(comboBox_filterDoctors.SelectedValue);
                int year = DateTime.Now.Year;
                if (comboBox_filterYears.SelectedIndex != -1)
                {
                    if (Convert.ToInt32(comboBox_filterYears.SelectedValue) == year - 1)
                    {
                        if (_dentnedModel.Invoices.Any(r => r.doctors_id == doctors_id && r.invoices_date.Year == year))
                            year = Convert.ToInt32(comboBox_filterYears.SelectedValue);
                    }
                    else
                        year = Convert.ToInt32(comboBox_filterYears.SelectedValue);
                }
                Nullable<int> maxnumber = null;
                if (_autoincrementInvoicesEstimatesNumber)
                    maxnumber = GetMaxNumber(doctors_id, year);
                ((invoices)invoicesBindingSource.Current).invoices_ispaid = _invoicesIsPaidDefault;
                ((invoices)invoicesBindingSource.Current).doctors_id = doctors_id;
                ((invoices)invoicesBindingSource.Current).patients_id = null;
                if (_dentnedModel.PaymentsTypes.Any(r => r.paymentstypes_isdefault))
                    ((invoices)invoicesBindingSource.Current).invoices_payment = _dentnedModel.PaymentsTypes.FirstOrDefault(r => r.paymentstypes_isdefault).paymentstypes_doctext;
                if (_dentnedModel.InvoicesFooters.Any(r => r.invoicesfooters_isdefault))
                    ((invoices)invoicesBindingSource.Current).invoices_footer = _dentnedModel.InvoicesFooters.FirstOrDefault(r => r.invoicesfooters_isdefault).invoicesfooters_doctext;
                if (_dentnedModel.TaxesDeductions.Any(r => r.taxesdeductions_isdefault))
                    ((invoices)invoicesBindingSource.Current).invoices_deductiontaxrate = _dentnedModel.TaxesDeductions.FirstOrDefault(r => r.taxesdeductions_isdefault).taxesdeductions_rate;
                ((invoices)invoicesBindingSource.Current).invoices_date = new DateTime(year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, 0);
                if (maxnumber != null)
                    ((invoices)invoicesBindingSource.Current).invoices_number = ((int)maxnumber).ToString();
                //reset BindingSource
                invoicesBindingSource.ResetBindings(true);
                //raise changed indexes
                IsBindingSourceLoading = false;
                doctors_idComboBox_SelectedIndexChanged(null, null);
                invoices_paymentComboBox_SelectedIndexChanged(null, null);
                invoices_footerComboBox_SelectedIndexChanged(null, null);
                invoices_deductiontaxrateComboBox_SelectedIndexChanged(null, null);
            }
            IsBindingSourceLoading = false;
        }

        /// <summary>
        /// Edit button handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_tabInvoices_edit_Click(object sender, EventArgs e)
        {
            if (UpdateClick(tabElement_tabInvoices))
            {
                doctors_idComboBox.Enabled = false;
                patients_idComboBox.Enabled = false;
            }
        }

        /// <summary>
        /// Paid button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_tabInvoices_setpaid_Click(object sender, EventArgs e)
        {
            if (vInvoicesBindingSource.Current != null)
            {
                int invoices_id = -1;
                if (vInvoicesBindingSource.Current != null)
                {
                    invoices_id = (((DataRowView)vInvoicesBindingSource.Current).Row).Field<int>("invoices_id");
                }

                if (invoices_id != -1)
                {
                    invoices invoice = _dentnedModel.Invoices.Find(invoices_id);

                    if (!invoice.invoices_ispaid)
                    {
                        if (MessageBox.Show(language.paidrequestMessage, language.paidrequestTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            invoice.invoices_ispaid = true;
                            _dentnedModel.Invoices.Update(invoice);
                            ReloadAfterSave(tabElement_tabInvoices, invoice);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Print button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_tabInvoices_print_Click(object sender, EventArgs e)
        {
            if (vInvoicesBindingSource.Current != null)
            {
                int invoices_id = -1;
                if (vInvoicesBindingSource.Current != null)
                {
                    invoices_id = (((DataRowView)vInvoicesBindingSource.Current).Row).Field<int>("invoices_id");
                }

                if (invoices_id != -1)
                {
                    PrintInvoices(invoices_id);
                }
            }
        }

        /// <summary>
        /// Save click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_tabInvoices_save_Click(object sender, EventArgs e)
        {
            if (tabElement_tabInvoices.CurrentEditingMode == EditingMode.C)
            {
                //check max number for new insertion
                if (_autoincrementInvoicesEstimatesNumber && ((invoices)invoicesBindingSource.Current).doctors_id != null)
                {
                    int doctors_id = (int)((invoices)invoicesBindingSource.Current).doctors_id;
                    int year = ((invoices)invoicesBindingSource.Current).invoices_date.Year;
                    int maxnumber = GetMaxNumber(doctors_id, year);
                    GetMaxNumber(doctors_id, year);
                    if (maxnumber.ToString() != ((invoices)invoicesBindingSource.Current).invoices_number)
                    {
                        if (MessageBox.Show(language.savewarningnumberMessage, language.savewarningnumberTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                        {
                            return;
                        }
                    }
                }
            }

            SaveClick(tabElement_tabInvoices);
        }

        /// <summary>
        /// Print an invoice
        /// </summary>
        /// <param name="invoices_id"></param>
        private void PrintInvoices(int invoices_id)
        {
            invoices invoice = _dentnedModel.Invoices.Find(invoices_id);
            if (invoice == null)
                return;

            //load print templates
            string[] templates = new string[] { };
            Dictionary<string, IDentneDPrintModel> templatesModels = new Dictionary<string, IDentneDPrintModel>();
            foreach (string assemblyPath in ConfigurationManager.AppSettings["printModels"].Split(','))
            {
                IDentneDPrintModel printModelt = DentneDPrintModelHelper.DentneDPrintModelInstance(assemblyPath);
                if (printModelt != null)
                {
                    if (printModelt.IsBuildInvoicePDFEnabled())
                    {
                        string modelname = printModelt.BuildInvoicePDFName(ConfigurationManager.AppSettings["language"]);
                        if (!templatesModels.ContainsKey(modelname))
                        {
                            templatesModels.Add(modelname, printModelt);
                            templates = templates.Concat(new string[] { modelname }).ToArray();
                        }
                    }
                }
            }
            if (templates.Count() == 0)
            {
                MessageBox.Show(language.printmodelerrorMessage, language.printmodelerrorNone, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //select printmodel from print template
            IDentneDPrintModel printModel = null;
            if (templates.Count() == 1)
                printModel = templatesModels.FirstOrDefault().Value;
            else
            {
                string template = null;
                if (SelectorBox.Show(language.printmodelselectMessage, language.printmodelselectTitle, templates, ref template) == DialogResult.OK)
                {
                    if (templatesModels.Any(r => r.Key == template))
                        printModel = templatesModels.FirstOrDefault(r => r.Key == template).Value;
                }
                else
                    return;
            }
            if (printModel == null)
            {
                MessageBox.Show(language.printmodelerrorMessage, language.printmodelerrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //prepare folders
            string destfolder = ConfigurationManager.AppSettings["tmpdir"];
            if (invoice.doctors_id != null)
                destfolder = ConfigurationManager.AppSettings["invoicesdir"] + "\\" + invoice.invoices_date.Year.ToString() + "\\" + ((int)invoice.doctors_id).ToString();
            if (!FileHelper.CreateFolder(destfolder))
            {
                MessageBox.Show(String.Format(language.printcreatefoldererrorMessage, destfolder), language.printcreatefoldererrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //make new filename
            bool buildpdf = true;
            string filename = FileHelper.FindRandomFileName(destfolder, "E", "pdf");
            if (invoice.doctors_id != null)
            {
                filename = destfolder + "\\" + ((int)invoice.doctors_id).ToString() + "_" + invoice.invoices_date.Year.ToString() + "-" + invoice.invoices_number + ".pdf";
                if (File.Exists(filename))
                {
                    DialogResult dialogResult = MessageBox.Show(String.Format(language.printoverwritefilenamewarningMessage, filename), language.printoverwritefilenamewarningTitle, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.Yes)
                    { }
                    else if (dialogResult == DialogResult.No)
                        buildpdf = false;
                    else
                        return;
                }
            }
            else
            {
                if (String.IsNullOrEmpty(filename))
                {
                    MessageBox.Show(language.printvalidfilenameerrorMessage, language.printvalidfilenameerrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (buildpdf)
            {
                //build PDF
                if (!printModel.BuildInvoicePDF(_dentnedModel, invoices_id, filename, ConfigurationManager.AppSettings["language"]))
                {
                    MessageBox.Show(String.Format(language.printbuildpdferrorMessage, filename), language.printbuildpdferrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            //try to start the process
            try
            {
                Process.Start(filename);
            }
            catch
            {
                MessageBox.Show(String.Format(language.printopenfilenameMessage, filename), language.printopenfilenameTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Get the max available number of invoice
        /// </summary>
        /// <param name="doctors_id"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        private int GetMaxNumber(int doctors_id, int year)
        {
            int maxnumber = 0;
            string[] numbers = _dentnedModel.Invoices.List(r => r.doctors_id == doctors_id && r.invoices_date.Year == year).Select(r => r.invoices_number).ToArray();
            try
            {
                foreach (string number in numbers)
                {
                    int n = Convert.ToInt32(number);
                    if (n > maxnumber)
                        maxnumber = n;
                }
                maxnumber++;
            }
            catch { }
            if (maxnumber == 0)
                maxnumber++;
            return maxnumber;
        }

        /// <summary>
        /// Doctors changed handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void doctors_idComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsBindingSourceLoading)
                return;

            if (doctors_idComboBox.SelectedValue != null && (tabElement_tabInvoices.CurrentEditingMode == EditingMode.C || tabElement_tabInvoices.CurrentEditingMode == EditingMode.U))
            {
                ((invoices)invoicesBindingSource.Current).invoices_doctor = "";
                doctors doctor = _dentnedModel.Doctors.Find((int)doctors_idComboBox.SelectedValue);
                if (doctor != null)
                    ((invoices)invoicesBindingSource.Current).invoices_doctor = doctor.doctors_doctext;
                ((invoices)invoicesBindingSource.Current).doctors_id = (int)doctors_idComboBox.SelectedValue;
                invoicesBindingSource.ResetBindings(true);
            }
        }

        /// <summary>
        /// Patients changed handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void patients_idComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsBindingSourceLoading)
                return;

            if (patients_idComboBox.SelectedValue != null && (tabElement_tabInvoices.CurrentEditingMode == EditingMode.C || tabElement_tabInvoices.CurrentEditingMode == EditingMode.U))
            {
                ((invoices)invoicesBindingSource.Current).invoices_patient = "";
                patients patient = _dentnedModel.Patients.Find((int)patients_idComboBox.SelectedValue);
                if (patient != null)
                    ((invoices)invoicesBindingSource.Current).invoices_patient = patient.patients_doctext;
                ((invoices)invoicesBindingSource.Current).patients_id = (int)patients_idComboBox.SelectedValue;
                invoicesBindingSource.ResetBindings(true);
            }
        }

        /// <summary>
        /// Payment Type changed handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void invoices_paymentComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsBindingSourceLoading)
                return;

            if (invoices_paymentComboBox.SelectedIndex != -1 && (tabElement_tabInvoices.CurrentEditingMode == EditingMode.C || tabElement_tabInvoices.CurrentEditingMode == EditingMode.U))
            {
                int paymentstypes_id = -1;
                try
                {
                    paymentstypes_id = Convert.ToInt32(invoices_paymentComboBox.SelectedValue);
                }
                catch { }
                if (paymentstypes_id != -1)
                {
                    paymentstypes paymentstype = _dentnedModel.PaymentsTypes.Find(paymentstypes_id);
                    ((invoices)invoicesBindingSource.Current).invoices_payment = paymentstype.paymentstypes_doctext;
                }
                invoicesBindingSource.ResetBindings(true);
            }
        }

        /// <summary>
        /// Footer changed handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void invoices_footerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsBindingSourceLoading)
                return;

            if (invoices_footerComboBox.SelectedIndex != -1 && (tabElement_tabInvoices.CurrentEditingMode == EditingMode.C || tabElement_tabInvoices.CurrentEditingMode == EditingMode.U))
            {
                int invoicesfooters_id = -1;
                try
                {
                    invoicesfooters_id = Convert.ToInt32(invoices_footerComboBox.SelectedValue);
                }
                catch { }
                if (invoicesfooters_id != -1)
                {
                    invoicesfooters invoicesfooter = _dentnedModel.InvoicesFooters.Find(invoicesfooters_id);
                    ((invoices)invoicesBindingSource.Current).invoices_footer = invoicesfooter.invoicesfooters_doctext;
                }
                invoicesBindingSource.ResetBindings(true);
            }
        }

        /// <summary>
        /// Deduction tax changed handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void invoices_deductiontaxrateComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsBindingSourceLoading)
                return;

            if (invoices_deductiontaxrateComboBox.SelectedIndex != -1 && (tabElement_tabInvoices.CurrentEditingMode == EditingMode.C || tabElement_tabInvoices.CurrentEditingMode == EditingMode.U))
            {
                int taxesdeductions_id = -1;
                try
                {
                    taxesdeductions_id = Convert.ToInt32(invoices_deductiontaxrateComboBox.SelectedValue);
                }
                catch { }
                if (taxesdeductions_id != -1)
                {
                    taxesdeductions taxesdeduction = _dentnedModel.TaxesDeductions.Find(taxesdeductions_id);
                    ((invoices)invoicesBindingSource.Current).invoices_deductiontaxrate = taxesdeduction.taxesdeductions_rate;
                }
                invoicesBindingSource.ResetBindings(true);
            }
        }

        /// <summary>
        /// Payment Type leaved
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void invoices_paymentComboBox_Leave(object sender, EventArgs e)
        {
            IsBindingSourceLoading = true;
            invoices_paymentComboBox.SelectedIndex = -1;
            IsBindingSourceLoading = false;
        }

        /// <summary>
        /// Footer leaved
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void invoices_footerComboBox_Leave(object sender, EventArgs e)
        {
            IsBindingSourceLoading = true;
            invoices_footerComboBox.SelectedIndex = -1;
            IsBindingSourceLoading = false;
        }

        /// <summary>
        /// Deduction tax leaved
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void invoices_deductiontaxrateComboBox_Leave(object sender, EventArgs e)
        {
            IsBindingSourceLoading = true;
            invoices_deductiontaxrateComboBox.SelectedIndex = -1;
            IsBindingSourceLoading = false;
        }

        /// <summary>
        /// Combobox autocomplete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void doctors_idComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComboBoxHelper.AutoCompleteOnKeyPress((ComboBox)sender, e);
        }

        /// <summary>
        /// Combobox autocomplete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void patients_idComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComboBoxHelper.AutoCompleteOnKeyPress((ComboBox)sender, e);
        }

        /// <summary>
        /// Combobox autocomplete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void invoices_paymentComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComboBoxHelper.AutoCompleteOnKeyPress((ComboBox)sender, e);
        }

        /// <summary>
        /// Combobox autocomplete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void invoices_footerComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComboBoxHelper.AutoCompleteOnKeyPress((ComboBox)sender, e);
        }

        /// <summary>
        /// Combobox autocomplete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void invoices_deductiontaxrateComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComboBoxHelper.AutoCompleteOnKeyPress((ComboBox)sender, e);
        }

        #endregion


        #region tabInvoicesLines

        /// <summary>
        /// Get tab list DataSource
        /// </summary>
        /// <returns></returns>
        private object GetDataSourceList_tabInvoicesLines()
        {
            object ret = null;

            int invoices_id = -1;
            if (vInvoicesBindingSource.Current != null)
            {
                invoices_id = (((DataRowView)vInvoicesBindingSource.Current).Row).Field<int>("invoices_id");
            }

            if (invoices_id != -1)
            {
                //reload patientstreatments tab
                invoices invoice = _dentnedModel.Invoices.Find(invoices_id);
                ReloadPatientsTreatments(invoice.patients_id, true);

                //reset list total
                SetListTotal(invoice.invoices_date.Year);
            }
            else
                ReloadPatientsTreatments(null, true);

            IEnumerable<VInvoicesLines> vInvoicesLines =
            _dentnedModel.InvoicesLines.List(r => r.invoices_id == invoices_id).Select(
            r => new VInvoicesLines
            {
                invoiceslines_id = r.invoiceslines_id,
                code = r.invoiceslines_code,
                quantity = r.invoiceslines_quantity,
                taxrate = (double)r.invoiceslines_taxrate,
                unitprice = (double)r.invoiceslines_unitprice,
                description = ((r.invoiceslines_description).Length > MaxRowValueLength ? (r.invoiceslines_description).Substring(0, MaxRowValueLength) + "..." : (r.invoiceslines_description)),
                totalprice = (double)Math.Round((r.invoiceslines_quantity * r.invoiceslines_unitprice) + (r.invoiceslines_quantity * r.invoiceslines_unitprice) * (r.invoiceslines_taxrate / 100), 2)
            }).ToList();

            ret = DGDataTableUtils.ToDataTable<VInvoicesLines>(vInvoicesLines);

            return ret;
        }

        /// <summary>
        /// Tab Datagrid filter handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void advancedDataGridView_tabInvoicesLines_list_FilterStringChanged(object sender, EventArgs e)
        {
            vInvoicesLinesBindingSource.Filter = advancedDataGridView_tabInvoicesLines_list.FilterString;
        }

        /// <summary>
        /// Tab Datagrid sort handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void advancedDataGridView_tabInvoicesLines_list_SortStringChanged(object sender, EventArgs e)
        {
            vInvoicesLinesBindingSource.Sort = advancedDataGridView_tabInvoicesLines_list.SortString;
        }

        /// <summary>
        /// Load the tab DataSource
        /// </summary>
        /// <returns></returns>
        private object GetDataSourceEdit_tabInvoicesLines()
        {
            return DGUIGHFData.LoadEntityFromCurrentBindingSource<invoiceslines, DentneDModel>(_dentnedModel.InvoicesLines, vInvoicesLinesBindingSource, new string[] { "invoiceslines_id" });
        }

        /// <summary>
        /// Do actions after Save
        /// </summary>
        /// <param name="item"></param>
        private void AfterSaveAction_tabInvoicesLines(object item)
        {
            DGUIGHFData.SetBindingSourcePosition<invoiceslines, DentneDModel>(_dentnedModel.InvoicesLines, item, vInvoicesLinesBindingSource);
        }

        /// <summary>
        /// Add an item
        /// </summary>
        /// <param name="item"></param>
        private void Add_tabInvoicesLines(object item)
        {
            //unset lazy load for invoice tab, to reload total
            tabElement_tabInvoices.IsLazyLoaded = false;

            DGUIGHFData.Add<invoiceslines, DentneDModel>(_dentnedModel.InvoicesLines, item);
        }

        /// <summary>
        /// Update an item
        /// </summary>
        /// <param name="item"></param>
        private void Update_tabInvoicesLines(object item)
        {
            //unset lazy load for invoice tab, to reload total
            tabElement_tabInvoices.IsLazyLoaded = false;

            DGUIGHFData.Update<invoiceslines, DentneDModel>(_dentnedModel.InvoicesLines, item);
        }

        /// <summary>
        /// Remove an item
        /// </summary>
        /// <param name="item"></param>
        private void Remove_tabInvoicesLines(object item)
        {
            //unset lazy load for invoice tab, to reload total
            tabElement_tabInvoices.IsLazyLoaded = false;

            DGUIGHFData.Remove<invoiceslines, DentneDModel>(_dentnedModel.InvoicesLines, item);
        }

        /// <summary>
        /// New tab button handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_tabInvoicesLines_new_Click(object sender, EventArgs e)
        {
            if (vInvoicesBindingSource.Current != null)
            {
                if (AddClick(tabElement_tabInvoicesLines))
                {
                    int invoices_id = (((DataRowView)vInvoicesBindingSource.Current).Row).Field<int>("invoices_id");
                    invoices invoice = _dentnedModel.Invoices.Find(invoices_id);
                    ReloadPatientsTreatments(invoice.patients_id, false);

                    ((invoiceslines)invoiceslinesBindingSource.Current).invoices_id = invoices_id;
                    ((invoiceslines)invoiceslinesBindingSource.Current).invoiceslines_code = "";
                    ((invoiceslines)invoiceslinesBindingSource.Current).invoiceslines_description = "";
                    ((invoiceslines)invoiceslinesBindingSource.Current).invoiceslines_quantity = 1;
                    ((invoiceslines)invoiceslinesBindingSource.Current).invoiceslines_unitprice = 0;
                    if (_dentnedModel.Taxes.Any(r => r.taxes_isdefault))
                        ((invoiceslines)invoiceslinesBindingSource.Current).invoiceslines_taxrate = _dentnedModel.Taxes.FirstOrDefault(r => r.taxes_isdefault).taxes_rate;
                    ((invoiceslines)invoiceslinesBindingSource.Current).invoiceslines_istaxesdeductionsable = true;
                    invoiceslinesBindingSource.ResetBindings(true);
                }
            }
        }

        /// <summary>
        /// Edit tab button handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_tabInvoicesLines_edit_Click(object sender, EventArgs e)
        {
            if (vInvoicesBindingSource.Current != null)
            {
                if (UpdateClick(tabElement_tabInvoicesLines))
                {
                    ((invoiceslines)invoiceslinesBindingSource.Current).invoiceslines_istaxesdeductionsable = true;
                    invoiceslinesBindingSource.ResetBindings(true);

                    groupBox_tabInvoicesLines_filler.Enabled = false;
                    patientstreatments_idComboBox.Enabled = false;
                }
            }
        }

        /// <summary>
        /// Invoices prices changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox_tabInvoicesLines_filterPriceslists_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsBindingSourceLoading)
                return;

            ReloadTab(tabElement_tabInvoicesLines);
        }

        /// <summary>
        /// Reload patients treatments combobox
        /// </summary>
        /// <param name="patients_id"></param>
        /// <param name="loadall"></param>
        private void ReloadPatientsTreatments(Nullable<int> patients_id, bool loadall)
        {
            //get only treatments not yet invoiced
            List<patientstreatments> patientstreatmentsl = new List<patientstreatments>();
            if (patients_id != null)
            {
                if (!loadall)
                {
                    //do not load already inserted treatments
                    patientstreatmentsl = _dentnedModel.PatientsTreatments.List(r => r.patients_id == patients_id).ToList();
                    invoiceslines[] invoiceslinel = new invoiceslines[] { };
                    using (var context = (dentnedEntities)Activator.CreateInstance(_dentnedModel.ContextType, _dentnedModel.ContextParameters))
                    {
                        invoiceslinel = (from invoicesline in context.invoiceslines
                                         join invoice in context.invoices on invoicesline.invoices_id equals invoice.invoices_id
                                         select invoicesline).ToArray();
                    }
                    foreach (invoiceslines invoicesline in invoiceslinel)
                    {
                        patientstreatments patientstreatment = patientstreatmentsl.FirstOrDefault(r => r.patientstreatments_id == invoicesline.patientstreatments_id);
                        if (patientstreatment != null)
                            patientstreatmentsl.Remove(patientstreatment);
                    }
                }
                else
                {
                    patientstreatmentsl = _dentnedModel.PatientsTreatments.List(r => r.patients_id == patients_id).ToList();
                }
            }

            //local patients treatments
            IsBindingSourceLoading = true;
            patientstreatments_idComboBox.DataSource = patientstreatmentsl.Select(r => new { name = _dentnedModel.Treatments.Find(r.treatments_id).treatments_code + " [" + _dentnedModel.PatientsTreatments.GetTreatmentsToothsString(r) + "] " + r.patientstreatments_creationdate.ToShortDateString(), r.patientstreatments_id }).OrderBy(r => r.name).ToArray();
            patientstreatments_idComboBox.DisplayMember = "name";
            patientstreatments_idComboBox.ValueMember = "patientstreatments_id";
            IsBindingSourceLoading = false;
        }

        /// <summary>
        /// Tax rate changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void invoiceslines_taxrateComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsBindingSourceLoading)
                return;

            if (invoiceslines_taxrateComboBox.SelectedIndex != -1 && (tabElement_tabInvoicesLines.CurrentEditingMode == EditingMode.C || tabElement_tabInvoicesLines.CurrentEditingMode == EditingMode.U))
            {
                int taxes_id = -1;
                try
                {
                    taxes_id = Convert.ToInt32(invoiceslines_taxrateComboBox.SelectedValue);
                }
                catch { }
                if (taxes_id != -1)
                {
                    taxes taxes = _dentnedModel.Taxes.Find(taxes_id);
                    ((invoiceslines)invoiceslinesBindingSource.Current).invoiceslines_taxrate = taxes.taxes_rate;
                }
                invoiceslinesBindingSource.ResetBindings(true);
            }
        }

        /// <summary>
        /// Treatments changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treatments_idComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsBindingSourceLoading)
                return;

            if (treatments_idComboBox.SelectedIndex != -1 && (tabElement_tabInvoicesLines.CurrentEditingMode == EditingMode.C || tabElement_tabInvoicesLines.CurrentEditingMode == EditingMode.U))
            {
                int invoices_id = -1;
                if (vInvoicesBindingSource.Current != null)
                {
                    invoices_id = (((DataRowView)vInvoicesBindingSource.Current).Row).Field<int>("invoices_id");
                }
                if (invoices_id != -1)
                {
                    invoices invoice = _dentnedModel.Invoices.Find(invoices_id);
                    int patients_id = -1;

                    if (invoice.patients_id != null)
                        patients_id = (int)invoice.patients_id;

                    if (patients_id != -1)
                    {
                        treatments treatment = _dentnedModel.Treatments.Find(Convert.ToInt32(treatments_idComboBox.SelectedValue));
                        if (treatment != null)
                        {
                            string code = treatment.treatments_code;
                            string description = treatment.treatments_name;
                            decimal price = treatment.treatments_price;
                            decimal taxrate = (treatment.taxes_id != null ? _dentnedModel.Taxes.Find((int)treatment.taxes_id).taxes_rate : 0);
                            if (patients_id != -1)
                            {
                                patients patient = _dentnedModel.Patients.Find(patients_id);
                                if (patient != null)
                                {
                                    treatmentsprices treatmentsprice = _dentnedModel.TreatmentsPrices.FirstOrDefault(r => r.treatments_id == treatment.treatments_id && r.treatmentspriceslists_id == patient.treatmentspriceslists_id);
                                    if (treatmentsprice != null)
                                    {
                                        price = treatmentsprice.treatmentsprices_price;
                                    }
                                }
                            }
                            ((invoiceslines)invoiceslinesBindingSource.Current).patientstreatments_id = null;
                            ((invoiceslines)invoiceslinesBindingSource.Current).invoiceslines_code = code;
                            ((invoiceslines)invoiceslinesBindingSource.Current).invoiceslines_description = description;
                            ((invoiceslines)invoiceslinesBindingSource.Current).invoiceslines_quantity = 1;
                            ((invoiceslines)invoiceslinesBindingSource.Current).invoiceslines_unitprice = price;
                            ((invoiceslines)invoiceslinesBindingSource.Current).invoiceslines_taxrate = taxrate;
                        }
                    }
                }
                invoiceslinesBindingSource.ResetBindings(true);
            }
        }

        /// <summary>
        /// Computed lines changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void computedlines_idComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsBindingSourceLoading)
                return;

            if (computedlines_idComboBox.SelectedIndex != -1 && (tabElement_tabInvoicesLines.CurrentEditingMode == EditingMode.C || tabElement_tabInvoicesLines.CurrentEditingMode == EditingMode.U))
            {
                int invoices_id = -1;
                if (vInvoicesBindingSource.Current != null)
                {
                    invoices_id = (((DataRowView)vInvoicesBindingSource.Current).Row).Field<int>("invoices_id");
                }
                if (invoices_id != -1)
                {
                    invoices estimate = _dentnedModel.Invoices.Find(invoices_id);
                    int patients_id = -1;

                    if (estimate.patients_id != null)
                        patients_id = (int)estimate.patients_id;

                    if (patients_id != -1)
                    {
                        computedlines computedline = _dentnedModel.ComputedLines.Find(Convert.ToInt32(computedlines_idComboBox.SelectedValue));
                        if (computedline != null)
                        {
                            decimal totallines = _dentnedModel.InvoicesLines.List(r => r.invoices_id == invoices_id).Sum(r => r.invoiceslines_quantity * r.invoiceslines_unitprice);
                            string code = computedline.computedlines_code;
                            string description = computedline.computedlines_name;
                            decimal price = totallines * (computedline.computedlines_rate / 100);
                            decimal taxrate = (computedline.taxes_id != null ? _dentnedModel.Taxes.Find((int)computedline.taxes_id).taxes_rate : 0);
                            ((invoiceslines)invoiceslinesBindingSource.Current).patientstreatments_id = null;
                            ((invoiceslines)invoiceslinesBindingSource.Current).invoiceslines_code = code;
                            ((invoiceslines)invoiceslinesBindingSource.Current).invoiceslines_description = description;
                            ((invoiceslines)invoiceslinesBindingSource.Current).invoiceslines_quantity = 1;
                            ((invoiceslines)invoiceslinesBindingSource.Current).invoiceslines_unitprice = price;
                            ((invoiceslines)invoiceslinesBindingSource.Current).invoiceslines_taxrate = taxrate;
                        }
                    }
                }
                invoiceslinesBindingSource.ResetBindings(true);
            }
        }

        /// <summary>
        /// Patient treatments changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void patientstreatments_idComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsBindingSourceLoading)
                return;

            if (patientstreatments_idComboBox.SelectedIndex != -1 && (tabElement_tabInvoicesLines.CurrentEditingMode == EditingMode.C || tabElement_tabInvoicesLines.CurrentEditingMode == EditingMode.U))
            {
                int invoices_id = -1;
                if (vInvoicesBindingSource.Current != null)
                {
                    invoices_id = (((DataRowView)vInvoicesBindingSource.Current).Row).Field<int>("invoices_id");
                }
                if (invoices_id != -1)
                {
                    invoices invoice = _dentnedModel.Invoices.Find(invoices_id);
                    int patients_id = -1;

                    if (invoice.patients_id != null)
                        patients_id = (int)invoice.patients_id;

                    if (patients_id != -1)
                    {
                        patientstreatments patientstreatment = null;
                        try
                        {
                            patientstreatment = _dentnedModel.PatientsTreatments.Find((int)patientstreatments_idComboBox.SelectedValue);
                        }
                        catch { }
                        if (patientstreatment != null)
                        {
                            treatments treatments = _dentnedModel.Treatments.Find(patientstreatment.treatments_id);
                            if (treatments != null)
                            {
                                int quantity = 1;
                                if (patientstreatment.patientstreatments_isunitprice)
                                {
                                    quantity = _dentnedModel.PatientsTreatments.GetNumberOfTooths(patientstreatment);
                                    if (quantity == 0)
                                        quantity = 1;
                                }
                                string code = treatments.treatments_code;
                                string description = treatments.treatments_name + (_addToothsToDocumentDescription ? " [" + _dentnedModel.PatientsTreatments.GetTreatmentsToothsString(patientstreatment) + "]" : "");
                                decimal price = patientstreatment.patientstreatments_price;
                                decimal taxrate = patientstreatment.patientstreatments_taxrate;
                                ((invoiceslines)invoiceslinesBindingSource.Current).patientstreatments_id = patientstreatment.patientstreatments_id;
                                ((invoiceslines)invoiceslinesBindingSource.Current).invoiceslines_code = code;
                                ((invoiceslines)invoiceslinesBindingSource.Current).invoiceslines_description = description;
                                ((invoiceslines)invoiceslinesBindingSource.Current).invoiceslines_quantity = quantity;
                                ((invoiceslines)invoiceslinesBindingSource.Current).invoiceslines_unitprice = price;
                                ((invoiceslines)invoiceslinesBindingSource.Current).invoiceslines_taxrate = taxrate;
                            }
                        }
                    }
                }
                invoiceslinesBindingSource.ResetBindings(true);
            }
        }

        /// <summary>
        /// Tax rate leaved
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void invoiceslines_taxrateComboBox_Leave(object sender, EventArgs e)
        {
            IsBindingSourceLoading = true;
            invoiceslines_taxrateComboBox.SelectedIndex = -1;
            IsBindingSourceLoading = false;
        }

        /// <summary>
        /// Treatments leaved
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treatments_idComboBox_Leave(object sender, EventArgs e)
        {

            IsBindingSourceLoading = true;
            treatments_idComboBox.SelectedIndex = -1;
            IsBindingSourceLoading = false;
        }

        /// <summary>
        /// Computed lines leaved
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void computedlines_idComboBox_Leave(object sender, EventArgs e)
        {
            IsBindingSourceLoading = true;
            computedlines_idComboBox.SelectedIndex = -1;
            IsBindingSourceLoading = false;
        }

        /// <summary>
        /// Combobox autocomplete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treatments_idComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComboBoxHelper.AutoCompleteOnKeyPress((ComboBox)sender, e);
        }

        /// <summary>
        /// Combobox autocomplete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void computedlines_idComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComboBoxHelper.AutoCompleteOnKeyPress((ComboBox)sender, e);
        }

        /// <summary>
        /// Combobox autocomplete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void patientstreatments_idComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComboBoxHelper.AutoCompleteOnKeyPress((ComboBox)sender, e);
        }

        /// <summary>
        /// Combobox autocomplete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void invoiceslines_taxrateComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComboBoxHelper.AutoCompleteOnKeyPress((ComboBox)sender, e);
        }

        #endregion
    }
}
