﻿namespace XmlModule
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;
    using ElectronicStoresSystem.Data;
    using ElectronicStoresSystem.Models;

    public class XmlReader
    {
        public static IList<Expense> GetXmlInfo()
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(@"..\..\..\Manufacturers-Expenses.xml");

            XmlNodeList xnList = xml.SelectNodes("expenses-by-month");
            List<Expense> expenses = new List<Expense>();

            foreach (XmlNode xn in xnList)
            {
                foreach (XmlNode node in xn.ChildNodes)
                {
                    string name = node.Attributes["name"].Value;

                    foreach (XmlNode manufacturerNode in node.ChildNodes)
                    {
                        Console.WriteLine(manufacturerNode.Attributes["month"].Value);
                        Console.WriteLine(manufacturerNode.InnerText);

                        Expense currentExpense = new Expense
                        {
                            Month = manufacturerNode.Attributes["month"].Value,
                            Value = decimal.Parse(manufacturerNode.InnerText)
                        };

                        expenses.Add(currentExpense);
                    }
                }
            }

            return expenses;
        }

        public static void AddExpensesToSql(ICollection<Expense> expenses)
        {
            ElectronicStoresSystemDbContext dbContex = new ElectronicStoresSystemDbContext();

            using (dbContex)
            {
                foreach (Expense expense in expenses)
                {
                    dbContex.Expenses.Add(expense);
                }

                dbContex.SaveChanges();
            }

        }
    }
}
