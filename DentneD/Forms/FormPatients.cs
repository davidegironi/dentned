#region License
// Copyright (c) 2015 Davide Gironi
//
// Please refer to LICENSE file for licensing information.
#endregion

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DG.Data.Model.Helpers;
using DG.UI.GHF;
using DG.DentneD.Model;
using DG.DentneD.Model.Entity;
using DG.DentneD.Forms.Objects;
using DentneD;
using Zuby.ADGV;
using System.Data;
using System.Configuration;
using System.Diagnostics;
using System.Text;
using DG.DentneD.Model.Repositories;
using System.Linq.Expressions;

namespace DG.DentneD.Forms
{
    public partial class FormPatients : DGUIGHFForm
    {
        private DentneDModel _dentnedModel = null;

        private TabElement tabElement_tabPatients = new TabElement();
        private TabElement tabElement_tabPatients_tabPatients = new TabElement();
        private TabElement tabElement_tabPatients_tabPatientsAddresses = new TabElement();
        private TabElement tabElement_tabPatients_tabPatientsContacts = new TabElement();
        private TabElement tabElement_tabPatientsMedicalrecords = new TabElement();
        private TabElement tabElement_tabPatientsTreatments = new TabElement();
        private TabElement tabElement_tabPayments = new TabElement();
        private TabElement tabElement_tabAppointments = new TabElement();
        private TabElement tabElement_tabPatientsAttachments = new TabElement();
        private TabElement tabElement_tabInvoices = new TabElement();
        private TabElement tabElement_tabEstimates = new TabElement();
        private TabElement tabElement_tabPatientsNotes = new TabElement();

        private const int MaxRowValueLength = 60;
        private const string SRMBinaryFileName = "srm.exe";

        private enum FilterShow { NotArchived, Archived, All };

        private readonly string _patientsDatadir = "";
        private readonly string _patientsAttachmentsdir = "";
        private readonly bool _doSecureDelete = false;

        /// <summary>
        /// Constructor
        /// </summary>
        public FormPatients()
        {
            InitializeComponent();

            Initialize(Program.uighfApplication);

            _dentnedModel = new DentneDModel();

            _patientsDatadir = ConfigurationManager.AppSettings["patientsDatadir"];
            _patientsAttachmentsdir = ConfigurationManager.AppSettings["patientsAttachmentsdir"];
            _doSecureDelete = Convert.ToBoolean(ConfigurationManager.AppSettings["doSecureDelete"]);
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
            BindingSourceMain = vPatientsBindingSource;
            GetDataSourceMain = GetDataSource_main;

            //set Main TabControl
            TabControlMain = tabControl_main;

            //set Main Panels
            PanelFiltersMain = null;
            PanelListMain = panel_list;
            PanelsExtraMain = null;

            //set tabPatients_tabPatients
            tabElement_tabPatients_tabPatients = new TabElement()
            {
                TabPageElement = tabPage_tabPatients_tabPatients,
                ElementItem = new TabElement.TabElementItem()
                {
                    PanelData = panel_tabPatients_tabPatients_data,
                    PanelActions = panel_tabPatients_tabPatients_actions,
                    PanelUpdates = panel_tabPatients_tabPatients_updates,

                    BindingSourceList = vPatientsBindingSource,
                    GetDataSourceList = GetDataSource_main,

                    BindingSourceEdit = patientsBindingSource,
                    GetDataSourceEdit = GetDataSourceEdit_tabPatients,
                    AfterSaveAction = AfterSaveAction_tabPatients,

                    AddButton = button_tabPatients_tabPatients_new,
                    IsAddButtonDefaultClickEventAttached = false,
                    UpdateButton = button_tabPatients_tabPatients_edit,
                    RemoveButton = button_tabPatients_tabPatients_delete,
                    SaveButton = button_tabPatients_tabPatients_save,
                    CancelButton = button_tabPatients_tabPatients_cancel,

                    Add = Add_tabPatients,
                    Update = Update_tabPatients,
                    Remove = Remove_tabPatients
                }
            };

            //set tabPatients_tabPatientsContacts
            tabElement_tabPatients_tabPatientsContacts = new TabElement()
            {
                TabPageElement = tabPage_tabPatients_tabPatientsContacts,
                ElementListItem = new TabElement.TabElementListItem()
                {
                    PanelFilters = null,
                    PanelList = panel_tabPatients_tabPatientsContacts_list,

                    PanelData = panel_tabPatients_tabPatientsContacts_data,
                    PanelActions = panel_tabPatients_tabPatientsContacts_actions,
                    PanelUpdates = panel_tabPatients_tabPatientsContacts_updates,

                    BindingSourceList = vPatientsContactsBindingSource,
                    GetDataSourceList = GetDataSourceList_tabPatients_tabPatientsContacts,

                    BindingSourceEdit = patientscontactsBindingSource,
                    GetDataSourceEdit = GetDataSourceEdit_tabPatients_tabPatientsContacts,
                    AfterSaveAction = AfterSaveAction_tabPatients_tabPatientsContacts,

                    AddButton = button_tabPatients_tabPatientsContacts_new,
                    IsAddButtonDefaultClickEventAttached = false,
                    UpdateButton = button_tabPatients_tabPatientsContacts_edit,
                    RemoveButton = button_tabPatients_tabPatientsContacts_delete,
                    SaveButton = button_tabPatients_tabPatientsContacts_save,
                    CancelButton = button_tabPatients_tabPatientsContacts_cancel,

                    Add = Add_tabPatients_tabPatientsContacts,
                    Update = Update_tabPatients_tabPatientsContacts,
                    Remove = Remove_tabPatients_tabPatientsContacts
                }
            };

            //set tabPatients_tabPatientsAddresses
            tabElement_tabPatients_tabPatientsAddresses = new TabElement()
            {
                TabPageElement = tabPage_tabPatients_tabPatientsAddresses,
                ElementListItem = new TabElement.TabElementListItem()
                {
                    PanelFilters = null,
                    PanelList = panel_tabPatients_tabPatientsAddresses_list,

                    PanelData = panel_tabPatients_tabPatientsAddresses_data,
                    PanelActions = panel_tabPatients_tabPatientsAddresses_actions,
                    PanelUpdates = panel_tabPatients_tabPatientsAddresses_updates,

                    BindingSourceList = vPatientsAddressesBindingSource,
                    GetDataSourceList = GetDataSourceList_tabPatients_tabPatientsAddresses,

                    BindingSourceEdit = patientsaddressesBindingSource,
                    GetDataSourceEdit = GetDataSourceEdit_tabPatients_tabPatientsAddresses,
                    AfterSaveAction = AfterSaveAction_tabPatients_tabPatientsAddresses,

                    AddButton = button_tabPatients_tabPatientsAddresses_new,
                    IsAddButtonDefaultClickEventAttached = false,
                    UpdateButton = button_tabPatients_tabPatientsAddresses_edit,
                    RemoveButton = button_tabPatients_tabPatientsAddresses_delete,
                    SaveButton = button_tabPatients_tabPatientsAddresses_save,
                    CancelButton = button_tabPatients_tabPatientsAddresses_cancel,

                    Add = Add_tabPatients_tabPatientsAddresses,
                    Update = Update_tabPatients_tabPatientsAddresses,
                    Remove = Remove_tabPatients_tabPatientsAddresses
                }
            };

            //set tabPatientsMedicalrecords
            tabElement_tabPatientsMedicalrecords = new TabElement()
            {
                TabPageElement = tabPage_tabPatientsMedicalrecords,
                ElementListItem = new TabElement.TabElementListItem()
                {
                    PanelFilters = null,
                    PanelList = panel_tabPatientsMedicalrecords_list,

                    PanelData = panel_tabPatientsMedicalrecords_data,
                    PanelActions = panel_tabPatientsMedicalrecords_actions,
                    PanelUpdates = panel_tabPatientsMedicalrecords_updates,

                    BindingSourceList = vPatientsMedicalrecordsBindingSource,
                    GetDataSourceList = GetDataSourceList_tabPatientsMedicalrecords,

                    BindingSourceEdit = patientsmedicalrecordsBindingSource,
                    GetDataSourceEdit = GetDataSourceEdit_tabPatientsMedicalrecords,
                    AfterSaveAction = AfterSaveAction_tabPatientsMedicalrecords,

                    AddButton = button_tabPatientsMedicalrecords_new,
                    IsAddButtonDefaultClickEventAttached = false,
                    UpdateButton = button_tabPatientsMedicalrecords_edit,
                    RemoveButton = button_tabPatientsMedicalrecords_delete,
                    SaveButton = button_tabPatientsMedicalrecords_save,
                    CancelButton = button_tabPatientsMedicalrecords_cancel,

                    Add = Add_tabPatientsMedicalrecords,
                    Update = Update_tabPatientsMedicalrecords,
                    Remove = Remove_tabPatientsMedicalrecords
                }
            };

            //set tabPatientsTreatments
            tabElement_tabPatientsTreatments = new TabElement()
            {
                TabPageElement = tabPage_tabPatientsTreatments,
                ElementListItem = new TabElement.TabElementListItem()
                {
                    PanelFilters = panel_tabPatientsTreatments_filters,
                    PanelList = panel_tabPatientsTreatments_list,

                    PanelData = panel_tabPatientsTreatments_data,
                    PanelActions = panel_tabPatientsTreatments_actions,
                    PanelUpdates = panel_tabPatientsTreatments_updates,

                    BindingSourceList = vPatientsTreatmentsBindingSource,
                    GetDataSourceList = GetDataSourceList_tabPatientsTreatments,

                    BindingSourceEdit = patientstreatmentsBindingSource,
                    GetDataSourceEdit = GetDataSourceEdit_tabPatientsTreatments,
                    AfterSaveAction = AfterSaveAction_tabPatientsTreatments,

                    AddButton = button_tabPatientsTreatments_new,
                    IsAddButtonDefaultClickEventAttached = false,
                    UpdateButton = button_tabPatientsTreatments_edit,
                    IsUpdateButtonDefaultClickEventAttached = false,
                    RemoveButton = button_tabPatientsTreatments_delete,
                    SaveButton = button_tabPatientsTreatments_save,
                    CancelButton = button_tabPatientsTreatments_cancel,

                    Add = Add_tabPatientsTreatments,
                    Update = Update_tabPatientsTreatments,
                    Remove = Remove_tabPatientsTreatments
                }
            };

            //set tabPayments
            tabElement_tabPayments = new TabElement()
            {
                TabPageElement = tabPage_tabPayments,
                ElementListItem = new TabElement.TabElementListItem()
                {
                    PanelFilters = null,
                    PanelList = panel_tabPayments_list,

                    PanelData = panel_tabPayments_data,
                    PanelActions = panel_tabPayments_actions,
                    PanelUpdates = panel_tabPayments_updates,

                    BindingSourceList = vPatientsPaymentsBindingSource,
                    GetDataSourceList = GetDataSourceList_tabPayments,

                    BindingSourceEdit = paymentsBindingSource,
                    GetDataSourceEdit = GetDataSourceEdit_tabPayments,
                    AfterSaveAction = AfterSaveAction_tabPayments,

                    AddButton = button_tabPayments_new,
                    IsAddButtonDefaultClickEventAttached = false,
                    UpdateButton = button_tabPayments_edit,
                    RemoveButton = button_tabPayments_delete,
                    SaveButton = button_tabPayments_save,
                    CancelButton = button_tabPayments_cancel,

                    Add = Add_tabPayments,
                    Update = Update_tabPayments,
                    Remove = Remove_tabPayments
                }
            };

            //set tabAppointments
            tabElement_tabAppointments = new TabElement()
            {
                TabPageElement = tabPage_tabAppointments,
                ElementListItem = new TabElement.TabElementListItem()
                {
                    PanelFilters = null,
                    PanelList = panel_tabAppointments_list,

                    PanelData = panel_tabAppointments_data,
                    PanelActions = null,
                    PanelUpdates = null,

                    BindingSourceList = vPatientsAppointmentsBindingSource,
                    GetDataSourceList = GetDataSourceList_tabAppointments,

                    BindingSourceEdit = appointmentsBindingSource,
                    GetDataSourceEdit = GetDataSourceEdit_tabAppointments,
                    AfterSaveAction = null,

                    AddButton = null,
                    UpdateButton = null,
                    RemoveButton = null,
                    SaveButton = null,
                    CancelButton = null,

                    Add = null,
                    Update = null,
                    Remove = null
                }
            };

            //set tabPatientsAttachments
            tabElement_tabPatientsAttachments = new TabElement()
            {
                TabPageElement = tabPage_tabPatientsAttachments,
                ElementListItem = new TabElement.TabElementListItem()
                {
                    PanelFilters = null,
                    PanelList = panel_tabPatientsAttachments_list,

                    PanelData = panel_tabPatientsAttachments_data,
                    PanelActions = panel_tabPatientsAttachments_actions,
                    PanelUpdates = panel_tabPatientsAttachments_updates,

                    BindingSourceList = vPatientsAttachmentsBindingSource,
                    GetDataSourceList = GetDataSourceList_tabPatientsAttachments,

                    BindingSourceEdit = patientsattachmentsBindingSource,
                    GetDataSourceEdit = GetDataSourceEdit_tabPatientsAttachments,
                    AfterSaveAction = AfterSaveAction_tabPatientsAttachments,

                    AddButton = button_tabPatientsAttachments_new,
                    IsAddButtonDefaultClickEventAttached = false,
                    UpdateButton = button_tabPatientsAttachments_edit,
                    IsUpdateButtonDefaultClickEventAttached = false,
                    RemoveButton = button_tabPatientsAttachments_delete,
                    SaveButton = button_tabPatientsAttachments_save,
                    CancelButton = button_tabPatientsAttachments_cancel,

                    Add = Add_tabPatientsAttachments,
                    Update = Update_tabPatientsAttachments,
                    Remove = Remove_tabPatientsAttachments
                }
            };

            //set tabInvoices
            tabElement_tabInvoices = new TabElement()
            {
                TabPageElement = tabPage_tabInvoices,
                ElementListItem = new TabElement.TabElementListItem()
                {
                    PanelFilters = null,
                    PanelList = panel_tabInvoices_list,

                    PanelData = null,
                    PanelActions = panel_tabInvoices_actions,
                    PanelUpdates = null,

                    BindingSourceList = vPatientsInvoicesBindingSource,
                    GetDataSourceList = GetDataSourceList_tabInvoices,

                    BindingSourceEdit = invoicesBindingSource,
                    GetDataSourceEdit = GetDataSourceEdit_tabInvoices,
                    AfterSaveAction = null,

                    AddButton = null,
                    UpdateButton = null,
                    RemoveButton = null,
                    SaveButton = null,
                    CancelButton = null,

                    Add = null,
                    Update = null,
                    Remove = null
                }
            };

            //set tabEstimates
            tabElement_tabEstimates = new TabElement()
            {
                TabPageElement = tabPage_tabEstimates,
                ElementListItem = new TabElement.TabElementListItem()
                {
                    PanelFilters = null,
                    PanelList = panel_tabEstimates_list,

                    PanelData = null,
                    PanelActions = panel_tabEstimates_actions,
                    PanelUpdates = null,

                    BindingSourceList = vPatientsEstimatesBindingSource,
                    GetDataSourceList = GetDataSourceList_tabEstimates,

                    BindingSourceEdit = estimatesBindingSource,
                    GetDataSourceEdit = GetDataSourceEdit_tabEstimates,
                    AfterSaveAction = null,

                    AddButton = null,
                    UpdateButton = null,
                    RemoveButton = null,
                    SaveButton = null,
                    CancelButton = null,

                    Add = null,
                    Update = null,
                    Remove = null
                }
            };

            //set tabPatientsNotes
            tabElement_tabPatientsNotes = new TabElement()
            {
                TabPageElement = tabPage_tabPatientsNotes,
                ElementListItem = new TabElement.TabElementListItem()
                {
                    PanelFilters = null,
                    PanelList = panel_tabPatientsNotes_list,

                    PanelData = panel_tabPatientsNotes_data,
                    PanelActions = panel_tabPatientsNotes_actions,
                    PanelUpdates = panel_tabPatientsNotes_updates,

                    BindingSourceList = vPatientsNotesBindingSource,
                    GetDataSourceList = GetDataSourceList_tabPatientsNotes,

                    BindingSourceEdit = patientsnotesBindingSource,
                    GetDataSourceEdit = GetDataSourceEdit_tabPatientsNotes,
                    AfterSaveAction = AfterSaveAction_tabPatientsNotes,

                    AddButton = button_tabPatientsNotes_new,
                    IsAddButtonDefaultClickEventAttached = false,
                    UpdateButton = button_tabPatientsNotes_edit,
                    RemoveButton = button_tabPatientsNotes_delete,
                    SaveButton = button_tabPatientsNotes_save,
                    CancelButton = button_tabPatientsNotes_cancel,

                    Add = Add_tabPatientsNotes,
                    Update = Update_tabPatientsNotes,
                    Remove = Remove_tabPatientsNotes
                }
            };

            //set tabPatients
            tabElement_tabPatients = new TabElement()
            {
                TabPageElement = tabPage_tabPatients,
                ElementTabs = new TabElement.TabElementTabs()
                {
                    PanelData = panel_tabPatients_data,

                    TabControlElement = tabControl_tabPatients,
                    TabElements = new List<TabElement>()
                    {
                        tabElement_tabPatients_tabPatients,
                        tabElement_tabPatients_tabPatientsContacts,
                        tabElement_tabPatients_tabPatientsAddresses,
                    }
                }
            };
            
            //set Elements
            TabElements.Add(tabElement_tabPatients);
            TabElements.Add(tabElement_tabPatientsMedicalrecords);
            TabElements.Add(tabElement_tabPatientsTreatments);
            TabElements.Add(tabElement_tabPayments);
            TabElements.Add(tabElement_tabAppointments);
            TabElements.Add(tabElement_tabPatientsAttachments);
            TabElements.Add(tabElement_tabInvoices);
            TabElements.Add(tabElement_tabEstimates);
            TabElements.Add(tabElement_tabPatientsNotes);
        }

        /// <summary>
        /// Loader
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormPatients_Load(object sender, EventArgs e)
        {
            PreloadView();

            ReloadView();

            advancedDataGridView_main.SortASC(advancedDataGridView_main.Columns[1]);
            advancedDataGridView_tabPatients_tabPatientsContacts_list.SortASC(advancedDataGridView_tabPatients_tabPatientsContacts_list.Columns[1]);
            advancedDataGridView_tabPatients_tabPatientsAddresses_list.SortASC(advancedDataGridView_tabPatients_tabPatientsAddresses_list.Columns[1]);
            advancedDataGridView_tabPatientsMedicalrecords_list.SortASC(advancedDataGridView_tabPatientsMedicalrecords_list.Columns[1]);
            advancedDataGridView_tabPatientsTreatments_list.SortDESC(advancedDataGridView_tabPatientsTreatments_list.Columns[1]);
            advancedDataGridView_tabPatientsTreatments_list.DisableFilterAndSort(advancedDataGridView_tabPatientsTreatments_list.Columns["toothsDataGridViewTextBoxColumn"]);
            advancedDataGridView_tabAppointments_list.SortDESC(advancedDataGridView_tabAppointments_list.Columns[1]);
            advancedDataGridView_tabPatientsAttachments_list.SortASC(advancedDataGridView_tabPatientsAttachments_list.Columns[1]);
            advancedDataGridView_tabInvoices_list.SortASC(advancedDataGridView_tabInvoices_list.Columns[1]);
            advancedDataGridView_tabEstimates_list.SortASC(advancedDataGridView_tabEstimates_list.Columns[1]);
            advancedDataGridView_tabPatientsNotes_list.SortASC(advancedDataGridView_tabPatientsNotes_list.Columns[1]);
        }

