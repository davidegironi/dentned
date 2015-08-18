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

namespace DG.DentneD.Forms
{
    public partial class FormEstimates : DGUIGHFForm
    {
        private DentneDModel _dentnedModel = null;

        private TabElement tabElement_tabEstimates = new TabElement();
        private TabElement tabElement_tabEstimatesLines = new TabElement();

        private const int MaxRowValueLength = 60;

        /// <summary>
        /// Constructor
        /// </summary>
        public FormEstimates()
        {
            InitializeComponent();

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
            LanguageHelper.AddComponent(label_filterDoctors);
            LanguageHelper.AddComponent(label_filterYears);
            LanguageHelper.AddComponent(totalLabel);
            LanguageHelper.AddComponent(totalinvoicedLabel);
            LanguageHelper.AddComponent(estimatesidDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(numberDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(dateDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(patientDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(isinvoicedDataGridViewCheckBoxColumn, this.GetType().Name, "HeaderText");
            //tabEstimates
            LanguageHelper.AddComponent(tabPage_tabEstimates);
            LanguageHelper.AddComponent(button_tabEstimates_new);
            LanguageHelper.AddComponent(button_tabEstimates_edit);
            LanguageHelper.AddComponent(button_tabEstimates_delete);
            LanguageHelper.AddComponent(button_tabEstimates_save);
            LanguageHelper.AddComponent(button_tabEstimates_cancel);
            LanguageHelper.AddComponent(button_tabEstimates_print);
            LanguageHelper.AddComponent(button_tabEstimates_invoice);
            LanguageHelper.AddComponent(estimates_idLabel);
            LanguageHelper.AddComponent(estimates_numberLabel);
            LanguageHelper.AddComponent(estimates_invoiceLabel);
            LanguageHelper.AddComponent(estimates_totalLabel);
            LanguageHelper.AddComponent(estimates_dateLabel);
            LanguageHelper.AddComponent(estimates_doctorLabel);
            LanguageHelper.AddComponent(estimates_patientLabel);
            LanguageHelper.AddComponent(estimates_paymentLabel);
            LanguageHelper.AddComponent(estimates_footerLabel);
            LanguageHelper.AddComponent(estimates_deductiontaxrateLabel);
            //tabEstimatesLines
            LanguageHelper.AddComponent(tabPage_tabEstimatesLines);
            LanguageHelper.AddComponent(estimateslinesidDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(codeDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(descriptionDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(quantityDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(unitpriceDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(taxrateDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(totalpriceDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(button_tabEstimatesLines_new);
            LanguageHelper.AddComponent(button_tabEstimatesLines_edit);
            LanguageHelper.AddComponent(button_tabEstimatesLines_delete);
            LanguageHelper.AddComponent(button_tabEstimatesLines_save);
            LanguageHelper.AddComponent(button_tabEstimatesLines_cancel);
            LanguageHelper.AddComponent(estimateslines_idLabel);
            LanguageHelper.AddComponent(patientstreatments_idLabel);
            LanguageHelper.AddComponent(estimateslines_codeLabel);
            LanguageHelper.AddComponent(estimateslines_quantityLabel);
            LanguageHelper.AddComponent(estimateslines_unitpriceLabel);
            LanguageHelper.AddComponent(estimateslines_taxrateLabel);
            LanguageHelper.AddComponent(estimateslines_descriptionLabel);
            LanguageHelper.AddComponent(treatments_idLabel);
            LanguageHelper.AddComponent(groupBox_tabEstimatesLines_filler);
        }

        /// <summary>
        /// Initialize TabElements
        /// </summary>
        protected override void InitializeTabElements()
        {
            //set Readonly OnSetEditingMode for Controls
            DisableReadonlyCheckOnSetEditingModeControlCollection.Add(typeof(DataGridView));
            DisableReadonlyCheckOnSetEditingModeControlCollection.Add(typeof(AdvancedDataGridView));

            //set Main BindingSource
            BindingSourceMain = vEstimatesBindingSource;
            GetDataSourceMain = GetDataSource_main;

            //set Main TabControl
            TabControlMain = tabControl_main;

            //set Main Panels
            PanelFiltersMain = null;
            PanelListMain = panel_list;
            PanelsExtraMain = null;

            //set tabEstimates
            tabElement_tabEstimates = new TabElement()
            {
                TabPageElement = tabPage_tabEstimates,
                ElementItem = new TabElement.TabElementItem()
                {
                    PanelData = panel_tabEstimates_data,
                    PanelActions = panel_tabEstimates_actions,
                    PanelUpdates = panel_tabEstimates_updates,

                    BindingSourceList = vEstimatesBindingSource,
                    GetDataSourceList = GetDataSource_main,

                    BindingSourceEdit = estimatesBindingSource,
                    GetDataSourceEdit = GetDataSourceEdit_tabEstimates,
                    AfterSaveAction = AfterSaveAction_tabEstimates,

                    AddButton = button_tabEstimates_new,
                    IsAddButtonDefaultClickEventAttached = false,
                    UpdateButton = button_tabEstimates_edit,
                    IsUpdateButtonDefaultClickEventAttached = false,
                    RemoveButton = button_tabEstimates_delete,
                    SaveButton = button_tabEstimates_save,
                    CancelButton = button_tabEstimates_cancel,

                    Add = Add_tabEstimates,
                    Update = Update_tabEstimates,
                    Remove = Remove_tabEstimates
                }
            };

            //set tabEstimatesLines
            tabElement_tabEstimatesLines = new TabElement()
            {
                TabPageElement = tabPage_tabEstimatesLines,
                ElementListItem = new TabElement.TabElementListItem()
                {
                    PanelFilters = null,
                    PanelList = panel_tabEstimatesLines_list,

                    PanelData = panel_tabEstimatesLines_data,
                    PanelActions = panel_tabEstimatesLines_actions,
                    PanelUpdates = panel_tabEstimatesLines_updates,

                    BindingSourceList = vEstimatesLinesBindingSource,
                    GetDataSourceList = GetDataSourceList_tabEstimatesLines,

                    BindingSourceEdit = estimateslinesBindingSource,
                    GetDataSourceEdit = GetDataSourceEdit_tabEstimatesLines,
                    AfterSaveAction = AfterSaveAction_tabEstimatesLines,

                    AddButton = button_tabEstimatesLines_new,
                    IsAddButtonDefaultClickEventAttached = false,
                    UpdateButton = button_tabEstimatesLines_edit,
                    IsUpdateButtonDefaultClickEventAttached = false,
                    RemoveButton = button_tabEstimatesLines_delete,
                    SaveButton = button_tabEstimatesLines_save,
                    CancelButton = button_tabEstimatesLines_cancel,

                    Add = Add_tabEstimatesLines,
                    Update = Update_tabEstimatesLines,
                    Remove = Remove_tabEstimatesLines
                }
            };

            //set Elements
            TabElements.Add(tabElement_tabEstimates);
            TabElements.Add(tabElement_tabEstimatesLines);
        }

        /// <summary>
        /// Loader
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormEstimates_Load(object sender, EventArgs e)
        {
            PreloadView();

            //select an estimate on load estimate
            int estimates_id = -1;
            estimates estimate = null;
            foreach (Form form in this.MdiParent.MdiChildren)
            {
                if (form.GetType() == typeof(FormPatients))
                {
                    estimates_id = ((FormPatients)form).estimates_id_toload;
                    ((FormPatients)form).estimates_id_toload = -1;
                }

                if (estimates_id != -1)
                {
                    IsBindingSourceLoading = true;
                    estimate = _dentnedModel.Estimates.Find(estimates_id);
                    if (estimate != null)
                    {
                        if (estimate.doctors_id != null)
                            DGUIGHFUtilsUI.DGComboBoxItem.SelectItemById(comboBox_filterDoctors, estimate.doctors_id);
                        else
                            comboBox_filterDoctors.SelectedIndex = -1;
                    }
                    DGUIGHFUtilsUI.DGComboBoxItem.SelectItemById(comboBox_filterYears, estimate.estimates_date.Year);
                    IsBindingSourceLoading = false;
                    break;
                }
            }

            ReloadView();

            IsBindingSourceLoading = true;
            advancedDataGridView_main.SortASC(advancedDataGridView_main.Columns[1]);
            IsBindingSourceLoading = false;

            ResetTabsDataGrid();

            //select an estiamte on load invoice
            if (estimate != null)
            {
                DGUIGHFData.SetBindingSourcePosition<estimates, DentneDModel>(_dentnedModel.Estimates, estimate, vEstimatesBindingSource);
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
            estimates_paymentComboBox.Items.Clear();
            foreach (paymentstypes a in _dentnedModel.PaymentsTypes.List().OrderBy(r => r.paymentstypes_name))
            {
                estimates_paymentComboBox.Items.Add(new DGUIGHFUtilsUI.DGComboBoxItem(a.paymentstypes_id.ToString(), a.paymentstypes_name));
            }
            estimates_paymentComboBox.SelectedIndex = -1;

            //load footers
            estimates_footerComboBox.Items.Clear();
            foreach (estimatesfooters a in _dentnedModel.EstimatesFooters.List().OrderBy(r => r.estimatesfooters_name))
            {
                estimates_footerComboBox.Items.Add(new DGUIGHFUtilsUI.DGComboBoxItem(a.estimatesfooters_id.ToString(), a.estimatesfooters_name));
            }
            estimates_footerComboBox.SelectedIndex = -1;

            //load deduction taxes
            estimates_deductiontaxrateComboBox.Items.Clear();
            foreach (taxesdeductions a in _dentnedModel.TaxesDeductions.List().OrderBy(r => r.taxesdeductions_name))
            {
                estimates_deductiontaxrateComboBox.Items.Add(new DGUIGHFUtilsUI.DGComboBoxItem(a.taxesdeductions_id.ToString(), a.taxesdeductions_name));
            }
            estimates_deductiontaxrateComboBox.SelectedIndex = -1;

            //load tax rates
            estimateslines_taxrateComboBox.Items.Clear();
            foreach (taxes a in _dentnedModel.Taxes.List().OrderBy(r => r.taxes_name))
            {
                estimateslines_taxrateComboBox.Items.Add(new DGUIGHFUtilsUI.DGComboBoxItem(a.taxes_id.ToString(), a.taxes_name));
            }
            estimateslines_taxrateComboBox.SelectedIndex = -1;

            //local treatments
            treatments_idComboBox.Items.Clear();
            foreach (treatments a in _dentnedModel.Treatments.List())
            {
                treatments_idComboBox.Items.Add(new DGUIGHFUtilsUI.DGComboBoxItem(a.treatments_id.ToString(), a.treatments_code + " - " + a.treatments_name));
            }
            treatments_idComboBox.SelectedIndex = -1;

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
            advancedDataGridView_tabEstimatesLines_list.CleanFilterAndSort();
            advancedDataGridView_tabEstimatesLines_list.SortASC(advancedDataGridView_tabEstimatesLines_list.Columns[1]);
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
            foreach (estimates a in _dentnedModel.Estimates.List().OrderBy(r => r.estimates_date))
            {
                if (!years.Contains(a.estimates_date.Year))
                {
                    comboBox_filterYears.Items.Add(new DGUIGHFUtilsUI.DGComboBoxItem(a.estimates_date.Year.ToString(), a.estimates_date.Year.ToString()));
                    years.Add(a.estimates_date.Year);
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
            if (comboBox_filterDoctors.SelectedIndex != -1)
            {
                year = Convert.ToInt32(((DGUIGHFUtilsUI.DGComboBoxItem)comboBox_filterYears.SelectedItem).Id);
            }

            totalTextBox.Text = "0";
            totalinvoicedTextBox.Text = "0";

            //reset list total
            SetListTotal();

            IEnumerable<VEstimates> vEstimates = _dentnedModel.Estimates.List(r => r.estimates_date.Year == year && r.doctors_id == (doctors_id == -1 ? null : (Nullable<int>)doctors_id)).Select(
                r => new VEstimates
                {
                    estimates_id = r.estimates_id,
                    date = r.estimates_date,
                    isinvoiced = (r.invoices_id != null ? true : false),
                    number = r.estimates_number,
                    patient = (_dentnedModel.Patients.Find(r.patients_id) != null ? _dentnedModel.Patients.Find(r.patients_id).patients_surname + " " + _dentnedModel.Patients.Find(r.patients_id).patients_name : "")
                }).ToList();

            return DGDataTableUtils.ToDataTable<VEstimates>(vEstimates);
        }

        /// <summary>
        /// Main Datagrid filter handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void advancedDataGridView_main_FilterStringChanged(object sender, EventArgs e)
        {
            vEstimatesBindingSource.Filter = advancedDataGridView_main.FilterString;
        }

        /// <summary>
        /// Main Datagrid sort handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void advancedDataGridView_main_SortStringChanged(object sender, EventArgs e)
        {
            vEstimatesBindingSource.Sort = advancedDataGridView_main.SortString;
        }

        /// <summary>
        /// Doctor filter handler
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
        private void comboBox_filterYears_SelectedIndexChanged(object sender, EventArgs e)
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

            totalTextBox.Text = Math.Round(_dentnedModel.Estimates.List(r => r.doctors_id == doctors_id).Sum(r => r.estimates_total), 2).ToString();
            totalinvoicedTextBox.Text = Math.Round(_dentnedModel.Estimates.List(r => r.doctors_id == doctors_id && r.invoices_id != null).Sum(r => r.estimates_total), 2).ToString();
        }
        
        /// <summary>
        /// Main BindingSource changed handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void vEstimatesBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            int estimates_id = -1;
            if (vEstimatesBindingSource.Current != null)
            {
                estimates_id = (((DataRowView)vEstimatesBindingSource.Current).Row).Field<int>("estimates_id");
            }

            estimates_invoiceTextBox.Text = "";
            if(estimates_id != -1)
            {
                estimates estimate = _dentnedModel.Estimates.Find(estimates_id);
                if(estimate.invoices_id != null)
                {
                    invoices invoice = _dentnedModel.Invoices.Find(estimate.invoices_id);
                    doctors doctor = null;
                    if(invoice.doctors_id != null)
                    {
                        doctor = _dentnedModel.Doctors.Find(invoice.doctors_id);
                    }
                    
                    estimates_invoiceTextBox.Text = invoice.invoices_number + " / " + invoice.invoices_date.ToShortDateString() + " " + (doctor != null ? "- " + doctor.doctors_surname + " " + doctor.doctors_name + " " : "") + "(" + invoice.invoices_id + ")";
                }
            }

        }


        #region tabEstimates

        /// <summary>
        /// Load the tab DataSource
        /// </summary>
        /// <returns></returns>
        private object GetDataSourceEdit_tabEstimates()
        {
            return DGUIGHFData.LoadEntityFromCurrentBindingSource<estimates, DentneDModel>(_dentnedModel.Estimates, vEstimatesBindingSource, new string[] { "estimates_id" });
        }

        /// <summary>
        /// Do actions after Save
        /// </summary>
        /// <param name="item"></param>
        private void AfterSaveAction_tabEstimates(object item)
        {
            DGUIGHFData.SetBindingSourcePosition<estimates, DentneDModel>(_dentnedModel.Estimates, item, vEstimatesBindingSource);
        }

        /// <summary>
        /// Add an item
        /// </summary>
        /// <param name="item"></param>
        private void Add_tabEstimates(object item)
        {
            DGUIGHFData.Add<estimates, DentneDModel>(_dentnedModel.Estimates, item);

            //load filter years
            ReloadFilterYears();
        }

        /// <summary>
        /// Update an item
        /// </summary>
        /// <param name="item"></param>
        private void Update_tabEstimates(object item)
        {
            DGUIGHFData.Update<estimates, DentneDModel>(_dentnedModel.Estimates, item);

            //load filter years
            ReloadFilterYears();
        }

        /// <summary>
        /// Remove an item
        /// </summary>
        /// <param name="item"></param>
        private void Remove_tabEstimates(object item)
        {
            DGUIGHFData.Remove<estimates, DentneDModel>(false, _dentnedModel.Estimates, item);

            //load filter years
            ReloadFilterYears();
        }

        /// <summary>
        /// New button handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_tabEstimates_new_Click(object sender, EventArgs e)
        {
            if (comboBox_filterDoctors.SelectedIndex == -1 || comboBox_filterDoctors.SelectedIndex == 0)
            {
                MessageBox.Show("Please select a Doctor", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            IsBindingSourceLoading = true;
            if (AddClick(tabElement_tabEstimates))
            {
                //set default values
                int doctors_id = Convert.ToInt32(((DGUIGHFUtilsUI.DGComboBoxItem)comboBox_filterDoctors.SelectedItem).Id);
                int maxnumber = 1;
                try
                {
                    maxnumber = Convert.ToInt32(_dentnedModel.Estimates.List(r => r.doctors_id == doctors_id && r.estimates_date.Year == DateTime.Now.Year).Max(r => r.estimates_number));
                    maxnumber++;
                }
                catch { }
                ((estimates)estimatesBindingSource.Current).doctors_id = doctors_id;
                ((estimates)estimatesBindingSource.Current).patients_id = null;
                if (_dentnedModel.PaymentsTypes.List(r => r.paymentstypes_isdefault).Count > 0)
                    ((estimates)estimatesBindingSource.Current).estimates_payment = _dentnedModel.PaymentsTypes.List(r => r.paymentstypes_isdefault).FirstOrDefault().paymentstypes_doctext;
                if (_dentnedModel.EstimatesFooters.List(r => r.estimatesfooters_isdefault).Count > 0)
                    ((estimates)estimatesBindingSource.Current).estimates_footer = _dentnedModel.EstimatesFooters.List(r => r.estimatesfooters_isdefault).FirstOrDefault().estimatesfooters_doctext;
                if (_dentnedModel.TaxesDeductions.List(r => r.taxesdeductions_isdefault).Count > 0)
                    ((estimates)estimatesBindingSource.Current).estimates_deductiontaxrate = _dentnedModel.TaxesDeductions.List(r => r.taxesdeductions_isdefault).FirstOrDefault().taxesdeductions_rate;
                ((estimates)estimatesBindingSource.Current).estimates_date = DateTime.Now;
                ((estimates)estimatesBindingSource.Current).estimates_number = maxnumber.ToString();
                //reset BindingSource
                estimatesBindingSource.ResetBindings(true);
                //raise changed indexes
                IsBindingSourceLoading = false;
                doctors_idComboBox_SelectedIndexChanged(null, null);
                estimates_paymentComboBox_SelectedIndexChanged(null, null);
                estimates_footerComboBox_SelectedIndexChanged(null, null);
                estimates_deductiontaxrateComboBox_SelectedIndexChanged(null, null);
            }
            IsBindingSourceLoading = false;
        }

        /// <summary>
        /// Edit button handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_tabEstimates_edit_Click(object sender, EventArgs e)
        {
            if (UpdateClick(tabElement_tabEstimates))
            {
                doctors_idComboBox.Enabled = false;
                patients_idComboBox.Enabled = false;
            }
        }

        /// <summary>
        /// Payed button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_tabEstimates_invoiced_Click(object sender, EventArgs e)
        {
            if (vEstimatesBindingSource.Current != null)
            {
                if (MessageBox.Show("Invoice this item?", "Invoice", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    int estimates_id = -1;
                    if (vEstimatesBindingSource.Current != null)
                    {
                        estimates_id = (((DataRowView)vEstimatesBindingSource.Current).Row).Field<int>("estimates_id");
                    }
                    
                    if(estimates_id != -1)
                    {
                        estimates estimate = _dentnedModel.Estimates.Find(estimates_id);

                        //add the new invoice
                        int maxnumber = 1;
                        try
                        {
                            maxnumber = Convert.ToInt32(_dentnedModel.Invoices.List(r => r.doctors_id == estimate.doctors_id && r.invoices_date.Year == DateTime.Now.Year).Max(r => r.invoices_number));
                            maxnumber++;
                        }
                        catch { }
                        invoices invoice = new invoices()
                        {
                            doctors_id = estimate.doctors_id,
                            patients_id = estimate.patients_id,
                            invoices_number = maxnumber.ToString(),
                            invoices_date = DateTime.Now,
                            invoices_doctor = estimate.estimates_doctor,
                            invoices_footer = estimate.estimates_footer,
                            invoices_deductiontaxrate = estimate.estimates_deductiontaxrate,
                            invoices_patient = estimate.estimates_patient,
                            invoices_payment = estimate.estimates_payment,
                            invoices_ispaid = false,
                            invoices_total = estimate.estimates_total
                        };
                        _dentnedModel.Invoices.Add(invoice);
                        //add invoices lines
                        foreach (estimateslines estimatesline in _dentnedModel.EstimatesLines.List(r => r.estimates_id == estimate.estimates_id))
                        {
                            invoiceslines invoicesline = new invoiceslines()
                            {
                                invoices_id = invoice.invoices_id,
                                invoiceslines_code = estimatesline.estimateslines_code,
                                invoiceslines_description = estimatesline.estimateslines_description,
                                invoiceslines_quantity = estimatesline.estimateslines_quantity,
                                invoiceslines_taxrate = estimatesline.estimateslines_taxrate,
                                invoiceslines_unitprice = estimatesline.estimateslines_unitprice,
                                patientstreatments_id = estimatesline.patientstreatments_id
                            };
                            _dentnedModel.InvoicesLines.Add(invoicesline);
                        }

                        //set the invoice number
                        estimate.invoices_id = invoice.invoices_id;
                        _dentnedModel.Estimates.Update(estimate);

                        MessageBox.Show("Successfully invoiced to invoice number " + maxnumber + ".", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        ReloadAfterSave(tabElement_tabEstimates, estimate);
                    }
                    
                }
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

            if (doctors_idComboBox.SelectedValue != null)
            {
                ((estimates)estimatesBindingSource.Current).estimates_doctor = "";
                doctors doctor = _dentnedModel.Doctors.Find((int)doctors_idComboBox.SelectedValue);
                if (doctor != null)
                    ((estimates)estimatesBindingSource.Current).estimates_doctor = doctor.doctors_doctext;
                ((estimates)estimatesBindingSource.Current).doctors_id = (int)doctors_idComboBox.SelectedValue;
                estimatesBindingSource.ResetBindings(true);
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

            if (patients_idComboBox.SelectedValue != null)
            {
                ((estimates)estimatesBindingSource.Current).estimates_patient = "";
                patients patient = _dentnedModel.Patients.Find((int)patients_idComboBox.SelectedValue);
                if (patient != null)
                    ((estimates)estimatesBindingSource.Current).estimates_patient = patient.patients_doctext;
                ((estimates)estimatesBindingSource.Current).patients_id = (int)patients_idComboBox.SelectedValue;
                estimatesBindingSource.ResetBindings(true);
            }
        }

        /// <summary>
        /// Payment Type changed handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void estimates_paymentComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsBindingSourceLoading)
                return;

            if (estimates_paymentComboBox.SelectedIndex != -1)
            {
                int paymentstypes_id = -1;
                try
                {
                    paymentstypes_id = Convert.ToInt32(((DGUIGHFUtilsUI.DGComboBoxItem)estimates_paymentComboBox.SelectedItem).Id);
                }
                catch { }
                if (paymentstypes_id != -1)
                {
                    paymentstypes paymentstype = _dentnedModel.PaymentsTypes.Find(paymentstypes_id);
                    ((estimates)estimatesBindingSource.Current).estimates_payment = paymentstype.paymentstypes_doctext;
                }
                estimatesBindingSource.ResetBindings(true);
            }
            IsBindingSourceLoading = true;
            estimates_paymentComboBox.SelectedIndex = -1;
            IsBindingSourceLoading = false;
        }

        /// <summary>
        /// Footer changed handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void estimates_footerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsBindingSourceLoading)
                return;

            if (estimates_footerComboBox.SelectedIndex != -1)
            {
                int estimatesfooters_id = -1;
                try
                {
                    estimatesfooters_id = Convert.ToInt32(((DGUIGHFUtilsUI.DGComboBoxItem)estimates_footerComboBox.SelectedItem).Id);
                }
                catch { }
                if (estimatesfooters_id != -1)
                {
                    estimatesfooters estimatesfooter = _dentnedModel.EstimatesFooters.Find(estimatesfooters_id);
                    ((estimates)estimatesBindingSource.Current).estimates_footer = estimatesfooter.estimatesfooters_doctext;
                }
                estimatesBindingSource.ResetBindings(true);
            }
            IsBindingSourceLoading = true;
            estimates_footerComboBox.SelectedIndex = -1;
            IsBindingSourceLoading = false;
        }

        /// <summary>
        /// Deduction tax changed handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void estimates_deductiontaxrateComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsBindingSourceLoading)
                return;

            if (estimates_deductiontaxrateComboBox.SelectedIndex != -1)
            {
                int taxesdeductions_id = -1;
                try
                {
                    taxesdeductions_id = Convert.ToInt32(((DGUIGHFUtilsUI.DGComboBoxItem)estimates_deductiontaxrateComboBox.SelectedItem).Id);
                }
                catch { }
                if (taxesdeductions_id != -1)
                {
                    taxesdeductions taxesdeduction = _dentnedModel.TaxesDeductions.Find(taxesdeductions_id);
                    ((estimates)estimatesBindingSource.Current).estimates_deductiontaxrate = taxesdeduction.taxesdeductions_rate;
                }
                estimatesBindingSource.ResetBindings(true);
            }
            IsBindingSourceLoading = true;
            estimates_deductiontaxrateComboBox.SelectedIndex = -1;
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
        private void estimates_paymentComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            DGUIGHFUtilsUI.DGComboBoxAutoComplete.OnKeyPress((ComboBox)sender, e);
        }

        /// <summary>
        /// Combobox autocomplete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void estimates_footerComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            DGUIGHFUtilsUI.DGComboBoxAutoComplete.OnKeyPress((ComboBox)sender, e);
        }

        /// <summary>
        /// Combobox autocomplete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void estimates_deductiontaxrateComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            DGUIGHFUtilsUI.DGComboBoxAutoComplete.OnKeyPress((ComboBox)sender, e);
        }


        #endregion


        #region tabEstimatesLines

        /// <summary>
        /// Get tab list DataSource
        /// </summary>
        /// <returns></returns>
        private object GetDataSourceList_tabEstimatesLines()
        {
            object ret = null;

            int estimates_id = -1;
            if (vEstimatesBindingSource.Current != null)
            {
                estimates_id = (((DataRowView)vEstimatesBindingSource.Current).Row).Field<int>("estimates_id");
            }

            if (estimates_id != -1)
            {
                //reload patientstreatments tab
                estimates estimate = _dentnedModel.Estimates.Find(estimates_id);
                ReloadPatientsTreatments(estimate.patients_id, true);
            }
            else
                ReloadPatientsTreatments(null, true);

            //reset list total
            SetListTotal();

            IEnumerable<VEstimatesLines> vEstimatesLines =
            _dentnedModel.EstimatesLines.List(r => r.estimates_id == estimates_id).Select(
            r => new VEstimatesLines
            {
                estimateslines_id = r.estimateslines_id,
                code = r.estimateslines_code,
                quantity = r.estimateslines_quantity,
                taxrate = (double)r.estimateslines_taxrate,
                unitprice = (double)r.estimateslines_unitprice,
                description = ((r.estimateslines_description).Length > MaxRowValueLength ? (r.estimateslines_description).Substring(0, MaxRowValueLength) + "..." : (r.estimateslines_description)),
                totalprice = (double)Math.Round((r.estimateslines_quantity * r.estimateslines_unitprice) + (r.estimateslines_quantity * r.estimateslines_unitprice) * (r.estimateslines_taxrate / 100), 2)
            }).ToList();

            ret = DGDataTableUtils.ToDataTable<VEstimatesLines>(vEstimatesLines);

            return ret;
        }

        /// <summary>
        /// Tab Datagrid filter handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void advancedDataGridView_tabEstimatesLines_list_FilterStringChanged(object sender, EventArgs e)
        {
            vEstimatesLinesBindingSource.Filter = advancedDataGridView_tabEstimatesLines_list.FilterString;
        }

        /// <summary>
        /// Tab Datagrid sort handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void advancedDataGridView_tabEstimatesLines_list_SortStringChanged(object sender, EventArgs e)
        {
            vEstimatesLinesBindingSource.Sort = advancedDataGridView_tabEstimatesLines_list.SortString;
        }

        /// <summary>
        /// Load the tab DataSource
        /// </summary>
        /// <returns></returns>
        private object GetDataSourceEdit_tabEstimatesLines()
        {
            return DGUIGHFData.LoadEntityFromCurrentBindingSource<estimateslines, DentneDModel>(_dentnedModel.EstimatesLines, vEstimatesLinesBindingSource, new string[] { "estimateslines_id" });
        }

        /// <summary>
        /// Do actions after Save
        /// </summary>
        /// <param name="item"></param>
        private void AfterSaveAction_tabEstimatesLines(object item)
        {
            DGUIGHFData.SetBindingSourcePosition<estimateslines, DentneDModel>(_dentnedModel.EstimatesLines, item, vEstimatesLinesBindingSource);
        }

        /// <summary>
        /// Add an item
        /// </summary>
        /// <param name="item"></param>
        private void Add_tabEstimatesLines(object item)
        {
            DGUIGHFData.Add<estimateslines, DentneDModel>(_dentnedModel.EstimatesLines, item);
        }

        /// <summary>
        /// Update an item
        /// </summary>
        /// <param name="item"></param>
        private void Update_tabEstimatesLines(object item)
        {
            DGUIGHFData.Update<estimateslines, DentneDModel>(_dentnedModel.EstimatesLines, item);
        }

        /// <summary>
        /// Remove an item
        /// </summary>
        /// <param name="item"></param>
        private void Remove_tabEstimatesLines(object item)
        {
            DGUIGHFData.Remove<estimateslines, DentneDModel>(_dentnedModel.EstimatesLines, item);
        }

        /// <summary>
        /// New tab button handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_tabEstimatesLines_new_Click(object sender, EventArgs e)
        {
            if (vEstimatesBindingSource.Current != null)
            {
                if (AddClick(tabElement_tabEstimatesLines))
                {
                    int estimates_id = (((DataRowView)vEstimatesBindingSource.Current).Row).Field<int>("estimates_id");
                    estimates estimate = _dentnedModel.Estimates.Find(estimates_id);
                    ReloadPatientsTreatments(estimate.patients_id, false);

                    ((estimateslines)estimateslinesBindingSource.Current).estimates_id = estimates_id;
                    ((estimateslines)estimateslinesBindingSource.Current).estimateslines_code = "";
                    ((estimateslines)estimateslinesBindingSource.Current).estimateslines_description = "";
                    ((estimateslines)estimateslinesBindingSource.Current).estimateslines_quantity = 0;
                    ((estimateslines)estimateslinesBindingSource.Current).estimateslines_unitprice = 0;
                    if (_dentnedModel.Taxes.List(r => r.taxes_isdefault).Count > 0)
                        ((estimateslines)estimateslinesBindingSource.Current).estimateslines_taxrate = _dentnedModel.Taxes.List(r => r.taxes_isdefault).FirstOrDefault().taxes_rate;
                    estimateslinesBindingSource.ResetBindings(true);
                }
            }
        }

        /// <summary>
        /// Edit tab button handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_tabEstimatesLines_edit_Click(object sender, EventArgs e)
        {
            if (vEstimatesBindingSource.Current != null)
            {
                if (UpdateClick(tabElement_tabEstimatesLines))
                {
                    groupBox_tabEstimatesLines_filler.Enabled = false;
                    patientstreatments_idComboBox.Enabled = false;
                }
            }
        }

        /// <summary>
        /// Estimates prices changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox_tabEstimatesLines_filterPriceslists_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsBindingSourceLoading)
                return;

            tabElement_tabEstimatesLines.IsLaziLoaded = false;
            TabControl_SelectedIndexChanged(null, null, TabElements, tabControl_main);
        }

        /// <summary>
        /// Reload patients treatments combobox
        /// </summary>
        /// <param name="patients_id"></param>
        /// <param name="loadall"></param>
        private void ReloadPatientsTreatments(Nullable<int> patients_id, bool loadall)
        {
            //get only treatments not yet estimated
            List<patientstreatments> patientstreatmentsl = new List<patientstreatments>();
            if (patients_id != null && !loadall)
            {
                if (!loadall)
                {
                    //do not load already inserted treatments and yet payed
                    patientstreatmentsl = _dentnedModel.PatientsTreatments.List(r => r.patients_id == patients_id && !r.patientstreatments_ispayed).ToList();
                    foreach (estimateslines estimatesline in _dentnedModel.EstimatesLines.List())
                    {
                        patientstreatments patientstreatment = patientstreatmentsl.Where(r => r.patientstreatments_id == estimatesline.patientstreatments_id).FirstOrDefault();
                        if (patientstreatment != null)
                            patientstreatmentsl.Remove(patientstreatment);
                    }
                }
                else
                {
                    patientstreatmentsl = _dentnedModel.PatientsTreatments.List(r => r.patients_id == patients_id && !r.patientstreatments_ispayed).ToList();
                }
            }
            else
            {
                patientstreatmentsl = _dentnedModel.PatientsTreatments.List().ToList();
            }
            //local patients treatments
            IsBindingSourceLoading = true;
            patientstreatments_idComboBox.DataSource = patientstreatmentsl.Select(r => new { name = _dentnedModel.Treatments.Find(r.treatments_id).treatments_code + " [" + _dentnedModel.PatientsTreatments.GetTreatmentsToothsString(r) + "] " + r.patientstreatments_creationdate.ToShortDateString(), r.patientstreatments_id }).OrderBy(r => r.name).ToList();
            patientstreatments_idComboBox.DisplayMember = "name";
            patientstreatments_idComboBox.ValueMember = "patientstreatments_id";
            IsBindingSourceLoading = false;
        }

        /// <summary>
        /// Tax rate changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void estimateslines_taxrateComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsBindingSourceLoading)
                return;

            if (estimateslinesBindingSource.Current != null && estimateslines_taxrateComboBox.SelectedIndex != -1)
            {
                int taxes_id = -1;
                try
                {
                    taxes_id = Convert.ToInt32(((DGUIGHFUtilsUI.DGComboBoxItem)estimateslines_taxrateComboBox.SelectedItem).Id);
                }
                catch { }
                if (taxes_id != -1)
                {
                    taxes taxes = _dentnedModel.Taxes.Find(taxes_id);
                    ((estimateslines)estimateslinesBindingSource.Current).estimateslines_taxrate = taxes.taxes_rate;
                }
                estimateslinesBindingSource.ResetBindings(true);
            }
            IsBindingSourceLoading = true;
            estimateslines_taxrateComboBox.SelectedIndex = -1;
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

            if (tabElement_tabEstimatesLines.CurrentEditingMode == EditingMode.C)
            {
                if (estimateslinesBindingSource.Current != null && treatments_idComboBox.SelectedIndex != -1)
                {
                    int estimates_id = -1;
                    if (vEstimatesBindingSource.Current != null)
                    {
                        estimates_id = (((DataRowView)vEstimatesBindingSource.Current).Row).Field<int>("estimates_id");
                    }
                    if (estimates_id != -1)
                    {
                        estimates estimate = _dentnedModel.Estimates.Find(estimates_id);
                        int patients_id = -1;

                        if (estimate.patients_id != null)
                            patients_id = (int)estimate.patients_id;

                        if (patients_id != -1)
                        {
                            treatments treatment = _dentnedModel.Treatments.Find(Convert.ToInt32(((DGUIGHFUtilsUI.DGComboBoxItem)treatments_idComboBox.SelectedItem).Id));
                            if (treatment != null)
                            {
                                string code = treatment.treatments_code;
                                string description = treatment.treatments_name;
                                decimal price = treatment.treatments_price;
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
                                ((estimateslines)estimateslinesBindingSource.Current).estimateslines_code = code;
                                ((estimateslines)estimateslinesBindingSource.Current).estimateslines_description = description;
                                ((estimateslines)estimateslinesBindingSource.Current).estimateslines_quantity = 1;
                                ((estimateslines)estimateslinesBindingSource.Current).estimateslines_unitprice = price;
                            }
                        }
                    }
                }
                estimateslinesBindingSource.ResetBindings(true);
            }
            IsBindingSourceLoading = true;
            patientstreatments_idComboBox.SelectedIndex = -1;
            IsBindingSourceLoading = false;
        }

        /// <summary>
        /// Treatments leaved
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treatments_idComboBox_Leave(object sender, EventArgs e)
        {
            if (IsBindingSourceLoading)
                return;

            IsBindingSourceLoading = true;
            treatments_idComboBox.SelectedIndex = -1;
            IsBindingSourceLoading = false;
        }

        //Patient treatments changed
        private void patientstreatments_idComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsBindingSourceLoading)
                return;

            if (tabElement_tabEstimatesLines.CurrentEditingMode == EditingMode.C)
            {
                if (estimateslinesBindingSource.Current != null && patientstreatments_idComboBox.SelectedIndex != -1)
                {
                    int estimates_id = -1;
                    if (vEstimatesBindingSource.Current != null)
                    {
                        estimates_id = (((DataRowView)vEstimatesBindingSource.Current).Row).Field<int>("estimates_id");
                    }
                    if (estimates_id != -1)
                    {
                        estimates estimate = _dentnedModel.Estimates.Find(estimates_id);
                        int patients_id = -1;

                        if (estimate.patients_id != null)
                            patients_id = (int)estimate.patients_id;

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
                                    ((estimateslines)estimateslinesBindingSource.Current).patientstreatments_id = patientstreatments.patientstreatments_id;
                                    ((estimateslines)estimateslinesBindingSource.Current).estimateslines_code = code;
                                    ((estimateslines)estimateslinesBindingSource.Current).estimateslines_description = description;
                                    ((estimateslines)estimateslinesBindingSource.Current).estimateslines_quantity = 1;
                                    ((estimateslines)estimateslinesBindingSource.Current).estimateslines_unitprice = price;
                                }
                            }
                        }
                    }
                }
                estimateslinesBindingSource.ResetBindings(true);
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
        private void patientstreatments_idComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            DGUIGHFUtilsUI.DGComboBoxAutoComplete.OnKeyPress((ComboBox)sender, e);
        }

        /// <summary>
        /// Combobox autocomplete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void estimateslines_taxrateComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            DGUIGHFUtilsUI.DGComboBoxAutoComplete.OnKeyPress((ComboBox)sender, e);
        }

        #endregion
                
    }
}
