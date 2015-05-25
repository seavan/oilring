	
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
using Web.Common.Metadata;
using Web.Common.Validation.Attributes;

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
        [Display(Name = "Имя")]
        [Required(ErrorMessage="Введите имя")]
		public System.String FirstName;
		
		// add metadata here
        [Display(Name = "Фамилия")]
        [Required(ErrorMessage = "Введите фамилию")]
		public System.String LastName;
		
		// add metadata here
		public System.DateTime BirthDate;
		
		// add metadata here
        [Display(Name = "Город")]
		public System.String City;
		
		// add metadata here
        [Display(Name = "Отчество")]
		public System.String MiddleName;
		
		// add metadata here
		public System.Guid AUTO_DefaultPhoto_Guid;
		
		// add metadata here
		public System.String AUTO_DefaultPhoto_Alt;
		
		// add metadata here
        [Display(Name = "Специальность")]
		public System.String Specialty;
		
		// add metadata here
        [Display(Name = "Адрес электронной почты/логин")]
		public System.String UserLogin;
		
		// add metadata here
		public System.String Password;
		
		// add metadata here
		public System.Guid Activation_guid;

        // add metadata here
        public System.Boolean Sex;
		
		// add metadata here
        [Display(Name = "Получать по e-mail новости проекта")]
		public System.Boolean Options_SubscribeNews;
		
		// add metadata here
        [Display(Name = "Получать по e-mail уведомления о личных сообщениях")]
		public System.Boolean Options_SubscribePrivateMessages;
		
		// add metadata here
        [Display(Name = "Получать по e-mail уведомления о новых комментариях")]
		public System.Boolean Options_SubscribeNewComments;
		
		// add metadata here
        [Display(Name = "Получать по e-mail уведомления о записи на семинары/конференции")]
		public System.Boolean Options_SubscribeJoin;
		
		// add metadata here
        [Display(Name = "Получать по e-mail уведомления о запросах в коллеги")]
		public System.Boolean Options_SubscribeFriendRequest;

        // add metadata here
        [PrivacyComboValuesAttribute]
        [Display(Name="Мой возраст виден:")]
        [DataType("CustomCombo")]
        public System.Int32 Options_ShowAge;

        // add metadata here
        [PrivacyComboValuesAttribute]
        [DataType("CustomCombo")]
        [Display(Name = "Мои контактные данные видны:")]
        public System.Int32 Options_ShowContacts;

        // add metadata here
        [PrivacyComboValuesAttribute]
        [DataType("CustomCombo")]
        [Display(Name = "Мои места работы видны:")]
        public System.Int32 Options_ShowJobs;

        // add metadata here
        [PrivacyComboValuesAttribute]
        [DataType("CustomCombo")]
        [Display(Name = "Мои места учебы видны:")]
        public System.Int32 Options_ShowEducations;

        // add metadata here
        [PrivacyComboValuesAttribute]
        [DataType("CustomCombo")]
        [Display(Name = "Мое отчество видно:")]
        public System.Int32 Options_ShowMiddleName;

        // add metadata here
        [PrivacyComboValuesAttribute]
        [DataType("CustomCombo")]
        [Display(Name = "Мои научные интересы видны:")]
        public System.Int32 Options_ShowInterests;

        [Display(Name = "Новый пароль")]
        [ConditionalRequired(FieldNames = new string[] { "NewPasswordRepeat", "OldPassword" })]
        [EqualityValidator(FieldNames = new string[] { "NewPasswordRepeat" })]
        [DataType("Password")]
        public string NewPassword;

        [Display(Name = "Новый пароль еще раз")]
        [ConditionalRequired(FieldNames = new string[] { "NewPassword", "OldPassword" })]
        [EqualityValidator(FieldNames = new string[] { "NewPassword" })]
        [DataType("Password")]
        public string NewPasswordRepeat;

        [Display(Name = "Старый пароль")]
        [NotEmptyValidator]
        [PasswordValidator]
        [ConditionalRequired( FieldNames = new string[] { "NewPassword", "NewPasswordRepeat" } )]
        [DataType("Password")]
        public string OldPassword;


    }
}	
