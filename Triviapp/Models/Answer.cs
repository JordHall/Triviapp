using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Triviapp.Models
{
    public class Answer
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public bool IsCorrect { get; set; }
        public int QuestionID { get; set; }
        public Question Question { get; set; }
    }
}
