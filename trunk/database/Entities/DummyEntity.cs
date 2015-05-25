namespace Database.Entities
{
    public class DummyEntity : IDatabaseEntity
    {
        public DummyEntity()
        {
            
        }
        public DummyEntity(IDatabaseEntity _entity)
        {
            Id = _entity.Id;
            ObjectType = _entity.ObjectType;
        }

        public DummyEntity(long _id, string _objectType)
        {
            Id = _id;
            ObjectType = _objectType;
        }

        public long Id { get; set; }
        public string ObjectType { get; set; }
        public bool Approved { get; set;  }
        public bool Published { get; set; }
        public string Lang { get; set;  }
    }
}