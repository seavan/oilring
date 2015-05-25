	
/*
	Metadata code generation
	Author: Samvel Avanesov 
	Mailto: seavan@gmail.com
	Table alias:	Rubric
	File name: 	Rubric.meta.cs
*/
			

using System;
using System.ComponentModel.DataAnnotations;
using Notamedia.Oilring.Database;

namespace admin.db
{
    public partial class RubricMeta
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
		public System.Int64 Parent_Rubric_ID;
		
		// add metadata here
		public System.String Alias;
		
		// add metadata here
		public System.String Header;
		
		// add metadata here
		public System.String MenuTitle_RU_I18N;
		
		// add metadata here
		public System.String MenuTitle_EN_I18N;
		
    }
}	
