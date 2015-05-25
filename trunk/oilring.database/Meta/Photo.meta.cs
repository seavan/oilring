	
/*
	Metadata code generation
	Author: Samvel Avanesov 
	Mailto: seavan@gmail.com
	Table alias:	Photo
	File name: 	Photo.meta.cs
*/
			

using System;
using System.ComponentModel.DataAnnotations;
using Notamedia.Oilring.Database;

namespace admin.db
{
    public partial class PhotoMeta
    {
    	
		// add metadata here
		public System.Int64 Id;
		
		// add metadata here
		public System.String ObjectType;
		
		// add metadata here
		public System.Int64 REL_Id;
		
		// add metadata here
		public System.String REL_ObjectType;
		
		// add metadata here
		public System.Boolean Published;
		
		// add metadata here
		public System.Boolean Approved;
		
		// add metadata here
		public System.String Lang;
		
		// add metadata here
		public System.Int64 Owner_User_ID;
		
		// add metadata here
		public System.String Title;
		
		// add metadata here
		public System.String UserFileName;
		
		// add metadata here
		public System.String ImageFormat;
		
		// add metadata here
		public System.Guid Guid;
		
		// add metadata here
		public System.DateTime CreationDate;
		
		// add metadata here
		public System.DateTime PublicationDate;
		
		// add metadata here
		public System.DateTime ModificationDate;
		
		// add metadata here
		public System.Int32 OrigWidth;
		
		// add metadata here
		public System.Int32 OrigHeight;
		
		// add metadata here
		public System.Int32 Width;
		
		// add metadata here
		public System.Int32 Height;
		
		// add metadata here
		public System.Int32 ThumbWidth;
		
		// add metadata here
		public System.Int32 ThumbHeight;
		
		// add metadata here
		public System.Boolean IsInText;
		
    }
}	
