using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Exp.Aspform.Form.UIHintAttributes;
using Microsoft.AspNetCore.Mvc;

namespace Exp.Aspform.Form.Models
{
    public enum Sex
    {
        Unknown,
        Male,
        Female,
    }

    public class CustomerViewModel
    {
        [HiddenInput]
        public int Id { get; set; }   

        public string Name { get; set; } = string.Empty;

        [Range(1000, 1999)]
        public int Number { get; set; }

        public DateTime RegisteredAt { get; set; }

        [DropDownHint(nameof(SexSource))]
        public Sex Sex { get; set; }

        public IEnumerable<Sex> SexSource { get; } = new [] { Sex.Male, Sex.Female, };
    }
}