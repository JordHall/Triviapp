using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Triviapp.Models;

namespace Triviapp
{
    public class BrowseModel : PageModel
    {
        private readonly Triviapp.Data.TriviappContext _context;

        public BrowseModel(Triviapp.Data.TriviappContext context)
        {
            _context = context;
        }

        public IList<Quiz> Quiz { get;set; }
        public Account Account { get; set; }
        public async Task OnGetAsync()
        {   
            try
            {
                //Get current players Account if they have one
                if (HttpContext.User.Identity.IsAuthenticated)
                {
                    Account = await _context.Accounts.FirstOrDefaultAsync(a => a.Username.Equals(HttpContext.User.Identity.Name));
                }
                Quiz = await _context.Quizzes.ToListAsync();
                foreach (var quiz in Quiz)
                {   //GET QUIZZES AND ACCOUNTS THAT ARE VISIBILE
                    quiz.Account = await _context.Accounts.Where(a => a.Visibility == true).FirstOrDefaultAsync(a => a.ID == quiz.AccountID);
                }
            }
            catch
            {   //REDIRECT IF DATABASE FAILS TO LOAD
                RedirectToPage("./Index");
            }
        }
    }
}
