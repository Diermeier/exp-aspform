using System;
using System.ComponentModel.DataAnnotations;

namespace Exp.Aspform.Form.UIHintAttributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class DropDownHintAttribute : UIHintAttribute
    {
        public DropDownHintAttribute(string dropDownSourcePropertyName)
            : base("DropDown")
        {
            DropDownSourcePropertyName = dropDownSourcePropertyName;
        }

        public string DropDownSourcePropertyName { get; set; }
    }
}