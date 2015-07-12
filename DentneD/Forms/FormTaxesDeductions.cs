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
    public partial class FormTaxesDeductions : DGUIGHFForm
    {
        private DentneDModel _dentnedModel = null;

        private TabElement tabElement_tabTaxesDeductions = new TabElement();

        /// <summary>
        /// Constructor
        /// </summary>
        public FormTaxesDeductions()
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
            BindingSourceMain = vTaxesDeductionsBindingSource;
            GetDataSourceMain = GetDataSource_main;

            //set Main TabControl
            TabControlMain = tabControl_main;

            //set Main Panels
            PanelFiltersMain = null;
            PanelListMain = panel_list;
            PanelsExtraMain = null;

            //set tabTaxesDeductions
            tabElement_tabTaxesDeductions = new TabElement()
            {
                TabPageElement = tabPage_tabTaxesDeductions,
                ElementItem = new TabElement.TabElementItem()
                {
                    PanelData = panel_tabTaxesDeductions_data,
                    PanelActions = panel_tabTaxesDeductions_actions,
                    PanelUpdates = panel_tabTaxesDeductions_updates,

                    BindingSourceList = vTaxesDeductionsBindingSource,
                    GetDataSourceList = GetDataSource_main,

                    BindingSourceEdit = taxesdeductionsBindingSource,
                    GetDataSourceEdit = GetDataSourceEdit_tabTaxesDeductions,
                    AfterSaveAction = AfterSaveAction_tabTaxesDeductions,

                    AddButton = button_tabTaxesDeductions_new,
                    UpdateButton = button_tabTaxesDeductions_edit,
                    RemoveButton = button_tabTaxesDeductions_delete,
                    SaveButton = button_tabTaxesDeductions_save,
                    CancelButton = button_tabTaxesDeductions_cancel,

                    Add = Add_tabTaxesDeductions,
                    Update = Update_tabTaxesDeductions,
                    Remove = Remove_tabTaxesDeductions
                }
            };

            //set Elements
            TabElements.Add(tabElement_tabTaxesDeductions);
        }

        /// <summary>
        /// Loader
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormTaxesDeductions_Load(object sender, EventArgs e)
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
            IEnumerable<VTaxesDeductions> vTaxesDeductions =
                _dentnedModel.TaxesDeductions.List().Select(
                r => new VTaxesDeductions
                {
                    taxesdeductions_id = r.taxesdeductions_id,
                    name = r.taxesdeductions_name
                }).ToList();

            return DGDataTableUtils.ToDataTable<VTaxesDeductions>(vTaxesDeductions);
        }

        /// <summary>
        /// Main Datagrid filter handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void advancedDataGridView_main_FilterStringChanged(object sender, EventArgs e)
        {
            vTaxesDeductionsBindingSource.Filter = advancedDataGridView_main.FilterString;
        }

        /// <summary>
        /// Main Datagrid sort handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void advancedDataGridView_main_SortStringChanged(object sender, EventArgs e)
        {
            vTaxesDeductionsBindingSource.Sort = advancedDataGridView_main.SortString;
        }


        #region tabTaxesDeductions

        /// <summary>
        /// Load the tab DataSource
        /// </summary>
        /// <returns></returns>
        private object GetDataSourceEdit_tabTaxesDeductions()
        {
            return DGUIGHFData.LoadEntityFromCurrentBindingSource<taxesdeductions, DentneDModel>(_dentnedModel.TaxesDeductions, vTaxesDeductionsBindingSource, new string[] { "taxesdeductions_id" });
        }

        /// <summary>
        /// Do actions after Save
        /// </summary>
        /// <param name="item"></param>
        private void AfterSaveAction_tabTaxesDeductions(object item)
        {
            DGUIGHFData.SetBindingSourcePosition<taxesdeductions, DentneDModel>(_dentnedModel.TaxesDeductions, item, vTaxesDeductionsBindingSource);
        }

        /// <summary>
        /// Add an item
        /// </summary>
        /// <param name="item"></param>
        private void Add_tabTaxesDeductions(object item)
        {
            DGUIGHFData.Add<taxesdeductions, DentneDModel>(_dentnedModel.TaxesDeductions, item);
        }

        /// <summary>
        /// Update an item
        /// </summary>
        /// <param name="item"></param>
        private void Update_tabTaxesDeductions(object item)
        {
            DGUIGHFData.Update<taxesdeductions, DentneDModel>(_dentnedModel.TaxesDeductions, item);
        }

        /// <summary>
        /// Remove an item
        /// </summary>
        /// <param name="item"></param>
        private void Remove_tabTaxesDeductions(object item)
        {
            DGUIGHFData.Remove<taxesdeductions, DentneDModel>(_dentnedModel.TaxesDeductions, item);
        }

        #endregion


    }
}
