using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Triviapp.Models
{
    public class Quiz
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public IList<Question> Questions { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }
    }
}
