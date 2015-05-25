using System;

namespace Database.Entities
{
    public interface IPublishedItem
    {
        DateTime CreationDate { get; set; }
        Nullable<DateTime> ModificationDate { get; set; }
        Nullable<DateTime> PublicationDate { get; set; }
    }
}