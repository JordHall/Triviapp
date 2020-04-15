using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Triviapp.Models
{
    public class Answer
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "Answer")]
        [Required]
        public string Title { get; set; }
        [Display(Name = "Correct")]
        [Required]
        public bool IsCorrect { get; set; }
        public int QuestionID { get; set; }
        public Question Question { get; set; }
    }
}
