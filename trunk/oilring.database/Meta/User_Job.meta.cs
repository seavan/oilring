	
/*
	Metadata code generation
	Author: Samvel Avanesov 
	Mailto: seavan@gmail.com
	Table alias:	User_Job
	File name: 	User_Job.meta.cs
*/
			

using System;
using System.ComponentModel.DataAnnotations;
using Notamedia.Oilring.Database;

namespace admin.db
{
    public partial class User_JobMeta
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
		public System.DateTime StartYear;
		
		// add metadata here
		public System.DateTime EndYear;
		
		// add metadata here
		public System.String Title;
		
		// add metadata here
		public System.String Division1;
		
		// add metadata here
		public System.String Division2;
		
		// add metadata here
		public System.String Division3;
		
		// add metadata here
		public System.String Position;
		
		// add metadata here
		public System.Boolean State;
		
		// add metadata here
		public System.Int64 REL_Id;
		
		// add metadata here
		public System.String REL_ObjectType;
		
    }
}	
