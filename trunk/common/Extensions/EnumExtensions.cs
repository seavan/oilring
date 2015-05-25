using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.ComponentModel;

namespace Common.Extensions
{
    public static class EnumExtensions
    {
        /// <summary>
        /// Читает описание енума из атрибута Description, если он есть. Атрибут DisplayName к элементам
        /// енума, к сожалению, не применим.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetDescription(this Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                  (DescriptionAttribute[])fi.GetCustomAttributes(
                  typeof(DescriptionAttribute), false);

            return (attributes.Length > 0) ? attributes[0].Description
                : value.ToString();
        }
    }
}
