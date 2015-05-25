	
/*
	Metadata code generation
	Author: Samvel Avanesov 
	Mailto: seavan@gmail.com
	Table alias:	Report
	File name: 	Report.meta.cs
*/
			

using System;
using System.ComponentModel.DataAnnotations;
using Notamedia.Oilring.Database;

namespace admin.db
{
    public partial class ReportMeta
    {
    	
		// add metadata here
		public System.Int64 Id;
		
		// add metadata here
		public System.String ObjectType;
		
		// add metadata here
		public System.Boolean Published;
		
		// add metadata here
		public System.Boolean Approved;
		
		// add metadata here
		public System.String Lang;
		
		// add metadata here
		public System.Int64 REL_Id;
		
		// add metadata here
		public System.String REL_ObjectType;
		
		// add metadata here
		public System.String Title;
		
		// add metadata here
		public System.DateTime CreationDate;
		
		// add metadata here
		public System.String Text;
		
		// add metadata here
		public System.DateTime StartDate;
		
		// add metadata here
		public System.DateTime EndDate;
		
    }
}	