        /// <summary>
        /// Preload View
        /// </summary>
        private void PreloadView()
        {
            //load filter doctors
            comboBox_filterArchived.Items.Clear();
            comboBox_filterArchived.Items.Add(new DGUIGHFUtilsUI.DGComboBoxItem(FilterShow.NotArchived.ToString(), "Not Archived"));
            comboBox_filterArchived.Items.Add(new DGUIGHFUtilsUI.DGComboBoxItem(FilterShow.Archived.ToString(), "Archived"));
            comboBox_filterArchived.Items.Add(new DGUIGHFUtilsUI.DGComboBoxItem(FilterShow.All.ToString(), "All"));
            comboBox_filterArchived.SelectedIndex = 0;

            //load prices lists
            treatmentspriceslists_idComboBox.DataSource = _dentnedModel.TreatmentsPricesLists.List().OrderBy(r => r.treatmentspriceslists_name).ToList();
            treatmentspriceslists_idComboBox.DisplayMember = "treatmentspriceslists_name";
            treatmentspriceslists_idComboBox.ValueMember = "treatmentspriceslists_id";

            //load prices lists
            treatmentspriceslists_idComboBox.DataSource = _dentnedModel.TreatmentsPricesLists.List().OrderBy(r => r.treatmentspriceslists_name).ToList();
            treatmentspriceslists_idComboBox.DisplayMember = "treatmentspriceslists_name";
            treatmentspriceslists_idComboBox.ValueMember = "treatmentspriceslists_id";

            //load contacts types
            contactstypes_idComboBox.DataSource = _dentnedModel.ContactsTypes.List().OrderBy(r => r.contactstypes_name).ToList();
            contactstypes_idComboBox.DisplayMember = "contactstypes_name";
            contactstypes_idComboBox.ValueMember = "contactstypes_id";

            //load addresses types
            addressestypes_idComboBox.DataSource = _dentnedModel.AddressesTypes.List().OrderBy(r => r.addressestypes_name).ToList();
            addressestypes_idComboBox.DisplayMember = "addressestypes_name";
            addressestypes_idComboBox.ValueMember = "addressestypes_id";

            //local medicalrecords types
            medicalrecordstypes_idComboBox.DataSource = _dentnedModel.MedicalrecordsTypes.List().OrderBy(r => r.medicalrecordstypes_name).ToList();
            medicalrecordstypes_idComboBox.DisplayMember = "medicalrecordstypes_name";
            medicalrecordstypes_idComboBox.ValueMember = "medicalrecordstypes_id";

            //local patientsattachments types
            patientsattachmentstypes_idComboBox.DataSource = _dentnedModel.PatientsAttachmentsTypes.List().OrderBy(r => r.patientsattachmentstypes_name).ToList();
            patientsattachmentstypes_idComboBox.DisplayMember = "patientsattachmentstypes_name";
            patientsattachmentstypes_idComboBox.ValueMember = "patientsattachmentstypes_id";

            //local rooms
            rooms_idComboBox.DataSource = _dentnedModel.Rooms.List().OrderBy(r => r.rooms_name).ToList();
            rooms_idComboBox.DisplayMember = "rooms_name";
            rooms_idComboBox.ValueMember = "rooms_id";
            
            //local doctors
            doctors_idComboBox.DataSource = _dentnedModel.Doctors.List().Select(r => new { name = r.doctors_surname + " " + r.doctors_name, r.doctors_id}).OrderBy(r => r.name).ToList();
            doctors_idComboBox.DisplayMember = "name";
            doctors_idComboBox.ValueMember = "doctors_id";
            doctors_idComboBox1.DataSource = _dentnedModel.Doctors.List().Select(r => new { name = r.doctors_surname + " " + r.doctors_name, r.doctors_id }).OrderBy(r => r.name).ToList();
            doctors_idComboBox1.DisplayMember = "name";
            doctors_idComboBox1.ValueMember = "doctors_id";

            //local treatments
            treatments_idComboBox.DataSource = _dentnedModel.Treatments.List().Select(r => new { name = r.treatments_code + " - " + r.treatments_name, r.treatments_id }).OrderBy(r => r.name).ToList();
            treatments_idComboBox.DisplayMember = "name";
            treatments_idComboBox.ValueMember = "treatments_id";
        }

        /// <summary>
        /// Get main list DataSource
        /// </summary>
        /// <returns></returns>
        private object GetDataSource_main()
        {
            advancedDataGridView_tabPatients_tabPatientsContacts_list.CleanFilterAndSort();
            advancedDataGridView_tabPatients_tabPatientsAddresses_list.CleanFilterAndSort();
            advancedDataGridView_tabPatientsMedicalrecords_list.CleanFilterAndSort();
            advancedDataGridView_tabPatientsTreatments_list.CleanFilterAndSort();
            advancedDataGridView_tabAppointments_list.CleanFilterAndSort();
            advancedDataGridView_tabPatientsAttachments_list.CleanFilterAndSort();
            advancedDataGridView_tabInvoices_list.CleanFilterAndSort();
            advancedDataGridView_tabEstimates_list.CleanFilterAndSort();
            advancedDataGridView_tabPatientsNotes_list.CleanFilterAndSort();

            List<patients> patients = new List<patients>();
            if(comboBox_filterArchived.SelectedIndex != -1)
            {
                string filterShow = ((DGUIGHFUtilsUI.DGComboBoxItem)comboBox_filterArchived.SelectedItem).Id;
                if(filterShow == FilterShow.NotArchived.ToString())
                    patients = _dentnedModel.Patients.List(r => !r.patients_isarchived).ToList();
                else if(filterShow == FilterShow.Archived.ToString())
                    patients = _dentnedModel.Patients.List(r => r.patients_isarchived).ToList();
                else
                    patients = _dentnedModel.Patients.List().ToList();
            }
            else
                patients = _dentnedModel.Patients.List().ToList();

            IEnumerable<VPatients> vPatients =
                patients.Select(
                r => new VPatients
                {
                    patients_id = r.patients_id,
                    name = r.patients_surname + " " + r.patients_name,
                    isarchived = r.patients_isarchived
                }).ToList();

            return DGDataTableUtils.ToDataTable<VPatients>(vPatients);
        }

        /// <summary>
        /// Main Datagrid filter handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void advancedDataGridView_main_FilterStringChanged(object sender, EventArgs e)
        {
            vPatientsBindingSource.Filter = advancedDataGridView_main.FilterString;
        }

        /// <summary>
        /// Main Datagrid sort handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void advancedDataGridView_main_SortStringChanged(object sender, EventArgs e)
        {
            vPatientsBindingSource.Sort = advancedDataGridView_main.SortString;
        }

        /// <summary>
        /// Main filter changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox_filterArchived_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReloadView();
        }

        /// <summary>
        /// Main BindingSource changed handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void vPatientsBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (IsBindingSourceLoading)
                return;

