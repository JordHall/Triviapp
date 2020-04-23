using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Triviapp
{
    public class LogoutModel : PageModel
    {
        public IActionResult OnGet()
        {
            try
            {
                HttpContext.SignOutAsync();
                return RedirectToPage("/Index");
            }
            catch
            {
                return RedirectToPage("/Index");
            }
        }
    }
}