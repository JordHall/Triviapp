using System.Collections.Generic;
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

        public async Task OnGetAsync()
        {
            Quiz = await _context.Quizzes.ToListAsync();
            foreach (var quiz in Quiz)
            {
                quiz.Account = await _context.Accounts.FirstOrDefaultAsync(a => a.ID == quiz.AccountID);
            }
        }
    }
}
