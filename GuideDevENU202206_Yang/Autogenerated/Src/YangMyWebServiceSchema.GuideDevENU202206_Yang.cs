namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: YangMyWebServiceSchema

	/// <exclude/>
	public class YangMyWebServiceSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public YangMyWebServiceSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public YangMyWebServiceSchema(YangMyWebServiceSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("c89369ff-7c41-4b80-959d-c1db5d5eff28");
			Name = "YangMyWebService";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("31a6737b-7268-45d1-bcfb-c57678242788");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,83,208,3,3,0,197,164,105,180,7,0,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c89369ff-7c41-4b80-959d-c1db5d5eff28"));
		}

		#endregion

	}

	#endregion

}

