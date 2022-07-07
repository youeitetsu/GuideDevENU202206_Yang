namespace Terrasoft.Core.Process
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Drawing;
	using System.Globalization;
	using System.Text;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Process;
	using Terrasoft.Core.Process.Configuration;

	#region Class: YangTestCSharpProcessMethodsWrapper

	/// <exclude/>
	public class YangTestCSharpProcessMethodsWrapper : ProcessModel
	{

		public YangTestCSharpProcessMethodsWrapper(Process process)
			: base(process) {
			AddScriptTaskMethod("ScriptTask1Execute", ScriptTask1Execute);
		}

		#region Methods: Private

		private bool ScriptTask1Execute(ProcessExecutingContext context) {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "YangRealty");
			var priceColumn = esq.AddColumn("YangPriceUSD");  // select YangPriceUSD as YangPriceUSD, YangAreaSqM as YangAreaSqM from YangRealty where ...
			var areaColumn = esq.AddColumn("YangAreaSqM");
			
			Guid typeId = Get<Guid>("RealtyTypeId");
			Guid offerTypeId = Get<Guid>("RealtyOfferTypeId");
			//Guid typeId = new Guid("207420b0-1fa5-459a-9bca-52e22ae441ab"); // Apartment realty type
			//Guid offerTypeId = new Guid("cdd02ff9-e12b-4603-9c21-f59cc4e4566e");  // Sales realty offer type
			
			var typeFilter = esq.CreateFilterWithParameters(FilterComparisonType.Equal, "YangType", typeId);
			esq.Filters.Add(typeFilter);
			
			var offerTypeFilter = esq.CreateFilterWithParameters(FilterComparisonType.Equal, "YangOfferType", offerTypeId);
			esq.Filters.Add(offerTypeFilter);
			
			var entityCollection = esq.GetEntityCollection(UserConnection);
			decimal totalUSD = 0;
			decimal totalArea = 0;
			foreach(var entity in entityCollection) {
				decimal price = entity.GetTypedColumnValue<decimal>(priceColumn.Name); // reading using column alias
				decimal area = entity.GetTypedColumnValue<decimal>(areaColumn.Name); // reading using column alias
				totalUSD = totalUSD + price;
				totalArea = totalArea + area;
			}
			
			decimal result = 0;
			if (totalArea > 0) {
				result = totalUSD / totalArea;
			}
			
			Set("AvgPriceUSD", result);
			
			return true;
		}

		#endregion

	}

	#endregion

}

