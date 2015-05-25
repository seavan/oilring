using Database.Entities;
namespace Notamedia.Oilring.Database.DataAccess
{
    public class DummyFullTextSearchable : DummyEntity, IFullTextSearchable
    {
        public DummyFullTextSearchable(IFullTextSearchable _src)
            : base(_src)
        {
            Title = _src.Title;
            ShortDescription = _src.ShortDescription;
        }

        #region IFullTextSearchable Members

        public string Title { get; set; }

        public string ShortDescription { get; set; }
        

        #endregion
    }
}