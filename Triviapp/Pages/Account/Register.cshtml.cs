using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
        public string ErrorMsg;

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            try
            {   //GRAB ACCOUNTS
                IList<Account> Accounts = _context.Accounts.ToList();
                foreach (var account in Accounts)
                {   //ERROR IF USERNAME NOT UNIQUE
                    if (account.Username == Account.Username)
                    {
                        ErrorMsg = "Username already exists";
                        return Page();
                    }
                }
                //INITIALISE SCORE
                Account.Score = 0;
                Account.Password = BCrypt.Net.BCrypt.HashPassword(Account.Password); //HASH PASSWORD WITH BCRYPT
                _context.Accounts.Add(Account);
                await _context.SaveChangesAsync(); //UPDATE DATABASE
                var userClaims = new List<Claim>()
                    {   //CREATE COOKIE
                        new Claim(ClaimTypes.Name, Account.Username),
                        new Claim("Triviapp","This is a user")
                    };
                var userIdentity = new ClaimsIdentity(userClaims, "User Identity");
                var userPrincipal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(userPrincipal);
                return RedirectToPage("/Quizzes/Browse");
            }
            catch
            {   //ERROR ACCESSING DATABASE
                ErrorMsg = "An error occurred, please try again later";
                return Page();
            }
        }
    }
}
