using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Triviapp.Models
{
    public class Question
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public ICollection<Answer> Answers { get; set; }
        public int QuizID { get; set; }
        public Quiz Quiz { get; set; }
    }
}
