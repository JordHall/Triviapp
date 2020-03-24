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
        public ICollection<Question> Questions { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime DateAdded { get; set; }
    }
}
