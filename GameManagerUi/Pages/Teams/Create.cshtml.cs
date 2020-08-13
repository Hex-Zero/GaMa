using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GameManagerUi.Models;
using Microsoft.EntityFrameworkCore;

namespace GameManagerUi.Pages.Teams
{
    public class CreateModel : PageModel
    {
        private readonly GameManagerUi.Models.GaMaDbContext _context;

        public CreateModel(GameManagerUi.Models.GaMaDbContext context)
        {
            _context = context;
        }

        public SelectList VenueSelect { get; set; }

        void PopulateVenueList(object selectedVenue = null)
        {
            var venueQuery = from venue in _context.Venues
                orderby venue.City
                select venue;
            VenueSelect = new SelectList(venueQuery.AsNoTracking(),"VenueId","Street", selectedVenue);
        }

        public IActionResult OnGet()
        {
            PopulateVenueList();
            return Page();
        }

        [BindProperty]
        public Team Team { get; set; }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Teams.Add(Team);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
