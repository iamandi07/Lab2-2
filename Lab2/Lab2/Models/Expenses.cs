using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2.Models
{
    public enum Importance { low, medium, high }
    public enum Status { always, necessary, optional }
    public class Expenses
    {
        [Required]
        public long Id { get; set; }
        [Required] 
        public string Description { get; set; }
        [Required] 
        public double Sum { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Currency { get; set; }
        [Required]
        public string Type { get; set; }
        public Importance Importance { get; set; }
        public Status Status { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
