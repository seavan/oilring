namespace admin.web.common
{
    public enum OrderList
    {
        Default = 0,
        PublicationDateDesc = 1,
        PublicationDateAsc = 2,
        Commented = 3,
        LastName = 4,
        Title = 5,
        Coming = 6,
        Passed = 7,
        CreationDateDesc = 8,
    }

    public enum StatusList
    {
        Default = 0,
        Member = 1,
        AuthorReader = 2,
        Organizer = 3,
        Request = 4,
        Author = 5
    }
}