            ResetPatientstreatmentsFiltert();
        }

        /// <summary>
        ///  Main BindingSource list changed handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void vPatientsBindingSource_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            countTextBox.Text = vPatientsBindingSource.Count.ToString();
        }


        #region various


        /// <summary>
        /// Build a random string of a given size
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        private static string BuildRandomString(int size)
        {
            Random r = new Random();
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < size; i++)
            {
                //26 letters in the alfabet, ascii + 65 for the capital letters
                builder.Append(Convert.ToChar(Convert.ToInt32(Math.Floor(26 * r.NextDouble() + 65))));
            }
            return builder.ToString();
        }

        /// <summary>
        /// Find a random filename that does not exists on a folder
        /// </summary>
        /// <param name="folder"></param>
        /// <param name="prefix"></param>
        /// <param name="extension"></param>
        /// <returns></returns>
        private static string FindRandomFileName(string folder, string prefix, string extension)
        {
            string filename = null;
            int tries = 0;
            do
            {
                filename = folder + "\\" + (!String.IsNullOrEmpty(prefix) ? prefix + "_" : "") + String.Format("{0:yyyyMMddHHmm}", DateTime.Now) + "-" + BuildRandomString(12) + "." + extension;
                tries++;
            } while (File.Exists(filename) || tries < 100);
            return filename;
        }

        /// <summary>
        /// Delete a file
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="displayerrors"></param>
        /// <returns></returns>
        private bool DeleteFile(string filename, bool displayerrors)
        {
            if (File.Exists(filename))
            {
                try
                {
                    if (_doSecureDelete)
                    {
                        ProcessStartInfo startInfo = new ProcessStartInfo();
                        startInfo.CreateNoWindow = true;
                        startInfo.UseShellExecute = false;
                        startInfo.FileName = SRMBinaryFileName;
                        startInfo.Arguments = "-r -s " + filename;
                        startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        Process exeProcess = Process.Start(startInfo);
                        exeProcess.WaitForExit();
                    }
                    else
                    {
                        File.Delete(filename);
                    }

                    patientsattachments_filenameTextBox.Text = "";
                }
                catch
                {
                    if (displayerrors)
                        MessageBox.Show("Error deleting file from folder.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Delete a folder
        /// </summary>
        /// <param name="foldername"></param>
        /// <param name="displayerrors"></param>
        /// <returns></returns>
        private bool DeleteFolder(string foldername, bool displayerrors)
        {
            if (Directory.Exists(foldername))
            {
                try
                {
                    if (_doSecureDelete)
                    {
                        ProcessStartInfo startInfo = new ProcessStartInfo();
                        startInfo.CreateNoWindow = true;
                        startInfo.UseShellExecute = false;
                        startInfo.FileName = SRMBinaryFileName;
                        startInfo.Arguments = "-r -s " + foldername;
                        startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        Process exeProcess = Process.Start(startInfo);
                        exeProcess.WaitForExit();
                    }
                    else
                    {
                        Directory.Delete(foldername, true);
                    }
                }
                catch
                {
                    if (displayerrors)
                        MessageBox.Show("Can not remove folder \"" + foldername + "\"", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }

        #endregion


        #region tabPatients_tabPatients

        /// <summary>
        /// Load the tab DataSource
        /// </summary>
        /// <returns></returns>
        private object GetDataSourceEdit_tabPatients()
        {
            return DGUIGHFData.LoadEntityFromCurrentBindingSource<patients, DentneDModel>(_dentnedModel.Patients, vPatientsBindingSource, new string[] { "patients_id" });
        }

        /// <summary>
        /// Do actions after Save
        /// </summary>
        /// <param name="item"></param>
        private void AfterSaveAction_tabPatients(object item)
        {
            DGUIGHFData.SetBindingSourcePosition<patients, DentneDModel>(_dentnedModel.Patients, item, vPatientsBindingSource);
        }

        /// <summary>
        /// Add an item
        /// </summary>
        /// <param name="item"></param>
        private void Add_tabPatients(object item)
        {
            if (patients_sexFRadioButton.Checked)
                ((patients)patientsBindingSource.Current).patients_sex = "F";
            else
                ((patients)patientsBindingSource.Current).patients_sex = "M";

            DGUIGHFData.Add<patients, DentneDModel>(_dentnedModel.Patients, item);
        }

        /// <summary>
        /// Update an item
        /// </summary>
        /// <param name="item"></param>
        private void Update_tabPatients(object item)
        {
            if (patients_sexFRadioButton.Checked)
                ((patients)patientsBindingSource.Current).patients_sex = "F";
            else
                ((patients)patientsBindingSource.Current).patients_sex = "M";

            DGUIGHFData.Update<patients, DentneDModel>(_dentnedModel.Patients, item);
        }

        /// <summary>
        /// Remove an item
        /// </summary>
        /// <param name="item"></param>
        private void Remove_tabPatients(object item)
        {
            patients patient = (patients)item;

            foreach(patientsattachments patientattachment in _dentnedModel.PatientsAttachments.List(r => r.patients_id == patient.patients_id))
            {
                if (!DeleteFile(_patientsAttachmentsdir + "\\" + patientattachment.patients_id + "\\" + patientattachment.patientsattachmentstypes_id + "\\" + patientsattachments_filenameTextBox.Text, true))
                    return;
            }

            if (!DeleteFolder(_patientsAttachmentsdir + "\\" + patient.patients_id, true))
                return;

            if (!DeleteFolder(_patientsDatadir + "\\" + patient.patients_id, true))
                return;
            
            DGUIGHFData.Remove<patients, DentneDModel>(false, _dentnedModel.Patients, item);
        }

        /// <summary>
        /// New tab button handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_tabPatients_tabPatients_new_Click(object sender, EventArgs e)
        {
            if (AddClick(tabElement_tabPatients_tabPatients))
            {
                ((patients)patientsBindingSource.Current).patients_birthdate = new DateTime(1970, 1, 1, 0, 0, 0);
                patients_sexMRadioButton.Checked = true;
                patientsBindingSource.ResetBindings(true);
            }
        }
        
        /// <summary>
        /// Price lists reset to default
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_tabPatients_tabPatients_priceslistsreset_Click(object sender, EventArgs e)
        {
            treatmentspriceslists_idComboBox.SelectedIndex = -1;
        }

        /// <summary>
        /// Data dir button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_tabPatients_tabPatients_datadir_Click(object sender, EventArgs e)
        {
            if (patientsBindingSource.Current != null)
            {
                if (!Directory.Exists(_patientsDatadir))
                {
                    try
                    {
                        Directory.CreateDirectory(_patientsDatadir);
                    }
                    catch
                    {
                        MessageBox.Show("Can not create folder \"" + _patientsDatadir + "\"", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                string patientsDatadir = _patientsDatadir + "\\" + ((patients)patientsBindingSource.Current).patients_id;
                if (!Directory.Exists(patientsDatadir))
                {
                    try
                    {
                        Directory.CreateDirectory(patientsDatadir);
                    }
                    catch
                    {
                        MessageBox.Show("Can not create folder \"" + patientsDatadir + "\"", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                Process.Start("explorer.exe", patientsDatadir);
            }
        }

        /// <summary>
        /// Tab DataSource current changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void patientsBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (IsBindingSourceLoading)
                return;

            if (patientsBindingSource.Current != null)
            {
                if (((patients)patientsBindingSource.Current).patients_sex == "F")
                    patients_sexFRadioButton.Checked = true;
                else
                    patients_sexMRadioButton.Checked = true;
            }
        }


        /// <summary>
        /// Combobox autocomplete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treatmentspriceslists_idComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            DGUIGHFUtilsUI.DGComboBoxAutoComplete.OnKeyPress((ComboBox)sender, e);
        }

        #endregion


        #region tabPatients_tabPatientsContacts

        /// <summary>
        /// Get tab list DataSource
        /// </summary>
        /// <returns></returns>
        private object GetDataSourceList_tabPatients_tabPatientsContacts()
        {
            object ret = null;

            int patients_id = -1;
            if (vPatientsBindingSource.Current != null)
            {
                patients_id = (((DataRowView)vPatientsBindingSource.Current).Row).Field<int>("patients_id");
            }

            IEnumerable<VPatientsContacts> vPatientsContacts =
            _dentnedModel.PatientsContacts.List(r => r.patients_id == patients_id).Select(
            r => new VPatientsContacts
            {
                patientscontacts_id = r.patientscontacts_id,
                contactstype = _dentnedModel.ContactsTypes.Find(r.contactstypes_id).contactstypes_name,
                contact = (r.patientscontacts_value.Length > MaxRowValueLength ? r.patientscontacts_value.Substring(0, MaxRowValueLength) + "..." : r.patientscontacts_value)
            }).ToList();

            ret = DGDataTableUtils.ToDataTable<VPatientsContacts>(vPatientsContacts);

            return ret;
        }

        /// <summary>
        /// Tab Datagrid filter handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void advancedDataGridView_tabPatients_tabPatientsContacts_list_FilterStringChanged(object sender, EventArgs e)
        {
            vPatientsContactsBindingSource.Filter = advancedDataGridView_tabPatients_tabPatientsContacts_list.FilterString;
        }

        /// <summary>
        /// Tab Datagrid sort handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void advancedDataGridView_tabPatients_tabPatientsContacts_list_SortStringChanged(object sender, EventArgs e)
        {
            vPatientsContactsBindingSource.Sort = advancedDataGridView_tabPatients_tabPatientsContacts_list.SortString;
        }

        /// <summary>
        /// Load the tab DataSource
        /// </summary>
        /// <returns></returns>
        private object GetDataSourceEdit_tabPatients_tabPatientsContacts()
        {
            return DGUIGHFData.LoadEntityFromCurrentBindingSource<patientscontacts, DentneDModel>(_dentnedModel.PatientsContacts, vPatientsContactsBindingSource, new string[] { "patientscontacts_id" });
        }

        /// <summary>
        /// Do actions after Save
        /// </summary>
        /// <param name="item"></param>
        private void AfterSaveAction_tabPatients_tabPatientsContacts(object item)
        {
            DGUIGHFData.SetBindingSourcePosition<patientscontacts, DentneDModel>(_dentnedModel.PatientsContacts, item, vPatientsContactsBindingSource);
        }

        /// <summary>
        /// Add an item
        /// </summary>
        /// <param name="item"></param>
        private void Add_tabPatients_tabPatientsContacts(object item)
        {
            DGUIGHFData.Add<patientscontacts, DentneDModel>(_dentnedModel.PatientsContacts, item);
        }

        /// <summary>
        /// Update an item
        /// </summary>
        /// <param name="item"></param>
        private void Update_tabPatients_tabPatientsContacts(object item)
        {
            DGUIGHFData.Update<patientscontacts, DentneDModel>(_dentnedModel.PatientsContacts, item);
        }

        /// <summary>
        /// Remove an item
        /// </summary>
        /// <param name="item"></param>
        private void Remove_tabPatients_tabPatientsContacts(object item)
        {
            DGUIGHFData.Remove<patientscontacts, DentneDModel>(_dentnedModel.PatientsContacts, item);
        }

        /// <summary>
        /// New tab button handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_tabPatients_tabPatientsContacts_new_Click(object sender, EventArgs e)
        {
            if (vPatientsBindingSource.Current != null)
            {
                if (AddClick(tabElement_tabPatients_tabPatientsContacts))
                {
                    ((patientscontacts)patientscontactsBindingSource.Current).patients_id = (((DataRowView)vPatientsBindingSource.Current).Row).Field<int>("patients_id");
                    patientscontactsBindingSource.ResetBindings(true);
                }
            }
        }

        /// <summary>
        /// Combobox autocomplete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contactstypes_idComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            DGUIGHFUtilsUI.DGComboBoxAutoComplete.OnKeyPress((ComboBox)sender, e);
        }

        #endregion


        #region tabPatients_tabPatientsAddresses

        /// <summary>
        /// Get tab list DataSource
        /// </summary>
        /// <returns></returns>
        private object GetDataSourceList_tabPatients_tabPatientsAddresses()
        {
            object ret = null;

            int patients_id = -1;
            if (vPatientsBindingSource.Current != null)
            {
                patients_id = (((DataRowView)vPatientsBindingSource.Current).Row).Field<int>("patients_id");
            }

            IEnumerable<VPatientsAddresses> vPatientsAddresses =
            _dentnedModel.PatientsAddresses.List(r => r.patients_id == patients_id).Select(
            r => new VPatientsAddresses
            {
                patientsaddresses_id = r.patientsaddresses_id,
                addresstype = _dentnedModel.AddressesTypes.Find(r.addressestypes_id).addressestypes_name,
                address = ((r.patientsaddresses_city + " " + r.patientsaddresses_street).Length > MaxRowValueLength ? (r.patientsaddresses_city + " " + r.patientsaddresses_street).Substring(0, MaxRowValueLength) + "..." : (r.patientsaddresses_city + " " + r.patientsaddresses_street))
            }).ToList();

            ret = DGDataTableUtils.ToDataTable<VPatientsAddresses>(vPatientsAddresses);

            return ret;
        }

        /// <summary>
        /// Tab Datagrid filter handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void advancedDataGridView_tabPatients_tabPatientsAddresses_list_FilterStringChanged(object sender, EventArgs e)
        {
            vPatientsAddressesBindingSource.Filter = advancedDataGridView_tabPatients_tabPatientsAddresses_list.FilterString;
        }

        /// <summary>
        /// Tab Datagrid sort handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void advancedDataGridView_tabPatients_tabPatientsAddresses_list_SortStringChanged(object sender, EventArgs e)
        {
            vPatientsAddressesBindingSource.Sort = advancedDataGridView_tabPatients_tabPatientsAddresses_list.SortString;
        }

        /// <summary>
        /// Load the tab DataSource
        /// </summary>
        /// <returns></returns>
        private object GetDataSourceEdit_tabPatients_tabPatientsAddresses()
        {
            return DGUIGHFData.LoadEntityFromCurrentBindingSource<patientsaddresses, DentneDModel>(_dentnedModel.PatientsAddresses, vPatientsAddressesBindingSource, new string[] { "patientsaddresses_id" });
        }

        /// <summary>
        /// Do actions after Save
        /// </summary>
        /// <param name="item"></param>
        private void AfterSaveAction_tabPatients_tabPatientsAddresses(object item)
        {
            DGUIGHFData.SetBindingSourcePosition<patientsaddresses, DentneDModel>(_dentnedModel.PatientsAddresses, item, vPatientsAddressesBindingSource);
        }

        /// <summary>
        /// Add an item
        /// </summary>
        /// <param name="item"></param>
        private void Add_tabPatients_tabPatientsAddresses(object item)
        {
            DGUIGHFData.Add<patientsaddresses, DentneDModel>(_dentnedModel.PatientsAddresses, item);
        }

        /// <summary>
        /// Update an item
        /// </summary>
        /// <param name="item"></param>
        private void Update_tabPatients_tabPatientsAddresses(object item)
        {
            DGUIGHFData.Update<patientsaddresses, DentneDModel>(_dentnedModel.PatientsAddresses, item);
        }

        /// <summary>
        /// Remove an item
        /// </summary>
        /// <param name="item"></param>
        private void Remove_tabPatients_tabPatientsAddresses(object item)
        {
            DGUIGHFData.Remove<patientsaddresses, DentneDModel>(_dentnedModel.PatientsAddresses, item);
        }

        /// <summary>
        /// New tab button handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_tabPatients_tabPatientsAddresses_new_Click(object sender, EventArgs e)
        {
            if (vPatientsBindingSource.Current != null)
            {
                if (AddClick(tabElement_tabPatients_tabPatientsAddresses))
                {
                    ((patientsaddresses)patientsaddressesBindingSource.Current).patients_id = (((DataRowView)vPatientsBindingSource.Current).Row).Field<int>("patients_id");
                    patientsaddressesBindingSource.ResetBindings(true);
                }
            }
        }

        /// <summary>
        /// Combobox autocomplete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addressestypes_idComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            DGUIGHFUtilsUI.DGComboBoxAutoComplete.OnKeyPress((ComboBox)sender, e);
        }

        #endregion


        #region tabPatientsMedicalrecords

        /// <summary>
        /// Get tab list DataSource
        /// </summary>
        /// <returns></returns>
        private object GetDataSourceList_tabPatientsMedicalrecords()
        {
            object ret = null;

            int patients_id = -1;
            if (vPatientsBindingSource.Current != null)
            {
                patients_id = (((DataRowView)vPatientsBindingSource.Current).Row).Field<int>("patients_id");
            }

            IEnumerable<VPatientsMedicalrecords> vPatientsMedicalrecords =
            _dentnedModel.PatientsMedicalrecords.List(r => r.patients_id == patients_id).Select(
            r => new VPatientsMedicalrecords
            {
                patientsmedicalrecords_id = r.patientsmedicalrecords_id,
                medicalrecordstype = _dentnedModel.MedicalrecordsTypes.Find(r.medicalrecordstypes_id).medicalrecordstypes_name,
                value = (r.patientsmedicalrecords_value != null ? (r.patientsmedicalrecords_value.Length > MaxRowValueLength ? r.patientsmedicalrecords_value.Substring(0, MaxRowValueLength) + "..." : r.patientsmedicalrecords_value) : "")
            }).ToList();

            ret = DGDataTableUtils.ToDataTable<VPatientsMedicalrecords>(vPatientsMedicalrecords);

            return ret;
        }

        /// <summary>
        /// Tab Datagrid filter handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void advancedDataGridView_tabPatientsMedicalrecords_list_FilterStringChanged(object sender, EventArgs e)
        {
            vPatientsMedicalrecordsBindingSource.Filter = advancedDataGridView_tabPatientsMedicalrecords_list.FilterString;
        }

        /// <summary>
        /// Tab Datagrid sort handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void advancedDataGridView_tabPatientsMedicalrecords_list_SortStringChanged(object sender, EventArgs e)
        {
            vPatientsMedicalrecordsBindingSource.Sort = advancedDataGridView_tabPatientsMedicalrecords_list.SortString;
        }

        /// <summary>
        /// Load the tab DataSource
        /// </summary>
        /// <returns></returns>
        private object GetDataSourceEdit_tabPatientsMedicalrecords()
        {
            return DGUIGHFData.LoadEntityFromCurrentBindingSource<patientsmedicalrecords, DentneDModel>(_dentnedModel.PatientsMedicalrecords, vPatientsMedicalrecordsBindingSource, new string[] { "patientsmedicalrecords_id" });
        }

        /// <summary>
        /// Do actions after Save
        /// </summary>
        /// <param name="item"></param>
        private void AfterSaveAction_tabPatientsMedicalrecords(object item)
        {
            DGUIGHFData.SetBindingSourcePosition<patientsmedicalrecords, DentneDModel>(_dentnedModel.PatientsMedicalrecords, item, vPatientsMedicalrecordsBindingSource);
        }

        /// <summary>
        /// Add an item
        /// </summary>
        /// <param name="item"></param>
        private void Add_tabPatientsMedicalrecords(object item)
        {
            DGUIGHFData.Add<patientsmedicalrecords, DentneDModel>(_dentnedModel.PatientsMedicalrecords, item);
        }

        /// <summary>
        /// Update an item
        /// </summary>
        /// <param name="item"></param>
        private void Update_tabPatientsMedicalrecords(object item)
        {
            DGUIGHFData.Update<patientsmedicalrecords, DentneDModel>(_dentnedModel.PatientsMedicalrecords, item);
        }

        /// <summary>
        /// Remove an item
        /// </summary>
        /// <param name="item"></param>
        private void Remove_tabPatientsMedicalrecords(object item)
        {
            DGUIGHFData.Remove<patientsmedicalrecords, DentneDModel>(_dentnedModel.PatientsMedicalrecords, item);
        }

        /// <summary>
        /// New tab button handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_tabPatientsMedicalrecords_new_Click(object sender, EventArgs e)
        {
            if (vPatientsBindingSource.Current != null)
            {
                if (AddClick(tabElement_tabPatientsMedicalrecords))
                {
                    ((patientsmedicalrecords)patientsmedicalrecordsBindingSource.Current).patients_id = (((DataRowView)vPatientsBindingSource.Current).Row).Field<int>("patients_id");
                    patientsmedicalrecordsBindingSource.ResetBindings(true);
                }
            }
        }

        /// <summary>
        /// Combobox autocomplete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void medicalrecordstypes_idComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            DGUIGHFUtilsUI.DGComboBoxAutoComplete.OnKeyPress((ComboBox)sender, e);
        }

        #endregion


        #region tabPatientsTreatments

        /// <summary>
        /// Get tab list DataSource
        /// </summary>
        /// <returns></returns>
        private object GetDataSourceList_tabPatientsTreatments()
        {
            object ret = null;

            int patients_id = -1;
            if (vPatientsBindingSource.Current != null)
            {
                patients_id = (((DataRowView)vPatientsBindingSource.Current).Row).Field<int>("patients_id");
            }

            //set predicate
            Expression<Func<patientstreatments, bool>> predicate = DGPredicateBuilder.True<patientstreatments>();
            Expression<Func<patientstreatments, bool>> predicateor = DGPredicateBuilder.False<patientstreatments>();
            predicate = predicate.And(r => r.patients_id == patients_id);
            if(!patientstreatments_filtertanyCheckBox.Checked)
            {
                if (
                    patientstreatments_filtert11CheckBox.Checked &&
                    patientstreatments_filtert12CheckBox.Checked &&
                    patientstreatments_filtert13CheckBox.Checked &&
                    patientstreatments_filtert14CheckBox.Checked &&
                    patientstreatments_filtert15CheckBox.Checked &&
                    patientstreatments_filtert16CheckBox.Checked &&
                    patientstreatments_filtert17CheckBox.Checked &&
                    patientstreatments_filtert18CheckBox.Checked &&
                    patientstreatments_filtert21CheckBox.Checked &&
                    patientstreatments_filtert22CheckBox.Checked &&
                    patientstreatments_filtert23CheckBox.Checked &&
                    patientstreatments_filtert24CheckBox.Checked &&
                    patientstreatments_filtert25CheckBox.Checked &&
                    patientstreatments_filtert26CheckBox.Checked &&
                    patientstreatments_filtert27CheckBox.Checked &&
                    patientstreatments_filtert28CheckBox.Checked &&
                    patientstreatments_filtert31CheckBox.Checked &&
                    patientstreatments_filtert32CheckBox.Checked &&
                    patientstreatments_filtert33CheckBox.Checked &&
                    patientstreatments_filtert34CheckBox.Checked &&
                    patientstreatments_filtert35CheckBox.Checked &&
                    patientstreatments_filtert36CheckBox.Checked &&
                    patientstreatments_filtert37CheckBox.Checked &&
                    patientstreatments_filtert38CheckBox.Checked &&
                    patientstreatments_filtert41CheckBox.Checked &&
                    patientstreatments_filtert42CheckBox.Checked &&
                    patientstreatments_filtert43CheckBox.Checked &&
                    patientstreatments_filtert44CheckBox.Checked &&
                    patientstreatments_filtert45CheckBox.Checked &&
                    patientstreatments_filtert46CheckBox.Checked &&
                    patientstreatments_filtert47CheckBox.Checked &&
                    patientstreatments_filtert48CheckBox.Checked)
                    predicate = predicate.And(r =>
                        r.patientstreatments_t11 &&
                        r.patientstreatments_t12 &&
                        r.patientstreatments_t13 &&
                        r.patientstreatments_t14 &&
                        r.patientstreatments_t15 &&
                        r.patientstreatments_t16 &&
                        r.patientstreatments_t17 &&
                        r.patientstreatments_t18 &&
                        r.patientstreatments_t21 &&
                        r.patientstreatments_t22 &&
                        r.patientstreatments_t23 &&
                        r.patientstreatments_t24 &&
                        r.patientstreatments_t25 &&
                        r.patientstreatments_t26 &&
                        r.patientstreatments_t27 &&
                        r.patientstreatments_t28 &&
                        r.patientstreatments_t31 &&
                        r.patientstreatments_t32 &&
                        r.patientstreatments_t33 &&
                        r.patientstreatments_t34 &&
                        r.patientstreatments_t35 &&
                        r.patientstreatments_t36 &&
                        r.patientstreatments_t37 &&
                        r.patientstreatments_t38 &&
                        r.patientstreatments_t41 &&
                        r.patientstreatments_t42 &&
                        r.patientstreatments_t43 &&
                        r.patientstreatments_t44 &&
                        r.patientstreatments_t45 &&
                        r.patientstreatments_t46 &&
                        r.patientstreatments_t47 &&
                        r.patientstreatments_t48);
                else if (
                    patientstreatments_filtert11CheckBox.Checked &&
                    patientstreatments_filtert12CheckBox.Checked &&
                    patientstreatments_filtert13CheckBox.Checked &&
                    patientstreatments_filtert14CheckBox.Checked &&
                    patientstreatments_filtert15CheckBox.Checked &&
                    patientstreatments_filtert16CheckBox.Checked &&
                    patientstreatments_filtert17CheckBox.Checked &&
                    patientstreatments_filtert18CheckBox.Checked &&
                    patientstreatments_filtert21CheckBox.Checked &&
                    patientstreatments_filtert22CheckBox.Checked &&
                    patientstreatments_filtert23CheckBox.Checked &&
                    patientstreatments_filtert24CheckBox.Checked &&
                    patientstreatments_filtert25CheckBox.Checked &&
                    patientstreatments_filtert26CheckBox.Checked &&
                    patientstreatments_filtert27CheckBox.Checked &&
                    patientstreatments_filtert28CheckBox.Checked &&
                    !patientstreatments_filtert31CheckBox.Checked &&
                    !patientstreatments_filtert32CheckBox.Checked &&
                    !patientstreatments_filtert33CheckBox.Checked &&
                    !patientstreatments_filtert34CheckBox.Checked &&
                    !patientstreatments_filtert35CheckBox.Checked &&
                    !patientstreatments_filtert36CheckBox.Checked &&
                    !patientstreatments_filtert37CheckBox.Checked &&
                    !patientstreatments_filtert38CheckBox.Checked &&
                    !patientstreatments_filtert41CheckBox.Checked &&
                    !patientstreatments_filtert42CheckBox.Checked &&
                    !patientstreatments_filtert43CheckBox.Checked &&
                    !patientstreatments_filtert44CheckBox.Checked &&
                    !patientstreatments_filtert45CheckBox.Checked &&
                    !patientstreatments_filtert46CheckBox.Checked &&
                    !patientstreatments_filtert47CheckBox.Checked &&
                    !patientstreatments_filtert48CheckBox.Checked)
                    predicate = predicate.And(r =>
                        r.patientstreatments_t11 &&
                        r.patientstreatments_t12 &&
                        r.patientstreatments_t13 &&
                        r.patientstreatments_t14 &&
                        r.patientstreatments_t15 &&
                        r.patientstreatments_t16 &&
                        r.patientstreatments_t17 &&
                        r.patientstreatments_t18 &&
                        r.patientstreatments_t21 &&
                        r.patientstreatments_t22 &&
                        r.patientstreatments_t23 &&
                        r.patientstreatments_t24 &&
                        r.patientstreatments_t25 &&
                        r.patientstreatments_t26 &&
                        r.patientstreatments_t27 &&
                        r.patientstreatments_t28 &&
                        !r.patientstreatments_t31 &&
                        !r.patientstreatments_t32 &&
                        !r.patientstreatments_t33 &&
                        !r.patientstreatments_t34 &&
                        !r.patientstreatments_t35 &&
                        !r.patientstreatments_t36 &&
                        !r.patientstreatments_t37 &&
                        !r.patientstreatments_t38 &&
                        !r.patientstreatments_t41 &&
                        !r.patientstreatments_t42 &&
                        !r.patientstreatments_t43 &&
                        !r.patientstreatments_t44 &&
                        !r.patientstreatments_t45 &&
                        !r.patientstreatments_t46 &&
                        !r.patientstreatments_t47 &&
                        !r.patientstreatments_t48);
                else if (
                    !patientstreatments_filtert11CheckBox.Checked &&
                    !patientstreatments_filtert12CheckBox.Checked &&
                    !patientstreatments_filtert13CheckBox.Checked &&
                    !patientstreatments_filtert14CheckBox.Checked &&
                    !patientstreatments_filtert15CheckBox.Checked &&
                    !patientstreatments_filtert16CheckBox.Checked &&
                    !patientstreatments_filtert17CheckBox.Checked &&
                    !patientstreatments_filtert18CheckBox.Checked &&
                    !patientstreatments_filtert21CheckBox.Checked &&
                    !patientstreatments_filtert22CheckBox.Checked &&
                    !patientstreatments_filtert23CheckBox.Checked &&
                    !patientstreatments_filtert24CheckBox.Checked &&
                    !patientstreatments_filtert25CheckBox.Checked &&
                    !patientstreatments_filtert26CheckBox.Checked &&
                    !patientstreatments_filtert27CheckBox.Checked &&
                    !patientstreatments_filtert28CheckBox.Checked &&
                    patientstreatments_filtert31CheckBox.Checked &&
                    patientstreatments_filtert32CheckBox.Checked &&
                    patientstreatments_filtert33CheckBox.Checked &&
                    patientstreatments_filtert34CheckBox.Checked &&
                    patientstreatments_filtert35CheckBox.Checked &&
                    patientstreatments_filtert36CheckBox.Checked &&
                    patientstreatments_filtert37CheckBox.Checked &&
                    patientstreatments_filtert38CheckBox.Checked &&
                    patientstreatments_filtert41CheckBox.Checked &&
                    patientstreatments_filtert42CheckBox.Checked &&
                    patientstreatments_filtert43CheckBox.Checked &&
                    patientstreatments_filtert44CheckBox.Checked &&
                    patientstreatments_filtert45CheckBox.Checked &&
                    patientstreatments_filtert46CheckBox.Checked &&
                    patientstreatments_filtert47CheckBox.Checked &&
                    patientstreatments_filtert48CheckBox.Checked)
                    predicate = predicate.And(r =>
                        !r.patientstreatments_t11 &&
                        !r.patientstreatments_t12 &&
                        !r.patientstreatments_t13 &&
                        !r.patientstreatments_t14 &&
                        !r.patientstreatments_t15 &&
                        !r.patientstreatments_t16 &&
                        !r.patientstreatments_t17 &&
                        !r.patientstreatments_t18 &&
                        !r.patientstreatments_t21 &&
                        !r.patientstreatments_t22 &&
                        !r.patientstreatments_t23 &&
                        !r.patientstreatments_t24 &&
                        !r.patientstreatments_t25 &&
                        !r.patientstreatments_t26 &&
                        !r.patientstreatments_t27 &&
                        !r.patientstreatments_t28 &&
                        r.patientstreatments_t31 &&
                        r.patientstreatments_t32 &&
                        r.patientstreatments_t33 &&
                        r.patientstreatments_t34 &&
                        r.patientstreatments_t35 &&
                        r.patientstreatments_t36 &&
                        r.patientstreatments_t37 &&
                        r.patientstreatments_t38 &&
                        r.patientstreatments_t41 &&
                        r.patientstreatments_t42 &&
                        r.patientstreatments_t43 &&
                        r.patientstreatments_t44 &&
                        r.patientstreatments_t45 &&
                        r.patientstreatments_t46 &&
                        r.patientstreatments_t47 &&
                        r.patientstreatments_t48);
                else if (
                    !patientstreatments_filtert11CheckBox.Checked &&
                    !patientstreatments_filtert12CheckBox.Checked &&
                    !patientstreatments_filtert13CheckBox.Checked &&
                    !patientstreatments_filtert14CheckBox.Checked &&
                    !patientstreatments_filtert15CheckBox.Checked &&
                    !patientstreatments_filtert16CheckBox.Checked &&
                    !patientstreatments_filtert17CheckBox.Checked &&
                    !patientstreatments_filtert18CheckBox.Checked &&
                    !patientstreatments_filtert21CheckBox.Checked &&
                    !patientstreatments_filtert22CheckBox.Checked &&
                    !patientstreatments_filtert23CheckBox.Checked &&
                    !patientstreatments_filtert24CheckBox.Checked &&
                    !patientstreatments_filtert25CheckBox.Checked &&
                    !patientstreatments_filtert26CheckBox.Checked &&
                    !patientstreatments_filtert27CheckBox.Checked &&
                    !patientstreatments_filtert28CheckBox.Checked &&
                    !patientstreatments_filtert31CheckBox.Checked &&
                    !patientstreatments_filtert32CheckBox.Checked &&
                    !patientstreatments_filtert33CheckBox.Checked &&
                    !patientstreatments_filtert34CheckBox.Checked &&
                    !patientstreatments_filtert35CheckBox.Checked &&
                    !patientstreatments_filtert36CheckBox.Checked &&
                    !patientstreatments_filtert37CheckBox.Checked &&
                    !patientstreatments_filtert38CheckBox.Checked &&
                    !patientstreatments_filtert41CheckBox.Checked &&
                    !patientstreatments_filtert42CheckBox.Checked &&
                    !patientstreatments_filtert43CheckBox.Checked &&
                    !patientstreatments_filtert44CheckBox.Checked &&
                    !patientstreatments_filtert45CheckBox.Checked &&
                    !patientstreatments_filtert46CheckBox.Checked &&
                    !patientstreatments_filtert47CheckBox.Checked &&
                    !patientstreatments_filtert48CheckBox.Checked)
                    predicate = predicate.And(r =>
                        !r.patientstreatments_t11 &&
                        !r.patientstreatments_t12 &&
                        !r.patientstreatments_t13 &&
                        !r.patientstreatments_t14 &&
                        !r.patientstreatments_t15 &&
                        !r.patientstreatments_t16 &&
                        !r.patientstreatments_t17 &&
                        !r.patientstreatments_t18 &&
                        !r.patientstreatments_t21 &&
                        !r.patientstreatments_t22 &&
                        !r.patientstreatments_t23 &&
                        !r.patientstreatments_t24 &&
                        !r.patientstreatments_t25 &&
                        !r.patientstreatments_t26 &&
                        !r.patientstreatments_t27 &&
                        !r.patientstreatments_t28 &&
                        !r.patientstreatments_t31 &&
                        !r.patientstreatments_t32 &&
                        !r.patientstreatments_t33 &&
                        !r.patientstreatments_t34 &&
                        !r.patientstreatments_t35 &&
                        !r.patientstreatments_t36 &&
                        !r.patientstreatments_t37 &&
                        !r.patientstreatments_t38 &&
                        !r.patientstreatments_t41 &&
                        !r.patientstreatments_t42 &&
                        !r.patientstreatments_t43 &&
                        !r.patientstreatments_t44 &&
                        !r.patientstreatments_t45 &&
                        !r.patientstreatments_t46 &&
                        !r.patientstreatments_t47 &&
                        !r.patientstreatments_t48);
                else
                {
                    if (patientstreatments_filtert11CheckBox.Checked)
                        predicateor = predicateor.Or(r => r.patientstreatments_t11);
                    if (patientstreatments_filtert12CheckBox.Checked)
                        predicateor = predicateor.Or(r => r.patientstreatments_t12);
                    if (patientstreatments_filtert13CheckBox.Checked)
                        predicateor = predicateor.Or(r => r.patientstreatments_t13);
                    if (patientstreatments_filtert14CheckBox.Checked)
                        predicateor = predicateor.Or(r => r.patientstreatments_t14);
                    if (patientstreatments_filtert15CheckBox.Checked)
                        predicateor = predicateor.Or(r => r.patientstreatments_t15);
                    if (patientstreatments_filtert16CheckBox.Checked)
                        predicateor = predicateor.Or(r => r.patientstreatments_t16);
                    if (patientstreatments_filtert17CheckBox.Checked)
                        predicateor = predicateor.Or(r => r.patientstreatments_t17);
                    if (patientstreatments_filtert18CheckBox.Checked)
                        predicateor = predicateor.Or(r => r.patientstreatments_t18);
                    if (patientstreatments_filtert21CheckBox.Checked)
                        predicateor = predicateor.Or(r => r.patientstreatments_t21);
                    if (patientstreatments_filtert22CheckBox.Checked)
                        predicateor = predicateor.Or(r => r.patientstreatments_t22);
                    if (patientstreatments_filtert23CheckBox.Checked)
                        predicateor = predicateor.Or(r => r.patientstreatments_t23);
                    if (patientstreatments_filtert24CheckBox.Checked)
                        predicateor = predicateor.Or(r => r.patientstreatments_t24);
                    if (patientstreatments_filtert25CheckBox.Checked)
                        predicateor = predicateor.Or(r => r.patientstreatments_t25);
                    if (patientstreatments_filtert26CheckBox.Checked)
                        predicateor = predicateor.Or(r => r.patientstreatments_t26);
                    if (patientstreatments_filtert27CheckBox.Checked)
                        predicateor = predicateor.Or(r => r.patientstreatments_t27);
                    if (patientstreatments_filtert28CheckBox.Checked)
                        predicateor = predicateor.Or(r => r.patientstreatments_t28);
                    if (patientstreatments_filtert31CheckBox.Checked)
                        predicateor = predicateor.Or(r => r.patientstreatments_t31);
                    if (patientstreatments_filtert32CheckBox.Checked)
                        predicateor = predicateor.Or(r => r.patientstreatments_t32);
                    if (patientstreatments_filtert33CheckBox.Checked)
                        predicateor = predicateor.Or(r => r.patientstreatments_t33);
                    if (patientstreatments_filtert34CheckBox.Checked)
                        predicateor = predicateor.Or(r => r.patientstreatments_t34);
                    if (patientstreatments_filtert35CheckBox.Checked)
                        predicateor = predicateor.Or(r => r.patientstreatments_t35);
                    if (patientstreatments_filtert36CheckBox.Checked)
                        predicateor = predicateor.Or(r => r.patientstreatments_t36);
                    if (patientstreatments_filtert37CheckBox.Checked)
                        predicateor = predicateor.Or(r => r.patientstreatments_t37);
                    if (patientstreatments_filtert38CheckBox.Checked)
                        predicateor = predicateor.Or(r => r.patientstreatments_t38);
                    if (patientstreatments_filtert41CheckBox.Checked)
                        predicateor = predicateor.Or(r => r.patientstreatments_t41);
                    if (patientstreatments_filtert42CheckBox.Checked)
                        predicateor = predicateor.Or(r => r.patientstreatments_t42);
                    if (patientstreatments_filtert43CheckBox.Checked)
                        predicateor = predicateor.Or(r => r.patientstreatments_t43);
                    if (patientstreatments_filtert44CheckBox.Checked)
                        predicateor = predicateor.Or(r => r.patientstreatments_t44);
                    if (patientstreatments_filtert45CheckBox.Checked)
                        predicateor = predicateor.Or(r => r.patientstreatments_t45);
                    if (patientstreatments_filtert46CheckBox.Checked)
                        predicateor = predicateor.Or(r => r.patientstreatments_t46);
                    if (patientstreatments_filtert47CheckBox.Checked)
                        predicateor = predicateor.Or(r => r.patientstreatments_t47);
                    if (patientstreatments_filtert48CheckBox.Checked)
                        predicateor = predicateor.Or(r => r.patientstreatments_t48);
                    predicate = predicate.And(predicateor);
                }
            }

            //set the filter numbers
            SetPatientstreatmentsFiltert();

            IEnumerable<VPatientsTreatments> vPatientsTreatments =
            _dentnedModel.PatientsTreatments.List(predicate.Compile()).Select(
            r => new VPatientsTreatments
            {
                patientstreatments_id = r.patientstreatments_id,
                treatment = _dentnedModel.Treatments.Find(r.treatments_id).treatments_code,
                isfulfilled = (r.patientstreatments_fulfilldate != null ? true : false),
                ispayed = r.patientstreatments_ispayed,
                date = r.patientstreatments_creationdate,
                tooths = _dentnedModel.PatientsTreatments.GetTreatmentsToothsString(r)
            }).ToList();

            ret = DGDataTableUtils.ToDataTable<VPatientsTreatments>(vPatientsTreatments);

            return ret;
        }

        /// <summary>
        /// Tab Datagrid filter handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void advancedDataGridView_tabPatientsTreatments_list_FilterStringChanged(object sender, EventArgs e)
        {
            vPatientsTreatmentsBindingSource.Filter = advancedDataGridView_tabPatientsTreatments_list.FilterString;
        }

        /// <summary>
        /// Tab Datagrid sort handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void advancedDataGridView_tabPatientsTreatments_list_SortStringChanged(object sender, EventArgs e)
        {
            vPatientsTreatmentsBindingSource.Sort = advancedDataGridView_tabPatientsTreatments_list.SortString;
        }

        /// <summary>
        /// Load the tab DataSource
        /// </summary>
        /// <returns></returns>
        private object GetDataSourceEdit_tabPatientsTreatments()
        {
            return DGUIGHFData.LoadEntityFromCurrentBindingSource<patientstreatments, DentneDModel>(_dentnedModel.PatientsTreatments, vPatientsTreatmentsBindingSource, new string[] { "patientstreatments_id" });
        }

        /// <summary>
        /// Do actions after Save
        /// </summary>
        /// <param name="item"></param>
        private void AfterSaveAction_tabPatientsTreatments(object item)
        {
            DGUIGHFData.SetBindingSourcePosition<patientstreatments, DentneDModel>(_dentnedModel.PatientsTreatments, item, vPatientsTreatmentsBindingSource);
        }

        /// <summary>
        /// Add an item
        /// </summary>
        /// <param name="item"></param>
        private void Add_tabPatientsTreatments(object item)
        {
            SetCurrentpatientstreatmentsBindingSource();

            //unset lazy load for payments tab, to reload totals
            tabElement_tabPayments.IsLaziLoaded = false;

            DGUIGHFData.Add<patientstreatments, DentneDModel>(_dentnedModel.PatientsTreatments, item);
        }

        /// <summary>
        /// Update an item
        /// </summary>
        /// <param name="item"></param>
        private void Update_tabPatientsTreatments(object item)
        {
            SetCurrentpatientstreatmentsBindingSource();

            //unset lazy load for payments tab, to reload totals
            tabElement_tabPayments.IsLaziLoaded = false;

            DGUIGHFData.Update<patientstreatments, DentneDModel>(_dentnedModel.PatientsTreatments, item);
        }

        /// <summary>
        /// Remove an item
        /// </summary>
        /// <param name="item"></param>
        private void Remove_tabPatientsTreatments(object item)
        {
            //unset lazy load for payments tab, to reload totals
            tabElement_tabPayments.IsLaziLoaded = false;

            DGUIGHFData.Remove<patientstreatments, DentneDModel>(_dentnedModel.PatientsTreatments, item);
        }

        /// <summary>
        /// New tab button handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_tabPatientsTreatments_new_Click(object sender, EventArgs e)
        {
            if (vPatientsBindingSource.Current != null)
            {
                if (AddClick(tabElement_tabPatientsTreatments))
                {
                    ((patientstreatments)patientstreatmentsBindingSource.Current).patients_id = (((DataRowView)vPatientsBindingSource.Current).Row).Field<int>("patients_id");
                    ((patientstreatments)patientstreatmentsBindingSource.Current).patientstreatments_creationdate = DateTime.Now;
                    doctors doctor = _dentnedModel.Doctors.List().FirstOrDefault();
                    if (doctor != null)
                        ((patientstreatments)patientstreatmentsBindingSource.Current).doctors_id = doctor.doctors_id;
                    patientstreatmentsBindingSource.ResetBindings(true);

                    patientstreatments_tnoCheckBox.Checked = true;
                }
            }
        }

        /// <summary>
        /// Edii tab button handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_tabPatientsTreatments_edit_Click(object sender, EventArgs e)
        {
            if (vPatientsBindingSource.Current != null)
            {
                if (UpdateClick(tabElement_tabPatientsTreatments))
                {
                    doctors_idComboBox1.Enabled = false;
                    treatments_idComboBox.Enabled = false;
                }
            }
        }

        /// <summary>
        /// Set current treatment fulfilled
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_tabPatientsTreatments_setfulfilled_Click(object sender, EventArgs e)
        {
            int patientstreatments_id = -1;
            if (vPatientsTreatmentsBindingSource.Current != null)
            {
                patientstreatments_id = (((DataRowView)vPatientsTreatmentsBindingSource.Current).Row).Field<int>("patientstreatments_id");
            }

            if (patientstreatments_id != -1)
            {
                patientstreatments patientstreatment = _dentnedModel.PatientsTreatments.Find(patientstreatments_id);
                patientstreatment.patientstreatments_fulfilldate = DateTime.Now;
                _dentnedModel.PatientsTreatments.Update(patientstreatment);

                ReloadView();
            }
        }

        /// <summary>
        /// Set current treatment payed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_tabPatientsTreatments_setpayed_Click(object sender, EventArgs e)
        {
            int patientstreatments_id = -1;
            if (vPatientsTreatmentsBindingSource.Current != null)
            {
                patientstreatments_id = (((DataRowView)vPatientsTreatmentsBindingSource.Current).Row).Field<int>("patientstreatments_id");
            }

            if (patientstreatments_id != -1)
            {
                patientstreatments patientstreatment = _dentnedModel.PatientsTreatments.Find(patientstreatments_id);
                patientstreatment.patientstreatments_ispayed = true;
                _dentnedModel.PatientsTreatments.Update(patientstreatment);

                ReloadView();
            }
        }

        /// <summary>
        /// Patients treatments view BindingSource changed handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void vPatientsTreatmentsBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            int patientstreatments_id = -1;
            if (vPatientsTreatmentsBindingSource.Current != null)
            {
                patientstreatments_id = (((DataRowView)vPatientsTreatmentsBindingSource.Current).Row).Field<int>("patientstreatments_id");
            }

            IsBindingSourceLoading = true;

            patientstreatments_talCheckBox.Checked = false;
            patientstreatments_tnoCheckBox.Checked = false;
            patientstreatments_tupCheckBox.Checked = false;
            patientstreatments_tdwCheckBox.Checked = false;
            patientstreatments_expirationdateenabledCheckBox.Checked = false;
            patientstreatments_fulfilldateenabledCheckBox.Checked = false;
            patientstreatments_invoiceTextBox.Text = "";

            if (patientstreatments_id != -1)
            {
                invoiceslines invoiceline = _dentnedModel.InvoicesLines.List(r => r.patientstreatments_id == patientstreatments_id).FirstOrDefault();
                if (invoiceline != null)
                {
                    invoices invoice = _dentnedModel.Invoices.Find(invoiceline.invoices_id);
                    doctors doctors = null;
                    if(invoice.doctors_id != null)
                        doctors = _dentnedModel.Doctors.Find(invoice.doctors_id);
                    patientstreatments_invoiceTextBox.Text = invoice.invoices_number + "/" + invoice.invoices_date.Year + (doctors != null ? " " + doctors.doctors_surname + " " + doctors.doctors_name + " (" + invoice.invoices_id + ")" : " (" + invoice.invoices_id + ")");
                }

                patientstreatments patientstreatments = _dentnedModel.PatientsTreatments.Find(patientstreatments_id);
                patientstreatments_t11CheckBox.Checked = patientstreatments.patientstreatments_t11;
                patientstreatments_t12CheckBox.Checked = patientstreatments.patientstreatments_t12;
                patientstreatments_t13CheckBox.Checked = patientstreatments.patientstreatments_t13;
                patientstreatments_t14CheckBox.Checked = patientstreatments.patientstreatments_t14;
                patientstreatments_t15CheckBox.Checked = patientstreatments.patientstreatments_t15;
                patientstreatments_t16CheckBox.Checked = patientstreatments.patientstreatments_t16;
                patientstreatments_t17CheckBox.Checked = patientstreatments.patientstreatments_t17;
                patientstreatments_t18CheckBox.Checked = patientstreatments.patientstreatments_t18;
                patientstreatments_t21CheckBox.Checked = patientstreatments.patientstreatments_t21;
                patientstreatments_t22CheckBox.Checked = patientstreatments.patientstreatments_t22;
                patientstreatments_t23CheckBox.Checked = patientstreatments.patientstreatments_t23;
                patientstreatments_t24CheckBox.Checked = patientstreatments.patientstreatments_t24;
                patientstreatments_t25CheckBox.Checked = patientstreatments.patientstreatments_t25;
                patientstreatments_t26CheckBox.Checked = patientstreatments.patientstreatments_t26;
                patientstreatments_t27CheckBox.Checked = patientstreatments.patientstreatments_t27;
                patientstreatments_t28CheckBox.Checked = patientstreatments.patientstreatments_t28;
                patientstreatments_t31CheckBox.Checked = patientstreatments.patientstreatments_t31;
                patientstreatments_t32CheckBox.Checked = patientstreatments.patientstreatments_t32;
                patientstreatments_t33CheckBox.Checked = patientstreatments.patientstreatments_t33;
                patientstreatments_t34CheckBox.Checked = patientstreatments.patientstreatments_t34;
                patientstreatments_t35CheckBox.Checked = patientstreatments.patientstreatments_t35;
                patientstreatments_t36CheckBox.Checked = patientstreatments.patientstreatments_t36;
                patientstreatments_t37CheckBox.Checked = patientstreatments.patientstreatments_t37;
                patientstreatments_t38CheckBox.Checked = patientstreatments.patientstreatments_t38;
                patientstreatments_t41CheckBox.Checked = patientstreatments.patientstreatments_t41;
                patientstreatments_t42CheckBox.Checked = patientstreatments.patientstreatments_t42;
                patientstreatments_t43CheckBox.Checked = patientstreatments.patientstreatments_t43;
                patientstreatments_t44CheckBox.Checked = patientstreatments.patientstreatments_t44;
                patientstreatments_t45CheckBox.Checked = patientstreatments.patientstreatments_t45;
                patientstreatments_t46CheckBox.Checked = patientstreatments.patientstreatments_t46;
                patientstreatments_t47CheckBox.Checked = patientstreatments.patientstreatments_t47;
                patientstreatments_t48CheckBox.Checked = patientstreatments.patientstreatments_t48;
                if (patientstreatments.patientstreatments_expirationdate != null)
                    patientstreatments_expirationdateenabledCheckBox.Checked = true;
                if (patientstreatments.patientstreatments_fulfilldate != null)
                    patientstreatments_fulfilldateenabledCheckBox.Checked = true;
            }
            else
            {
                patientstreatments_t11CheckBox.Checked = false;
                patientstreatments_t12CheckBox.Checked = false;
                patientstreatments_t13CheckBox.Checked = false;
                patientstreatments_t14CheckBox.Checked = false;
                patientstreatments_t15CheckBox.Checked = false;
                patientstreatments_t16CheckBox.Checked = false;
                patientstreatments_t17CheckBox.Checked = false;
                patientstreatments_t18CheckBox.Checked = false;
                patientstreatments_t21CheckBox.Checked = false;
                patientstreatments_t22CheckBox.Checked = false;
                patientstreatments_t23CheckBox.Checked = false;
                patientstreatments_t24CheckBox.Checked = false;
                patientstreatments_t25CheckBox.Checked = false;
                patientstreatments_t26CheckBox.Checked = false;
                patientstreatments_t27CheckBox.Checked = false;
                patientstreatments_t28CheckBox.Checked = false;
                patientstreatments_t31CheckBox.Checked = false;
                patientstreatments_t32CheckBox.Checked = false;
                patientstreatments_t33CheckBox.Checked = false;
                patientstreatments_t34CheckBox.Checked = false;
                patientstreatments_t35CheckBox.Checked = false;
                patientstreatments_t36CheckBox.Checked = false;
                patientstreatments_t37CheckBox.Checked = false;
                patientstreatments_t38CheckBox.Checked = false;
                patientstreatments_t41CheckBox.Checked = false;
                patientstreatments_t42CheckBox.Checked = false;
                patientstreatments_t43CheckBox.Checked = false;
                patientstreatments_t44CheckBox.Checked = false;
                patientstreatments_t45CheckBox.Checked = false;
                patientstreatments_t46CheckBox.Checked = false;
                patientstreatments_t47CheckBox.Checked = false;
                patientstreatments_t48CheckBox.Checked = false;
            }

            IsBindingSourceLoading = false;

            patientstreatments_expirationdateenabledCheckBox_CheckedChanged(null, null);
            patientstreatments_fulfilldateenabledCheckBox_CheckedChanged(null, null);
        }
        
        /// <summary>
        /// Treatment combobox changed handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treatments_idComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsBindingSourceLoading)
                return;

            if (treatments_idComboBox.SelectedIndex != -1)
            {
                int patients_id = -1;
                if (vPatientsBindingSource.Current != null)
                {
                    patients_id = (((DataRowView)vPatientsBindingSource.Current).Row).Field<int>("patients_id");
                }

                if (patientstreatmentsBindingSource.Current != null &&
                    (tabElement_tabPatientsTreatments.CurrentEditingMode == EditingMode.C || tabElement_tabPatientsTreatments.CurrentEditingMode == EditingMode.U))
                {
                    treatments treatment = _dentnedModel.Treatments.Find(treatments_idComboBox.SelectedValue);
                    if (treatment != null)
                    {
                        string description = treatment.treatments_name;
                        decimal price = treatment.treatments_price;
                        byte expirationmonths = 0;
                        if (treatment.treatments_mexpiration != null)
                            expirationmonths = (byte)treatment.treatments_mexpiration;
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

                        if (expirationmonths != 0)
                        {
                            patientstreatments_expirationdateDateTimePicker.Value = ((patientstreatments)patientstreatmentsBindingSource.Current).patientstreatments_creationdate.AddMonths((int)expirationmonths);
                            patientstreatments_expirationdateenabledCheckBox.Checked = true;
                        }
                        else
                            patientstreatments_expirationdateenabledCheckBox.Checked = false;

                        patientstreatments_priceTextBox.Text = price.ToString();
                        patientstreatments_descriptionTextBox.Text = description;
                    }
                }
            }
        }

        /// <summary>
        /// Patients treatments expiration date enabler checked handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void patientstreatments_expirationdateenabledCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (IsBindingSourceLoading)
                return;

            if (patientstreatments_expirationdateenabledCheckBox.Checked)
                patientstreatments_expirationdateDateTimePicker.Visible = true;
            else
                patientstreatments_expirationdateDateTimePicker.Visible = false;
        }

        /// <summary>
        /// Patients treatments fulfill checked handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void patientstreatments_fulfilldateenabledCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (IsBindingSourceLoading)
                return;

            if (patientstreatments_fulfilldateenabledCheckBox.Checked)
                patientstreatments_fulfilldateDateTimePicker.Visible = true;
            else
                patientstreatments_fulfilldateDateTimePicker.Visible = false;
        }
        
        /// <summary>
        /// Set the current patient treatments before update the record
        /// </summary>
        private void SetCurrentpatientstreatmentsBindingSource()
        {
            if(patientstreatmentsBindingSource.Current != null)
            {
                ((patientstreatments)patientstreatmentsBindingSource.Current).patientstreatments_t11 = patientstreatments_t11CheckBox.Checked;
                ((patientstreatments)patientstreatmentsBindingSource.Current).patientstreatments_t12 = patientstreatments_t12CheckBox.Checked;
                ((patientstreatments)patientstreatmentsBindingSource.Current).patientstreatments_t13 = patientstreatments_t13CheckBox.Checked;
                ((patientstreatments)patientstreatmentsBindingSource.Current).patientstreatments_t14 = patientstreatments_t14CheckBox.Checked;
                ((patientstreatments)patientstreatmentsBindingSource.Current).patientstreatments_t15 = patientstreatments_t15CheckBox.Checked;
                ((patientstreatments)patientstreatmentsBindingSource.Current).patientstreatments_t16 = patientstreatments_t16CheckBox.Checked;
                ((patientstreatments)patientstreatmentsBindingSource.Current).patientstreatments_t17 = patientstreatments_t17CheckBox.Checked;
                ((patientstreatments)patientstreatmentsBindingSource.Current).patientstreatments_t18 = patientstreatments_t18CheckBox.Checked;
                ((patientstreatments)patientstreatmentsBindingSource.Current).patientstreatments_t21 = patientstreatments_t21CheckBox.Checked;
                ((patientstreatments)patientstreatmentsBindingSource.Current).patientstreatments_t22 = patientstreatments_t22CheckBox.Checked;
                ((patientstreatments)patientstreatmentsBindingSource.Current).patientstreatments_t23 = patientstreatments_t23CheckBox.Checked;
                ((patientstreatments)patientstreatmentsBindingSource.Current).patientstreatments_t24 = patientstreatments_t24CheckBox.Checked;
                ((patientstreatments)patientstreatmentsBindingSource.Current).patientstreatments_t25 = patientstreatments_t25CheckBox.Checked;
                ((patientstreatments)patientstreatmentsBindingSource.Current).patientstreatments_t26 = patientstreatments_t26CheckBox.Checked;
                ((patientstreatments)patientstreatmentsBindingSource.Current).patientstreatments_t27 = patientstreatments_t27CheckBox.Checked;
                ((patientstreatments)patientstreatmentsBindingSource.Current).patientstreatments_t28 = patientstreatments_t28CheckBox.Checked;
                ((patientstreatments)patientstreatmentsBindingSource.Current).patientstreatments_t31 = patientstreatments_t31CheckBox.Checked;
                ((patientstreatments)patientstreatmentsBindingSource.Current).patientstreatments_t32 = patientstreatments_t32CheckBox.Checked;
                ((patientstreatments)patientstreatmentsBindingSource.Current).patientstreatments_t33 = patientstreatments_t33CheckBox.Checked;
                ((patientstreatments)patientstreatmentsBindingSource.Current).patientstreatments_t34 = patientstreatments_t34CheckBox.Checked;
                ((patientstreatments)patientstreatmentsBindingSource.Current).patientstreatments_t35 = patientstreatments_t35CheckBox.Checked;
                ((patientstreatments)patientstreatmentsBindingSource.Current).patientstreatments_t36 = patientstreatments_t36CheckBox.Checked;
                ((patientstreatments)patientstreatmentsBindingSource.Current).patientstreatments_t37 = patientstreatments_t37CheckBox.Checked;
                ((patientstreatments)patientstreatmentsBindingSource.Current).patientstreatments_t38 = patientstreatments_t38CheckBox.Checked;
                ((patientstreatments)patientstreatmentsBindingSource.Current).patientstreatments_t41 = patientstreatments_t41CheckBox.Checked;
                ((patientstreatments)patientstreatmentsBindingSource.Current).patientstreatments_t42 = patientstreatments_t42CheckBox.Checked;
                ((patientstreatments)patientstreatmentsBindingSource.Current).patientstreatments_t43 = patientstreatments_t43CheckBox.Checked;
                ((patientstreatments)patientstreatmentsBindingSource.Current).patientstreatments_t44 = patientstreatments_t44CheckBox.Checked;
                ((patientstreatments)patientstreatmentsBindingSource.Current).patientstreatments_t45 = patientstreatments_t45CheckBox.Checked;
                ((patientstreatments)patientstreatmentsBindingSource.Current).patientstreatments_t46 = patientstreatments_t46CheckBox.Checked;
                ((patientstreatments)patientstreatmentsBindingSource.Current).patientstreatments_t47 = patientstreatments_t47CheckBox.Checked;
                ((patientstreatments)patientstreatmentsBindingSource.Current).patientstreatments_t48 = patientstreatments_t48CheckBox.Checked;

                if (!patientstreatments_expirationdateenabledCheckBox.Checked)
                    ((patientstreatments)patientstreatmentsBindingSource.Current).patientstreatments_expirationdate = null;
                else
                    ((patientstreatments)patientstreatmentsBindingSource.Current).patientstreatments_expirationdate = patientstreatments_expirationdateDateTimePicker.Value;

                if (!patientstreatments_fulfilldateenabledCheckBox.Checked)
                    ((patientstreatments)patientstreatmentsBindingSource.Current).patientstreatments_fulfilldate = null;
                else
                    ((patientstreatments)patientstreatmentsBindingSource.Current).patientstreatments_fulfilldate = patientstreatments_fulfilldateDateTimePicker.Value;
            }
        }
        
        /// <summary>
        /// Treatments all checked handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void patientstreatments_talCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (IsBindingSourceLoading)
                return;

            if (patientstreatmentsBindingSource.Current != null)
            {
                if (patientstreatments_talCheckBox.Checked)
                {
                    patientstreatments_t11CheckBox.Checked = true;
                    patientstreatments_t12CheckBox.Checked = true;
                    patientstreatments_t13CheckBox.Checked = true;
                    patientstreatments_t14CheckBox.Checked = true;
                    patientstreatments_t15CheckBox.Checked = true;
                    patientstreatments_t16CheckBox.Checked = true;
                    patientstreatments_t17CheckBox.Checked = true;
                    patientstreatments_t18CheckBox.Checked = true;
                    patientstreatments_t21CheckBox.Checked = true;
                    patientstreatments_t22CheckBox.Checked = true;
                    patientstreatments_t23CheckBox.Checked = true;
                    patientstreatments_t24CheckBox.Checked = true;
                    patientstreatments_t25CheckBox.Checked = true;
                    patientstreatments_t26CheckBox.Checked = true;
                    patientstreatments_t27CheckBox.Checked = true;
                    patientstreatments_t28CheckBox.Checked = true;
                    patientstreatments_t31CheckBox.Checked = true;
                    patientstreatments_t32CheckBox.Checked = true;
                    patientstreatments_t33CheckBox.Checked = true;
                    patientstreatments_t34CheckBox.Checked = true;
                    patientstreatments_t35CheckBox.Checked = true;
                    patientstreatments_t36CheckBox.Checked = true;
                    patientstreatments_t37CheckBox.Checked = true;
                    patientstreatments_t38CheckBox.Checked = true;
                    patientstreatments_t41CheckBox.Checked = true;
                    patientstreatments_t42CheckBox.Checked = true;
                    patientstreatments_t43CheckBox.Checked = true;
                    patientstreatments_t44CheckBox.Checked = true;
                    patientstreatments_t45CheckBox.Checked = true;
                    patientstreatments_t46CheckBox.Checked = true;
                    patientstreatments_t47CheckBox.Checked = true;
                    patientstreatments_t48CheckBox.Checked = true;
                }

                patientstreatments_talCheckBox.Checked = false;
            }
        }

        /// <summary>
        /// Treatments no checked handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void patientstreatments_tnoCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (IsBindingSourceLoading)
                return;

            if (patientstreatmentsBindingSource.Current != null)
            {
                if (patientstreatments_tnoCheckBox.Checked)
                {
                    patientstreatments_t11CheckBox.Checked = false;
                    patientstreatments_t12CheckBox.Checked = false;
                    patientstreatments_t13CheckBox.Checked = false;
                    patientstreatments_t14CheckBox.Checked = false;
                    patientstreatments_t15CheckBox.Checked = false;
                    patientstreatments_t16CheckBox.Checked = false;
                    patientstreatments_t17CheckBox.Checked = false;
                    patientstreatments_t18CheckBox.Checked = false;
                    patientstreatments_t21CheckBox.Checked = false;
                    patientstreatments_t22CheckBox.Checked = false;
                    patientstreatments_t23CheckBox.Checked = false;
                    patientstreatments_t24CheckBox.Checked = false;
                    patientstreatments_t25CheckBox.Checked = false;
                    patientstreatments_t26CheckBox.Checked = false;
                    patientstreatments_t27CheckBox.Checked = false;
                    patientstreatments_t28CheckBox.Checked = false;
                    patientstreatments_t31CheckBox.Checked = false;
                    patientstreatments_t32CheckBox.Checked = false;
                    patientstreatments_t33CheckBox.Checked = false;
                    patientstreatments_t34CheckBox.Checked = false;
                    patientstreatments_t35CheckBox.Checked = false;
                    patientstreatments_t36CheckBox.Checked = false;
                    patientstreatments_t37CheckBox.Checked = false;
                    patientstreatments_t38CheckBox.Checked = false;
                    patientstreatments_t41CheckBox.Checked = false;
                    patientstreatments_t42CheckBox.Checked = false;
                    patientstreatments_t43CheckBox.Checked = false;
                    patientstreatments_t44CheckBox.Checked = false;
                    patientstreatments_t45CheckBox.Checked = false;
                    patientstreatments_t46CheckBox.Checked = false;
                    patientstreatments_t47CheckBox.Checked = false;
                    patientstreatments_t48CheckBox.Checked = false;
                }

                patientstreatments_tnoCheckBox.Checked = false;
            }
        }

        /// <summary>
        /// Treatments up checked handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void patientstreatments_tupCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (IsBindingSourceLoading)
                return;

            if (patientstreatmentsBindingSource.Current != null)
            {
                if (patientstreatments_tupCheckBox.Checked)
                {
                    patientstreatments_t11CheckBox.Checked = true;
                    patientstreatments_t12CheckBox.Checked = true;
                    patientstreatments_t13CheckBox.Checked = true;
                    patientstreatments_t14CheckBox.Checked = true;
                    patientstreatments_t15CheckBox.Checked = true;
                    patientstreatments_t16CheckBox.Checked = true;
                    patientstreatments_t17CheckBox.Checked = true;
                    patientstreatments_t18CheckBox.Checked = true;
                    patientstreatments_t21CheckBox.Checked = true;
                    patientstreatments_t22CheckBox.Checked = true;
                    patientstreatments_t23CheckBox.Checked = true;
                    patientstreatments_t24CheckBox.Checked = true;
                    patientstreatments_t25CheckBox.Checked = true;
                    patientstreatments_t26CheckBox.Checked = true;
                    patientstreatments_t27CheckBox.Checked = true;
                    patientstreatments_t28CheckBox.Checked = true;
                    patientstreatments_t31CheckBox.Checked = false;
                    patientstreatments_t32CheckBox.Checked = false;
                    patientstreatments_t33CheckBox.Checked = false;
                    patientstreatments_t34CheckBox.Checked = false;
                    patientstreatments_t35CheckBox.Checked = false;
                    patientstreatments_t36CheckBox.Checked = false;
                    patientstreatments_t37CheckBox.Checked = false;
                    patientstreatments_t38CheckBox.Checked = false;
                    patientstreatments_t41CheckBox.Checked = false;
                    patientstreatments_t42CheckBox.Checked = false;
                    patientstreatments_t43CheckBox.Checked = false;
                    patientstreatments_t44CheckBox.Checked = false;
                    patientstreatments_t45CheckBox.Checked = false;
                    patientstreatments_t46CheckBox.Checked = false;
                    patientstreatments_t47CheckBox.Checked = false;
                    patientstreatments_t48CheckBox.Checked = false;
                }

                patientstreatments_tupCheckBox.Checked = false;
            }
        }

        /// <summary>
        /// Treatments down checked handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void patientstreatments_tdwCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (IsBindingSourceLoading)
                return;

            if (patientstreatmentsBindingSource.Current != null)
            {
                if (patientstreatments_tdwCheckBox.Checked)
                {
                    patientstreatments_t11CheckBox.Checked = false;
                    patientstreatments_t12CheckBox.Checked = false;
                    patientstreatments_t13CheckBox.Checked = false;
                    patientstreatments_t14CheckBox.Checked = false;
                    patientstreatments_t15CheckBox.Checked = false;
                    patientstreatments_t16CheckBox.Checked = false;
                    patientstreatments_t17CheckBox.Checked = false;
                    patientstreatments_t18CheckBox.Checked = false;
                    patientstreatments_t21CheckBox.Checked = false;
                    patientstreatments_t22CheckBox.Checked = false;
                    patientstreatments_t23CheckBox.Checked = false;
                    patientstreatments_t24CheckBox.Checked = false;
                    patientstreatments_t25CheckBox.Checked = false;
                    patientstreatments_t26CheckBox.Checked = false;
                    patientstreatments_t27CheckBox.Checked = false;
                    patientstreatments_t28CheckBox.Checked = false;
                    patientstreatments_t31CheckBox.Checked = true;
                    patientstreatments_t32CheckBox.Checked = true;
                    patientstreatments_t33CheckBox.Checked = true;
                    patientstreatments_t34CheckBox.Checked = true;
                    patientstreatments_t35CheckBox.Checked = true;
                    patientstreatments_t36CheckBox.Checked = true;
                    patientstreatments_t37CheckBox.Checked = true;
                    patientstreatments_t38CheckBox.Checked = true;
                    patientstreatments_t41CheckBox.Checked = true;
                    patientstreatments_t42CheckBox.Checked = true;
                    patientstreatments_t43CheckBox.Checked = true;
                    patientstreatments_t44CheckBox.Checked = true;
                    patientstreatments_t45CheckBox.Checked = true;
                    patientstreatments_t46CheckBox.Checked = true;
                    patientstreatments_t47CheckBox.Checked = true;
                    patientstreatments_t48CheckBox.Checked = true;
                }

                patientstreatments_tdwCheckBox.Checked = false;
            }
        }

        /// <summary>
        /// Combobox autocomplete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void doctors_idComboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            DGUIGHFUtilsUI.DGComboBoxAutoComplete.OnKeyPress((ComboBox)sender, e);
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


        #region patients treatments filter

        /// <summary>
        /// Set the current patient treatments filter text
        /// </summary>
        private void SetPatientstreatmentsFiltert()
        {
            int patients_id = -1;
            if (vPatientsBindingSource.Current != null)
            {
                patients_id = (((DataRowView)vPatientsBindingSource.Current).Row).Field<int>("patients_id");
            }

            int patientstreatments_talnum = _dentnedModel.PatientsTreatments.List(r => r.patients_id == patients_id &&
                r.patientstreatments_t11 &&
                r.patientstreatments_t12 &&
                r.patientstreatments_t13 &&
                r.patientstreatments_t14 &&
                r.patientstreatments_t15 &&
                r.patientstreatments_t16 &&
                r.patientstreatments_t17 &&
                r.patientstreatments_t18 &&
                r.patientstreatments_t21 &&
                r.patientstreatments_t22 &&
                r.patientstreatments_t23 &&
                r.patientstreatments_t24 &&
                r.patientstreatments_t25 &&
                r.patientstreatments_t26 &&
                r.patientstreatments_t27 &&
                r.patientstreatments_t28 &&
                r.patientstreatments_t31 &&
                r.patientstreatments_t32 &&
                r.patientstreatments_t33 &&
                r.patientstreatments_t34 &&
                r.patientstreatments_t35 &&
                r.patientstreatments_t36 &&
                r.patientstreatments_t37 &&
                r.patientstreatments_t38 &&
                r.patientstreatments_t41 &&
                r.patientstreatments_t42 &&
                r.patientstreatments_t43 &&
                r.patientstreatments_t44 &&
                r.patientstreatments_t45 &&
                r.patientstreatments_t46 &&
                r.patientstreatments_t47 &&
                r.patientstreatments_t48).Count;
            int patientstreatments_tnonum = _dentnedModel.PatientsTreatments.List(r => r.patients_id == patients_id &&
                !r.patientstreatments_t11 &&
                !r.patientstreatments_t12 &&
                !r.patientstreatments_t13 &&
                !r.patientstreatments_t14 &&
                !r.patientstreatments_t15 &&
                !r.patientstreatments_t16 &&
                !r.patientstreatments_t17 &&
                !r.patientstreatments_t18 &&
                !r.patientstreatments_t21 &&
                !r.patientstreatments_t22 &&
                !r.patientstreatments_t23 &&
                !r.patientstreatments_t24 &&
                !r.patientstreatments_t25 &&
                !r.patientstreatments_t26 &&
                !r.patientstreatments_t27 &&
                !r.patientstreatments_t28 &&
                !r.patientstreatments_t31 &&
                !r.patientstreatments_t32 &&
                !r.patientstreatments_t33 &&
                !r.patientstreatments_t34 &&
                !r.patientstreatments_t35 &&
                !r.patientstreatments_t36 &&
                !r.patientstreatments_t37 &&
                !r.patientstreatments_t38 &&
                !r.patientstreatments_t41 &&
                !r.patientstreatments_t42 &&
                !r.patientstreatments_t43 &&
                !r.patientstreatments_t44 &&
                !r.patientstreatments_t45 &&
                !r.patientstreatments_t46 &&
                !r.patientstreatments_t47 &&
                !r.patientstreatments_t48).Count;
            int patientstreatments_tupnum = _dentnedModel.PatientsTreatments.List(r => r.patients_id == patients_id &&
                r.patientstreatments_t11 &&
                r.patientstreatments_t12 &&
                r.patientstreatments_t13 &&
                r.patientstreatments_t14 &&
                r.patientstreatments_t15 &&
                r.patientstreatments_t16 &&
                r.patientstreatments_t17 &&
                r.patientstreatments_t18 &&
                r.patientstreatments_t21 &&
                r.patientstreatments_t22 &&
                r.patientstreatments_t23 &&
                r.patientstreatments_t24 &&
                r.patientstreatments_t25 &&
                r.patientstreatments_t26 &&
                r.patientstreatments_t27 &&
                r.patientstreatments_t28 &&
                !r.patientstreatments_t31 &&
                !r.patientstreatments_t32 &&
                !r.patientstreatments_t33 &&
                !r.patientstreatments_t34 &&
                !r.patientstreatments_t35 &&
                !r.patientstreatments_t36 &&
                !r.patientstreatments_t37 &&
                !r.patientstreatments_t38 &&
                !r.patientstreatments_t41 &&
                !r.patientstreatments_t42 &&
                !r.patientstreatments_t43 &&
                !r.patientstreatments_t44 &&
                !r.patientstreatments_t45 &&
                !r.patientstreatments_t46 &&
                !r.patientstreatments_t47 &&
                !r.patientstreatments_t48).Count;
            int patientstreatments_tdwnum = _dentnedModel.PatientsTreatments.List(r => r.patients_id == patients_id &&
                !r.patientstreatments_t11 &&
                !r.patientstreatments_t12 &&
                !r.patientstreatments_t13 &&
                !r.patientstreatments_t14 &&
                !r.patientstreatments_t15 &&
                !r.patientstreatments_t16 &&
                !r.patientstreatments_t17 &&
                !r.patientstreatments_t18 &&
                !r.patientstreatments_t21 &&
                !r.patientstreatments_t22 &&
                !r.patientstreatments_t23 &&
                !r.patientstreatments_t24 &&
                !r.patientstreatments_t25 &&
                !r.patientstreatments_t26 &&
                !r.patientstreatments_t27 &&
                !r.patientstreatments_t28 &&
                r.patientstreatments_t31 &&
                r.patientstreatments_t32 &&
                r.patientstreatments_t33 &&
                r.patientstreatments_t34 &&
                r.patientstreatments_t35 &&
                r.patientstreatments_t36 &&
                r.patientstreatments_t37 &&
                r.patientstreatments_t38 &&
                r.patientstreatments_t41 &&
                r.patientstreatments_t42 &&
                r.patientstreatments_t43 &&
                r.patientstreatments_t44 &&
                r.patientstreatments_t45 &&
                r.patientstreatments_t46 &&
                r.patientstreatments_t47 &&
                r.patientstreatments_t48).Count;
            int patientstreatments_t11num = 0;
            int patientstreatments_t12num = 0;
            int patientstreatments_t13num = 0;
            int patientstreatments_t14num = 0;
            int patientstreatments_t15num = 0;
            int patientstreatments_t16num = 0;
            int patientstreatments_t17num = 0;
            int patientstreatments_t18num = 0;
            int patientstreatments_t21num = 0;
            int patientstreatments_t22num = 0;
            int patientstreatments_t23num = 0;
            int patientstreatments_t24num = 0;
            int patientstreatments_t25num = 0;
            int patientstreatments_t26num = 0;
            int patientstreatments_t27num = 0;
            int patientstreatments_t28num = 0;
            int patientstreatments_t31num = 0;
            int patientstreatments_t32num = 0;
            int patientstreatments_t33num = 0;
            int patientstreatments_t34num = 0;
            int patientstreatments_t35num = 0;
            int patientstreatments_t36num = 0;
            int patientstreatments_t37num = 0;
            int patientstreatments_t38num = 0;
            int patientstreatments_t41num = 0;
            int patientstreatments_t42num = 0;
            int patientstreatments_t43num = 0;
            int patientstreatments_t44num = 0;
            int patientstreatments_t45num = 0;
            int patientstreatments_t46num = 0;
            int patientstreatments_t47num = 0;
            int patientstreatments_t48num = 0;
            foreach (patientstreatments patientstreatment in _dentnedModel.PatientsTreatments.List(r => r.patients_id == patients_id))
            {
                if (patientstreatment.patientstreatments_t11)
                    patientstreatments_t11num++;
                if (patientstreatment.patientstreatments_t12)
                    patientstreatments_t12num++;
                if (patientstreatment.patientstreatments_t13)
                    patientstreatments_t13num++;
                if (patientstreatment.patientstreatments_t14)
                    patientstreatments_t14num++;
                if (patientstreatment.patientstreatments_t15)
                    patientstreatments_t15num++;
                if (patientstreatment.patientstreatments_t16)
                    patientstreatments_t16num++;
                if (patientstreatment.patientstreatments_t17)
                    patientstreatments_t17num++;
                if (patientstreatment.patientstreatments_t18)
                    patientstreatments_t18num++;
                if (patientstreatment.patientstreatments_t21)
                    patientstreatments_t21num++;
                if (patientstreatment.patientstreatments_t22)
                    patientstreatments_t22num++;
                if (patientstreatment.patientstreatments_t23)
                    patientstreatments_t23num++;
                if (patientstreatment.patientstreatments_t24)
                    patientstreatments_t24num++;
                if (patientstreatment.patientstreatments_t25)
                    patientstreatments_t25num++;
                if (patientstreatment.patientstreatments_t26)
                    patientstreatments_t26num++;
                if (patientstreatment.patientstreatments_t27)
                    patientstreatments_t27num++;
                if (patientstreatment.patientstreatments_t28)
                    patientstreatments_t28num++;
                if (patientstreatment.patientstreatments_t31)
                    patientstreatments_t31num++;
                if (patientstreatment.patientstreatments_t32)
                    patientstreatments_t32num++;
                if (patientstreatment.patientstreatments_t33)
                    patientstreatments_t33num++;
                if (patientstreatment.patientstreatments_t34)
                    patientstreatments_t34num++;
                if (patientstreatment.patientstreatments_t35)
                    patientstreatments_t35num++;
                if (patientstreatment.patientstreatments_t36)
                    patientstreatments_t36num++;
                if (patientstreatment.patientstreatments_t37)
                    patientstreatments_t37num++;
                if (patientstreatment.patientstreatments_t38)
                    patientstreatments_t38num++;
                if (patientstreatment.patientstreatments_t41)
                    patientstreatments_t41num++;
                if (patientstreatment.patientstreatments_t42)
                    patientstreatments_t42num++;
                if (patientstreatment.patientstreatments_t43)
                    patientstreatments_t43num++;
                if (patientstreatment.patientstreatments_t44)
                    patientstreatments_t44num++;
                if (patientstreatment.patientstreatments_t45)
                    patientstreatments_t45num++;
                if (patientstreatment.patientstreatments_t46)
                    patientstreatments_t46num++;
                if (patientstreatment.patientstreatments_t47)
                    patientstreatments_t47num++;
                if (patientstreatment.patientstreatments_t48)
                    patientstreatments_t48num++;
            }
            patientstreatments_filtertalnumLabel.Text = patientstreatments_talnum.ToString();
            patientstreatments_filtertnonumLabel.Text = patientstreatments_tnonum.ToString();
            patientstreatments_filtertupnumLabel.Text = patientstreatments_tupnum.ToString();
            patientstreatments_filtertdwnumLabel.Text = patientstreatments_tdwnum.ToString();
            patientstreatments_filtert11numLabel.Text = patientstreatments_t11num.ToString();
            patientstreatments_filtert12numLabel.Text = patientstreatments_t12num.ToString();
            patientstreatments_filtert13numLabel.Text = patientstreatments_t13num.ToString();
            patientstreatments_filtert14numLabel.Text = patientstreatments_t14num.ToString();
            patientstreatments_filtert15numLabel.Text = patientstreatments_t15num.ToString();
            patientstreatments_filtert16numLabel.Text = patientstreatments_t16num.ToString();
            patientstreatments_filtert17numLabel.Text = patientstreatments_t17num.ToString();
            patientstreatments_filtert18numLabel.Text = patientstreatments_t18num.ToString();
            patientstreatments_filtert21numLabel.Text = patientstreatments_t21num.ToString();
            patientstreatments_filtert22numLabel.Text = patientstreatments_t22num.ToString();
            patientstreatments_filtert23numLabel.Text = patientstreatments_t23num.ToString();
            patientstreatments_filtert24numLabel.Text = patientstreatments_t24num.ToString();
            patientstreatments_filtert25numLabel.Text = patientstreatments_t25num.ToString();
            patientstreatments_filtert26numLabel.Text = patientstreatments_t26num.ToString();
            patientstreatments_filtert27numLabel.Text = patientstreatments_t27num.ToString();
            patientstreatments_filtert28numLabel.Text = patientstreatments_t28num.ToString();
            patientstreatments_filtert31numLabel.Text = patientstreatments_t31num.ToString();
            patientstreatments_filtert32numLabel.Text = patientstreatments_t32num.ToString();
            patientstreatments_filtert33numLabel.Text = patientstreatments_t33num.ToString();
            patientstreatments_filtert34numLabel.Text = patientstreatments_t34num.ToString();
            patientstreatments_filtert35numLabel.Text = patientstreatments_t35num.ToString();
            patientstreatments_filtert36numLabel.Text = patientstreatments_t36num.ToString();
            patientstreatments_filtert37numLabel.Text = patientstreatments_t37num.ToString();
            patientstreatments_filtert38numLabel.Text = patientstreatments_t38num.ToString();
            patientstreatments_filtert41numLabel.Text = patientstreatments_t41num.ToString();
            patientstreatments_filtert42numLabel.Text = patientstreatments_t42num.ToString();
            patientstreatments_filtert43numLabel.Text = patientstreatments_t43num.ToString();
            patientstreatments_filtert44numLabel.Text = patientstreatments_t44num.ToString();
            patientstreatments_filtert45numLabel.Text = patientstreatments_t45num.ToString();
            patientstreatments_filtert46numLabel.Text = patientstreatments_t46num.ToString();
            patientstreatments_filtert47numLabel.Text = patientstreatments_t47num.ToString();
            patientstreatments_filtert48numLabel.Text = patientstreatments_t48num.ToString();
        }

        /// <summary>
        /// Reset the current patient treatments filter text
        /// </summary>
        private void ResetPatientstreatmentsFiltert()
        {
            patientstreatments_filtertnoCheckBox.Checked = false;
            patientstreatments_filtertnoCheckBox_CheckedChanged(null, null);
        }

        /// <summary>
        /// Patients Treatment filter change
        /// </summary>
        private void PatientsTreatmentsFilter()
        {
            if (IsBindingSourceLoading)
                return;

            if (
                patientstreatments_filtert11CheckBox.Checked ||
                patientstreatments_filtert12CheckBox.Checked ||
                patientstreatments_filtert13CheckBox.Checked ||
                patientstreatments_filtert14CheckBox.Checked ||
                patientstreatments_filtert15CheckBox.Checked ||
                patientstreatments_filtert16CheckBox.Checked ||
                patientstreatments_filtert17CheckBox.Checked ||
                patientstreatments_filtert18CheckBox.Checked ||
                patientstreatments_filtert21CheckBox.Checked ||
                patientstreatments_filtert22CheckBox.Checked ||
                patientstreatments_filtert23CheckBox.Checked ||
                patientstreatments_filtert24CheckBox.Checked ||
                patientstreatments_filtert25CheckBox.Checked ||
                patientstreatments_filtert26CheckBox.Checked ||
                patientstreatments_filtert27CheckBox.Checked ||
                patientstreatments_filtert28CheckBox.Checked ||
                patientstreatments_filtert31CheckBox.Checked ||
                patientstreatments_filtert32CheckBox.Checked ||
                patientstreatments_filtert33CheckBox.Checked ||
                patientstreatments_filtert34CheckBox.Checked ||
                patientstreatments_filtert35CheckBox.Checked ||
                patientstreatments_filtert36CheckBox.Checked ||
                patientstreatments_filtert37CheckBox.Checked ||
                patientstreatments_filtert38CheckBox.Checked ||
                patientstreatments_filtert41CheckBox.Checked ||
                patientstreatments_filtert42CheckBox.Checked ||
                patientstreatments_filtert43CheckBox.Checked ||
                patientstreatments_filtert44CheckBox.Checked ||
                patientstreatments_filtert45CheckBox.Checked ||
                patientstreatments_filtert46CheckBox.Checked ||
                patientstreatments_filtert47CheckBox.Checked ||
                patientstreatments_filtert48CheckBox.Checked)
                patientstreatments_filtertanyCheckBox.Checked = false;

            //get the new binding source
            IsBindingSourceLoading = true;
            vPatientsTreatmentsBindingSource.DataSource = GetDataSourceList_tabPatientsTreatments();
            IsBindingSourceLoading = false;

            vPatientsTreatmentsBindingSource_CurrentChanged(null, null);
        }

        /// <summary>
        /// Treatments filter all checked handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void patientstreatments_filtertalCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            IsBindingSourceLoading = true;

            if (patientstreatments_filtertalCheckBox.Checked)
            {
                patientstreatments_filtert11CheckBox.Checked = true;
                patientstreatments_filtert12CheckBox.Checked = true;
                patientstreatments_filtert13CheckBox.Checked = true;
                patientstreatments_filtert14CheckBox.Checked = true;
                patientstreatments_filtert15CheckBox.Checked = true;
                patientstreatments_filtert16CheckBox.Checked = true;
                patientstreatments_filtert17CheckBox.Checked = true;
                patientstreatments_filtert18CheckBox.Checked = true;
                patientstreatments_filtert21CheckBox.Checked = true;
                patientstreatments_filtert22CheckBox.Checked = true;
                patientstreatments_filtert23CheckBox.Checked = true;
                patientstreatments_filtert24CheckBox.Checked = true;
                patientstreatments_filtert25CheckBox.Checked = true;
                patientstreatments_filtert26CheckBox.Checked = true;
                patientstreatments_filtert27CheckBox.Checked = true;
                patientstreatments_filtert28CheckBox.Checked = true;
                patientstreatments_filtert31CheckBox.Checked = true;
                patientstreatments_filtert32CheckBox.Checked = true;
                patientstreatments_filtert33CheckBox.Checked = true;
                patientstreatments_filtert34CheckBox.Checked = true;
                patientstreatments_filtert35CheckBox.Checked = true;
                patientstreatments_filtert36CheckBox.Checked = true;
                patientstreatments_filtert37CheckBox.Checked = true;
                patientstreatments_filtert38CheckBox.Checked = true;
                patientstreatments_filtert41CheckBox.Checked = true;
                patientstreatments_filtert42CheckBox.Checked = true;
                patientstreatments_filtert43CheckBox.Checked = true;
                patientstreatments_filtert44CheckBox.Checked = true;
                patientstreatments_filtert45CheckBox.Checked = true;
                patientstreatments_filtert46CheckBox.Checked = true;
                patientstreatments_filtert47CheckBox.Checked = true;
                patientstreatments_filtert48CheckBox.Checked = true;
            }

            patientstreatments_filtertalCheckBox.Checked = false;
            patientstreatments_filtertanyCheckBox.Checked = false;

            IsBindingSourceLoading = false;

            PatientsTreatmentsFilter();
        }

        /// <summary>
        /// Treatments filter none checked handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void patientstreatments_filtertnoCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            IsBindingSourceLoading = true;

            if (patientstreatments_filtertnoCheckBox.Checked)
            {
                patientstreatments_filtert11CheckBox.Checked = false;
                patientstreatments_filtert12CheckBox.Checked = false;
                patientstreatments_filtert13CheckBox.Checked = false;
                patientstreatments_filtert14CheckBox.Checked = false;
                patientstreatments_filtert15CheckBox.Checked = false;
                patientstreatments_filtert16CheckBox.Checked = false;
                patientstreatments_filtert17CheckBox.Checked = false;
                patientstreatments_filtert18CheckBox.Checked = false;
                patientstreatments_filtert21CheckBox.Checked = false;
                patientstreatments_filtert22CheckBox.Checked = false;
                patientstreatments_filtert23CheckBox.Checked = false;
                patientstreatments_filtert24CheckBox.Checked = false;
                patientstreatments_filtert25CheckBox.Checked = false;
                patientstreatments_filtert26CheckBox.Checked = false;
                patientstreatments_filtert27CheckBox.Checked = false;
                patientstreatments_filtert28CheckBox.Checked = false;
                patientstreatments_filtert31CheckBox.Checked = false;
                patientstreatments_filtert32CheckBox.Checked = false;
                patientstreatments_filtert33CheckBox.Checked = false;
                patientstreatments_filtert34CheckBox.Checked = false;
                patientstreatments_filtert35CheckBox.Checked = false;
                patientstreatments_filtert36CheckBox.Checked = false;
                patientstreatments_filtert37CheckBox.Checked = false;
                patientstreatments_filtert38CheckBox.Checked = false;
                patientstreatments_filtert41CheckBox.Checked = false;
                patientstreatments_filtert42CheckBox.Checked = false;
                patientstreatments_filtert43CheckBox.Checked = false;
                patientstreatments_filtert44CheckBox.Checked = false;
                patientstreatments_filtert45CheckBox.Checked = false;
                patientstreatments_filtert46CheckBox.Checked = false;
                patientstreatments_filtert47CheckBox.Checked = false;
                patientstreatments_filtert48CheckBox.Checked = false;
            }

            patientstreatments_filtertnoCheckBox.Checked = false;
            patientstreatments_filtertanyCheckBox.Checked = false;

            IsBindingSourceLoading = false;

            PatientsTreatmentsFilter();
        }

        /// <summary>
        /// Treatments filter up checked handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void patientstreatments_filtertupCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            IsBindingSourceLoading = true;

            if (patientstreatments_filtertupCheckBox.Checked)
            {
                patientstreatments_filtert11CheckBox.Checked = true;
                patientstreatments_filtert12CheckBox.Checked = true;
                patientstreatments_filtert13CheckBox.Checked = true;
                patientstreatments_filtert14CheckBox.Checked = true;
                patientstreatments_filtert15CheckBox.Checked = true;
                patientstreatments_filtert16CheckBox.Checked = true;
                patientstreatments_filtert17CheckBox.Checked = true;
                patientstreatments_filtert18CheckBox.Checked = true;
                patientstreatments_filtert21CheckBox.Checked = true;
                patientstreatments_filtert22CheckBox.Checked = true;
                patientstreatments_filtert23CheckBox.Checked = true;
                patientstreatments_filtert24CheckBox.Checked = true;
                patientstreatments_filtert25CheckBox.Checked = true;
                patientstreatments_filtert26CheckBox.Checked = true;
                patientstreatments_filtert27CheckBox.Checked = true;
                patientstreatments_filtert28CheckBox.Checked = true;
                patientstreatments_filtert31CheckBox.Checked = false;
                patientstreatments_filtert32CheckBox.Checked = false;
                patientstreatments_filtert33CheckBox.Checked = false;
                patientstreatments_filtert34CheckBox.Checked = false;
                patientstreatments_filtert35CheckBox.Checked = false;
                patientstreatments_filtert36CheckBox.Checked = false;
                patientstreatments_filtert37CheckBox.Checked = false;
                patientstreatments_filtert38CheckBox.Checked = false;
                patientstreatments_filtert41CheckBox.Checked = false;
                patientstreatments_filtert42CheckBox.Checked = false;
                patientstreatments_filtert43CheckBox.Checked = false;
                patientstreatments_filtert44CheckBox.Checked = false;
                patientstreatments_filtert45CheckBox.Checked = false;
                patientstreatments_filtert46CheckBox.Checked = false;
                patientstreatments_filtert47CheckBox.Checked = false;
                patientstreatments_filtert48CheckBox.Checked = false;
            }

            patientstreatments_filtertupCheckBox.Checked = false;
            patientstreatments_filtertanyCheckBox.Checked = false;

            IsBindingSourceLoading = false;

            PatientsTreatmentsFilter();
        }

        /// <summary>
        /// Treatments filter down checked handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void patientstreatments_filtertdwCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            IsBindingSourceLoading = true;

            if (patientstreatments_filtertdwCheckBox.Checked)
            {
                patientstreatments_filtert11CheckBox.Checked = false;
                patientstreatments_filtert12CheckBox.Checked = false;
                patientstreatments_filtert13CheckBox.Checked = false;
                patientstreatments_filtert14CheckBox.Checked = false;
                patientstreatments_filtert15CheckBox.Checked = false;
                patientstreatments_filtert16CheckBox.Checked = false;
                patientstreatments_filtert17CheckBox.Checked = false;
                patientstreatments_filtert18CheckBox.Checked = false;
                patientstreatments_filtert21CheckBox.Checked = false;
                patientstreatments_filtert22CheckBox.Checked = false;
                patientstreatments_filtert23CheckBox.Checked = false;
                patientstreatments_filtert24CheckBox.Checked = false;
                patientstreatments_filtert25CheckBox.Checked = false;
                patientstreatments_filtert26CheckBox.Checked = false;
                patientstreatments_filtert27CheckBox.Checked = false;
                patientstreatments_filtert28CheckBox.Checked = false;
                patientstreatments_filtert31CheckBox.Checked = true;
                patientstreatments_filtert32CheckBox.Checked = true;
                patientstreatments_filtert33CheckBox.Checked = true;
                patientstreatments_filtert34CheckBox.Checked = true;
                patientstreatments_filtert35CheckBox.Checked = true;
                patientstreatments_filtert36CheckBox.Checked = true;
                patientstreatments_filtert37CheckBox.Checked = true;
                patientstreatments_filtert38CheckBox.Checked = true;
                patientstreatments_filtert41CheckBox.Checked = true;
                patientstreatments_filtert42CheckBox.Checked = true;
                patientstreatments_filtert43CheckBox.Checked = true;
                patientstreatments_filtert44CheckBox.Checked = true;
                patientstreatments_filtert45CheckBox.Checked = true;
                patientstreatments_filtert46CheckBox.Checked = true;
                patientstreatments_filtert47CheckBox.Checked = true;
                patientstreatments_filtert48CheckBox.Checked = true;
            }

            patientstreatments_filtertdwCheckBox.Checked = false;
            patientstreatments_filtertanyCheckBox.Checked = false;

            IsBindingSourceLoading = false;

            PatientsTreatmentsFilter();
        }

        /// <summary>
        /// Treatments filter any checked handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void patientstreatments_filtertanyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            IsBindingSourceLoading = true;

            if (patientstreatments_filtertanyCheckBox.Checked)
            {
                patientstreatments_filtert11CheckBox.Checked = false;
                patientstreatments_filtert12CheckBox.Checked = false;
                patientstreatments_filtert13CheckBox.Checked = false;
                patientstreatments_filtert14CheckBox.Checked = false;
                patientstreatments_filtert15CheckBox.Checked = false;
                patientstreatments_filtert16CheckBox.Checked = false;
                patientstreatments_filtert17CheckBox.Checked = false;
                patientstreatments_filtert18CheckBox.Checked = false;
                patientstreatments_filtert21CheckBox.Checked = false;
                patientstreatments_filtert22CheckBox.Checked = false;
                patientstreatments_filtert23CheckBox.Checked = false;
                patientstreatments_filtert24CheckBox.Checked = false;
                patientstreatments_filtert25CheckBox.Checked = false;
                patientstreatments_filtert26CheckBox.Checked = false;
                patientstreatments_filtert27CheckBox.Checked = false;
                patientstreatments_filtert28CheckBox.Checked = false;
                patientstreatments_filtert31CheckBox.Checked = false;
                patientstreatments_filtert32CheckBox.Checked = false;
                patientstreatments_filtert33CheckBox.Checked = false;
                patientstreatments_filtert34CheckBox.Checked = false;
                patientstreatments_filtert35CheckBox.Checked = false;
                patientstreatments_filtert36CheckBox.Checked = false;
                patientstreatments_filtert37CheckBox.Checked = false;
                patientstreatments_filtert38CheckBox.Checked = false;
                patientstreatments_filtert41CheckBox.Checked = false;
                patientstreatments_filtert42CheckBox.Checked = false;
                patientstreatments_filtert43CheckBox.Checked = false;
                patientstreatments_filtert44CheckBox.Checked = false;
                patientstreatments_filtert45CheckBox.Checked = false;
                patientstreatments_filtert46CheckBox.Checked = false;
                patientstreatments_filtert47CheckBox.Checked = false;
                patientstreatments_filtert48CheckBox.Checked = false;
            }

            IsBindingSourceLoading = false;

            PatientsTreatmentsFilter();
        }

        /// <summary>
        /// Treatment filter change handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void patientstreatments_filtert11CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PatientsTreatmentsFilter();
        }

        /// <summary>
        /// Treatment filter change handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void patientstreatments_filtert12CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PatientsTreatmentsFilter();
        }

        /// <summary>
        /// Treatment filter change handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void patientstreatments_filtert13CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PatientsTreatmentsFilter();
        }

        /// <summary>
        /// Treatment filter change handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void patientstreatments_filtert14CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PatientsTreatmentsFilter();
        }

        /// <summary>
        /// Treatment filter change handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void patientstreatments_filtert15CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PatientsTreatmentsFilter();
        }

        /// <summary>
        /// Treatment filter change handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void patientstreatments_filtert16CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PatientsTreatmentsFilter();
        }

        /// <summary>
        /// Treatment filter change handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void patientstreatments_filtert17CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PatientsTreatmentsFilter();
        }

        /// <summary>
        /// Treatment filter change handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void patientstreatments_filtert18CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PatientsTreatmentsFilter();
        }

        /// <summary>
        /// Treatment filter change handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void patientstreatments_filtert21CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PatientsTreatmentsFilter();
        }

        /// <summary>
        /// Treatment filter change handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void patientstreatments_filtert22CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PatientsTreatmentsFilter();
        }

        /// <summary>
        /// Treatment filter change handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void patientstreatments_filtert23CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PatientsTreatmentsFilter();
        }

        /// <summary>
        /// Treatment filter change handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void patientstreatments_filtert24CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PatientsTreatmentsFilter();
        }

        /// <summary>
        /// Treatment filter change handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void patientstreatments_filtert25CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PatientsTreatmentsFilter();
        }

        /// <summary>
        /// Treatment filter change handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void patientstreatments_filtert26CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PatientsTreatmentsFilter();
        }

        /// <summary>
        /// Treatment filter change handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void patientstreatments_filtert27CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PatientsTreatmentsFilter();
        }

        /// <summary>
        /// Treatment filter change handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void patientstreatments_filtert28CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PatientsTreatmentsFilter();
        }

        /// <summary>
        /// Treatment filter change handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void patientstreatments_filtert31CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PatientsTreatmentsFilter();
        }

        /// <summary>
        /// Treatment filter change handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void patientstreatments_filtert32CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PatientsTreatmentsFilter();
        }

        /// <summary>
        /// Treatment filter change handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void patientstreatments_filtert33CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PatientsTreatmentsFilter();
        }

        /// <summary>
        /// Treatment filter change handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void patientstreatments_filtert34CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PatientsTreatmentsFilter();
        }

        /// <summary>
        /// Treatment filter change handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void patientstreatments_filtert35CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PatientsTreatmentsFilter();
        }

        /// <summary>
        /// Treatment filter change handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void patientstreatments_filtert36CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PatientsTreatmentsFilter();
        }

        /// <summary>
        /// Treatment filter change handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void patientstreatments_filtert37CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PatientsTreatmentsFilter();
        }

        /// <summary>
        /// Treatment filter change handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void patientstreatments_filtert38CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PatientsTreatmentsFilter();
        }

        /// <summary>
        /// Treatment filter change handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void patientstreatments_filtert41CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PatientsTreatmentsFilter();
        }

        /// <summary>
        /// Treatment filter change handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void patientstreatments_filtert42CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PatientsTreatmentsFilter();
        }

        /// <summary>
        /// Treatment filter change handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void patientstreatments_filtert43CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PatientsTreatmentsFilter();
        }

        /// <summary>
        /// Treatment filter change handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void patientstreatments_filtert44CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PatientsTreatmentsFilter();
        }

        /// <summary>
        /// Treatment filter change handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void patientstreatments_filtert45CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PatientsTreatmentsFilter();
        }

        /// <summary>
        /// Treatment filter change handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void patientstreatments_filtert46CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PatientsTreatmentsFilter();
        }

        /// <summary>
        /// Treatment filter change handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void patientstreatments_filtert47CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PatientsTreatmentsFilter();
        }

        /// <summary>
        /// Treatment filter change handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void patientstreatments_filtert48CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PatientsTreatmentsFilter();
        }

        #endregion


        #endregion


        #region tabPayments

        /// <summary>
        /// Get tab list DataSource
        /// </summary>
        /// <returns></returns>
        private object GetDataSourceList_tabPayments()
        {
            object ret = null;

            int patients_id = -1;
            if (vPatientsBindingSource.Current != null)
            {
                patients_id = (((DataRowView)vPatientsBindingSource.Current).Row).Field<int>("patients_id");
            }

            //update totals
            double payedtotalnum = Convert.ToDouble(_dentnedModel.Payments.List(r => r.patients_id == patients_id).Sum(r => r.payments_amount));
            double treatmentstotalnum = Convert.ToDouble(_dentnedModel.PatientsTreatments.List(r => r.patients_id == patients_id && !r.patientstreatments_ispayed && r.patientstreatments_fulfilldate != null).Sum(r => r.patientstreatments_price));
            double treatmentslefttotalnum = treatmentstotalnum - payedtotalnum;
            label_tabPayments_payedtotalnum.Text = String.Format("{0:0.00}", payedtotalnum);
            label_tabPayments_treatmentstotalnum.Text = String.Format("{0:0.00}", treatmentstotalnum);
            label_tabPayments_treatmentslefttotalnum.Text = String.Format("{0:0.00}", treatmentslefttotalnum);

            IEnumerable<VPatientsPayments> vPayments =
            _dentnedModel.Payments.List(r => r.patients_id == patients_id).Select(
            r => new VPatientsPayments
            {
                payments_id = r.payments_id,
                amount = (double)r.payments_amount,
                date = r.payments_date,
                note = (!String.IsNullOrEmpty(r.payments_notes) ? (r.payments_notes.Length > MaxRowValueLength ? r.payments_notes.Substring(0, MaxRowValueLength) + "..." : r.payments_notes) : "") 
            }).ToList();

            ret = DGDataTableUtils.ToDataTable<VPatientsPayments>(vPayments);

            return ret;
        }

        /// <summary>
        /// Tab Datagrid filter handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void advancedDataGridView_tabPayments_list_FilterStringChanged(object sender, EventArgs e)
        {
            vPatientsPaymentsBindingSource.Filter = advancedDataGridView_tabPayments_list.FilterString;
        }

        /// <summary>
        /// Tab Datagrid sort handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void advancedDataGridView_tabPayments_list_SortStringChanged(object sender, EventArgs e)
        {
            vPatientsPaymentsBindingSource.Sort = advancedDataGridView_tabPayments_list.SortString;
        }

        /// <summary>
        /// Load the tab DataSource
        /// </summary>
        /// <returns></returns>
        private object GetDataSourceEdit_tabPayments()
        {
            return DGUIGHFData.LoadEntityFromCurrentBindingSource<payments, DentneDModel>(_dentnedModel.Payments, vPatientsPaymentsBindingSource, new string[] { "payments_id" });
        }

        /// <summary>
        /// Do actions after Save
        /// </summary>
        /// <param name="item"></param>
        private void AfterSaveAction_tabPayments(object item)
        {
            DGUIGHFData.SetBindingSourcePosition<payments, DentneDModel>(_dentnedModel.Payments, item, vPatientsPaymentsBindingSource);
        }

        /// <summary>
        /// Add an item
        /// </summary>
        /// <param name="item"></param>
        private void Add_tabPayments(object item)
        {
            DGUIGHFData.Add<payments, DentneDModel>(_dentnedModel.Payments, item);
        }

        /// <summary>
        /// Update an item
        /// </summary>
        /// <param name="item"></param>
        private void Update_tabPayments(object item)
        {
            DGUIGHFData.Update<payments, DentneDModel>(_dentnedModel.Payments, item);
        }

        /// <summary>
        /// Remove an item
        /// </summary>
        /// <param name="item"></param>
        private void Remove_tabPayments(object item)
        {
            DGUIGHFData.Remove<payments, DentneDModel>(_dentnedModel.Payments, item);
        }

        /// <summary>
        /// New tab button handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_tabPayments_new_Click(object sender, EventArgs e)
        {
            if (vPatientsBindingSource.Current != null)
            {
                if (AddClick(tabElement_tabPayments))
                {
                    ((payments)paymentsBindingSource.Current).patients_id = (((DataRowView)vPatientsBindingSource.Current).Row).Field<int>("patients_id");
                    ((payments)paymentsBindingSource.Current).payments_date = DateTime.Now;
                    paymentsBindingSource.ResetBindings(true);
                }
            }
        }

        #endregion


        #region tabAppointments

        /// <summary>
        /// Get tab list DataSource
        /// </summary>
        /// <returns></returns>
        private object GetDataSourceList_tabAppointments()
        {
            object ret = null;

            int patients_id = -1;
            if (vPatientsBindingSource.Current != null)
            {
                patients_id = (((DataRowView)vPatientsBindingSource.Current).Row).Field<int>("patients_id");
            }

            IEnumerable<VPatientsAppointments> vPatientsAppointments =
            _dentnedModel.Appointments.List(r => r.patients_id == patients_id).Select(
            r => new VPatientsAppointments
            {
                appointments_id = r.appointments_id,
                from = r.appointments_from,
                to = String.Format("{0:HH:mm}", r.appointments_to),
                title = (r.appointments_title.Length > MaxRowValueLength ? r.appointments_title.Substring(0, MaxRowValueLength) + "..." : r.appointments_title)
            }).ToList();

            ret = DGDataTableUtils.ToDataTable<VPatientsAppointments>(vPatientsAppointments);

            return ret;
        }

        /// <summary>
        /// Tab Datagrid filter handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void advancedDataGridView_tabAppointments_list_FilterStringChanged(object sender, EventArgs e)
        {
            vPatientsAppointmentsBindingSource.Filter = advancedDataGridView_tabAppointments_list.FilterString;
        }

        /// <summary>
        /// Tab Datagrid sort handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void advancedDataGridView_tabAppointments_list_SortStringChanged(object sender, EventArgs e)
        {
            vPatientsAppointmentsBindingSource.Sort = advancedDataGridView_tabAppointments_list.SortString;
        }

        /// <summary>
        /// Load the tab DataSource
        /// </summary>
        /// <returns></returns>
        private object GetDataSourceEdit_tabAppointments()
        {
            return DGUIGHFData.LoadEntityFromCurrentBindingSource<appointments, DentneDModel>(_dentnedModel.Appointments, vPatientsAppointmentsBindingSource, new string[] { "appointments_id" });
        }
        
        #endregion


        #region tabPatientsAttachments

        private bool _tabPatientsAttachments_isnewsave = false;

        /// <summary>
        /// Get tab list DataSource
        /// </summary>
        /// <returns></returns>
        private object GetDataSourceList_tabPatientsAttachments()
        {
            object ret = null;

            int patients_id = -1;
            if (vPatientsBindingSource.Current != null)
            {
                patients_id = (((DataRowView)vPatientsBindingSource.Current).Row).Field<int>("patients_id");
            }

            IEnumerable<VPatientsAttachments> vPatientsAttachments =
            _dentnedModel.PatientsAttachments.List(r => r.patients_id == patients_id).Select(
            r => new VPatientsAttachments
            {
                patientsattachments_id = r.patientsattachments_id,
                attachmetnstype = _dentnedModel.PatientsAttachmentsTypes.Find(r.patientsattachmentstypes_id).patientsattachmentstypes_name,
                attachment = (r.patientsattachments_value.Length > MaxRowValueLength ? r.patientsattachments_value.Substring(0, MaxRowValueLength) + "..." : r.patientsattachments_value)
            }).ToList();

            ret = DGDataTableUtils.ToDataTable<VPatientsAttachments>(vPatientsAttachments);

            return ret;
        }

        /// <summary>
        /// Tab Datagrid filter handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void advancedDataGridView_tabPatientsAttachments_list_FilterStringChanged(object sender, EventArgs e)
        {
            vPatientsAttachmentsBindingSource.Filter = advancedDataGridView_tabPatientsAttachments_list.FilterString;
        }

        /// <summary>
        /// Tab Datagrid sort handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void advancedDataGridView_tabPatientsAttachments_list_SortStringChanged(object sender, EventArgs e)
        {
            vPatientsAttachmentsBindingSource.Sort = advancedDataGridView_tabPatientsAttachments_list.SortString;
        }

        /// <summary>
        /// Load the tab DataSource
        /// </summary>
        /// <returns></returns>
        private object GetDataSourceEdit_tabPatientsAttachments()
        {
            return DGUIGHFData.LoadEntityFromCurrentBindingSource<patientsattachments, DentneDModel>(_dentnedModel.PatientsAttachments, vPatientsAttachmentsBindingSource, new string[] { "patientsattachments_id" });
        }

        /// <summary>
        /// Do actions after Save
        /// </summary>
        /// <param name="item"></param>
        private void AfterSaveAction_tabPatientsAttachments(object item)
        {
            DGUIGHFData.SetBindingSourcePosition<patientsattachments, DentneDModel>(_dentnedModel.PatientsAttachments, item, vPatientsAttachmentsBindingSource);
            if (_tabPatientsAttachments_isnewsave)
            {
                button_tabPatientsAttachments_edit_Click(null, null);
            }
            _tabPatientsAttachments_isnewsave = false;
        }

        /// <summary>
        /// Add an item
        /// </summary>
        /// <param name="item"></param>
        private void Add_tabPatientsAttachments(object item)
        {
            DGUIGHFData.Add<patientsattachments, DentneDModel>(_dentnedModel.PatientsAttachments, item);
            _tabPatientsAttachments_isnewsave = true;
        }

        /// <summary>
        /// Update an item
        /// </summary>
        /// <param name="item"></param>
        private void Update_tabPatientsAttachments(object item)
        {
            DGUIGHFData.Update<patientsattachments, DentneDModel>(_dentnedModel.PatientsAttachments, item);
        }

        /// <summary>
        /// Remove an item
        /// </summary>
        /// <param name="item"></param>
        private void Remove_tabPatientsAttachments(object item)
        {
            patientsattachments patientsattachment = (patientsattachments)item;
            if (!DeleteFile(_patientsAttachmentsdir + "\\" + patientsattachment.patients_id + "\\" + patientsattachment.patientsattachmentstypes_id + "\\" + patientsattachments_filenameTextBox.Text, true))
                return;

            DGUIGHFData.Remove<patientsattachments, DentneDModel>(_dentnedModel.PatientsAttachments, item);
        }

        /// <summary>
        /// New tab button handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_tabPatientsAttachments_new_Click(object sender, EventArgs e)
        {
            if (vPatientsBindingSource.Current != null)
            {
                if (AddClick(tabElement_tabPatientsAttachments))
                {
                    ((patientsattachments)patientsattachmentsBindingSource.Current).patients_id = (((DataRowView)vPatientsBindingSource.Current).Row).Field<int>("patients_id");
                    ((patientsattachments)patientsattachmentsBindingSource.Current).patientsattachments_date = DateTime.Now;
                    patientsattachmentsBindingSource.ResetBindings(true);

                    button_tabPatientsAttachments_filepathselect.Enabled = false;
                    button_tabPatientsAttachments_filepathdelete.Enabled = false;
                    patientsattachments_filenameTextBox.Enabled = false;
                }
            }
        }

        /// <summary>
        /// Edit tab button handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_tabPatientsAttachments_edit_Click(object sender, EventArgs e)
        {
            if (vPatientsBindingSource.Current != null)
            {
                if (UpdateClick(tabElement_tabPatientsAttachments))
                {
                    patientsattachmentstypes_idComboBox.Enabled = false;
                }
            }
        }
        
        /// <summary>
        /// File attachment delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_tabPatientsAttachments_filepathdelete_Click(object sender, EventArgs e)
        {
            string patients_id = (((patientsattachments)patientsattachmentsBindingSource.Current).patients_id).ToString();
            if (!String.IsNullOrEmpty(patients_id))
            {
                string patientsattachmentstypes_id = (((patientsattachments)patientsattachmentsBindingSource.Current).patientsattachmentstypes_id).ToString();
                if (!String.IsNullOrEmpty(patientsattachmentstypes_id))
                {
                    if (patientsattachments_filenameTextBox.Text != "")
                    {
                        if (!DeleteFile(_patientsAttachmentsdir + "\\" + patients_id + "\\" + patientsattachmentstypes_id + "\\" + patientsattachments_filenameTextBox.Text, true))
                            return;
                    }
                }
            }
        }

        /// <summary>
        /// File attachment new
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_tabPatientsAttachments_filepathselect_Click(object sender, EventArgs e)
        {
            string patients_id = (((patientsattachments)patientsattachmentsBindingSource.Current).patients_id).ToString();
            if (!String.IsNullOrEmpty(patients_id))
            {
                string patientsattachmentstypes_id = (((patientsattachments)patientsattachmentsBindingSource.Current).patientsattachmentstypes_id).ToString();
                if (!String.IsNullOrEmpty(patientsattachmentstypes_id))
                {
                    string patientsAttachmentsdir = _patientsAttachmentsdir + "\\" + patients_id + "\\" + patientsattachmentstypes_id;
                    using (OpenFileDialog openFileDialog = new OpenFileDialog())
                    {
                        openFileDialog.Title = "Select a file";
                        openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                        openFileDialog.Filter = "JPEG|*.jpg|ZIP|*.zip";
                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            if (!Directory.Exists(patientsAttachmentsdir))
                                Directory.CreateDirectory(patientsAttachmentsdir);

                            //delete old file
                            if (!DeleteFile(_patientsAttachmentsdir + "\\" + patients_id + "\\" + patientsattachmentstypes_id + "\\" + patientsattachments_filenameTextBox.Text, true))
                                return;                       

                            try
                            {
                                //build a new file
                                string destinationFilePath = patientsAttachmentsdir + "\\" + Path.GetFileName(openFileDialog.FileName);
                                string extention = Path.GetExtension(openFileDialog.FileName);
                                destinationFilePath = FindRandomFileName(patientsAttachmentsdir, null, extention.Substring(1, extention.Length - 1));
                                File.Copy(openFileDialog.FileName, destinationFilePath);
                                patientsattachments_filenameTextBox.Text = Path.GetFileName(destinationFilePath);
                            }
                            catch
                            {
                                MessageBox.Show("Error copying file to folder.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// File attachment open folder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_tabPatientsAttachments_filepathopenfolder_Click(object sender, EventArgs e)
        {
            string patients_id = (((patientsattachments)patientsattachmentsBindingSource.Current).patients_id).ToString();
            if (!String.IsNullOrEmpty(patients_id))
            {
                string patientsattachmentstypes_id = (((patientsattachments)patientsattachmentsBindingSource.Current).patientsattachmentstypes_id).ToString();
                if (!String.IsNullOrEmpty(patientsattachmentstypes_id))
                {
                    if (patientsattachments_filenameTextBox.Text != "")
                    {
                        string patientsAttachmentsdir = _patientsAttachmentsdir + "\\" + patients_id + "\\" + patientsattachmentstypes_id;
                        if (File.Exists(patientsAttachmentsdir + "\\" + patientsattachments_filenameTextBox.Text))
                        {
                            Process.Start("explorer.exe", patientsAttachmentsdir);
                        }
                    }                    
                }
            }
        }

        /// <summary>
        /// Combobox autocomplete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void patientsattachmentstypes_idComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            DGUIGHFUtilsUI.DGComboBoxAutoComplete.OnKeyPress((ComboBox)sender, e);
        }

        #endregion


        #region tabInvoices

        /// <summary>
        /// Get tab list DataSource
        /// </summary>
        /// <returns></returns>
        private object GetDataSourceList_tabInvoices()
        {
            object ret = null;

            int patients_id = -1;
            if (vPatientsBindingSource.Current != null)
            {
                patients_id = (((DataRowView)vPatientsBindingSource.Current).Row).Field<int>("patients_id");
            }

            //update totals
            double payedtotalnum = Convert.ToDouble(_dentnedModel.Invoices.List(r => r.patients_id == patients_id && r.invoices_ispaid).Sum(r => r.invoices_total));
            double invoicestotalnum = Convert.ToDouble(_dentnedModel.Invoices.List(r => r.patients_id == patients_id).Sum(r => r.invoices_total));
            double invoiceslefttotalnum = Convert.ToDouble(_dentnedModel.Invoices.List(r => r.patients_id == patients_id && !r.invoices_ispaid).Sum(r => r.invoices_total));
            label_tabInvoices_payedtotalnum.Text = String.Format("{0:0.00}", payedtotalnum);
            label_tabInvoices_invoicestotalnum.Text = String.Format("{0:0.00}", invoicestotalnum);
            label_tabInvoices_invoiceslefttotalnum.Text = String.Format("{0:0.00}", invoiceslefttotalnum);

            IEnumerable<VPatientsInvoices> vPatientsInvoices =
            _dentnedModel.Invoices.List(r => r.patients_id == patients_id).Select(
            r => new VPatientsInvoices
            {
                invoices_id = r.invoices_id,
                date = r.invoices_date,
                doctor = (r.doctors_id != null ? _dentnedModel.Doctors.Find(r.doctors_id).doctors_surname + " " + _dentnedModel.Doctors.Find(r.doctors_id).doctors_name : ""),
                number = r.invoices_number,
                total = (double)r.invoices_total,
                ispayed = r.invoices_ispaid
            }).ToList();

            ret = DGDataTableUtils.ToDataTable<VPatientsInvoices>(vPatientsInvoices);

            return ret;
        }

        /// <summary>
        /// Tab Datagrid filter handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void advancedDataGridView_tabInvoices_list_FilterStringChanged(object sender, EventArgs e)
        {
            vPatientsInvoicesBindingSource.Filter = advancedDataGridView_tabInvoices_list.FilterString;
        }

        /// <summary>
        /// Tab Datagrid sort handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void advancedDataGridView_tabInvoices_list_SortStringChanged(object sender, EventArgs e)
        {
            vPatientsInvoicesBindingSource.Sort = advancedDataGridView_tabInvoices_list.SortString;
        }

        /// <summary>
        /// Load the tab DataSource
        /// </summary>
        /// <returns></returns>
        private object GetDataSourceEdit_tabInvoices()
        {
            return null;
        }

        /// <summary>
        /// Invoices button view click handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_tabInvoices_view_Click(object sender, EventArgs e)
        {
            if (vPatientsInvoicesBindingSource.Current != null)
            {
                int invoices_id = -1;
                if (vPatientsInvoicesBindingSource.Current != null)
                {
                    invoices_id = (((DataRowView)vPatientsInvoicesBindingSource.Current).Row).Field<int>("invoices_id");
                }

                if (invoices_id != -1)
                {

                }
            }
        }

        #endregion


        #region tabEstimates

        /// <summary>
        /// Get tab list DataSource
        /// </summary>
        /// <returns></returns>
        private object GetDataSourceList_tabEstimates()
        {
            object ret = null;

            int patients_id = -1;
            if (vPatientsBindingSource.Current != null)
            {
                patients_id = (((DataRowView)vPatientsBindingSource.Current).Row).Field<int>("patients_id");
            }

            //update totals
            double invoicedtotalnum = Convert.ToDouble(_dentnedModel.Estimates.List(r => r.patients_id == patients_id && r.invoices_id == null).Sum(r => r.estimates_total));
            double estimatestotalnum = Convert.ToDouble(_dentnedModel.Estimates.List(r => r.patients_id == patients_id).Sum(r => r.estimates_total));
            double estimateslefttotalnum = Convert.ToDouble(_dentnedModel.Estimates.List(r => r.patients_id == patients_id && r.invoices_id != null).Sum(r => r.estimates_total));
            label_tabEstimates_invoicedtotalnum.Text = String.Format("{0:0.00}", invoicedtotalnum);
            label_tabEstimates_estimatestotalnum.Text = String.Format("{0:0.00}", estimatestotalnum);
            label_tabEstimates_estimateslefttotalnum.Text = String.Format("{0:0.00}", estimateslefttotalnum);

            IEnumerable<VPatientsEstimates> vPatientsEstimates =
            _dentnedModel.Estimates.List(r => r.patients_id == patients_id).Select(
            r => new VPatientsEstimates
            {
                estimates_id = r.estimates_id,
                date = r.estimates_date,
                doctor = (r.doctors_id != null ? _dentnedModel.Doctors.Find(r.doctors_id).doctors_surname + " " + _dentnedModel.Doctors.Find(r.doctors_id).doctors_name : ""),
                number = r.estimates_number,
                total = (double)r.estimates_total,
                isinvoiced = (r.invoices_id != null ? true : false)
            }).ToList();

            ret = DGDataTableUtils.ToDataTable<VPatientsEstimates>(vPatientsEstimates);

            return ret;
        }

        /// <summary>
        /// Tab Datagrid filter handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void advancedDataGridView_tabEstimates_list_FilterStringChanged(object sender, EventArgs e)
        {
            vPatientsEstimatesBindingSource.Filter = advancedDataGridView_tabEstimates_list.FilterString;
        }

        /// <summary>
        /// Tab Datagrid sort handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void advancedDataGridView_tabEstimates_list_SortStringChanged(object sender, EventArgs e)
        {
            vPatientsEstimatesBindingSource.Sort = advancedDataGridView_tabEstimates_list.SortString;
        }

        /// <summary>
        /// Load the tab DataSource
        /// </summary>
        /// <returns></returns>
        private object GetDataSourceEdit_tabEstimates()
        {
            return null;
        }

        /// <summary>
        /// Estimates button view click handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_tabEstimates_view_Click(object sender, EventArgs e)
        {
            if (vPatientsEstimatesBindingSource.Current != null)
            {
                int estimates_id = -1;
                if (vPatientsEstimatesBindingSource.Current != null)
                {
                    estimates_id = (((DataRowView)vPatientsEstimatesBindingSource.Current).Row).Field<int>("estimates_id");
                }

                if (estimates_id != -1)
                {

                }
            }
        }

        #endregion


        #region tabPatientsNotes

        /// <summary>
        /// Get tab list DataSource
        /// </summary>
        /// <returns></returns>
        private object GetDataSourceList_tabPatientsNotes()
        {
            object ret = null;

            int patients_id = -1;
            if (vPatientsBindingSource.Current != null)
            {
                patients_id = (((DataRowView)vPatientsBindingSource.Current).Row).Field<int>("patients_id");
            }

            IEnumerable<VPatientsNotes> vPatientsNotes =
            _dentnedModel.PatientsNotes.List(r => r.patients_id == patients_id).Select(
            r => new VPatientsNotes
            {
                patientsnotes_id = r.patientsnotes_id,
                date = r.patientsnotes_date,
                note = (r.patientsnotes_text.Length > MaxRowValueLength ? r.patientsnotes_text.Substring(0, MaxRowValueLength) + "..." : r.patientsnotes_text)
            }).ToList();

            ret = DGDataTableUtils.ToDataTable<VPatientsNotes>(vPatientsNotes);

            return ret;
        }

        /// <summary>
        /// Tab Datagrid filter handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void advancedDataGridView_tabPatientsNotes_list_FilterStringChanged(object sender, EventArgs e)
        {
            vPatientsNotesBindingSource.Filter = advancedDataGridView_tabPatientsNotes_list.FilterString;
        }

        /// <summary>
        /// Tab Datagrid sort handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void advancedDataGridView_tabPatientsNotes_list_SortStringChanged(object sender, EventArgs e)
        {
            vPatientsNotesBindingSource.Sort = advancedDataGridView_tabPatientsNotes_list.SortString;
        }

        /// <summary>
        /// Load the tab DataSource
        /// </summary>
        /// <returns></returns>
        private object GetDataSourceEdit_tabPatientsNotes()
        {
            return DGUIGHFData.LoadEntityFromCurrentBindingSource<patientsnotes, DentneDModel>(_dentnedModel.PatientsNotes, vPatientsNotesBindingSource, new string[] { "patientsnotes_id" });
        }

        /// <summary>
        /// Do actions after Save
        /// </summary>
        /// <param name="item"></param>
        private void AfterSaveAction_tabPatientsNotes(object item)
        {
            DGUIGHFData.SetBindingSourcePosition<patientsnotes, DentneDModel>(_dentnedModel.PatientsNotes, item, vPatientsNotesBindingSource);
        }

        /// <summary>
        /// Add an item
        /// </summary>
        /// <param name="item"></param>
        private void Add_tabPatientsNotes(object item)
        {
            DGUIGHFData.Add<patientsnotes, DentneDModel>(_dentnedModel.PatientsNotes, item);
        }

        /// <summary>
        /// Update an item
        /// </summary>
        /// <param name="item"></param>
        private void Update_tabPatientsNotes(object item)
        {
            DGUIGHFData.Update<patientsnotes, DentneDModel>(_dentnedModel.PatientsNotes, item);
        }

        /// <summary>
        /// Remove an item
        /// </summary>
        /// <param name="item"></param>
        private void Remove_tabPatientsNotes(object item)
        {
            DGUIGHFData.Remove<patientsnotes, DentneDModel>(_dentnedModel.PatientsNotes, item);
        }

        /// <summary>
        /// New tab button handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_tabPatientsNotes_new_Click(object sender, EventArgs e)
        {
            if (vPatientsBindingSource.Current != null)
            {
                if (AddClick(tabElement_tabPatientsNotes))
                {
                    ((patientsnotes)patientsnotesBindingSource.Current).patients_id = (((DataRowView)vPatientsBindingSource.Current).Row).Field<int>("patients_id");
                    ((patientsnotes)patientsnotesBindingSource.Current).patientsnotes_date = DateTime.Now;
                    patientsnotesBindingSource.ResetBindings(true);
                }
            }
        }

        #endregion
               
    }
}
