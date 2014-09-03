#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the FluentMappingGenerator.ttinclude code generation file.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Common;
using System.Collections.Generic;
using Telerik.OpenAccess;
using Telerik.OpenAccess.Metadata;
using Telerik.OpenAccess.Data.Common;
using Telerik.OpenAccess.Metadata.Fluent;
using Telerik.OpenAccess.Metadata.Fluent.Advanced;
using Telerik.OpenAccess.Metadata.Relational;

namespace ElectronicStoreMySQL.Model
{

	public partial class ElectronicStoreMySQLFluentModelMetadataSource : FluentMetadataSource
	{
		
		protected override IList<MappingConfiguration> PrepareMapping()
		{
            List<MappingConfiguration> configurations = new List<MappingConfiguration>();

            var report = new MappingConfiguration<Report>();
            report.MapType(r => new
            {
                ReportID = r.ReportId,
                StoreName = r.StoreName,
                ProductName = r.ProductName,
                Quantity = r.Quantity,
                Price = r.Price,
                Sun = r.Sum,
            }).ToTable("Report");
            report.HasProperty(r => r.ReportId).IsIdentity();
            configurations.Add(report);

            return configurations;
		}
		
		protected override void SetContainerSettings(MetadataContainer container)
		{
			container.Name = "ElectronicStoreMySQLFluentModel";
			container.DefaultNamespace = "ElectronicStoreMySQL.Model";
			container.NameGenerator.SourceStrategy = Telerik.OpenAccess.Metadata.NamingSourceStrategy.Property;
			container.NameGenerator.RemoveCamelCase = false;
		}
	}
}
#pragma warning restore 1591
