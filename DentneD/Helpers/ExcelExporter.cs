#region License
// Copyright (c) 2015 Davide Gironi
//
// Please refer to LICENSE file for licensing information.
#endregion

using ExcelLibrary.SpreadSheet;
using System;
using System.Data;

namespace DG.DentneD.Helpers
{
    public class ExcelExporter
    {
        /// <summary>
        /// Create a workbook
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="dataset"></param>
        public static void CreateWorkbook(String filename, DataSet dataset)
        {
            Workbook workbook = new Workbook();
            foreach (DataTable dt in dataset.Tables)
            {
                Worksheet worksheet = new Worksheet(dt.TableName);
                for (int i = 0; i < 100; i++) //Office 2010 doesn't support less than 100 cells
                    worksheet.Cells[i, 0] = new Cell("");
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    worksheet.Cells[0, i] = new Cell(dt.Columns[i].ColumnName);
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        if (dt.Rows[j][i].GetType() == typeof(DateTime))
                            worksheet.Cells[j + 1, i] = new Cell(dt.Rows[j][i], @"YYYY\-MM\-DD hh:mm:ss");
                        else
                            worksheet.Cells[j + 1, i] = new Cell(dt.Rows[j][i] == DBNull.Value ? "" : dt.Rows[j][i]);
                    }

                }
                workbook.Worksheets.Add(worksheet);
            }
            workbook.Save(filename);
        }
    }
}
