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
    public partial class FormRooms : DGUIGHFForm
    {
        private DentneDModel _dentnedModel = null;

        private TabElement tabElement_tabRooms = new TabElement();

        /// <summary>
        /// Constructor
        /// </summary>
        public FormRooms()
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
            BindingSourceMain = vRoomsBindingSource;
            GetDataSourceMain = GetDataSource_main;

            //set Main TabControl
            TabControlMain = tabControl_main;

            //set Main Panels
            PanelFiltersMain = null;
            PanelListMain = panel_list;
            PanelsExtraMain = null;

            //set tabRooms
            tabElement_tabRooms = new TabElement()
            {
                TabPageElement = tabPage_tabRooms,
                ElementItem = new TabElement.TabElementItem()
                {
                    PanelData = panel_tabRooms_data,
                    PanelActions = panel_tabRooms_actions,
                    PanelUpdates = panel_tabRooms_updates,

                    BindingSourceList = vRoomsBindingSource,
                    GetDataSourceList = GetDataSource_main,

                    BindingSourceEdit = roomsBindingSource,
                    GetDataSourceEdit = GetDataSourceEdit_tabRooms,
                    AfterSaveAction = AfterSaveAction_tabRooms,

                    AddButton = button_tabRooms_new,
                    UpdateButton = button_tabRooms_edit,
                    RemoveButton = button_tabRooms_delete,
                    SaveButton = button_tabRooms_save,
                    CancelButton = button_tabRooms_cancel,

                    Add = Add_tabRooms,
                    Update = Update_tabRooms,
                    Remove = Remove_tabRooms
                }
            };

            //set Elements
            TabElements.Add(tabElement_tabRooms);
        }

        /// <summary>
        /// Loader
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormRooms_Load(object sender, EventArgs e)
        {
            ReloadView();

            IsBindingSourceLoading = true;
            advancedDataGridView_main.SortASC(advancedDataGridView_main.Columns[1]);
            IsBindingSourceLoading = false;
        }

        /// <summary>
        /// Get main list DataSource
        /// </summary>
        /// <returns></returns>
        private object GetDataSource_main()
        {
            IEnumerable<VRooms> vRooms =
                _dentnedModel.Rooms.List().Select(
                r => new VRooms
                {
                    rooms_id = r.rooms_id,
                    name = r.rooms_name
                }).ToList();

            return DGDataTableUtils.ToDataTable<VRooms>(vRooms);
        }

        /// <summary>
        /// Main Datagrid filter handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void advancedDataGridView_main_FilterStringChanged(object sender, EventArgs e)
        {
            vRoomsBindingSource.Filter = advancedDataGridView_main.FilterString;
        }
        
        /// <summary>
        /// Main Datagrid sort handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void advancedDataGridView_main_SortStringChanged(object sender, EventArgs e)
        {
            vRoomsBindingSource.Sort = advancedDataGridView_main.SortString;
        }


        #region tabRooms

        /// <summary>
        /// Load the tab DataSource
        /// </summary>
        /// <returns></returns>
        private object GetDataSourceEdit_tabRooms()
        {
            return DGUIGHFData.LoadEntityFromCurrentBindingSource<rooms, DentneDModel>(_dentnedModel.Rooms, vRoomsBindingSource, new string[] { "rooms_id" });
        }

        /// <summary>
        /// Do actions after Save
        /// </summary>
        /// <param name="item"></param>
        private void AfterSaveAction_tabRooms(object item)
        {
            DGUIGHFData.SetBindingSourcePosition<rooms, DentneDModel>(_dentnedModel.Rooms, item, vRoomsBindingSource);
        }

        /// <summary>
        /// Add an item
        /// </summary>
        /// <param name="item"></param>
        private void Add_tabRooms(object item)
        {
            DGUIGHFData.Add<rooms, DentneDModel>(_dentnedModel.Rooms, item);
        }

        /// <summary>
        /// Update an item
        /// </summary>
        /// <param name="item"></param>
        private void Update_tabRooms(object item)
        {
            DGUIGHFData.Update<rooms, DentneDModel>(_dentnedModel.Rooms, item);
        }

        /// <summary>
        /// Remove an item
        /// </summary>
        /// <param name="item"></param>
        private void Remove_tabRooms(object item)
        {
            DGUIGHFData.Remove<rooms, DentneDModel>(_dentnedModel.Rooms, item);
        }

        #endregion


    }
}
