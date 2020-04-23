using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Triviapp.Models;

namespace Triviapp
{
    public class ProfileModel : PageModel
    {
        private readonly Triviapp.Data.TriviappContext _context;

        public ProfileModel(Triviapp.Data.TriviappContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Account Account { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            try
            {
                Account = await _context.Accounts.FirstOrDefaultAsync(a => a.Username.Equals(HttpContext.User.Identity.Name)); //GET ACCOUNT FROM DATABASE
                if (Account == null)
                {
                    return NotFound();
                }
                Account.Quizzes = await _context.Quizzes.Where(q => q.AccountID == Account.ID).ToListAsync(); //GET ACCOUNTS QUIZZES
                return Page();
            }
            catch
            {
                return NotFound();
            }
        }
    }
}