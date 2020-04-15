using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var storedAccount = _context.Accounts.SingleOrDefault(a => a.Username.Equals(Account.Username));
            if (storedAccount != null)
            {
                if (BCrypt.Net.BCrypt.Verify(Account.Password, storedAccount.Password))
                {
                    HttpContext.Session.SetString("username", Account.Username);
                    return RedirectToPage("/Quizzes/Browse");
                }
                else
                {
                    return Page();
                }
            }
            else
            {
                return Page();
            }
        }
    }
}