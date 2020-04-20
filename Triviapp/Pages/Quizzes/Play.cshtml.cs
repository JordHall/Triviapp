﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
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
        public Account PlayingAccount { get; set; }
        public string ErrorMsg;
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //Get Quiz with the passed ID and store locally
            Quiz = await _context.Quizzes.FirstOrDefaultAsync(m => m.ID == id);

            //Get Account with the Account ID in the Quiz
            Quiz.Account = await _context.Accounts.FirstOrDefaultAsync(a => a.ID == Quiz.AccountID);

            //Get current players Account if they have one
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                PlayingAccount = await _context.Accounts.FirstOrDefaultAsync(a => a.Username.Equals(HttpContext.User.Identity.Name));
            }

            //Get the Questions from this Quiz and store into its list
            Quiz.Questions = await _context.Questions.Where(q => q.QuizID == id).ToListAsync();

            //Get each Questions Answers and store them into their lists
            foreach (var item in Quiz.Questions)
            {
                item.Answers = await _context.Answers.Where(a => a.QuestionID == item.ID).ToListAsync();
            }

            if (Quiz == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            //Account PlayingAccount = await _context.Accounts.FirstOrDefaultAsync(a => a.Username.Equals(HttpContext.User.Identity.Name));
            //PlayingAccount.Score +=;
            //_context.Attach(PlayingAccount).State = EntityState.Modified;
            //_context.Accounts.Update(PlayingAccount);
            _context.Attach(PlayingAccount).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountExists(this.PlayingAccount.ID))
                {
                    return base.NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("Browse");
        }

        private bool AccountExists(int id)
        {
            return _context.Accounts.Any(a => a.ID == id);
        }
    }
}
