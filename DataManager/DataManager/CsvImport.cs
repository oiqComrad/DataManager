using System;
using System.Data;
using System.IO;
using Microsoft.VisualBasic.FileIO;

namespace DataManager
{
    /// <summary>
    /// Статический класс, метод которого считывает csv файл в DataTable.
    /// </summary>
    public static class CsvImport
    {
        /// <summary>
        /// Метод считывания csv файла.
        /// </summary>
        /// <param name="filePath">Путь файла.</param>
        /// <param name="separator">Знак-разделитеть.</param>
        /// <param name="firstRowContainesColumnsName">Является ли первая строка заголовком столбцов.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Метод устанавливет значения по умолчанию, если ячейка оказалась пустая.
        /// </summary>
        /// <param name="dataTable"></param>
        /// <returns></returns>
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

