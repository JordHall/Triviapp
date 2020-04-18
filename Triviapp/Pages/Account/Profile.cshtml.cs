using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
            Account = _context.Accounts.SingleOrDefault(a => a.Username.Equals(HttpContext.User.Identity.Name)); //GET ACCOUNT FROM DATABASE
        }
    }
}