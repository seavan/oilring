namespace Database.Entities
{
    public interface IRelatable
    {
        long REL_Id1 { get; set; }
        string REL_ObjectType1 { get; set; }
        long REL_Id2 { get; set; }
        string REL_ObjectType2 { get; set; }
    }

    public interface  IManyToOne
    {
        long REL_Id { get; set; }
        string REL_ObjectType { get; set; }
    }

    public interface IOneToOne
    {
        long Id { get; set; }
        string REF_ObjectType { get; set; }
    }
}