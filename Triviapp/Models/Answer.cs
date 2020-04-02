using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Triviapp.Models
{
    public class Answer
    {
        public int ID { get; set; }

        [Display(Name = "Answer")]
        public string Title { get; set; }
        public bool IsCorrect { get; set; }
        public int QuestionID { get; set; }
        public Question Question { get; set; }
    }
}
