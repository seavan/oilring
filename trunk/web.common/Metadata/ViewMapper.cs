using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Web.Common.Validation;


namespace Web.Common.Metadata
{
    public enum LinkType
    {
        ltOneToOne, ltOneToMany, ltManyToMany
    }

    public enum LinkMode
    {
        ltGrid, ltComboBox
    }



    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class ComboValuesAttribute : Attribute
    {
        public Dictionary<int, string> Values { get; set; }
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class PrivacyComboValuesAttribute : ComboValuesAttribute
    {
        public PrivacyComboValuesAttribute()
        {
            Values = new Dictionary<int, string>()
            {
                {0, "Всем"},
                {1, "Коллегам"},
                {2, "Никому"},
            };
        }
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class LinkAttribute : Attribute
    {
        public LinkType LinkType { get; set; }
        public LinkMode LinkMode { get; set; }
        public string ThisKeyName { get; set; }
        public string ForeignKeyName { get; set; }
        public string DisplayField { get; set; }
        public string ThisLinkTable { get; set; }
        public string Template { get; set; }
        public string Controller { get; set; }
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class ManyToManyLinkAttribute : LinkAttribute
    {
        public ManyToManyLinkAttribute()
        {
            LinkType = LinkType.ltManyToMany;
        }
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class OneToManyLinkAttribute : LinkAttribute
    {
        public OneToManyLinkAttribute()
        {
            LinkType = LinkType.ltOneToMany;
        }
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class OneToOneLinkAttribute : LinkAttribute
    {
        public OneToOneLinkAttribute()
        {
            LinkType = LinkType.ltOneToOne;
        }
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class WizardAttribute : Attribute
    {
        public WizardAttribute()
        {
            
        }

        public int Step { get; set; }
    }

}
