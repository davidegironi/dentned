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

namespace DG.DentneD.Forms
{
    public partial class FormMedicalrecordsTypes : DGUIGHFForm
    {
        private DentneDModel _dentnedModel = null;

        private TabElement tabElement_tabMedicalrecordsTypes = new TabElement();

        /// <summary>
        /// Constructor
        /// </summary>
        public FormMedicalrecordsTypes()
        {
            InitializeComponent();

            Initialize(Program.uighfApplication);
            
            _dentnedModel = new DentneDModel();
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
            BindingSourceMain = vMedicalrecordsTypesBindingSource;
            GetDataSourceMain = GetDataSource_main;

            //set Main TabControl
            TabControlMain = tabControl_main;

            //set Main Panels
            PanelFiltersMain = null;
            PanelListMain = panel_list;
            PanelsExtraMain = null;

            //set tabMedicalrecordsTypes
            tabElement_tabMedicalrecordsTypes = new TabElement()
            {
                TabPageElement = tabPage_tabMedicalrecordsTypes,
                ElementItem = new TabElement.TabElementItem()
                {
                    PanelData = panel_tabMedicalrecordsTypes_data,
                    PanelActions = panel_tabMedicalrecordsTypes_actions,
                    PanelUpdates = panel_tabMedicalrecordsTypes_updates,

                    BindingSourceList = vMedicalrecordsTypesBindingSource,
                    GetDataSourceList = GetDataSource_main,

                    BindingSourceEdit = medicalrecordstypesBindingSource,
                    GetDataSourceEdit = GetDataSourceEdit_tabMedicalrecordsTypes,
                    AfterSaveAction = AfterSaveAction_tabMedicalrecordsTypes,

                    AddButton = button_tabMedicalrecordsTypes_new,
                    UpdateButton = button_tabMedicalrecordsTypes_edit,
                    RemoveButton = button_tabMedicalrecordsTypes_delete,
                    SaveButton = button_tabMedicalrecordsTypes_save,
                    CancelButton = button_tabMedicalrecordsTypes_cancel,

                    Add = Add_tabMedicalrecordsTypes,
                    Update = Update_tabMedicalrecordsTypes,
                    Remove = Remove_tabMedicalrecordsTypes
                }
            };

            //set Elements
            TabElements.Add(tabElement_tabMedicalrecordsTypes);
        }

        /// <summary>
        /// Loader
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMedicalrecordsTypes_Load(object sender, EventArgs e)
        {
            ReloadView();

            advancedDataGridView_main.SortASC(advancedDataGridView_main.Columns[1]);
        }

        /// <summary>
        /// Get main list DataSource
        /// </summary>
        /// <returns></returns>
        private object GetDataSource_main()
        {
            IEnumerable<VMedicalrecordsTypes> vMedicalrecordsTypes =
                _dentnedModel.MedicalrecordsTypes.List().Select(
                r => new VMedicalrecordsTypes
                {
                    medicalrecordstypes_id = r.medicalrecordstypes_id,
                    name = r.medicalrecordstypes_name
                }).ToList();

            return DGDataTableUtils.ToDataTable<VMedicalrecordsTypes>(vMedicalrecordsTypes);
        }

        /// <summary>
        /// Main Datagrid filter handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void advancedDataGridView_main_FilterStringChanged(object sender, EventArgs e)
        {
            vMedicalrecordsTypesBindingSource.Filter = advancedDataGridView_main.FilterString;
        }

        /// <summary>
        /// Main Datagrid sort handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void advancedDataGridView_main_SortStringChanged(object sender, EventArgs e)
        {
            vMedicalrecordsTypesBindingSource.Sort = advancedDataGridView_main.SortString;
        }


        #region tabMedicalrecordsTypes

        /// <summary>
        /// Load the tab DataSource
        /// </summary>
        /// <returns></returns>
        private object GetDataSourceEdit_tabMedicalrecordsTypes()
        {
            return DGUIGHFData.LoadEntityFromCurrentBindingSource<medicalrecordstypes, DentneDModel>(_dentnedModel.MedicalrecordsTypes, vMedicalrecordsTypesBindingSource, new string[] { "medicalrecordstypes_id" });
        }

        /// <summary>
        /// Do actions after Save
        /// </summary>
        /// <param name="item"></param>
        private void AfterSaveAction_tabMedicalrecordsTypes(object item)
        {
            DGUIGHFData.SetBindingSourcePosition<medicalrecordstypes, DentneDModel>(_dentnedModel.MedicalrecordsTypes, item, vMedicalrecordsTypesBindingSource);
        }

        /// <summary>
        /// Add an item
        /// </summary>
        /// <param name="item"></param>
        private void Add_tabMedicalrecordsTypes(object item)
        {
            DGUIGHFData.Add<medicalrecordstypes, DentneDModel>(_dentnedModel.MedicalrecordsTypes, item);
        }

        /// <summary>
        /// Update an item
        /// </summary>
        /// <param name="item"></param>
        private void Update_tabMedicalrecordsTypes(object item)
        {
            DGUIGHFData.Update<medicalrecordstypes, DentneDModel>(_dentnedModel.MedicalrecordsTypes, item);
        }

        /// <summary>
        /// Remove an item
        /// </summary>
        /// <param name="item"></param>
        private void Remove_tabMedicalrecordsTypes(object item)
        {
            DGUIGHFData.Remove<medicalrecordstypes, DentneDModel>(_dentnedModel.MedicalrecordsTypes, item);
        }

        #endregion


    }
}
