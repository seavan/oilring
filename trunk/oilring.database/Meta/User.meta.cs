	
/*
	Metadata code generation
	Author: Samvel Avanesov 
	Mailto: seavan@gmail.com
	Table alias:	User
	File name: 	User.meta.cs
*/
			

using System;
using System.ComponentModel.DataAnnotations;
using Notamedia.Oilring.Database;

namespace admin.db
{
    public partial class UserMeta
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
		public System.DateTime LastVisitDate;
		
		// add metadata here
		public System.DateTime RegistrationDate;
		
		// add metadata here
		public System.Boolean IsOnline;
		
		// add metadata here
		public System.String Photo;
		
		// add metadata here
		public System.String FirstName;
		
		// add metadata here
		public System.String LastName;
		
		// add metadata here
		public System.DateTime BirthDate;
		
		// add metadata here
		public System.String City;
		
		// add metadata here
		public System.String MiddleName;
		
		// add metadata here
		public System.Guid AUTO_DefaultPhoto_Guid;
		
		// add metadata here
		public System.String AUTO_DefaultPhoto_Alt;
		
		// add metadata here
		public System.String Specialty;
		
		// add metadata here
		public System.String UserLogin;
		
		// add metadata here
		public System.String Password;
		
		// add metadata here
		public System.Guid Activation_guid;
		
		// add metadata here
		public System.Boolean Sex;
		
		// add metadata here
		public System.Boolean Options_SubscribeNews;
		
		// add metadata here
		public System.Boolean Options_SubscribePrivateMessages;
		
		// add metadata here
		public System.Boolean Options_SubscribeNewComments;
		
		// add metadata here
		public System.Boolean Options_SubscribeJoin;
		
		// add metadata here
		public System.Boolean Options_SubscribeFriendRequest;
		
		// add metadata here
		public System.Int32 Options_ShowAge;
		
		// add metadata here
		public System.Int32 Options_ShowContacts;
		
		// add metadata here
		public System.Int32 Options_ShowJobs;
		
		// add metadata here
		public System.Int32 Options_ShowEducations;
		
		// add metadata here
		public System.Int32 Options_ShowMiddleName;
		
		// add metadata here
		public System.Int32 Options_ShowInterests;
		
		// add metadata here
		public System.Guid Recoverpass_guid;
		
		// add metadata here
		public System.Boolean IsAdmin;
		
		// add metadata here
		public System.Boolean UseSelectedRubrics;
		
		// add metadata here
		public System.Int64 OneRubricSelection;
		
    }
}	
