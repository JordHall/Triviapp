using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Triviapp.Data;
using Triviapp.Models;

namespace Triviapp
{
    public class RegisterModel : PageModel
    {
        private readonly Triviapp.Data.TriviappContext _context;

        public RegisterModel(Triviapp.Data.TriviappContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Account Account { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            try
            {
                IList<Account> Accounts = _context.Accounts.ToList();
                foreach (var account in Accounts)
                {
                    if (account.Username == Account.Username)
                    {
                        return Page();
                    }
                }

                Account.Score = 0; //INITIALISE SCORE
                Account.Password = BCrypt.Net.BCrypt.HashPassword(Account.Password); //HASH PASSWORD WITH BCRYPT
                _context.Accounts.Add(Account);
                await _context.SaveChangesAsync();//UPDATE DATABASE
                HttpContext.Session.SetString("username", Account.Username);
                return RedirectToPage("/Quizzes/Browse");
            }
            catch
            {
                return Page();
            }
        }
    }
}
