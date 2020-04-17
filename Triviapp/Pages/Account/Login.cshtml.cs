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

            var storedAccount = _context.Accounts.SingleOrDefault(a => a.Username.Equals(Account.Username));
            if (storedAccount != null)
            {
                if (BCrypt.Net.BCrypt.Verify(Account.Password, storedAccount.Password))
                {
                    var userClaims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name, Account.Username),
                        new Claim("Triviapp","This is a user")
                    };
                    var userIdentity = new ClaimsIdentity(userClaims, "User Identity");
                    var userPrincipal = new ClaimsPrincipal(userIdentity);
                    await HttpContext.SignInAsync(userPrincipal);
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