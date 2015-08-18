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

namespace DG.DentneD.Forms
{
    public partial class FormTaxes : DGUIGHFForm
    {
        private DentneDModel _dentnedModel = null;

        private TabElement tabElement_tabTaxes = new TabElement();

        /// <summary>
        /// Constructor
        /// </summary>
        public FormTaxes()
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
            LanguageHelper.AddComponent(taxesidDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(nameDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(isdefaultDataGridViewCheckBoxColumn, this.GetType().Name, "HeaderText");
            //tabTaxes
            LanguageHelper.AddComponent(tabPage_tabTaxes);
            LanguageHelper.AddComponent(button_tabTaxes_new);
            LanguageHelper.AddComponent(button_tabTaxes_edit);
            LanguageHelper.AddComponent(button_tabTaxes_delete);
            LanguageHelper.AddComponent(button_tabTaxes_save);
            LanguageHelper.AddComponent(button_tabTaxes_cancel);
            LanguageHelper.AddComponent(taxes_idLabel);
            LanguageHelper.AddComponent(taxes_nameLabel);
            LanguageHelper.AddComponent(taxes_rateLabel);
            LanguageHelper.AddComponent(taxes_isdefaultCheckBox);
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
            BindingSourceMain = vTaxesBindingSource;
            GetDataSourceMain = GetDataSource_main;

            //set Main TabControl
            TabControlMain = tabControl_main;

            //set Main Panels
            PanelFiltersMain = null;
            PanelListMain = panel_list;
            PanelsExtraMain = null;

            //set tabTaxes
            tabElement_tabTaxes = new TabElement()
            {
                TabPageElement = tabPage_tabTaxes,
                ElementItem = new TabElement.TabElementItem()
                {
                    PanelData = panel_tabTaxes_data,
                    PanelActions = panel_tabTaxes_actions,
                    PanelUpdates = panel_tabTaxes_updates,

                    BindingSourceList = vTaxesBindingSource,
                    GetDataSourceList = GetDataSource_main,

                    BindingSourceEdit = taxesBindingSource,
                    GetDataSourceEdit = GetDataSourceEdit_tabTaxes,
                    AfterSaveAction = AfterSaveAction_tabTaxes,

                    AddButton = button_tabTaxes_new,
                    UpdateButton = button_tabTaxes_edit,
                    RemoveButton = button_tabTaxes_delete,
                    SaveButton = button_tabTaxes_save,
                    CancelButton = button_tabTaxes_cancel,

                    Add = Add_tabTaxes,
                    Update = Update_tabTaxes,
                    Remove = Remove_tabTaxes
                }
            };

            //set Elements
            TabElements.Add(tabElement_tabTaxes);
        }

        /// <summary>
        /// Loader
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormTaxes_Load(object sender, EventArgs e)
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
            IEnumerable<VTaxes> vTaxes =
                _dentnedModel.Taxes.List().Select(
                r => new VTaxes
                {
                    taxes_id = r.taxes_id,
                    name = r.taxes_name
                }).ToList();

            return DGDataTableUtils.ToDataTable<VTaxes>(vTaxes);
        }

        /// <summary>
        /// Main Datagrid filter handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void advancedDataGridView_main_FilterStringChanged(object sender, EventArgs e)
        {
            vTaxesBindingSource.Filter = advancedDataGridView_main.FilterString;
        }

        /// <summary>
        /// Main Datagrid sort handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void advancedDataGridView_main_SortStringChanged(object sender, EventArgs e)
        {
            vTaxesBindingSource.Sort = advancedDataGridView_main.SortString;
        }


        #region tabTaxes

        /// <summary>
        /// Load the tab DataSource
        /// </summary>
        /// <returns></returns>
        private object GetDataSourceEdit_tabTaxes()
        {
            return DGUIGHFData.LoadEntityFromCurrentBindingSource<taxes, DentneDModel>(_dentnedModel.Taxes, vTaxesBindingSource, new string[] { "taxes_id" });
        }

        /// <summary>
        /// Do actions after Save
        /// </summary>
        /// <param name="item"></param>
        private void AfterSaveAction_tabTaxes(object item)
        {
            DGUIGHFData.SetBindingSourcePosition<taxes, DentneDModel>(_dentnedModel.Taxes, item, vTaxesBindingSource);
        }

        /// <summary>
        /// Add an item
        /// </summary>
        /// <param name="item"></param>
        private void Add_tabTaxes(object item)
        {
            DGUIGHFData.Add<taxes, DentneDModel>(_dentnedModel.Taxes, item);
        }

        /// <summary>
        /// Update an item
        /// </summary>
        /// <param name="item"></param>
        private void Update_tabTaxes(object item)
        {
            DGUIGHFData.Update<taxes, DentneDModel>(_dentnedModel.Taxes, item);
        }

        /// <summary>
        /// Remove an item
        /// </summary>
        /// <param name="item"></param>
        private void Remove_tabTaxes(object item)
        {
            DGUIGHFData.Remove<taxes, DentneDModel>(_dentnedModel.Taxes, item);
        }

        #endregion

    }
}
