#region License
// Copyright (c) 2015 Davide Gironi
//
// Please refer to LICENSE file for licensing information.
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DG.Data.Model.Helpers;
using DG.UI.GHF;
using DG.DentneD.Model;
using DG.DentneD.Model.Entity;
using DG.DentneD.Forms.Objects;
using Zuby.ADGV;
using System.Data;
using System.Configuration;
using DG.DentneD.Helpers;
using System.Diagnostics;
using System.IO;
using SMcMaster;
using DG.DentneD.Model.Repositories;

namespace DG.DentneD.Forms
{
    public partial class FormInvoices : DGUIGHFForm
    {
        private DentneDModel _dentnedModel = null;

        private TabElement tabElement_tabInvoices = new TabElement();
        private TabElement tabElement_tabInvoicesLines = new TabElement();

        private const int MaxRowValueLength = 60;

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

                    BindingSourceList = vInvoicesBindingSource,
                    GetDataSourceList = GetDataSource_main,

                    BindingSourceEdit = invoicesBindingSource,
                    GetDataSourceEdit = GetDataSourceEdit_tabInvoices,
                    AfterSaveAction = AfterSaveAction_tabInvoices,

                    AddButton = button_tabInvoices_new,
                    IsAddButtonDefaultClickEventAttached = false,
                    UpdateButton = button_tabInvoices_edit,
                    IsUpdateButtonDefaultClickEventAttached = false,
                    RemoveButton = button_tabInvoices_delete,
                    SaveButton = button_tabInvoices_save,
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
                            DGUIGHFUtilsUI.DGComboBoxItem.SelectItemById(comboBox_filterDoctors, invoice.doctors_id);
                        else
                            comboBox_filterDoctors.SelectedIndex = -1;
                    }
                    DGUIGHFUtilsUI.DGComboBoxItem.SelectItemById(comboBox_filterYears, invoice.invoices_date.Year);
                    IsBindingSourceLoading = false;
                    break;
                }
            }

            ReloadView();

            ResetTabsDataGrid();

            //select an invoice on load invoice
            if (invoice != null)
            {
                DGUIGHFData.SetBindingSourcePosition<invoices, DentneDModel>(_dentnedModel.Invoices, invoice, vInvoicesBindingSource);
            }
        }

        /// <summary>
        /// Preload View
        /// </summary>
        private void PreloadView()
        {
            IsBindingSourceLoading = true;

            //load doctors
            doctors_idComboBox.DataSource = _dentnedModel.Doctors.List().Select(r => new { name = r.doctors_surname + " " + r.doctors_name, r.doctors_id }).OrderBy(r => r.name).ToList();
            doctors_idComboBox.DisplayMember = "name";
            doctors_idComboBox.ValueMember = "doctors_id";

            //load patients
            patients_idComboBox.DataSource = _dentnedModel.Patients.List().Select(r => new { name = r.patients_surname + " " + r.patients_name, r.patients_id }).OrderBy(r => r.name).ToList();
            patients_idComboBox.DisplayMember = "name";
            patients_idComboBox.ValueMember = "patients_id";

            //load payments
            invoices_paymentComboBox.Items.Clear();
            foreach (paymentstypes a in _dentnedModel.PaymentsTypes.List().OrderBy(r => r.paymentstypes_name))
            {
                invoices_paymentComboBox.Items.Add(new DGUIGHFUtilsUI.DGComboBoxItem(a.paymentstypes_id.ToString(), a.paymentstypes_name));
            }
            invoices_paymentComboBox.SelectedIndex = -1;

            //load footers
            invoices_footerComboBox.Items.Clear();
            foreach (invoicesfooters a in _dentnedModel.InvoicesFooters.List().OrderBy(r => r.invoicesfooters_name))
            {
                invoices_footerComboBox.Items.Add(new DGUIGHFUtilsUI.DGComboBoxItem(a.invoicesfooters_id.ToString(), a.invoicesfooters_name));
            }
            invoices_footerComboBox.SelectedIndex = -1;

            //load deduction taxes
            invoices_deductiontaxrateComboBox.Items.Clear();
            foreach (taxesdeductions a in _dentnedModel.TaxesDeductions.List().OrderBy(r => r.taxesdeductions_name))
            {
                invoices_deductiontaxrateComboBox.Items.Add(new DGUIGHFUtilsUI.DGComboBoxItem(a.taxesdeductions_id.ToString(), a.taxesdeductions_name));
            }
            invoices_deductiontaxrateComboBox.SelectedIndex = -1;

            //load tax rates
            invoiceslines_taxrateComboBox.Items.Clear();
            foreach (taxes a in _dentnedModel.Taxes.List().OrderBy(r => r.taxes_name))
            {
                invoiceslines_taxrateComboBox.Items.Add(new DGUIGHFUtilsUI.DGComboBoxItem(a.taxes_id.ToString(), a.taxes_name));
            }
            invoiceslines_taxrateComboBox.SelectedIndex = -1;
            
            //load treatments
            treatments_idComboBox.Items.Clear();
            foreach (treatments a in _dentnedModel.Treatments.List())
            {
                treatments_idComboBox.Items.Add(new DGUIGHFUtilsUI.DGComboBoxItem(a.treatments_id.ToString(), a.treatments_code + " - " + a.treatments_name));
            }
            treatments_idComboBox.SelectedIndex = -1;

            //load computed lines
            computedlines_idComboBox.Items.Clear();
            foreach (computedlines a in _dentnedModel.ComputedLines.List())
            {
                computedlines_idComboBox.Items.Add(new DGUIGHFUtilsUI.DGComboBoxItem(a.computedlines_id.ToString(), a.computedlines_name));
            }
            computedlines_idComboBox.SelectedIndex = -1;

            //load filter doctors
            comboBox_filterDoctors.Items.Clear();
            comboBox_filterDoctors.Items.Add(new DGUIGHFUtilsUI.DGComboBoxItem("-1", ""));
            foreach (doctors a in _dentnedModel.Doctors.List().OrderBy(r => r.doctors_surname))
            {
                comboBox_filterDoctors.Items.Add(new DGUIGHFUtilsUI.DGComboBoxItem(a.doctors_id.ToString(), a.doctors_surname + " " + a.doctors_name));
            }
            if (comboBox_filterDoctors.Items.Count == 2)
                comboBox_filterDoctors.SelectedIndex = 1;
            else
                comboBox_filterDoctors.SelectedIndex = -1;
            
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
            comboBox_filterYears.Items.Clear();
            foreach (invoices a in _dentnedModel.Invoices.List().OrderBy(r => r.invoices_date))
            {
                if(!years.Contains(a.invoices_date.Year))
                {
                    comboBox_filterYears.Items.Add(new DGUIGHFUtilsUI.DGComboBoxItem(a.invoices_date.Year.ToString(), a.invoices_date.Year.ToString()));
                    years.Add(a.invoices_date.Year);
                }                    
            }
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
                doctors_id = Convert.ToInt32(((DGUIGHFUtilsUI.DGComboBoxItem)comboBox_filterDoctors.SelectedItem).Id);
            }
            int year = -1;
            if (comboBox_filterYears.SelectedIndex != -1)
            {
                year = Convert.ToInt32(((DGUIGHFUtilsUI.DGComboBoxItem)comboBox_filterYears.SelectedItem).Id);
            }

            totalnetTextBox.Text = "0";
            totalgrossTextBox.Text = "0";
            totaldueTextBox.Text = "0";
            totalduepaidTextBox.Text = "0";

            //reset list total
            SetListTotal();

            IEnumerable<VInvoices> vInvoices = _dentnedModel.Invoices.List(r => r.invoices_date.Year == year && r.doctors_id == (doctors_id == -1 ? null : (Nullable<int>)doctors_id)).Select(
                r => new VInvoices
                {
                    invoices_id = r.invoices_id,
                    date = r.invoices_date,
                    ispaid = r.invoices_ispaid,
                    number = r.invoices_number,
                    patient = (_dentnedModel.Patients.Find(r.patients_id) != null ? _dentnedModel.Patients.Find(r.patients_id).patients_surname + " " + _dentnedModel.Patients.Find(r.patients_id).patients_name : "")
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
        private void SetListTotal()
        {
            int doctors_id = -1;
            if (comboBox_filterDoctors.SelectedIndex != -1)
            {
                doctors_id = Convert.ToInt32(((DGUIGHFUtilsUI.DGComboBoxItem)comboBox_filterDoctors.SelectedItem).Id);
            }

            totalnetTextBox.Text = Math.Round(_dentnedModel.Invoices.List(r => r.doctors_id == doctors_id).Sum(r => r.invoices_totalnet), 2).ToString();
            totalgrossTextBox.Text = Math.Round(_dentnedModel.Invoices.List(r => r.doctors_id == doctors_id).Sum(r => r.invoices_totalgross), 2).ToString();
            totaldueTextBox.Text = Math.Round(_dentnedModel.Invoices.List(r => r.doctors_id == doctors_id).Sum(r => r.invoices_totaldue), 2).ToString();
            totalduepaidTextBox.Text = Math.Round(_dentnedModel.Invoices.List(r => r.doctors_id == doctors_id && r.invoices_ispaid).Sum(r => r.invoices_totaldue), 2).ToString();
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
        }

        /// <summary>
        /// Remove an item
        /// </summary>
        /// <param name="item"></param>
        private void Remove_tabInvoices(object item)
        {
            DGUIGHFData.Remove<invoices, DentneDModel>(false, _dentnedModel.Invoices, item);

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
                int doctors_id = Convert.ToInt32(((DGUIGHFUtilsUI.DGComboBoxItem)comboBox_filterDoctors.SelectedItem).Id);
                int maxnumber = 1;
                int year = DateTime.Now.Year;
                if (comboBox_filterYears.SelectedIndex != -1)
                {
                    year = Convert.ToInt32(((DGUIGHFUtilsUI.DGComboBoxItem)comboBox_filterYears.SelectedItem).Id);
                }
                string[] numbers = _dentnedModel.Invoices.List(r => r.doctors_id == doctors_id && r.invoices_date.Year == year).Select(r => r.invoices_number).ToArray();
                try
                {
                    foreach(string number in numbers)
                    {
                        int n = Convert.ToInt32(number);
                        if(n > maxnumber)
                            maxnumber = n;
                    }
                    if (maxnumber != 1)
                        maxnumber++;
                }
                catch { }
                ((invoices)invoicesBindingSource.Current).doctors_id = doctors_id;
                ((invoices)invoicesBindingSource.Current).patients_id = null;
                if (_dentnedModel.PaymentsTypes.List(r => r.paymentstypes_isdefault).Count > 0)
                    ((invoices)invoicesBindingSource.Current).invoices_payment = _dentnedModel.PaymentsTypes.List(r => r.paymentstypes_isdefault).FirstOrDefault().paymentstypes_doctext;
                if (_dentnedModel.InvoicesFooters.List(r => r.invoicesfooters_isdefault).Count > 0)
                    ((invoices)invoicesBindingSource.Current).invoices_footer = _dentnedModel.InvoicesFooters.List(r => r.invoicesfooters_isdefault).FirstOrDefault().invoicesfooters_doctext;
                if (_dentnedModel.TaxesDeductions.List(r => r.taxesdeductions_isdefault).Count > 0)
                    ((invoices)invoicesBindingSource.Current).invoices_deductiontaxrate = _dentnedModel.TaxesDeductions.List(r => r.taxesdeductions_isdefault).FirstOrDefault().taxesdeductions_rate;
                ((invoices)invoicesBindingSource.Current).invoices_date = DateTime.Now;
                ((invoices)invoicesBindingSource.Current).invoices_number = maxnumber.ToString();
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
            if(vInvoicesBindingSource.Current != null)
            {
                int invoices_id = -1;
                if (vInvoicesBindingSource.Current != null)
                {
                    invoices_id = (((DataRowView)vInvoicesBindingSource.Current).Row).Field<int>("invoices_id");
                }

                if(invoices_id != -1)
                {
                    invoices invoice = _dentnedModel.Invoices.Find(invoices_id);

                    if(!invoice.invoices_ispaid)
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
        /// Print an invoice
        /// </summary>
        /// <param name="invoices_id"></param>
        private void PrintInvoices(int invoices_id)
        {
            invoices invoice = _dentnedModel.Invoices.Find(invoices_id);
            if (invoice == null)
                return;

            //instantiate the printmodel
            string assemblyPath = ConfigurationManager.AppSettings["printModel"];
            IDentneDPrintModel printModel = DentneDPrintModelHelper.DentneDPrintModelInstance(assemblyPath);
            if (printModel == null)
            {
                MessageBox.Show(language.printmodelerrorMessage, language.printmodelerrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            //prepare folders
            string destfolder = ConfigurationManager.AppSettings["tmpdir"];
            if(invoice.doctors_id != null)
                destfolder = ConfigurationManager.AppSettings["invoicesdir"] + "\\" + invoice.invoices_date.Year.ToString() + "\\" + ((int)invoice.doctors_id).ToString();
            if (!FileHelper.CreateFolder(destfolder))
            {
                MessageBox.Show(String.Format(language.printcreatefoldererrorMessage, destfolder), language.printcreatefoldererrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //make new filename
            bool buildpdf = true;
            string filename = FileHelper.FindRandomFileName(destfolder, "E", "pdf");
            if(invoice.doctors_id != null)
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
                    paymentstypes_id = Convert.ToInt32(((DGUIGHFUtilsUI.DGComboBoxItem)invoices_paymentComboBox.SelectedItem).Id);
                }
                catch { }
                if (paymentstypes_id != -1)
                {
                    paymentstypes paymentstype = _dentnedModel.PaymentsTypes.Find(paymentstypes_id);
                    ((invoices)invoicesBindingSource.Current).invoices_payment = paymentstype.paymentstypes_doctext;
                }
                invoicesBindingSource.ResetBindings(true);
            }
            IsBindingSourceLoading = true;
            invoices_paymentComboBox.SelectedIndex = -1;
            IsBindingSourceLoading = false;
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
                    invoicesfooters_id = Convert.ToInt32(((DGUIGHFUtilsUI.DGComboBoxItem)invoices_footerComboBox.SelectedItem).Id);
                }
                catch { }
                if (invoicesfooters_id != -1)
                {
                    invoicesfooters invoicesfooter = _dentnedModel.InvoicesFooters.Find(invoicesfooters_id);
                    ((invoices)invoicesBindingSource.Current).invoices_footer = invoicesfooter.invoicesfooters_doctext;
                }
                invoicesBindingSource.ResetBindings(true);
            }
            IsBindingSourceLoading = true;
            invoices_footerComboBox.SelectedIndex = -1;
            IsBindingSourceLoading = false;
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
                    taxesdeductions_id = Convert.ToInt32(((DGUIGHFUtilsUI.DGComboBoxItem)invoices_deductiontaxrateComboBox.SelectedItem).Id);
                }
                catch { }
                if (taxesdeductions_id != -1)
                {
                    taxesdeductions taxesdeduction = _dentnedModel.TaxesDeductions.Find(taxesdeductions_id);
                    ((invoices)invoicesBindingSource.Current).invoices_deductiontaxrate = taxesdeduction.taxesdeductions_rate;
                }
                invoicesBindingSource.ResetBindings(true);
            }
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
            DGUIGHFUtilsUI.DGComboBoxAutoComplete.OnKeyPress((ComboBox)sender, e);
        }

        /// <summary>
        /// Combobox autocomplete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void patients_idComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            DGUIGHFUtilsUI.DGComboBoxAutoComplete.OnKeyPress((ComboBox)sender, e);
        }

        /// <summary>
        /// Combobox autocomplete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void invoices_paymentComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            DGUIGHFUtilsUI.DGComboBoxAutoComplete.OnKeyPress((ComboBox)sender, e);
        }

        /// <summary>
        /// Combobox autocomplete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void invoices_footerComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            DGUIGHFUtilsUI.DGComboBoxAutoComplete.OnKeyPress((ComboBox)sender, e);
        }

        /// <summary>
        /// Combobox autocomplete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void invoices_deductiontaxrateComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            DGUIGHFUtilsUI.DGComboBoxAutoComplete.OnKeyPress((ComboBox)sender, e);
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
            }
            else
                ReloadPatientsTreatments(null, true);

            //reset list total
            SetListTotal();

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
                    ((invoiceslines)invoiceslinesBindingSource.Current).invoiceslines_quantity = 0;
                    ((invoiceslines)invoiceslinesBindingSource.Current).invoiceslines_unitprice = 0;
                    if (_dentnedModel.Taxes.List(r => r.taxes_isdefault).Count > 0)
                        ((invoiceslines)invoiceslinesBindingSource.Current).invoiceslines_taxrate = _dentnedModel.Taxes.List(r => r.taxes_isdefault).FirstOrDefault().taxes_rate;
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
            if (patients_id != null && !loadall)
            {
                if (!loadall)
                {
                    //do not load already inserted treatments
                    patientstreatmentsl = _dentnedModel.PatientsTreatments.List(r => r.patients_id == patients_id).ToList();
                    foreach (invoiceslines invoicesline in _dentnedModel.InvoicesLines.List().Join(
                            _dentnedModel.Invoices.List(), a => a.invoices_id, b => b.invoices_id, (a, b) => a).ToList())
                    {
                        patientstreatments patientstreatment = patientstreatmentsl.Where(r => r.patientstreatments_id == invoicesline.patientstreatments_id).FirstOrDefault();
                        if (patientstreatment != null)
                            patientstreatmentsl.Remove(patientstreatment);
                    }
                }
                else
                {
                    patientstreatmentsl = _dentnedModel.PatientsTreatments.List(r => r.patients_id == patients_id).ToList();
                }
            }
            else
            {
                patientstreatmentsl = _dentnedModel.PatientsTreatments.List().ToList();
            }
            //local patients treatments
            IsBindingSourceLoading = true;
            patientstreatments_idComboBox.DataSource = patientstreatmentsl.Select(r => new { name = _dentnedModel.Treatments.Find(r.treatments_id).treatments_code + (tabElement_tabInvoicesLines.CurrentEditingMode == EditingMode.C || tabElement_tabInvoicesLines.CurrentEditingMode == EditingMode.U ? " [" + _dentnedModel.PatientsTreatments.GetTreatmentsToothsString(r) + "] " : " " ) + r.patientstreatments_creationdate.ToShortDateString(), r.patientstreatments_id }).OrderBy(r => r.name).ToList();
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
                    taxes_id = Convert.ToInt32(((DGUIGHFUtilsUI.DGComboBoxItem)invoiceslines_taxrateComboBox.SelectedItem).Id);
                }
                catch { }
                if (taxes_id != -1)
                {
                    taxes taxes = _dentnedModel.Taxes.Find(taxes_id);
                    ((invoiceslines)invoiceslinesBindingSource.Current).invoiceslines_taxrate = taxes.taxes_rate;
                }
                invoiceslinesBindingSource.ResetBindings(true);
            }
            IsBindingSourceLoading = true;
            invoiceslines_taxrateComboBox.SelectedIndex = -1;
            IsBindingSourceLoading = false;
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
                        treatments treatment = _dentnedModel.Treatments.Find(Convert.ToInt32(((DGUIGHFUtilsUI.DGComboBoxItem)treatments_idComboBox.SelectedItem).Id));
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
                                    treatmentsprices treatmentsprice = _dentnedModel.TreatmentsPrices.List(r => r.treatments_id == treatment.treatments_id && r.treatmentspriceslists_id == patient.treatmentspriceslists_id).FirstOrDefault();
                                    if (treatmentsprice != null)
                                    {
                                        price = treatmentsprice.treatmentsprices_price;
                                    }
                                }
                            }
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
            IsBindingSourceLoading = true;
            treatments_idComboBox.SelectedIndex = -1;
            IsBindingSourceLoading = false;
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
                        computedlines computedline = _dentnedModel.ComputedLines.Find(Convert.ToInt32(((DGUIGHFUtilsUI.DGComboBoxItem)computedlines_idComboBox.SelectedItem).Id));
                        if (computedline != null)
                        {
                            decimal totallines = _dentnedModel.InvoicesLines.List(r => r.invoices_id == invoices_id).Sum(r => r.invoiceslines_quantity * r.invoiceslines_unitprice);
                            string code = computedline.computedlines_code;
                            string description = computedline.computedlines_name;
                            decimal price = totallines * (computedline.computedlines_rate / 100);
                            decimal taxrate = (computedline.taxes_id != null ? _dentnedModel.Taxes.Find((int)computedline.taxes_id).taxes_rate : 0);
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
            IsBindingSourceLoading = true;
            computedlines_idComboBox.SelectedIndex = -1;
            IsBindingSourceLoading = false;
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
                        patientstreatments patientstreatments = null;
                        try
                        {
                            patientstreatments = _dentnedModel.PatientsTreatments.Find((int)patientstreatments_idComboBox.SelectedValue);
                        }
                        catch { }
                        if (patientstreatments != null)
                        {
                            treatments treatments = _dentnedModel.Treatments.Find(patientstreatments.treatments_id);
                            if (treatments != null)
                            {
                                string code = treatments.treatments_code;
                                string description = treatments.treatments_name;
                                decimal price = patientstreatments.patientstreatments_price;
                                decimal taxrate = patientstreatments.patientstreatments_taxrate;
                                ((invoiceslines)invoiceslinesBindingSource.Current).patientstreatments_id = patientstreatments.patientstreatments_id;
                                ((invoiceslines)invoiceslinesBindingSource.Current).invoiceslines_code = code;
                                ((invoiceslines)invoiceslinesBindingSource.Current).invoiceslines_description = description;
                                ((invoiceslines)invoiceslinesBindingSource.Current).invoiceslines_quantity = 1;
                                ((invoiceslines)invoiceslinesBindingSource.Current).invoiceslines_unitprice = price;
                                ((invoiceslines)invoiceslinesBindingSource.Current).invoiceslines_taxrate = taxrate;
                            }
                        }
                    }
                }
                invoiceslinesBindingSource.ResetBindings(true);
            }
            IsBindingSourceLoading = true;
            treatments_idComboBox.SelectedIndex = -1;
            IsBindingSourceLoading = false;
        }
        
        /// <summary>
        /// Combobox autocomplete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treatments_idComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            DGUIGHFUtilsUI.DGComboBoxAutoComplete.OnKeyPress((ComboBox)sender, e);
        }
        
        /// <summary>
        /// Combobox autocomplete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void computedlines_idComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            DGUIGHFUtilsUI.DGComboBoxAutoComplete.OnKeyPress((ComboBox)sender, e);
        }

        /// <summary>
        /// Combobox autocomplete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void patientstreatments_idComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            DGUIGHFUtilsUI.DGComboBoxAutoComplete.OnKeyPress((ComboBox)sender, e);
        }

        /// <summary>
        /// Combobox autocomplete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void invoiceslines_taxrateComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            DGUIGHFUtilsUI.DGComboBoxAutoComplete.OnKeyPress((ComboBox)sender, e);
        }

        #endregion
                               
    }
}
