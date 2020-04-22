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
    public class DeleteModel : PageModel
    {
        private readonly Triviapp.Data.TriviappContext _context;

        public DeleteModel(Triviapp.Data.TriviappContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Quiz Quiz { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //RETREIVE QUIZ AND ASSOCIATED ACCOUNT
            Quiz = await _context.Quizzes
                .Include(q => q.Account).FirstOrDefaultAsync(m => m.ID == id);

            if (Quiz == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //RETREIVE QUIZ
            Quiz = await _context.Quizzes.FindAsync(id);

            if (Quiz != null)
            {
                _context.Quizzes.Remove(Quiz); //DELETE RECORD AND UPDATE
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Browse");
        }
    }
}
