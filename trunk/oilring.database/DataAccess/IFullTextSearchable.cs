using Database.Entities;
namespace Notamedia.Oilring.Database.DataAccess
{
    public interface IFullTextSearchable : IDatabaseEntity
    {
        string Title { get; set; }
        string ShortDescription { get; set; }
    }
}