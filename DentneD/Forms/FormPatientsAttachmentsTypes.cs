#region License
// Copyright (c) 2015 Davide Gironi
//
// Please refer to LICENSE file for licensing information.
#endregion

using DG.Data.Model.Helpers;
using DG.DentneD.Forms.Objects;
using DG.DentneD.Model;
using DG.DentneD.Model.Entity;
using DG.DentneD.Model.Repositories;
using DG.UI.GHF;
using DG.UI.Helpers;
using SMcMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
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
            LanguageHelper.AddComponent(patientsattachmentstypesidDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(nameDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            //tabPatientsAttachmentsTypes
            LanguageHelper.AddComponent(tabPage_tabPatientsAttachmentsTypes);
            LanguageHelper.AddComponent(button_tabPatientsAttachmentsTypes_new);
            LanguageHelper.AddComponent(button_tabPatientsAttachmentsTypes_edit);
            LanguageHelper.AddComponent(button_tabPatientsAttachmentsTypes_delete);
            LanguageHelper.AddComponent(button_tabPatientsAttachmentsTypes_save);
            LanguageHelper.AddComponent(button_tabPatientsAttachmentsTypes_cancel);
            LanguageHelper.AddComponent(patientsattachmentstypes_idLabel);
            LanguageHelper.AddComponent(patientsattachmentstypes_nameLabel);
            LanguageHelper.AddComponent(patientsattachmentstypes_valueautofuncLabel);
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
            PanelFiltersMain = panel_filters;
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

                    ParentBindingSourceList = vPatientsAttachmentsTypesBindingSource,
                    GetParentDataSourceList = GetDataSource_main,

                    BindingSourceEdit = patientsattachmentstypesBindingSource,
                    GetDataSourceEdit = GetDataSourceEdit_tabPatientsAttachmentsTypes,
                    AfterSaveAction = AfterSaveAction_tabPatientsAttachmentsTypes,

                    AddButton = button_tabPatientsAttachmentsTypes_new,
                    IsAddButtonDefaultClickEventAttached = false,
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
            IsBindingSourceLoading = true;
            advancedDataGridView_main.SortASC(advancedDataGridView_main.Columns[1]);
            IsBindingSourceLoading = false;

            PreloadView();

            ReloadView();
        }

        /// <summary>
        /// Preload View
        /// </summary>
        private void PreloadView()
        {
            IsBindingSourceLoading = true;

            EnhancedComboBoxHelper.AttachComboBox(
                patientsattachmentstypes_valueautofuncComboBox,
                new string[] { "Name" },
                new EnhancedComboBoxHelper.Items[] {
                    new EnhancedComboBoxHelper.Items()
                    {
                        _id = PatientsAttachmentsTypesRepository.ValueAutoFuncCode.NUL.ToString(),
                        _value = _dentnedModel.PatientsAttachmentsTypes.language.valueAutoFuncNUL,
                        _values = new string[]
                        {
                            _dentnedModel.PatientsAttachmentsTypes.language.valueAutoFuncNUL
                        }
                    },
                    new EnhancedComboBoxHelper.Items()
                    {
                        _id = PatientsAttachmentsTypesRepository.ValueAutoFuncCode.AMG.ToString(),
                        _value = _dentnedModel.PatientsAttachmentsTypes.language.valueAutoFuncAMG,
                        _values = new string[]
                        {
                            _dentnedModel.PatientsAttachmentsTypes.language.valueAutoFuncAMG
                        }
                    },
                    new EnhancedComboBoxHelper.Items()
                    {
                        _id = PatientsAttachmentsTypesRepository.ValueAutoFuncCode.AML.ToString(),
                        _value = _dentnedModel.PatientsAttachmentsTypes.language.valueAutoFuncAML,
                        _values = new string[]
                        {
                            _dentnedModel.PatientsAttachmentsTypes.language.valueAutoFuncAML
                        }
                    },
                    new EnhancedComboBoxHelper.Items()
                    {
                        _id = PatientsAttachmentsTypesRepository.ValueAutoFuncCode.AMD.ToString(),
                        _value = _dentnedModel.PatientsAttachmentsTypes.language.valueAutoFuncAMD,
                        _values = new string[]
                        {
                            _dentnedModel.PatientsAttachmentsTypes.language.valueAutoFuncAMD
                        }
                    }
                }.ToArray());

            IsBindingSourceLoading = false;
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

        /// <summary>
        /// New tab button handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_tabPatientsAttachmentsTypes_new_Click(object sender, EventArgs e)
        {
            if (AddClick(tabElement_tabPatientsAttachmentsTypes))
            {
                ((patientsattachmentstypes)patientsattachmentstypesBindingSource.Current).patientsattachmentstypes_valueautofunc = PatientsAttachmentsTypesRepository.ValueAutoFuncCode.NUL.ToString();
                patientsattachmentstypesBindingSource.ResetBindings(true);
            }
        }

        #endregion

    }
}
