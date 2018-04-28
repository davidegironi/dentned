#region License
// Copyright (c) 2015 Davide Gironi
//
// Please refer to LICENSE file for licensing information.
#endregion

using System;
using System.Drawing;
using System.Windows.Forms;

namespace DG.DentneD.Helpers
{
    public static class SelectorBox
    {
        /// <summary>
        /// Show a SelectorBox
        /// </summary>
        /// <param name="message"></param>
        /// <param name="title"></param>
        /// <param name="items"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DialogResult Show(string message, string title, string[] items, ref string value)
        {
            Form form = new Form();
            Label label = new Label();
            ComboBox comboBox = new ComboBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = message;
            comboBox.Items.Clear();
            foreach (string item in items)
                comboBox.Items.Add(item);
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            comboBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            comboBox.Anchor = comboBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, comboBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = (comboBox.SelectedItem != null ? comboBox.SelectedItem.ToString() : null);
            return dialogResult;
        }
    }

}

