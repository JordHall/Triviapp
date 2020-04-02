﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Triviapp.Data;
using Triviapp.Models;

namespace Triviapp
{
    public class CreateModel : PageModel
    {
        private readonly Triviapp.Data.TriviappContext _context;

        public CreateModel(Triviapp.Data.TriviappContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Quiz Quiz { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            //Quiz data validation failure
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //Quiz date validation success
            //Binds current date
            Quiz.DateAdded = DateTime.Today;
            _context.Quizzes.Add(Quiz);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Quizzes/Browse");
        }
    }
}