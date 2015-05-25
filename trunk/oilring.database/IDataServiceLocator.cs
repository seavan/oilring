
using System;

namespace admin.db
{
    public interface IDataServiceLocator
    {
        IArticleService ArticleService { get; }
	
        ICommentService CommentService { get; }
	
        IConferenceService ConferenceService { get; }
	
        IContactService ContactService { get; }
	
        IDiscussionService DiscussionService { get; }
	
        IDummy_SearchObjectService Dummy_SearchObjectService { get; }
	
        IEventService EventService { get; }
	
        IFileAttachmentService FileAttachmentService { get; }
	
        IGrantService GrantService { get; }
	
        IJournalService JournalService { get; }
	
        ILanguageService LanguageService { get; }
	
        IMessageTemplateService MessageTemplateService { get; }
	
        INotificationService NotificationService { get; }
	
        IOrganization_DeptService Organization_DeptService { get; }
	
        IOrganization_UserService Organization_UserService { get; }
	
        IOrganizationService OrganizationService { get; }
	
        IOuterLinkService OuterLinkService { get; }
	
        IParagraphService ParagraphService { get; }
	
        IPatentService PatentService { get; }
	
        IPhotoService PhotoService { get; }
	
        IPrivateMessageItemService PrivateMessageItemService { get; }
	
        IPrivateMessageService PrivateMessageService { get; }
	
        IPublicationLinkService PublicationLinkService { get; }
	
        IReportService ReportService { get; }
	
        IRubricService RubricService { get; }
	
        ISeminarService SeminarService { get; }
	
        ITagService TagService { get; }
	
        ITechnoService TechnoService { get; }
	
        IUser_DegreeService User_DegreeService { get; }
	
        IUser_FriendRequestService User_FriendRequestService { get; }
	
        IUser_GroupService User_GroupService { get; }
	
        IUser_JobService User_JobService { get; }
	
        IUser_UniverService User_UniverService { get; }
	
        IUserService UserService { get; }
	
        IViewMaterialService ViewMaterialService { get; }
	
        IViewUserMaterialService ViewUserMaterialService { get; }
	
    }
}
				
	