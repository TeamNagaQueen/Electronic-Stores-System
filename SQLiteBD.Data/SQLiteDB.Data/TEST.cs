﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteDB.Data
{
    class TEST
    {
        public static void Main()
        {
            SQLiteDBTaxesEntities db = new SQLiteDBTaxesEntities();

            using (db)
            {
            }
        }
    }
}
