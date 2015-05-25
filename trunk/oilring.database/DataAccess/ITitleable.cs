using Database.Entities;
namespace Notamedia.Oilring.Database.DataAccess
{
    public interface ITitleable : IDatabaseEntity
    {
        string Title { get; set; }

        string ShortDescription { get; set; }
    }
}