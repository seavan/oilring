using System;

namespace Web.Common.Validation.Parsers
{
    public class BasicOrdinalParser<T> : RegisteredParser<T> where T : struct
    {

        #region ICustomParser Members

        public override bool TryParse(object _value, out object _result)
        {
            if (_value == null)
            {
                _result = Activator.CreateInstance<T>();
            }
            try
            {
                _result = Convert.ChangeType(_value, typeof(T));
            }
            catch
            {
                _result = null;
                return false;
            }

            return true;
        }

        #endregion
    }

    public class BasicNullableParser<T> : RegisteredParser<T?> where T: struct
    {

        #region ICustomParser Members

        public override bool TryParse(object _value, out object _result)
        {
            if (_value == null)
            {
                _result = Activator.CreateInstance<T>();
            }
            try
            {
                _result = new Nullable<T>((T)Convert.ChangeType(_value, typeof(T)));
            }
            catch
            {
                _result = null;
                return false;
            }

            return true;
        }

        #endregion
    }

    public class IntParser : BasicOrdinalParser<int>
    {
    }

    public class LongParser : BasicOrdinalParser<long>
    {
    }

    public class BooleanParser : RegisteredParser<bool>
    {
        #region ICustomParser Members

        public override bool TryParse(object _value, out object _result)
        {
            if (_value == null)
            {
                _result = Activator.CreateInstance<bool>();
            }
            try
            {
                var input = _value.ToString().ToLower().Trim();
                if ((input.Length == 0) || (input == "false") || (input == "0"))
                {
                    _result = false;
                }
                else
                {
                    _result = true;
                }

            }
            catch
            {
                _result = null;
                return false;
            }

            return true;
        }

        #endregion
    }

    public class NIntParser : BasicNullableParser<int>
    {
    }

    public class NLongParser : BasicNullableParser<long>
    {

    }

    public class NBooleanParser : RegisteredParser<bool?>
    {
        #region ICustomParser Members

        public override bool TryParse(object _value, out object _result)
        {
            if (_value == null)
            {
                _result = Activator.CreateInstance<bool>();
            }
            try
            {
                var input = _value.ToString().ToLower().Trim();
                if ((input.Length == 0) || (input == "false") || (input == "0"))
                {
                    _result = false;
                }
                _result = true;

            }
            catch
            {
                _result = null;
                return false;
            }

            return true;
        }

        #endregion
    }

    public class DateTimeParser : RegisteredParser<DateTime>
    {

        public override bool TryParse(object _value, out object _result)
        {
            if (_value == null)
            {
                _result = DateTime.Now;
            }
            try
            {
                _result = DateTime.Parse(_value.ToString());
            }
            catch
            {
                _result = null;
                return false;
            }

            return true;
            
        }
    }

    public class NDateTimeParser : RegisteredParser<DateTime?>
    {

        public override bool TryParse(object _value, out object _result)
        {
            if (_value == null)
            {
                _result = null;
            }
            try
            {
                _result = new Nullable<DateTime>(DateTime.Parse(_value.ToString()));
            }
            catch
            {
                _result = null;
                return false;
            }

            return true;

        }
    }

    public class StringParser : RegisteredParser<String>
    {

        public override bool TryParse(object _value, out object _result)
        {
            if (_value == null)
            {
                _result = "";
            }
            try
            {
                _result = _value.ToString();
            }
            catch
            {
                _result = null;
                return false;
            }

            return true;

        }
    }

    public class GuidParser : RegisteredParser<Guid>
    {
        public override bool TryParse(object _value, out object _result)
        {
            if (_value == null)
            {
                _result = new Guid();
            }
            try
            {
                _result = new Guid(_value.ToString());
            }
            catch
            {
                _result = null;
                return false;
            }
            return true;
        }
    }

    public class NGuidParser : RegisteredParser<Guid?>
    {
        public override bool TryParse(object _value, out object _result)
        {
            if (_value == null)
            {
                _result = new Nullable<Guid>(new Guid());
            }
            try
            {
                _result = new Nullable<Guid>(new Guid(_value.ToString()));
            }
            catch
            {
                _result = null;
                return false;
            }
            return true;
        }
    }
}