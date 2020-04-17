using System.Linq;
using Microsoft.AspNetCore.Http;
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
        public void OnGet()
        {
            var Username = HttpContext.User.Identity.Name;
            Account = _context.Accounts.SingleOrDefault(a => a.Username.Equals(Username));
        }

        public IActionResult OnPost()
        {
            _context.Entry(Account).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToPage("Profile");
        }
    }
}