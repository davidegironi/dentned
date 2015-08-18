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
    public partial class FormDoctors : DGUIGHFForm
    {
        private DentneDModel _dentnedModel = null;

        private TabElement tabElement_tabDoctors = new TabElement();

        /// <summary>
        /// Constructor
        /// </summary>
        public FormDoctors()
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
            LanguageHelper.AddComponent(doctorsidDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            LanguageHelper.AddComponent(nameDataGridViewTextBoxColumn, this.GetType().Name, "HeaderText");
            //tabDoctors
            LanguageHelper.AddComponent(tabPage_tabDoctors);
            LanguageHelper.AddComponent(button_tabDoctors_new);
            LanguageHelper.AddComponent(button_tabDoctors_edit);
            LanguageHelper.AddComponent(button_tabDoctors_delete);
            LanguageHelper.AddComponent(button_tabDoctors_save);
            LanguageHelper.AddComponent(button_tabDoctors_cancel);
            LanguageHelper.AddComponent(doctors_idLabel);
            LanguageHelper.AddComponent(doctors_nameLabel);
            LanguageHelper.AddComponent(doctors_surnameLabel);
            LanguageHelper.AddComponent(doctors_doctextLabel);
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
            BindingSourceMain = vDoctorsBindingSource;
            GetDataSourceMain = GetDataSource_main;

            //set Main TabControl
            TabControlMain = tabControl_main;

            //set Main Panels
            PanelFiltersMain = null;
            PanelListMain = panel_list;
            PanelsExtraMain = null;

            //set tabDoctors
            tabElement_tabDoctors = new TabElement()
            {
                TabPageElement = tabPage_tabDoctors,
                ElementItem = new TabElement.TabElementItem()
                {
                    PanelData = panel_tabDoctors_data,
                    PanelActions = panel_tabDoctors_actions,
                    PanelUpdates = panel_tabDoctors_updates,

                    BindingSourceList = vDoctorsBindingSource,
                    GetDataSourceList = GetDataSource_main,

                    BindingSourceEdit = doctorsBindingSource,
                    GetDataSourceEdit = GetDataSourceEdit_tabDoctors,
                    AfterSaveAction = AfterSaveAction_tabDoctors,

                    AddButton = button_tabDoctors_new,
                    UpdateButton = button_tabDoctors_edit,
                    RemoveButton = button_tabDoctors_delete,
                    SaveButton = button_tabDoctors_save,
                    CancelButton = button_tabDoctors_cancel,

                    Add = Add_tabDoctors,
                    Update = Update_tabDoctors,
                    Remove = Remove_tabDoctors
                }
            };

            //set Elements
            TabElements.Add(tabElement_tabDoctors);
        }

        /// <summary>
        /// Loader
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormDoctors_Load(object sender, EventArgs e)
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
            IEnumerable<VDoctors> vDoctors =
                _dentnedModel.Doctors.List().Select(
                r => new VDoctors
                {
                    doctors_id = r.doctors_id,
                    name = r.doctors_surname + " " + r.doctors_name
                }).ToList();

            return DGDataTableUtils.ToDataTable<VDoctors>(vDoctors);
        }

        /// <summary>
        /// Main Datagrid filter handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void advancedDataGridView_main_FilterStringChanged(object sender, EventArgs e)
        {
            vDoctorsBindingSource.Filter = advancedDataGridView_main.FilterString;
        }

        /// <summary>
        /// Main DataGrid sor handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void advancedDataGridView_main_SortStringChanged(object sender, EventArgs e)
        {
            vDoctorsBindingSource.Sort = advancedDataGridView_main.SortString;
        }


        #region tabDoctors

        /// <summary>
        /// Load the tab DataSource
        /// </summary>
        /// <returns></returns>
        private object GetDataSourceEdit_tabDoctors()
        {
            return DGUIGHFData.LoadEntityFromCurrentBindingSource<doctors, DentneDModel>(_dentnedModel.Doctors, vDoctorsBindingSource, new string[] { "doctors_id" });
        }

        /// <summary>
        /// Do actions after Save
        /// </summary>
        /// <param name="item"></param>
        private void AfterSaveAction_tabDoctors(object item)
        {
            DGUIGHFData.SetBindingSourcePosition<doctors, DentneDModel>(_dentnedModel.Doctors, item, vDoctorsBindingSource);
        }

        /// <summary>
        /// Add an item
        /// </summary>
        /// <param name="item"></param>
        private void Add_tabDoctors(object item)
        {
            DGUIGHFData.Add<doctors, DentneDModel>(_dentnedModel.Doctors, item);
        }

        /// <summary>
        /// Update an item
        /// </summary>
        /// <param name="item"></param>
        private void Update_tabDoctors(object item)
        {
            DGUIGHFData.Update<doctors, DentneDModel>(_dentnedModel.Doctors, item);
        }

        /// <summary>
        /// Remove an item
        /// </summary>
        /// <param name="item"></param>
        private void Remove_tabDoctors(object item)
        {
            DGUIGHFData.Remove<doctors, DentneDModel>(_dentnedModel.Doctors, item);
        }

        #endregion

    }
}
