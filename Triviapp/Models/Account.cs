using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Triviapp.Models
{
    public class Account
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public int Score { get; set; }
        public bool Visibility { get; set; }
        public IList<Quiz> Quizzes { get; set; }
    }
}
