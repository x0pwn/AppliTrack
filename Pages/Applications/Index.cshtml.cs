using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AppliTrack.Data;
using AppliTrack.Models;

namespace AppliTrack.Pages.Applications
{
    public class IndexModel : PageModel
    {
        private readonly JobTrackerContext _context;

        public IndexModel(JobTrackerContext context)
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
