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
    public class PlayModel : PageModel
    {
        private readonly Triviapp.Data.TriviappContext _context;

        public PlayModel(Triviapp.Data.TriviappContext context)
        {
            _context = context;
        }

        public Quiz Quiz { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Quiz = await _context.Quizzes.FirstOrDefaultAsync(m => m.ID == id);

            if (Quiz == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
