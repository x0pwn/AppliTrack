using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppliTrack.Data;
using AppliTrack.Models;

namespace AppliTrack.Pages_Notes
{
    public class EditModel : PageModel
    {
        private readonly AppliTrack.Data.JobTrackerContext _context;

        public EditModel(AppliTrack.Data.JobTrackerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Note Note { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Notes == null)
            {
                return NotFound();
            }

            var note =  await _context.Notes.FirstOrDefaultAsync(m => m.Id == id);
            if (note == null)
            {
                return NotFound();
            }
            Note = note;
           ViewData["ApplicationId"] = new SelectList(_context.Applications, "Id", "Company");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Note).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NoteExists(Note.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool NoteExists(int id)
        {
          return (_context.Notes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
