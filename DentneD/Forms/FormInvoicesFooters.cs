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
    public partial class FormInvoicesFooters : DGUIGHFForm
    {
        private DentneDModel _dentnedModel = null;

        private TabElement tabElement_tabInvoicesFooters = new TabElement();

        /// <summary>
        /// Constructor
        /// </summary>
        public FormInvoicesFooters()
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
            LanguageHelper.AddComponent(invoicesfootersidDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(nameDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(isdefaultDataGridViewCheckBoxColumn, this.GetType().Name, "HeaderText");
            //tabInvoicesFooters
            LanguageHelper.AddComponent(tabPage_tabInvoicesFooters);
            LanguageHelper.AddComponent(button_tabInvoicesFooters_new);
            LanguageHelper.AddComponent(button_tabInvoicesFooters_edit);
            LanguageHelper.AddComponent(button_tabInvoicesFooters_delete);
            LanguageHelper.AddComponent(button_tabInvoicesFooters_save);
            LanguageHelper.AddComponent(button_tabInvoicesFooters_cancel);
            LanguageHelper.AddComponent(invoicesfooters_idLabel);
            LanguageHelper.AddComponent(invoicesfooters_nameLabel);
            LanguageHelper.AddComponent(invoicesfooters_doctextLabel);
            LanguageHelper.AddComponent(invoicesfooters_isdefaultCheckBox);
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
            BindingSourceMain = vInvoicesFootersBindingSource;
            GetDataSourceMain = GetDataSource_main;

            //set Main TabControl
            TabControlMain = tabControl_main;

            //set Main Panels
            PanelFiltersMain = null;
            PanelListMain = panel_list;
            PanelsExtraMain = null;

            //set tabInvoicesFooters
            tabElement_tabInvoicesFooters = new TabElement()
            {
                TabPageElement = tabPage_tabInvoicesFooters,
                ElementItem = new TabElement.TabElementItem()
                {
                    PanelData = panel_tabInvoicesFooters_data,
                    PanelActions = panel_tabInvoicesFooters_actions,
                    PanelUpdates = panel_tabInvoicesFooters_updates,

                    BindingSourceList = vInvoicesFootersBindingSource,
                    GetDataSourceList = GetDataSource_main,

                    BindingSourceEdit = invoicesfootersBindingSource,
                    GetDataSourceEdit = GetDataSourceEdit_tabInvoicesFooters,
                    AfterSaveAction = AfterSaveAction_tabInvoicesFooters,

                    AddButton = button_tabInvoicesFooters_new,
                    UpdateButton = button_tabInvoicesFooters_edit,
                    RemoveButton = button_tabInvoicesFooters_delete,
                    SaveButton = button_tabInvoicesFooters_save,
                    CancelButton = button_tabInvoicesFooters_cancel,

                    Add = Add_tabInvoicesFooters,
                    Update = Update_tabInvoicesFooters,
                    Remove = Remove_tabInvoicesFooters
                }
            };

            //set Elements
            TabElements.Add(tabElement_tabInvoicesFooters);
        }

        /// <summary>
        /// Loader
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormInvoicesFooters_Load(object sender, EventArgs e)
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
            IEnumerable<VInvoicesFooters> vInvoicesFooters =
                _dentnedModel.InvoicesFooters.List().Select(
                r => new VInvoicesFooters
                {
                    invoicesfooters_id = r.invoicesfooters_id,
                    name = r.invoicesfooters_name
                }).ToList();

            return DGDataTableUtils.ToDataTable<VInvoicesFooters>(vInvoicesFooters);
        }

        /// <summary>
        /// Main Datagrid filter handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void advancedDataGridView_main_FilterStringChanged(object sender, EventArgs e)
        {
            vInvoicesFootersBindingSource.Filter = advancedDataGridView_main.FilterString;
        }

        /// <summary>
        /// Main Datagrid sort handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void advancedDataGridView_main_SortStringChanged(object sender, EventArgs e)
        {
            vInvoicesFootersBindingSource.Sort = advancedDataGridView_main.SortString;
        }


        #region tabInvoicesFooters

        /// <summary>
        /// Load the tab DataSource
        /// </summary>
        /// <returns></returns>
        private object GetDataSourceEdit_tabInvoicesFooters()
        {
            return DGUIGHFData.LoadEntityFromCurrentBindingSource<invoicesfooters, DentneDModel>(_dentnedModel.InvoicesFooters, vInvoicesFootersBindingSource, new string[] { "invoicesfooters_id" });
        }

        /// <summary>
        /// Do actions after Save
        /// </summary>
        /// <param name="item"></param>
        private void AfterSaveAction_tabInvoicesFooters(object item)
        {
            DGUIGHFData.SetBindingSourcePosition<invoicesfooters, DentneDModel>(_dentnedModel.InvoicesFooters, item, vInvoicesFootersBindingSource);
        }

        /// <summary>
        /// Add an item
        /// </summary>
        /// <param name="item"></param>
        private void Add_tabInvoicesFooters(object item)
        {
            DGUIGHFData.Add<invoicesfooters, DentneDModel>(_dentnedModel.InvoicesFooters, item);
        }

        /// <summary>
        /// Update an item
        /// </summary>
        /// <param name="item"></param>
        private void Update_tabInvoicesFooters(object item)
        {
            DGUIGHFData.Update<invoicesfooters, DentneDModel>(_dentnedModel.InvoicesFooters, item);
        }

        /// <summary>
        /// Remove an item
        /// </summary>
        /// <param name="item"></param>
        private void Remove_tabInvoicesFooters(object item)
        {
            DGUIGHFData.Remove<invoicesfooters, DentneDModel>(_dentnedModel.InvoicesFooters, item);
        }

        #endregion

    }
}
