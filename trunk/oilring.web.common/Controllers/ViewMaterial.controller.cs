
    /*
    Common controller code generation
    Author: Samvel Avanesov
    Mailto: seavan@gmail.com
    Table alias:	ViewMaterial
    File name: 	ViewMaterial.controller.cs
    */
    

    using System;
    using System.ComponentModel.DataAnnotations;
    using Notamedia.Oilring.Database;
    using admin.db;
using Database.Interfaces;

    namespace admin.web.common
    {
    public partial class ViewMaterialController : OilringBaseUniversalController<ViewMaterialObject>
    {
    protected IViewMaterialService m_ViewMaterialService;

    protected IViewMaterialService ViewMaterialService
    {
    get
    {
    if (m_ViewMaterialService == null)
    {
    m_ViewMaterialService = GetService() as IViewMaterialService;
    }

    return m_ViewMaterialService;
    }
    }
    protected override IDataService<ViewMaterialObject> GetService()
    {
        return DataServiceLocator.ViewMaterialService;
    }
    }
    }
  