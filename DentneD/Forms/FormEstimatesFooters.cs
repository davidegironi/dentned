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
    public partial class FormEstimatesFooters : DGUIGHFForm
    {
        private DentneDModel _dentnedModel = null;

        private TabElement tabElement_tabEstimatesFooters = new TabElement();

        /// <summary>
        /// Constructor
        /// </summary>
        public FormEstimatesFooters()
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
            BindingSourceMain = vEstimatesFootersBindingSource;
            GetDataSourceMain = GetDataSource_main;

            //set Main TabControl
            TabControlMain = tabControl_main;

            //set Main Panels
            PanelFiltersMain = null;
            PanelListMain = panel_list;
            PanelsExtraMain = null;

            //set tabEstimatesFooters
            tabElement_tabEstimatesFooters = new TabElement()
            {
                TabPageElement = tabPage_tabEstimatesFooters,
                ElementItem = new TabElement.TabElementItem()
                {
                    PanelData = panel_tabEstimatesFooters_data,
                    PanelActions = panel_tabEstimatesFooters_actions,
                    PanelUpdates = panel_tabEstimatesFooters_updates,

                    BindingSourceList = vEstimatesFootersBindingSource,
                    GetDataSourceList = GetDataSource_main,

                    BindingSourceEdit = estimatesfootersBindingSource,
                    GetDataSourceEdit = GetDataSourceEdit_tabEstimatesFooters,
                    AfterSaveAction = AfterSaveAction_tabEstimatesFooters,

                    AddButton = button_tabEstimatesFooters_new,
                    UpdateButton = button_tabEstimatesFooters_edit,
                    RemoveButton = button_tabEstimatesFooters_delete,
                    SaveButton = button_tabEstimatesFooters_save,
                    CancelButton = button_tabEstimatesFooters_cancel,

                    Add = Add_tabEstimatesFooters,
                    Update = Update_tabEstimatesFooters,
                    Remove = Remove_tabEstimatesFooters
                }
            };

            //set Elements
            TabElements.Add(tabElement_tabEstimatesFooters);
        }

        /// <summary>
        /// Loader
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormEstimatesFooters_Load(object sender, EventArgs e)
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
            IEnumerable<VEstimatesFooters> vEstimatesFooters =
                _dentnedModel.EstimatesFooters.List().Select(
                r => new VEstimatesFooters
                {
                    estimatesfooters_id = r.estimatesfooters_id,
                    name = r.estimatesfooters_name
                }).ToList();

            return DGDataTableUtils.ToDataTable<VEstimatesFooters>(vEstimatesFooters);
        }

        /// <summary>
        /// Main Datagrid filter handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void advancedDataGridView_main_FilterStringChanged(object sender, EventArgs e)
        {
            vEstimatesFootersBindingSource.Filter = advancedDataGridView_main.FilterString;
        }

        /// <summary>
        /// Main Datagrid sort handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void advancedDataGridView_main_SortStringChanged(object sender, EventArgs e)
        {
            vEstimatesFootersBindingSource.Sort = advancedDataGridView_main.SortString;
        }


        #region tabEstimatesFooters

        /// <summary>
        /// Load the tab DataSource
        /// </summary>
        /// <returns></returns>
        private object GetDataSourceEdit_tabEstimatesFooters()
        {
            return DGUIGHFData.LoadEntityFromCurrentBindingSource<estimatesfooters, DentneDModel>(_dentnedModel.EstimatesFooters, vEstimatesFootersBindingSource, new string[] { "estimatesfooters_id" });
        }

        /// <summary>
        /// Do actions after Save
        /// </summary>
        /// <param name="item"></param>
        private void AfterSaveAction_tabEstimatesFooters(object item)
        {
            DGUIGHFData.SetBindingSourcePosition<estimatesfooters, DentneDModel>(_dentnedModel.EstimatesFooters, item, vEstimatesFootersBindingSource);
        }

        /// <summary>
        /// Add an item
        /// </summary>
        /// <param name="item"></param>
        private void Add_tabEstimatesFooters(object item)
        {
            DGUIGHFData.Add<estimatesfooters, DentneDModel>(_dentnedModel.EstimatesFooters, item);
        }

        /// <summary>
        /// Update an item
        /// </summary>
        /// <param name="item"></param>
        private void Update_tabEstimatesFooters(object item)
        {
            DGUIGHFData.Update<estimatesfooters, DentneDModel>(_dentnedModel.EstimatesFooters, item);
        }

        /// <summary>
        /// Remove an item
        /// </summary>
        /// <param name="item"></param>
        private void Remove_tabEstimatesFooters(object item)
        {
            DGUIGHFData.Remove<estimatesfooters, DentneDModel>(_dentnedModel.EstimatesFooters, item);
        }

        #endregion


    }
}
