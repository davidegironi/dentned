#region License
// Copyright (c) 2016 Davide Gironi
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
    public partial class FormPatientsAttributesTypes : DGUIGHFForm
    {
        private DentneDModel _dentnedModel = null;

        private TabElement tabElement_tabPatientsAttributesTypes = new TabElement();

        /// <summary>
        /// Constructor
        /// </summary>
        public FormPatientsAttributesTypes()
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
            LanguageHelper.AddComponent(patientsattributestypesidDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(nameDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            //tabPatientsAttributesTypes
            LanguageHelper.AddComponent(tabPage_tabPatientsAttributesTypes);
            LanguageHelper.AddComponent(button_tabPatientsAttributesTypes_new);
            LanguageHelper.AddComponent(button_tabPatientsAttributesTypes_edit);
            LanguageHelper.AddComponent(button_tabPatientsAttributesTypes_delete);
            LanguageHelper.AddComponent(button_tabPatientsAttributesTypes_save);
            LanguageHelper.AddComponent(button_tabPatientsAttributesTypes_cancel);
            LanguageHelper.AddComponent(patientsattributestypes_idLabel);
            LanguageHelper.AddComponent(patientsattributestypes_nameLabel);
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
            BindingSourceMain = vPatientsAttributesTypesBindingSource;
            GetDataSourceMain = GetDataSource_main;

            //set Main TabControl
            TabControlMain = tabControl_main;

            //set Main Panels
            PanelFiltersMain = panel_filters;
            PanelListMain = panel_list;
            PanelsExtraMain = null;

            //set tabPatientsAttributesTypes
            tabElement_tabPatientsAttributesTypes = new TabElement()
            {
                TabPageElement = tabPage_tabPatientsAttributesTypes,
                ElementItem = new TabElement.TabElementItem()
                {
                    PanelData = panel_tabPatientsAttributesTypes_data,
                    PanelActions = panel_tabPatientsAttributesTypes_actions,
                    PanelUpdates = panel_tabPatientsAttributesTypes_updates,

                    ParentBindingSourceList = vPatientsAttributesTypesBindingSource,
                    GetParentDataSourceList = GetDataSource_main,

                    BindingSourceEdit = patientsattributestypesBindingSource,
                    GetDataSourceEdit = GetDataSourceEdit_tabPatientsAttributesTypes,
                    AfterSaveAction = AfterSaveAction_tabPatientsAttributesTypes,

                    AddButton = button_tabPatientsAttributesTypes_new,
                    UpdateButton = button_tabPatientsAttributesTypes_edit,
                    RemoveButton = button_tabPatientsAttributesTypes_delete,
                    SaveButton = button_tabPatientsAttributesTypes_save,
                    CancelButton = button_tabPatientsAttributesTypes_cancel,

                    Add = Add_tabPatientsAttributesTypes,
                    Update = Update_tabPatientsAttributesTypes,
                    Remove = Remove_tabPatientsAttributesTypes
                }
            };

            //set Elements
            TabElements.Add(tabElement_tabPatientsAttributesTypes);
        }

        /// <summary>
        /// Loader
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormPatientsAttributesTypes_Load(object sender, EventArgs e)
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
            IEnumerable<VPatientsAttributesTypes> vPatientsAttributesTypes =
                _dentnedModel.PatientsAttributesTypes.List().Select(
                r => new VPatientsAttributesTypes
                {
                    patientsattributestypes_id = r.patientsattributestypes_id,
                    name = r.patientsattributestypes_name
                }).ToList();

            return DGDataTableUtils.ToDataTable<VPatientsAttributesTypes>(vPatientsAttributesTypes);
        }

        /// <summary>
        /// Main Datagrid filter handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void advancedDataGridView_main_FilterStringChanged(object sender, EventArgs e)
        {
            vPatientsAttributesTypesBindingSource.Filter = advancedDataGridView_main.FilterString;
        }

        /// <summary>
        /// Main Datagrid sort handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void advancedDataGridView_main_SortStringChanged(object sender, EventArgs e)
        {
            vPatientsAttributesTypesBindingSource.Sort = advancedDataGridView_main.SortString;
        }


        #region tabPatientsAttributesTypes

        /// <summary>
        /// Load the tab DataSource
        /// </summary>
        /// <returns></returns>
        private object GetDataSourceEdit_tabPatientsAttributesTypes()
        {
            return DGUIGHFData.LoadEntityFromCurrentBindingSource<patientsattributestypes, DentneDModel>(_dentnedModel.PatientsAttributesTypes, vPatientsAttributesTypesBindingSource, new string[] { "patientsattributestypes_id" });
        }

        /// <summary>
        /// Do actions after Save
        /// </summary>
        /// <param name="item"></param>
        private void AfterSaveAction_tabPatientsAttributesTypes(object item)
        {
            DGUIGHFData.SetBindingSourcePosition<patientsattributestypes, DentneDModel>(_dentnedModel.PatientsAttributesTypes, item, vPatientsAttributesTypesBindingSource);
        }

        /// <summary>
        /// Add an item
        /// </summary>
        /// <param name="item"></param>
        private void Add_tabPatientsAttributesTypes(object item)
        {
            DGUIGHFData.Add<patientsattributestypes, DentneDModel>(_dentnedModel.PatientsAttributesTypes, item);
        }

        /// <summary>
        /// Update an item
        /// </summary>
        /// <param name="item"></param>
        private void Update_tabPatientsAttributesTypes(object item)
        {
            DGUIGHFData.Update<patientsattributestypes, DentneDModel>(_dentnedModel.PatientsAttributesTypes, item);
        }

        /// <summary>
        /// Remove an item
        /// </summary>
        /// <param name="item"></param>
        private void Remove_tabPatientsAttributesTypes(object item)
        {
            DGUIGHFData.Remove<patientsattributestypes, DentneDModel>(_dentnedModel.PatientsAttributesTypes, item);
        }

        #endregion

    }
}
