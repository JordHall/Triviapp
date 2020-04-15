using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Triviapp.Models;

namespace Triviapp
{
    public class LoginModel : PageModel
    {
        private readonly Triviapp.Data.TriviappContext _context;

        public LoginModel(Triviapp.Data.TriviappContext context)
        {
            _context = context;
        }
        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Account Account { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Accounts.Add(Account);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Quizzes/Browse");
        }
    }
}