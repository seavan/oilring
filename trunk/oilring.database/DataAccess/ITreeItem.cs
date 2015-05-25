using System.Collections.Generic;

namespace Notamedia.Oilring.Database.DataAccess
{
    public interface ITreeItem<T>
    {
        long ParentId { get; set; }

        List<T> Children { get; set; }
    }
}