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
    public partial class FormPatientsAttachmentsTypes : DGUIGHFForm
    {
        private DentneDModel _dentnedModel = null;

        private TabElement tabElement_tabPatientsAttachmentsTypes = new TabElement();

        /// <summary>
        /// Constructor
        /// </summary>
        public FormPatientsAttachmentsTypes()
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
            BindingSourceMain = vPatientsAttachmentsTypesBindingSource;
            GetDataSourceMain = GetDataSource_main;

            //set Main TabControl
            TabControlMain = tabControl_main;

            //set Main Panels
            PanelFiltersMain = null;
            PanelListMain = panel_list;
            PanelsExtraMain = null;

            //set tabPatientsAttachmentsTypes
            tabElement_tabPatientsAttachmentsTypes = new TabElement()
            {
                TabPageElement = tabPage_tabPatientsAttachmentsTypes,
                ElementItem = new TabElement.TabElementItem()
                {
                    PanelData = panel_tabPatientsAttachmentsTypes_data,
                    PanelActions = panel_tabPatientsAttachmentsTypes_actions,
                    PanelUpdates = panel_tabPatientsAttachmentsTypes_updates,

                    BindingSourceList = vPatientsAttachmentsTypesBindingSource,
                    GetDataSourceList = GetDataSource_main,

                    BindingSourceEdit = patientsattachmentstypesBindingSource,
                    GetDataSourceEdit = GetDataSourceEdit_tabPatientsAttachmentsTypes,
                    AfterSaveAction = AfterSaveAction_tabPatientsAttachmentsTypes,

                    AddButton = button_tabPatientsAttachmentsTypes_new,
                    UpdateButton = button_tabPatientsAttachmentsTypes_edit,
                    RemoveButton = button_tabPatientsAttachmentsTypes_delete,
                    SaveButton = button_tabPatientsAttachmentsTypes_save,
                    CancelButton = button_tabPatientsAttachmentsTypes_cancel,

                    Add = Add_tabPatientsAttachmentsTypes,
                    Update = Update_tabPatientsAttachmentsTypes,
                    Remove = Remove_tabPatientsAttachmentsTypes
                }
            };

            //set Elements
            TabElements.Add(tabElement_tabPatientsAttachmentsTypes);
        }

        /// <summary>
        /// Loader
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormPatientsAttachmentsTypes_Load(object sender, EventArgs e)
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
            IEnumerable<VPatientsAttachmentsTypes> vPatientsAttachmentsTypes =
                _dentnedModel.PatientsAttachmentsTypes.List().Select(
                r => new VPatientsAttachmentsTypes
                {
                    patientsattachmentstypes_id = r.patientsattachmentstypes_id,
                    name = r.patientsattachmentstypes_name
                }).ToList();

            return DGDataTableUtils.ToDataTable<VPatientsAttachmentsTypes>(vPatientsAttachmentsTypes);
        }

        /// <summary>
        /// Main Datagrid filter handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void advancedDataGridView_main_FilterStringChanged(object sender, EventArgs e)
        {
            vPatientsAttachmentsTypesBindingSource.Filter = advancedDataGridView_main.FilterString;
        }

        /// <summary>
        /// Main Datagrid sort handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void advancedDataGridView_main_SortStringChanged(object sender, EventArgs e)
        {
            vPatientsAttachmentsTypesBindingSource.Sort = advancedDataGridView_main.SortString;
        }


        #region tabPatientsAttachmentsTypes

        /// <summary>
        /// Load the tab DataSource
        /// </summary>
        /// <returns></returns>
        private object GetDataSourceEdit_tabPatientsAttachmentsTypes()
        {
            return DGUIGHFData.LoadEntityFromCurrentBindingSource<patientsattachmentstypes, DentneDModel>(_dentnedModel.PatientsAttachmentsTypes, vPatientsAttachmentsTypesBindingSource, new string[] { "patientsattachmentstypes_id" });
        }

        /// <summary>
        /// Do actions after Save
        /// </summary>
        /// <param name="item"></param>
        private void AfterSaveAction_tabPatientsAttachmentsTypes(object item)
        {
            DGUIGHFData.SetBindingSourcePosition<patientsattachmentstypes, DentneDModel>(_dentnedModel.PatientsAttachmentsTypes, item, vPatientsAttachmentsTypesBindingSource);
        }

        /// <summary>
        /// Add an item
        /// </summary>
        /// <param name="item"></param>
        private void Add_tabPatientsAttachmentsTypes(object item)
        {
            DGUIGHFData.Add<patientsattachmentstypes, DentneDModel>(_dentnedModel.PatientsAttachmentsTypes, item);
        }

        /// <summary>
        /// Update an item
        /// </summary>
        /// <param name="item"></param>
        private void Update_tabPatientsAttachmentsTypes(object item)
        {
            DGUIGHFData.Update<patientsattachmentstypes, DentneDModel>(_dentnedModel.PatientsAttachmentsTypes, item);
        }

        /// <summary>
        /// Remove an item
        /// </summary>
        /// <param name="item"></param>
        private void Remove_tabPatientsAttachmentsTypes(object item)
        {
            DGUIGHFData.Remove<patientsattachmentstypes, DentneDModel>(_dentnedModel.PatientsAttachmentsTypes, item);
        }

        #endregion


    }
}
