using System;
using System.Collections.Generic;
using System.Linq;
using Web.Common.Validation.Parsers;

namespace Web.Common.Validation
{
  public class CustomValidatorRepository
    {
        private CustomValidatorRepository()
        {
            AddParser<int, IntParser>()
                .AddParser<long, LongParser>()
                .AddParser<bool, BooleanParser>()
                .AddParser<string, StringParser>()
                .AddParser<DateTime, DateTimeParser>()
                .AddParser<int?, NIntParser>()
                .AddParser<long?, NLongParser>()
                .AddParser<bool?, NBooleanParser>()
                .AddParser<Guid, GuidParser>()
                .AddParser<Guid?, NGuidParser>()
                .AddParser<DateTime?, NDateTimeParser>();
                
        }

        private string FormatKey(Type _type)
        {
            return _type.Name + ":" + String.Join(";", _type.GetGenericArguments().Select(s => s.Name));
        }

        public ICustomParser GetParser(Type _type)
        {
            var key = FormatKey(_type);
            return m_Parsers.IndexOfKey(key) != -1 ? m_Parsers[key] : null;

        }

        public void AddParser(Type _type, ICustomParser _parser)
        {
            m_Parsers[FormatKey(_type)] = _parser;
        }

        public CustomValidatorRepository AddParser<T, P>() where P : RegisteredParser<T>, ICustomParser,  new() 
        {
            AddParser(typeof(T), new P());
            return this;
        }

      public static CustomValidatorRepository INST = new CustomValidatorRepository();

        private SortedList<string, ICustomParser> m_Parsers = new SortedList<string, ICustomParser>();
    }

    public class CustomValidationMessageRepository
    {
        public void GetMessage(ICustomValidator _validator, Type _parentType, Type _fieldType, string _propertyName)
        {

        }

        public static CustomValidationMessageRepository INST = new CustomValidationMessageRepository();
    }
    /*  
    public class BaseStringTryStack
    {
        public BaseStringTryStack(params Type[] _types)
        {
            for (int i = 0; i < _types.Length; ++i)
            {
            }
        }

        public string GetValue(params string[] _values)
        {
            string cval = null;
            string ckey = "";
            for(int i = 0; i < _values.Length; ++i )
            {
                string val = _values[i];
                if( i > 0 ) ckey += "%";
                ckey += val;

                if (m_List.IndexOfKey(val) != -1)
                {
                    cval = m_List[i][val];
                }
                else
                {
                    break;
                }
            }
            return null;
        }

        private string CalculateHash(params string[] _values)
        {
            return String.Join("%", _values);
        }

        SortedList<string, string> m_List = new SortedList<string,string>();
    }

    public class StringTryStack4<A, B, C, D>
    {
        public StringTryStack3()
            : base(typeof(A), typeof(B), typeof(C))
        {
        }

        public string 
    } */
}