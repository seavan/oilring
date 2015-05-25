	
/*
	Metadata code generation
	Author: Samvel Avanesov 
	Mailto: seavan@gmail.com
	Table alias:	Notification
	File name: 	Notification.meta.cs
*/
			

using System;
using System.ComponentModel.DataAnnotations;
using Notamedia.Oilring.Database;

namespace admin.db
{
    public partial class NotificationMeta
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
		public System.String Text;
		
		// add metadata here
		public System.DateTime CreationDate;
		
		// add metadata here
		public System.DateTime PublicationDate;
		
		// add metadata here
		public System.DateTime ModificationDate;
		
		// add metadata here
		public System.Int32 AUTO_UsageCount;
		
		// add metadata here
		public System.Boolean IsEmailSent;
		
		// add metadata here
		public System.Int32 NotificationType;
		
		// add metadata here
		public System.Int64 REL_Id;
		
		// add metadata here
		public System.String REL_ObjectType;
		
		// add metadata here
		public System.Int64 REL_Entity_ID;
		
		// add metadata here
		public System.String REL_Entity_ObjectType;
		
		// add metadata here
		public System.Int64 REL_User_ID;
		
		// add metadata here
		public System.String REL_User_ObjectType;
		
		// add metadata here
		public System.Boolean IsAccepted;
		
		// add metadata here
		public System.Boolean IsDenied;
		
    }
}	
