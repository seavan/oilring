	
/*
	Metadata code generation
	Author: Samvel Avanesov 
	Mailto: seavan@gmail.com
	Table alias:	Techno
	File name: 	Techno.meta.cs
*/
			

using System;
using System.ComponentModel.DataAnnotations;
using Notamedia.Oilring.Database;

namespace admin.db
{
    public partial class TechnoMeta
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
        [Display(Name = "")]
        [Required(ErrorMessage = "Введите название технологии")]
		public System.String Title;
		
		// add metadata here
        [Display(Name = "Анонс материала")]
        [Required(ErrorMessage = "Введите анонс технологии")]
        [DataType("TextAreaBox")]
		public System.String ShortDescription;
		
		// add metadata here
        [Display(Name = "Текст материала")]
        [Required(ErrorMessage="Введите текст материала")]
        [DataType("TelerikHtml")]
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

        // add metadata here
        [Display(Name = "Стадия развития")]
        [DataType("TextAreaBox")]
        public System.String DevelopmentStage;

        // add metadata here
        [Display(Name = "Инновационные характеристики")]
        [DataType("TextAreaBox")]
        public System.String InnovativeFeatures;

        // add metadata here
        [Display(Name = "Конкурентные преимущества")]
        [DataType("TextAreaBox")]
        public System.String CompetitiveAdvantages;

        // add metadata here
        [Display(Name = "Область применения")]
        [DataType("TextAreaBox")]
        public System.String Scope;

        // add metadata here
        [Display(Name = "Необходимые ресурсы для дальнейшего развития")]
        [DataType("TextAreaBox")]
        public System.String ResourcesDevelopment;

        // add metadata here
        [Display(Name = "Способ коммерциализации")]
        [DataType("TextAreaBox")]
        public System.String WayCommercialization;

        // add metadata here
        [Display(Name = "Ограничения на коммерциалиацию")]
        [DataType("TextAreaBox")]
        public System.String RestrictionsCommercialization;

        // add metadata here
        [Display(Name = "Ожидаемый рынок")]
        [DataType("TextAreaBox")]
        public System.String ExpectedMarket;

        // add metadata here
        [Display(Name = "Опыт коммерческого использования")]
        [DataType("TextAreaBox")]
        public System.String CommercialExperience;

        // add metadata here
        [Display(Name = "Дополнительная информация")]
        [DataType("TelerikHtml")]
        public System.String AdditionalInformation;
		
    }
}	
