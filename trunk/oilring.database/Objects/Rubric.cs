/*
    Business Objects code generation
    Author: Samvel Avanesov 
    Mailto: seavan@gmail.com
    Table alias:	Rubric
    File name: 	Rubric.object.cs
*/


using System;
using System.ComponentModel.DataAnnotations;
using Notamedia.Oilring.Database;
using Notamedia.Oilring.Database.DataAccess;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Database.Entities;

namespace admin.db
{
    public partial class RubricObject : DatabaseEntity, IDatabaseEntity
    {
        protected List<RubricObject> m_Children = new List<RubricObject>();
        protected SortedList<int, long> m_LevelId = new SortedList<int, long>();

        private BigInteger _hash;

        public void SetHash(BigInteger value)
        {
            _hash = value;
        }

        public BigInteger GetHash()
        {
            return _hash;
        }

        private string _hashHex;

        public void SetHashHex(string value)
        {
            _hashHex = value;
        }

        public string GetHashHex()
        {
            return _hashHex;
        }

        private BigInteger _hashWithParents;

        public void SetHashWithParents(BigInteger value)
        {
            _hashWithParents = value;
        }

        public BigInteger GetHashWithParents()
        {
            return _hashWithParents;
        }

        private string _hashWithParentsHex;

        public void SetHashWithParentsHex(string value)
        {
            _hashWithParentsHex = value;
        }

        public string GetHashWithParentsHex()
        {
            return _hashWithParentsHex;
        }

        public int Index { get; set; }

        public int Level
        {
            get
            {
                return m_Level;
            }
            set
            {
                m_Level = value;
                SetHash(new BigInteger(1) << Index);
                SetHashWithParents(GetHash() | (GetParent() != null ? GetParent().GetHashWithParents() : 0));
                SetHashHex(GetHash().ToString("X"));
                SetHashWithParentsHex(GetHash().ToString("X"));
            }
        }

        private int m_Level;

        public void SetLevelId(int _level, long _id)
        {
            m_LevelId[_level] = _id;
        }

        public int Left { get; set; }
        public int Right { get; set; }

        public long GetLevelId(int _level)
        {
            return m_LevelId[_level];
        }

        public long Level0
        {
            get { return GetLevelId(0); }
        }

        public long Level1
        {
            get { return GetLevelId(1); }
        }

        public long Level2
        {
            get { return GetLevelId(2); }
        }

        public void SetParent(RubricObject value)
        {
            m_RubricObject = value;
            var cnt = 0;
            var parent = GetParent();

            parent = this;
            while (parent != null)
            {
                cnt++;
                parent = parent.GetParent();
            }

            cnt--;

            parent = this;
            for (int i = 0; i < 3; ++i )
            {
                if(parent != null )
                {
                    SetLevelId(cnt - i, parent.Id);
                    parent = parent.GetParent();
                }
                else
                {
                    SetLevelId(i, 0);
                }
            }
        }

        public RubricObject GetParent()
        {
            return m_RubricObject;
        }

        private RubricObject m_RubricObject;

        public List<RubricObject> Children
        {
            get { return m_Children; }
            set { m_Children = value; }
        }
    }
}
