using System.Linq;
using Database.Entities;

namespace Database
{
    public class DataServiceBehavior<_T> where _T : IDatabaseEntity
    {
        public DataServiceBehavior()
        {
            OnlyApproved = false;
            OnlyPublished = false;
            LangOrDefault = false;
            LangStrict = false;
            Lang = "";
        }

        public IQueryable<_T> Behave(IQueryable<_T> _q)
        {
            if(OnlyApproved)
            {
                _q = _q.Where(s => s.Approved);
            }
            if (OnlyPublished)
            {
                _q = _q.Where(s => s.Published);
            }
            return _q;
        }

        public bool OnlyApproved { get; set; }
        public bool OnlyPublished { get; set; }
        public bool LangOrDefault { get; set; }
        public bool LangStrict { get; set; }
        public string Lang { get; set; }

    }
}