	
/*
	Metadata code generation
	Author: Samvel Avanesov 
	Mailto: seavan@gmail.com
	Table alias:	PublicationLink
	File name: 	PublicationLink.meta.cs
*/
			

using System;
using System.ComponentModel.DataAnnotations;
using Notamedia.Oilring.Database;

namespace admin.db
{
    public partial class PublicationLinkMeta
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
		public System.String PublicationTitle;
		
		// add metadata here
		public System.String ISBN;
		
		// add metadata here
		public System.String Publisher;
		
		// add metadata here
		public System.String Editor;
		
		// add metadata here
		public System.Int64 REF_Journal_Id;
		
		// add metadata here
		public System.String ISSN;
		
		// add metadata here
		public System.String TypePublication;
		
		// add metadata here
		public System.DateTime DatePublication;
		
		// add metadata here
		public System.Int32 NumberEdition;
		
    }
}	
