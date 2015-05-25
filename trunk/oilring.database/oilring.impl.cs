
using Notamedia.Oilring.Database.DataAccess;
using Database.Entities;

namespace Notamedia.Oilring.Database
{
        public partial class ViewMaterial : IDatabaseEntity, ITitleable { }

        public partial class ViewUserMaterial : IDatabaseEntity, ITitleable { }

        public partial class _ObjectJoinRequestLink : IRelatable { }

        public partial class _ObjectJoinRejectLink : IRelatable { }

        public partial class _FriendLink : IRelatable { }

        public partial class _CommentableVisitLink : IRelatable { }

        public partial class _TagRubricLink : IRelatable { }

        public partial class _UserFavouriteLink : IRelatable { }

        public partial class _PublicationLink : IRelatable { }

        public partial class _ObjectAuthorLink : IRelatable { }

	    public partial class _RubricLink : IRelatable { }

        public partial class _TagLink : IRelatable { }

        public partial class _OuterLink : IRelatable { }

        public partial class _OrganizationLink : IRelatable { }

        public partial class _OrganizationMemberLink : IRelatable { }

        public partial class _ObjectAuthorReaderLink : IRelatable { }

        public partial class _ObjectUserReaderLink : IRelatable { }

        public partial class _GrantMemberLink : IRelatable { }

        public partial class _GrantMemberRequestLink : IRelatable { }

        public partial class _ObjectUserVisitorLink : IRelatable { }

        public partial class _TechnoGrantLink : IRelatable { }

        public partial class _ObjectUserDelegateLink : IRelatable { }

        public partial class _ContactUserLink : IRelatable { }

        public partial class _LanguageLink : IRelatable { }

        public partial class _JournalArticleLink : IRelatable { }

        public partial class Dummy_SearchObject : IDatabaseEntity { }

        public partial class MessageTemplate : IDatabaseEntity { }

        public partial class User_FriendRequest : IDatabaseEntity, IManyToOne { }

        public partial class MessageTemplate : IDatabaseEntity { }

        public partial class PrivateMessage : IDatabaseEntity, IManyToOne, IPublishedItem { }

        public partial class PrivateMessageItem : IDatabaseEntity, IManyToOne { }

        public partial class Notification : IDatabaseEntity, IManyToOne, IPublishedItem { }

        public partial class Language : IDatabaseEntity { }

        public partial class Comment : IDatabaseEntity, IManyToOne { }

        public partial class Patent : IDatabaseEntity, IManyToOne { }

        public partial class Contact : IDatabaseEntity, IManyToOne { }

        public partial class Report : IDatabaseEntity, IManyToOne { }

        public partial class Tag : IDatabaseEntity { }

        public partial class Photo : IDatabaseEntity { }

        public partial class Language : IDatabaseEntity { }

        public partial class FileAttachment : IDatabaseEntity, IManyToOne { }

        public partial class Article : IDatabaseEntity, IPublishedItem, IDefaultPhotoable, ICommentable, IFullTextSearchable { }

        public partial class Conference : IDatabaseEntity, IPublishedItem, IDefaultPhotoable, ICommentable, IFullTextSearchable, IDateRangeItem, IManyToOne { }

        public partial class Discussion : IDatabaseEntity, IPublishedItem, IDefaultPhotoable, ICommentable, IFullTextSearchable { }

        public partial class OuterLink : IDatabaseEntity { }

        public partial class Event : IDatabaseEntity, IPublishedItem, IDefaultPhotoable, ICommentable, IFullTextSearchable { }

        public partial class Grant : IDatabaseEntity, IPublishedItem, IDefaultPhotoable, ICommentable, IFullTextSearchable { }

        public partial class Journal : IDatabaseEntity, IPublishedItem, IDefaultPhotoable, ICommentable, IFullTextSearchable { }

        public partial class Seminar : IDatabaseEntity, IPublishedItem, IDefaultPhotoable, ICommentable, IObjectUserVisitorCountable, IDateRangeItem, IFullTextSearchable, IManyToOne { }

        public partial class Techno : IDatabaseEntity, IPublishedItem, IDefaultPhotoable, ICommentable, IFullTextSearchable { }
        
        public partial class User : IDatabaseEntity, IDefaultPhotoable, IUserItem { }
	
        public partial class Organization_Dept : IDatabaseEntity { }
	
        public partial class Organization_User : IDatabaseEntity { }

        public partial class Organization : IDatabaseEntity, IOrgItem, ITitleable { }
	
        public partial class Paragraph : IDatabaseEntity { }
	
        public partial class Rubric : IDatabaseEntity { }

        public partial class PublicationLink : IDatabaseEntity { }
	
        public partial class User_Degree : IDatabaseEntity, IManyToOne  { }
	
        public partial class User_Job : IDatabaseEntity, IManyToOne  { }
	
        public partial class User_Univer : IDatabaseEntity, IManyToOne  { }

        public partial class User_Group : IDatabaseEntity, IManyToOne { }
}
				
	