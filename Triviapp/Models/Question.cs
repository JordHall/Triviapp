﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Triviapp.Models
{
    public class Question
    {
        public int ID { get; set; }
        
        [Display(Name = "Question")]
        public string Title { get; set; }
        public IList<Answer> Answers { get; set; }
        public int QuizID { get; set; }
        public Quiz Quiz { get; set; }
    }
}
