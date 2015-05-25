using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Notamedia.Oilring.Community.Metadata.Attributes
{
    public class AutoCompleteAttribute : Attribute, IMetadataAttribute
    {
        public const string CONTROLLER = "AutoCompleteController";
        public const string ACTION = "AutoCompleteAction";
        public const string ADDITIONAL_PARAMS = "AutoCompleteParams";

        private readonly string m_controllerName;
        private readonly string m_actionName;
        /// <summary>
        /// Дополнительные параметры, значения которых надо передавать в запросе
        /// </summary>
        private readonly string[] m_additionalParameterNames;

        public AutoCompleteAttribute(string _controller, string _action, params string[] _parameterNames)
        {
            m_controllerName = _controller;
            m_actionName = _action;
            m_additionalParameterNames = _parameterNames;
        }

        public void Process(ModelMetadata _modelMetaData)
        {
            _modelMetaData.AdditionalValues.Add(CONTROLLER, m_controllerName);
            _modelMetaData.AdditionalValues.Add(ACTION, m_actionName);
            _modelMetaData.AdditionalValues.Add(ADDITIONAL_PARAMS, m_additionalParameterNames);

            // если шаблон не установлен вручную - применяем шаблон автокомплита по умалчиванию
            if (_modelMetaData.TemplateHint == null)
            {
                _modelMetaData.TemplateHint = "AutoComplete";
            }
        }
    }
}