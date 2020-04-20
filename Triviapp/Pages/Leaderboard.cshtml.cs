using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Triviapp.Data;
using Triviapp.Models;

namespace Triviapp
{
    public class LeaderboardModel : PageModel
    {
        private readonly Triviapp.Data.TriviappContext _context;

        public LeaderboardModel(Triviapp.Data.TriviappContext context)
        {
            _context = context;
        }

        public IList<Account> Account { get;set; }

        public async Task OnGetAsync()
        {
            Account = await _context.Accounts.OrderByDescending(a => a.Score).ToListAsync();
        }
    }
}
