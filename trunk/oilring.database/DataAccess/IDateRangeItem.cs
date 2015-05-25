using System;

namespace Notamedia.Oilring.Database.DataAccess
{
    public interface IDateRangeItem
    {
        DateTime EventStartDate { get; set; }
        DateTime EventEndDate { get; set; }
    }
}