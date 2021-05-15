using System;

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
        public int Id { get; set; }   
        public string Name { get; set; }
        public int Number { get; set; }
        public DateTime RegisteredAt { get; set; }
        public Sex Sex { get; set; }
    }
}