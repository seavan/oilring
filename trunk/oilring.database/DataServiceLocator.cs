
    using System;
    using Microsoft.Practices.Unity;
using Common.IoC;

    namespace admin.db
    {
        public class DataServiceLocator : IDataServiceLocator
        {
        private readonly IUnityContainer _container;
    
        private IArticleService m_ArticleService;
    
        private ICommentService m_CommentService;
    
        private IConferenceService m_ConferenceService;
    
        private IContactService m_ContactService;
    
        private IDiscussionService m_DiscussionService;
    
        private IDummy_SearchObjectService m_Dummy_SearchObjectService;
    
        private IEventService m_EventService;
    
        private IFileAttachmentService m_FileAttachmentService;
    
        private IGrantService m_GrantService;
    
        private IJournalService m_JournalService;
    
        private ILanguageService m_LanguageService;
    
        private IMessageTemplateService m_MessageTemplateService;
    
        private INotificationService m_NotificationService;
    
        private IOrganization_DeptService m_Organization_DeptService;
    
        private IOrganization_UserService m_Organization_UserService;
    
        private IOrganizationService m_OrganizationService;
    
        private IOuterLinkService m_OuterLinkService;
    
        private IParagraphService m_ParagraphService;
    
        private IPatentService m_PatentService;
    
        private IPhotoService m_PhotoService;
    
        private IPrivateMessageItemService m_PrivateMessageItemService;
    
        private IPrivateMessageService m_PrivateMessageService;
    
        private IPublicationLinkService m_PublicationLinkService;
    
        private IReportService m_ReportService;
    
        private IRubricService m_RubricService;
    
        private ISeminarService m_SeminarService;
    
        private ITagService m_TagService;
    
        private ITechnoService m_TechnoService;
    
        private IUser_DegreeService m_User_DegreeService;
    
        private IUser_FriendRequestService m_User_FriendRequestService;
    
        private IUser_GroupService m_User_GroupService;
    
        private IUser_JobService m_User_JobService;
    
        private IUser_UniverService m_User_UniverService;
    
        private IUserService m_UserService;
    
        private IViewMaterialService m_ViewMaterialService;
    
        private IViewUserMaterialService m_ViewUserMaterialService;


        public DataServiceLocator()
    {
        _container = MvcUnityContainer.Container;
    
        m_ArticleService = _container.Resolve<ArticleService>();;
    
        m_CommentService = _container.Resolve<CommentService>();;
    
        m_ConferenceService = _container.Resolve<ConferenceService>();;
    
        m_ContactService = _container.Resolve<ContactService>();;
    
        m_DiscussionService = _container.Resolve<DiscussionService>();;
    
        m_Dummy_SearchObjectService = _container.Resolve<Dummy_SearchObjectService>();;
    
        m_EventService = _container.Resolve<EventService>();;
    
        m_FileAttachmentService = _container.Resolve<FileAttachmentService>();;
    
        m_GrantService = _container.Resolve<GrantService>();;
    
        m_JournalService = _container.Resolve<JournalService>();;
    
        m_LanguageService = _container.Resolve<LanguageService>();;
    
        m_MessageTemplateService = _container.Resolve<MessageTemplateService>();;
    
        m_NotificationService = _container.Resolve<NotificationService>();;
    
        m_Organization_DeptService = _container.Resolve<Organization_DeptService>();;
    
        m_Organization_UserService = _container.Resolve<Organization_UserService>();;
    
        m_OrganizationService = _container.Resolve<OrganizationService>();;
    
        m_OuterLinkService = _container.Resolve<OuterLinkService>();;
    
        m_ParagraphService = _container.Resolve<ParagraphService>();;
    
        m_PatentService = _container.Resolve<PatentService>();;
    
        m_PhotoService = _container.Resolve<PhotoService>();;
    
        m_PrivateMessageItemService = _container.Resolve<PrivateMessageItemService>();;
    
        m_PrivateMessageService = _container.Resolve<PrivateMessageService>();;
    
        m_PublicationLinkService = _container.Resolve<PublicationLinkService>();;
    
        m_ReportService = _container.Resolve<ReportService>();;
    
        m_RubricService = _container.Resolve<RubricService>();;
    
        m_SeminarService = _container.Resolve<SeminarService>();;
    
        m_TagService = _container.Resolve<TagService>();;
    
        m_TechnoService = _container.Resolve<TechnoService>();;
    
        m_User_DegreeService = _container.Resolve<User_DegreeService>();;
    
        m_User_FriendRequestService = _container.Resolve<User_FriendRequestService>();;
    
        m_User_GroupService = _container.Resolve<User_GroupService>();;
    
        m_User_JobService = _container.Resolve<User_JobService>();;
    
        m_User_UniverService = _container.Resolve<User_UniverService>();;
    
        m_UserService = _container.Resolve<UserService>();;
    
        m_ViewMaterialService = _container.Resolve<ViewMaterialService>();;
    
        m_ViewUserMaterialService = _container.Resolve<ViewUserMaterialService>();;
    
    }
    
      public IArticleService ArticleService
      {
      get { return m_ArticleService; }
      }
    
      public ICommentService CommentService
      {
      get { return m_CommentService; }
      }
    
      public IConferenceService ConferenceService
      {
      get { return m_ConferenceService; }
      }
    
      public IContactService ContactService
      {
      get { return m_ContactService; }
      }
    
      public IDiscussionService DiscussionService
      {
      get { return m_DiscussionService; }
      }
    
      public IDummy_SearchObjectService Dummy_SearchObjectService
      {
      get { return m_Dummy_SearchObjectService; }
      }
    
      public IEventService EventService
      {
      get { return m_EventService; }
      }
    
      public IFileAttachmentService FileAttachmentService
      {
      get { return m_FileAttachmentService; }
      }
    
      public IGrantService GrantService
      {
      get { return m_GrantService; }
      }
    
      public IJournalService JournalService
      {
      get { return m_JournalService; }
      }
    
      public ILanguageService LanguageService
      {
      get { return m_LanguageService; }
      }
    
      public IMessageTemplateService MessageTemplateService
      {
      get { return m_MessageTemplateService; }
      }
    
      public INotificationService NotificationService
      {
      get { return m_NotificationService; }
      }
    
      public IOrganization_DeptService Organization_DeptService
      {
      get { return m_Organization_DeptService; }
      }
    
      public IOrganization_UserService Organization_UserService
      {
      get { return m_Organization_UserService; }
      }
    
      public IOrganizationService OrganizationService
      {
      get { return m_OrganizationService; }
      }
    
      public IOuterLinkService OuterLinkService
      {
      get { return m_OuterLinkService; }
      }
    
      public IParagraphService ParagraphService
      {
      get { return m_ParagraphService; }
      }
    
      public IPatentService PatentService
      {
      get { return m_PatentService; }
      }
    
      public IPhotoService PhotoService
      {
      get { return m_PhotoService; }
      }
    
      public IPrivateMessageItemService PrivateMessageItemService
      {
      get { return m_PrivateMessageItemService; }
      }
    
      public IPrivateMessageService PrivateMessageService
      {
      get { return m_PrivateMessageService; }
      }
    
      public IPublicationLinkService PublicationLinkService
      {
      get { return m_PublicationLinkService; }
      }
    
      public IReportService ReportService
      {
      get { return m_ReportService; }
      }
    
      public IRubricService RubricService
      {
      get { return m_RubricService; }
      }
    
      public ISeminarService SeminarService
      {
      get { return m_SeminarService; }
      }
    
      public ITagService TagService
      {
      get { return m_TagService; }
      }
    
      public ITechnoService TechnoService
      {
      get { return m_TechnoService; }
      }
    
      public IUser_DegreeService User_DegreeService
      {
      get { return m_User_DegreeService; }
      }
    
      public IUser_FriendRequestService User_FriendRequestService
      {
      get { return m_User_FriendRequestService; }
      }
    
      public IUser_GroupService User_GroupService
      {
      get { return m_User_GroupService; }
      }
    
      public IUser_JobService User_JobService
      {
      get { return m_User_JobService; }
      }
    
      public IUser_UniverService User_UniverService
      {
      get { return m_User_UniverService; }
      }
    
      public IUserService UserService
      {
      get { return m_UserService; }
      }
    
      public IViewMaterialService ViewMaterialService
      {
      get { return m_ViewMaterialService; }
      }
    
      public IViewUserMaterialService ViewUserMaterialService
      {
      get { return m_ViewUserMaterialService; }
      }
    
    }
    }

  