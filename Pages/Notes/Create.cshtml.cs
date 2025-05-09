using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AppliTrack.Data;
using AppliTrack.Models;

namespace AppliTrack.Pages_Notes
{
    public class CreateModel : PageModel
    {
        private readonly AppliTrack.Data.JobTrackerContext _context;

        public CreateModel(AppliTrack.Data.JobTrackerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ApplicationId"] = new SelectList(_context.Applications, "Id", "Company");
            return Page();
        }

        [BindProperty]
        public Note Note { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Notes == null || Note == null)
            {
                return Page();
            }

            _context.Notes.Add(Note);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
