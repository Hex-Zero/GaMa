using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GameManagerUi.Models;

namespace GameManagerUi.Pages.Matches
{
    public class EditModel : PageModel
    {
        private readonly GameManagerUi.Models.GaMaDbContext _context;

        public EditModel(GameManagerUi.Models.GaMaDbContext context)
        {
            _context = context;
        }

        public SelectList TeamSelect { get; set; }

        public void PopulateTeamsList(object selectedTeam = null)
        {
            var teamQuery = from team in _context.Teams
                orderby team.Name
                select team;
            TeamSelect = new SelectList(teamQuery.AsNoTracking(),"TeamId","Name",selectedTeam);
        }


        [BindProperty]
        public Match Match { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Match = await _context.Matches.FirstOrDefaultAsync(m => m.MatchId == id);
            PopulateTeamsList();
            if (Match == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Match.ManagerId = ManagerId.Id;
            _context.Attach(Match).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MatchExists(Match.MatchId))
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

        private bool MatchExists(int id)
        {

            return _context.Matches.Any(e => e.MatchId == id);
        }
    }
}
