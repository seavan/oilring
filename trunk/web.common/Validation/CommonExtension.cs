using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Linq;

namespace Web.Common.Validation
{
    public static class CommonExtension
    {
        static public Tattr GetSingleAttribute<Tattr>(this Type pi, bool Inherit = true) where Tattr : Attribute
        {
            var attrs = pi.GetCustomAttributes(typeof(Tattr), Inherit);
            if (attrs.Length > 0)
                return (Tattr)attrs[0];
            return null;
        }

        static public Tattr[] GetSpecialAttributes<Tattr>(this FieldInfo pi, bool Inherit = true) where Tattr : class
        {
            var attrs = pi.GetCustomAttributes(typeof(Tattr), Inherit);
            if (attrs.Length > 0)
                return attrs.Cast<Tattr>().ToArray();
            var mt = pi.DeclaringType.GetSingleAttribute<MetadataTypeAttribute>();
            if (mt != null)
            {
                var pi2 = mt.MetadataClassType.GetProperty(pi.Name);
                if (pi2 != null)
                    return pi2.GetSpecialAttributes<Tattr>(Inherit);
                var fi2 = mt.MetadataClassType.GetField(pi.Name);
                if (fi2 != null)
                    return fi2.GetSpecialAttributes<Tattr>(Inherit);

            }
            return null;
        }

        static public Tattr[] GetSpecialAttributes<Tattr>(this PropertyInfo pi, bool Inherit = true) where Tattr : class
        {
            var attrs = pi.GetCustomAttributes(typeof(Tattr), Inherit);
            if (attrs.Length > 0)
                return attrs.Cast<Tattr>().ToArray();
            var mt = pi.DeclaringType.GetSingleAttribute<MetadataTypeAttribute>();
            if (mt != null)
            {
                var pi2 = mt.MetadataClassType.GetProperty(pi.Name);
                if (pi2 != null)
                    return pi2.GetSpecialAttributes<Tattr>(Inherit);
                var fi2 = mt.MetadataClassType.GetField(pi.Name);
                if (fi2 != null)
                    return fi2.GetSpecialAttributes<Tattr>(Inherit);

            }
            return null;
        }

        static public Tattr GetSingleAttribute<Tattr>(this PropertyInfo pi, bool Inherit = true) where Tattr : class
        {
            var attrs = pi.GetSpecialAttributes<Tattr>();
            if ((attrs != null) && (attrs.Length > 0))
                return attrs[0];
            return null;
        }
 
    }
}