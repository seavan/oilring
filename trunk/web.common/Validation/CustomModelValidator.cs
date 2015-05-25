using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.Reflection;
using System;
using Web.Common.Metadata;
using Web.Common.Validation.Attributes;

namespace Web.Common.Validation
{

    public abstract class CustomModelValidator : ICustomValueProvider
    {
        public CustomModelValidator()
        {
        }


        public bool TryUpdate(object _model, MessageStacker _messages)
        {
            return ProcessData(_model, _messages, true, true);
        }

        public string GetQualifiedName(PropertyInfo _property, object[] _parentObjects)
        {
            return _property.Name;
        }

        private bool TryGetParam(PropertyInfo _property, object _valueToConvert, out object _result)
        {
            var parser = CustomValidatorRepository.INST.GetParser(_property.PropertyType);
            //if (parser == null) throw new System.Exception("CustomModelValidator - value type not supported");
            if (parser == null)
            {
                _result = null;
                return false;
            }

            if (parser.TryParse(_valueToConvert, out _result))
            {
                return true;
            }
            else
            {
                _result = null;
                return false;
            }
        }

        private bool IsParamValid(PropertyInfo _property, object _parentObject, object _param, IList<string> _messages)
        {
            bool valid = true;
            var validators = _property.GetSpecialAttributes<ICustomValidator>();
            if ((validators == null) || (validators.Length == 0)) return valid;
            foreach(var validator in validators)
            {
                if (!validator.IsValid(_property, _parentObject, _param, this))
                {
                    _messages.Add( validator.GetMessage(_property, _parentObject, _param, this) );
                    valid = false;
                }
            }
            return valid;
        }

        private ICustomValidationParams GetValidationParams(PropertyInfo _property)
        {
            var validatorParams = _property.GetCustomAttributes(typeof(ICustomValidationParams), true).Cast<ICustomValidationParams>().FirstOrDefault();
            if (validatorParams == null) return new ValidationParamsAttribute();
            return validatorParams;
        }

        public abstract object GetPropertyParam(string _paramName);



        private bool ProcessData(object _object, MessageStacker _messages, bool _update = false, bool _checkValid = true, 
                                 object[] _parentObjects = null)
        {
            if( _object == null ) return false;
            var desiredType = _object.GetType();

            var props = desiredType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            if (_parentObjects == null) _parentObjects = new object[] { };

            bool RObjectValid = true;
            bool RObjectAssigned = true;

            SortedList<object, string> messages = new SortedList<object,string>();

            var messageStacker = _messages;

            foreach( var prop in props )
            {
                var propMessageStack = messageStacker.GetList(prop.Name);
                //var newParentObjects = new List<object>(_parentObjects.Length + 1);
                //newParentObjects.AddRange(_parentObjects);
                var rawParamName = GetQualifiedName(prop, _parentObjects);
                var rawParam = GetPropertyParam(rawParamName);
                object newValue = null;

                var validationParams = GetValidationParams(prop);

                // pre check if validation is required
                bool needValidationForEmpty = validationParams.ValidationRequired(null);
                bool requireField = validationParams.AttributeRequired(prop, _object, this);
                bool defaultIfEmpty = validationParams.ConvertNullToEmpty(prop);

                // partial saves
                if (rawParam == null) continue;
                if (requireField && ((rawParam == null) || ((rawParam != null)) && ((rawParam.ToString().Trim().Length == 0))))
                {
                    RObjectValid &= false;
                    RObjectAssigned &= false;
                    propMessageStack.Add(validationParams.GetMissingMessage(prop));
                    continue;
                }

                if ( (rawParam == null) || String.IsNullOrEmpty(rawParam.ToString()))
                {
                    continue;
                }

                if( TryGetParam(prop, rawParam, out newValue) )
                {
                    if (IsParamValid(prop, _object, rawParam, propMessageStack))
                    {
                        if (_update)
                        {
                            try
                            {
                                prop.SetValue(_object, newValue, new object[] { });
                            }
                            catch (System.Exception _e)
                            {
                            }
                        }
                    }
                    else
                    {
                        RObjectValid &= false;
                        RObjectAssigned &= false;
                    }
                }
                else
                {
                    if (rawParam != null && !String.IsNullOrEmpty(rawParam.ToString()))
                    {
                        RObjectValid &= false;
                        RObjectAssigned &= false;
                        propMessageStack.Add(validationParams.GetInvalidFormatMessage(prop));
                    }

                }
                
                // validation

            }

            return RObjectValid && (_update && RObjectAssigned || !_update);
        }
    }
}
