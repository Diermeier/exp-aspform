using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [Editable(false)]
        public int Id { get; set; }   

        public string Name { get; set; } = string.Empty;

        [Range(1000, 1999)]
        public int Number { get; set; }
        public DateTime RegisteredAt { get; set; }

        public Sex Sex { get; set; }
    }
}