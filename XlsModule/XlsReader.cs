namespace XlsModule
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Ionic.Zip;

    public class XlsReader
    {
        public static void ExtractZipReports()
        {
            string zipToUnpack = @"..\..\..\Sales-report.zip";
            string unpackDirectory = @"..\..\Extracted Files";
            using (ZipFile zip = ZipFile.Read(zipToUnpack))
            { 
                foreach (ZipEntry e in zip)
                {
                    e.Extract(unpackDirectory, ExtractExistingFileAction.OverwriteSilently);
                }
            }
        }
    }
}
