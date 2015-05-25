
    /*
    Common controller code generation
    Author: Samvel Avanesov
    Mailto: seavan@gmail.com
    Table alias:	ViewUserMaterial
    File name: 	ViewUserMaterial.controller.cs
    */
    

    using System;
    using System.ComponentModel.DataAnnotations;
    using Notamedia.Oilring.Database;
    using admin.db;
using Database.Interfaces;

    namespace admin.web.common
    {
    public partial class ViewUserMaterialController : OilringBaseUniversalController<ViewUserMaterialObject>
    {
    protected IViewUserMaterialService m_ViewUserMaterialService;

    protected IViewUserMaterialService ViewUserMaterialService
    {
    get
    {
    if (m_ViewUserMaterialService == null)
    {
    m_ViewUserMaterialService = GetService() as IViewUserMaterialService;
    }

    return m_ViewUserMaterialService;
    }
    }
    protected override IDataService<ViewUserMaterialObject> GetService()
    {
        return DataServiceLocator.ViewUserMaterialService;
    }
    }
    }
  