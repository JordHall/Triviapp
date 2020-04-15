using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Triviapp.Models
{
    public class Account
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Score { get; set; }
        public bool Visibility { get; set; }
        public IList<Quiz> Quizzes { get; set; }
    }
}
