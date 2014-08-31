using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLiteDB.Data;
using System.Data.OleDb;
using System.Data;

namespace SQLiteDB.ConsoleClient
{
    class ConsoleClient
    {
        static void Main(string[] args)
        {
            InsertDateTimeNowToExcel();

            InsertAllTaxRecordsToExcel();
        }

        private static void InsertDateTimeNowToExcel()
        {
            string nameOfTheSheet = "Sheet1";

            using (var excelConnection = new OleDbConnection(
                "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Report.xlsx;Extended Properties='Excel 12.0 xml;HDR=Yes';"))
            {
                excelConnection.Open();

                DateTime timeNow = DateTime.Now;
                string dataTimeNowToString = timeNow.Day + " " + timeNow.Month + " " + timeNow.Year;

                OleDbCommand excelCommand = SetDateLineWithOleDbCommand(
                    excelConnection, nameOfTheSheet, dataTimeNowToString);
                excelCommand.ExecuteNonQuery();
            }
        }

        private static void InsertAllTaxRecordsToExcel()
        {
            string nameOfTheSheet = "Sheet1";

            SQLiteDBTaxesEntities db = new SQLiteDBTaxesEntities();

            using (db)
            {
                using (var excelConnection = new OleDbConnection(
                    "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Report.xlsx;Extended Properties='Excel 12.0 xml;HDR=Yes';"))
                {
                    excelConnection.Open();

                    var allTaxesFromDB =
                        from p in db.Products
                        select p;

                    foreach (var record in allTaxesFromDB.ToList())
                    {
                        OleDbCommand excelCommand = SetTaxRecordsWithOleDbCommand(
                            excelConnection, nameOfTheSheet, record.Name, record.ProductTaxes.ToString());
                        excelCommand.ExecuteNonQuery();
                    }
                }
            }
        }

        private static OleDbCommand SetTaxRecordsWithOleDbCommand(
            OleDbConnection oleDbConnection, string sheetName, string product, string productTax)
        {
            OleDbCommand excelCommand = new OleDbCommand(@"INSERT INTO [" + sheetName + @"]
                                                           VALUES (@name, @tax)", oleDbConnection);

            excelCommand.Parameters.AddWithValue("@name", product);
            excelCommand.Parameters.AddWithValue("@tax", productTax);

            return excelCommand;
        }

        private static OleDbCommand SetDateLineWithOleDbCommand(
            OleDbConnection oleDbConnection, string sheetName, string dateTime)
        {
            OleDbCommand excelCommand = new OleDbCommand(@"INSERT INTO [" + sheetName + @"]
                                                           VALUES (@dateTime)", oleDbConnection);

            excelCommand.Parameters.AddWithValue("@dateTime", dateTime);

            return excelCommand;
        }
    }
}