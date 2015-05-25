
    /*
    Common controller code generation
    Author: Samvel Avanesov
    Mailto: seavan@gmail.com
    Table alias:	Report
    File name: 	Report.controller.cs
    */
    

    using System;
    using System.ComponentModel.DataAnnotations;
    using Notamedia.Oilring.Database;
    using admin.db;
using Database.Interfaces;

    namespace admin.web.common
    {
    public partial class ReportController : OilringBaseUniversalController<ReportObject>
    {
    protected IReportService m_ReportService;

    protected IReportService ReportService
    {
    get
    {
    if (m_ReportService == null)
    {
    m_ReportService = GetService() as IReportService;
    }

    return m_ReportService;
    }
    }
    protected override IDataService<ReportObject> GetService()
    {
        return DataServiceLocator.ReportService;
    }
    }
    }
  