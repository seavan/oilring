	
/*
	Metadata code generation
	Author: Samvel Avanesov 
	Mailto: seavan@gmail.com
	Table alias:	Discussion
	File name: 	Discussion.meta.cs
*/
			

using System;
using System.ComponentModel.DataAnnotations;
using Notamedia.Oilring.Database;

namespace admin.db
{
    public partial class DiscussionMeta
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
        [Display(Name = "�������� ���������")]
		public System.String Title;
		
		// add metadata here
        [Display(Name = "����� ���������")]
        [DataType("TelerikHtml")]
		public System.String ShortDescription;
		
		// add metadata here
		public System.String Text;
		
		// add metadata here
		public System.DateTime CreationDate;
		
		// add metadata here
		public System.DateTime PublicationDate;
		
		// add metadata here
		public System.DateTime ModificationDate;
		
		// add metadata here
		public System.Int32 AUTO_CommentCount;
		
		// add metadata here
		public System.DateTime AUTO_Comment_LastDateTime;
		
		// add metadata here
		public System.Guid AUTO_DefaultPhoto_Guid;
		
		// add metadata here
		public System.String AUTO_DefaultPhoto_Alt;
		
		// add metadata here
		public System.Boolean PSEUDO_IsUserFavourite;
		
		// add metadata here
		public System.Int32 PSEUDO_NewCommentCount;
		
    }
}	
