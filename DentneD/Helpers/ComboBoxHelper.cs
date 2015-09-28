#region License
// Copyright (c) 2015 Davide Gironi
//
// Please refer to LICENSE file for licensing information.
#endregion

using System;
using System.Windows.Forms;

namespace DG.DentneD.Helpers
{
    public class ComboBoxHelper
    {
        /// <summary>
        /// Autocomplete a combobox on keypress
        /// </summary>
        /// <param name="comboBox"></param>
        /// <param name="e"></param>
        public static void AutoCompleteOnKeyPress(ComboBox comboBox, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar))
                return;
            string stringToFind = comboBox.Text.Substring(0, comboBox.SelectionStart) + e.KeyChar;
            int index = comboBox.FindStringExact(stringToFind);
            if (index == -1)
                index = comboBox.FindString(stringToFind);
            if (index == -1)
                return;
            comboBox.SelectedIndex = index;
            comboBox.SelectionStart = stringToFind.Length;
            comboBox.SelectionLength = comboBox.Text.Length - comboBox.SelectionStart;
            e.Handled = true;
        }
    }
}
