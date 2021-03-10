using System;
using System.Data;
using System.IO;
using Microsoft.VisualBasic.FileIO;

namespace DataManager
{
    public class CsvImport
    {
        public static DataTable NewDataTable(string filePath, string separator = ",", bool firstRowContainesColumnsName = true)
        {
            var dataTable = new DataTable();

            var csvFile = new FileInfo(filePath);
            if (csvFile.Extension != ".csv")
                throw new ArgumentException("Файл должен иметь расширение csv");

            using (TextFieldParser tfp = new TextFieldParser(filePath))
            {
                tfp.SetDelimiters(separator);

                if (!tfp.EndOfData)
                {
                    string[] columns = tfp.ReadFields();

                    for (int i = 0; i < columns.Length; i++)
                    {
                        if (firstRowContainesColumnsName)
                            dataTable.Columns.Add(columns[i]);
                        else
                            dataTable.Columns.Add("Col" + i);
                    }

                    if (!firstRowContainesColumnsName)
                        dataTable.Rows.Add(columns);
                }

                while (!tfp.EndOfData)
                    dataTable.Rows.Add(tfp.ReadFields());
            }

            return RemoveEmpty(dataTable);
        }

        public static DataTable RemoveEmpty(DataTable dataTable)
        {
            for (var row = 0; row < dataTable.Rows.Count; row++)
                for (var col = 0; col < dataTable.Columns.Count; col++)
                    if (dataTable.Rows[row][col] != null && string.IsNullOrEmpty(dataTable.Rows[row][col].ToString()))
                        dataTable.Rows[row][col] = "empty";
            return dataTable;
        }
    }
}

