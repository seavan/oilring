namespace Notamedia.Oilring.Database.DataAccess
{
    public interface IUserItem
    {
        string LastName { get; set; }
        string FirstName { get; set; }
        string MiddleName { get; set; }
    }
}