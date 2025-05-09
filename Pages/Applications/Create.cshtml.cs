using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AppliTrack.Data;
using AppliTrack.Models;
using System;
using System.Linq;
using System.Collections.Generic;

namespace AppliTrack.Pages.Applications
{
    public class CreateModel : PageModel
    {
        private readonly JobTrackerContext _context;

        public CreateModel(JobTrackerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Application Application { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            // Check ModelState errors if validation fails
            if (!ModelState.IsValid)
            {
                // Log which fields are invalid
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    Console.WriteLine($"Validation Error: {error.ErrorMessage}");
                }
                return Page();
            }

            try
            {
                // Make sure Application.Notes is initialized
                Application.Notes = new List<Note>();
                
                _context.Applications.Add(Application);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                // Add the error to ModelState
                ModelState.AddModelError(string.Empty, $"Error creating application: {ex.Message}");
                return Page();
            }
        }
    }
}
