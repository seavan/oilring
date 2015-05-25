	
/*
	Metadata code generation
	Author: Samvel Avanesov 
	Mailto: seavan@gmail.com
	Table alias:	FileAttachment
	File name: 	FileAttachment.meta.cs
*/
			

using System;
using System.ComponentModel.DataAnnotations;
using Notamedia.Oilring.Database;

namespace admin.db
{
    public partial class FileAttachmentMeta
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
		public System.Guid Guid;
		
		// add metadata here
		public System.DateTime CreationDate;
		
		// add metadata here
		public System.DateTime PublicationDate;
		
		// add metadata here
		public System.DateTime ModificationDate;
		
		// add metadata here
		public System.Int64 OrigFileSize;
		
		// add metadata here
		public System.Boolean IsInText;
		
		// add metadata here
		public System.String FileType;
		
		// add metadata here
		public System.Boolean IsConversionRequired;
		
		// add metadata here
		public System.Boolean IsConverted;
		
		// add metadata here
		public System.Boolean IsConversionInProgress;
		
		// add metadata here
		public System.String Content;
		
		// add metadata here
		public System.Boolean IsError;
		
    }
}	
