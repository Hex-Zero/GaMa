using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GameManagerUi.Models;

namespace GameManagerUi.Pages.Venues
{
    public class DeleteModel : PageModel
    {
        private readonly GameManagerUi.Models.GaMaDbContext _context;

        public DeleteModel(GameManagerUi.Models.GaMaDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Venue Venue { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Venue = await _context.Venues.FirstOrDefaultAsync(m => m.VenueId == id);

            if (Venue == null)
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

            Venue = await _context.Venues.FindAsync(id);

            if (Venue != null)
            {
                _context.Venues.Remove(Venue);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
