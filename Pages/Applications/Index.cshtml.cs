using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AppliTrack.Data;
using AppliTrack.Models;

namespace AppliTrack.Pages_Applications
{
    public class IndexModel : PageModel
    {
        private readonly AppliTrack.Data.JobTrackerContext _context;

        public IndexModel(AppliTrack.Data.JobTrackerContext context)
        {
            _context = context;
        }

        public IList<Application> Application { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Applications != null)
            {
                Application = await _context.Applications.ToListAsync();
            }
        }
    }
}
