using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace Database.Entities
{
    public interface IIdentifiedTyped
    {
        long Id { get; set; }
        string ObjectType { get; set; }
    }

    public interface IDatabaseEntity : IIdentifiedTyped
    {
        bool Published { get; set; }
        bool Approved { get; set;  }
        string Lang { get; set; }
    }
}
