
    /*
    Common controller code generation
    Author: Samvel Avanesov
    Mailto: seavan@gmail.com
    Table alias:	Photo
    File name: 	Photo.controller.cs
    */
    

    using System;
    using System.ComponentModel.DataAnnotations;
    using Notamedia.Oilring.Database;
    using admin.db;
using Database.Interfaces;

    namespace admin.web.common
    {
    public partial class PhotoController : OilringBaseUniversalController<PhotoObject>
    {
    protected IPhotoService m_PhotoService;

    protected IPhotoService PhotoService
    {
    get
    {
    if (m_PhotoService == null)
    {
    m_PhotoService = GetService() as IPhotoService;
    }

    return m_PhotoService;
    }
    }
    protected override IDataService<PhotoObject> GetService()
    {
        return DataServiceLocator.PhotoService;
    }
    }
    }
  