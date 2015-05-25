	
/*
	Metadata code generation
	Author: Samvel Avanesov 
	Mailto: seavan@gmail.com
	Table alias:	PrivateMessage
	File name: 	PrivateMessage.meta.cs
*/
			

using System;
using System.ComponentModel.DataAnnotations;
using Notamedia.Oilring.Database;

namespace admin.db
{
    public partial class PrivateMessageMeta
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
		public System.Int64 Owner_User_ID;
		
		// add metadata here
		public System.DateTime CreationDate;
		
		// add metadata here
		public System.DateTime PublicationDate;
		
		// add metadata here
		public System.DateTime ModificationDate;
		
		// add metadata here
		public System.Boolean IsEmailSent;
		
		// add metadata here
		public System.String EmailType;
		
		// add metadata here
		public System.Int64 REL_Id;
		
		// add metadata here
		public System.String REL_ObjectType;
		
		// add metadata here
		public System.String AUTO_Subject;
		
		// add metadata here
		public System.String AUTO_Text;
		
		// add metadata here
		public System.Int64 REL_SenderUserId;
		
		// add metadata here
		public System.Int64 REL_ReceiverUserId;
		
		// add metadata here
		public System.Int64 REL_Adjoined;
		
		// add metadata here
		public System.Int32 AUTO_Item_Count;
		
    }
}	
