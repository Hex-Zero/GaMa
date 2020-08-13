using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GameManagerUi.Models;

namespace GameManagerUi.Pages.Players
{
    public class EditModel : PageModel
    {
        private readonly GameManagerUi.Models.GaMaDbContext _context;

        public EditModel(GameManagerUi.Models.GaMaDbContext context)
        {
            _context = context;
        } public SelectList TeamSelect { get; set; }

        public void PopulateTeamsList(object selectedTeam = null)
        {
            var teamQuery = from team in _context.Teams
                orderby team.Name
                select team;
            TeamSelect = new SelectList(teamQuery.AsNoTracking(),"TeamId","Name",selectedTeam);
        }


        [BindProperty]
        public Player Player { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Player = await _context.Players.FirstOrDefaultAsync(m => m.PlayerId == id);

            if (Player == null)
            {
                return NotFound();
            }

            PopulateTeamsList(Player);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Player).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerExists(Player.PlayerId))
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

        private bool PlayerExists(int id)
        {
            return _context.Players.Any(e => e.PlayerId == id);
        }
    }
}
