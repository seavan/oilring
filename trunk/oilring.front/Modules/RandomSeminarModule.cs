﻿using admin.db;
using admin.web.common;

namespace Notamedia.Oilring
{
    public class RandomSeminarModule : OilringModule<SeminarController, SeminarObject, RandomSeminarModule>
    {
        public RandomSeminarModule()
        {
        }

        public RandomSeminarModule(SeminarObject _related)
        {
            ViewName = "RandomRelatedListWidget";
            REL_ObjectID = _related.Id;
            REL_ObjectType = _related.ObjectType;
            PageSize = 3;
            this.SetOrder(OrderList.PublicationDateDesc);
        }
    }
}