
    /*
    Common controller code generation
    Author: Samvel Avanesov
    Mailto: seavan@gmail.com
    Table alias:	User_FriendRequest
    File name: 	User_FriendRequest.controller.cs
    */
    

    using System;
    using System.ComponentModel.DataAnnotations;
    using Notamedia.Oilring.Database;
    using admin.db;
using Database.Interfaces;

    namespace admin.web.common
    {
    public partial class User_FriendRequestController : OilringBaseUniversalController<User_FriendRequestObject>
    {
    protected IUser_FriendRequestService m_User_FriendRequestService;

    protected IUser_FriendRequestService User_FriendRequestService
    {
    get
    {
    if (m_User_FriendRequestService == null)
    {
    m_User_FriendRequestService = GetService() as IUser_FriendRequestService;
    }

    return m_User_FriendRequestService;
    }
    }
    protected override IDataService<User_FriendRequestObject> GetService()
    {
        return DataServiceLocator.User_FriendRequestService;
    }
    }
    }
  