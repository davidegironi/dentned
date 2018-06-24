#region License
// Copyright (c) 2015 Davide Gironi
//
// Please refer to LICENSE file for licensing information.
#endregion

using DG.Data.Model.Helpers;
using DG.DentneD.Forms.Objects;
using DG.DentneD.Model;
using DG.DentneD.Model.Entity;
using DG.UI.GHF;
using SMcMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Zuby.ADGV;

namespace DG.DentneD.Forms
{
    public partial class FormTreatmentsPricesLists : DGUIGHFForm
    {
        private DentneDModel _dentnedModel = null;

        private TabElement tabElement_tabTreatmentsPricesLists = new TabElement();

        /// <summary>
        /// Constructor
        /// </summary>
        public FormTreatmentsPricesLists()
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
            LanguageHelper.AddComponent(treatmentspriceslistsidDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(nameDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            //tabTreatmentsPricesLists
            LanguageHelper.AddComponent(tabPage_tabTreatmentsPricesLists);
            LanguageHelper.AddComponent(button_tabTreatmentsPricesLists_new);
            LanguageHelper.AddComponent(button_tabTreatmentsPricesLists_edit);
            LanguageHelper.AddComponent(button_tabTreatmentsPricesLists_delete);
            LanguageHelper.AddComponent(button_tabTreatmentsPricesLists_save);
            LanguageHelper.AddComponent(button_tabTreatmentsPricesLists_cancel);
            LanguageHelper.AddComponent(treatmentspriceslists_idLabel);
            LanguageHelper.AddComponent(treatmentspriceslists_nameLabel);
            LanguageHelper.AddComponent(treatmentspriceslists_multiplierLabel);
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
            BindingSourceMain = vTreatmentsPricesListsBindingSource;
            GetDataSourceMain = GetDataSource_main;

            //set Main TabControl
            TabControlMain = tabControl_main;

            //set Main Panels
            PanelFiltersMain = panel_filters;
            PanelListMain = panel_list;
            PanelsExtraMain = null;

            //set tabTreatmentsPricesLists
            tabElement_tabTreatmentsPricesLists = new TabElement()
            {
                TabPageElement = tabPage_tabTreatmentsPricesLists,
                ElementItem = new TabElement.TabElementItem()
                {
                    PanelData = panel_tabTreatmentsPricesLists_data,
                    PanelActions = panel_tabTreatmentsPricesLists_actions,
                    PanelUpdates = panel_tabTreatmentsPricesLists_updates,

                    ParentBindingSourceList = vTreatmentsPricesListsBindingSource,
                    GetParentDataSourceList = GetDataSource_main,

                    BindingSourceEdit = treatmentspriceslistsBindingSource,
                    GetDataSourceEdit = GetDataSourceEdit_tabTreatmentsPricesLists,
                    AfterSaveAction = AfterSaveAction_tabTreatmentsPricesLists,

                    AddButton = button_tabTreatmentsPricesLists_new,
                    UpdateButton = button_tabTreatmentsPricesLists_edit,
                    RemoveButton = button_tabTreatmentsPricesLists_delete,
                    SaveButton = button_tabTreatmentsPricesLists_save,
                    CancelButton = button_tabTreatmentsPricesLists_cancel,

                    Add = Add_tabTreatmentsPricesLists,
                    Update = Update_tabTreatmentsPricesLists,
                    Remove = Remove_tabTreatmentsPricesLists
                }
            };

            //set Elements
            TabElements.Add(tabElement_tabTreatmentsPricesLists);
        }

        /// <summary>
        /// Loader
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormTreatmentsPricesLists_Load(object sender, EventArgs e)
        {
            IsBindingSourceLoading = true;
            advancedDataGridView_main.SortASC(advancedDataGridView_main.Columns[1]);
            IsBindingSourceLoading = false;

            ReloadView();
        }

        /// <summary>
        /// Get main list DataSource
        /// </summary>
        /// <returns></returns>
        private object GetDataSource_main()
        {
            IEnumerable<VTreatmentsPricesLists> vTreatmentsPricesLists =
                _dentnedModel.TreatmentsPricesLists.List().Select(
                r => new VTreatmentsPricesLists
                {
                    treatmentspriceslists_id = r.treatmentspriceslists_id,
                    name = r.treatmentspriceslists_name
                }).ToList();

            return DGDataTableUtils.ToDataTable<VTreatmentsPricesLists>(vTreatmentsPricesLists);
        }


        #region tabTreatmentsPricesLists

        /// <summary>
        /// Load the tab DataSource
        /// </summary>
        /// <returns></returns>
        private object GetDataSourceEdit_tabTreatmentsPricesLists()
        {
            return DGUIGHFData.LoadEntityFromCurrentBindingSource<treatmentspriceslists, DentneDModel>(_dentnedModel.TreatmentsPricesLists, vTreatmentsPricesListsBindingSource, new string[] { "treatmentspriceslists_id" });
        }

        /// <summary>
        /// Do actions after Save
        /// </summary>
        /// <param name="item"></param>
        private void AfterSaveAction_tabTreatmentsPricesLists(object item)
        {
            DGUIGHFData.SetBindingSourcePosition<treatmentspriceslists, DentneDModel>(_dentnedModel.TreatmentsPricesLists, item, vTreatmentsPricesListsBindingSource);
        }

        /// <summary>
        /// Add an item
        /// </summary>
        /// <param name="item"></param>
        private void Add_tabTreatmentsPricesLists(object item)
        {
            DGUIGHFData.Add<treatmentspriceslists, DentneDModel>(_dentnedModel.TreatmentsPricesLists, item);
        }

        /// <summary>
        /// Update an item
        /// </summary>
        /// <param name="item"></param>
        private void Update_tabTreatmentsPricesLists(object item)
        {
            DGUIGHFData.Update<treatmentspriceslists, DentneDModel>(_dentnedModel.TreatmentsPricesLists, item);
        }

        /// <summary>
        /// Remove an item
        /// </summary>
        /// <param name="item"></param>
        private void Remove_tabTreatmentsPricesLists(object item)
        {
            DGUIGHFData.Remove<treatmentspriceslists, DentneDModel>(_dentnedModel.TreatmentsPricesLists, item);
        }

        #endregion

    }
}
