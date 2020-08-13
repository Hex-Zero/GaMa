using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GameManagerUi.Models;
using Microsoft.EntityFrameworkCore;

namespace GameManagerUi.Pages.Players
{
    public class CreateModel : PageModel
    {
        private readonly GameManagerUi.Models.GaMaDbContext _context;

        public CreateModel(GameManagerUi.Models.GaMaDbContext context)
        {
            _context = context;
        }
        public SelectList TeamSelect { get; set; }
        void PopulateTeamsList(object selectedTeam = null)
        {
            var teamQuery = from team in _context.Teams
                orderby team.Name
                select team;
            TeamSelect = new SelectList(teamQuery.AsNoTracking(),"TeamId","Name",selectedTeam);
        }

        public IActionResult OnGet()
        {
            PopulateTeamsList();
            return Page();
        }

        [BindProperty]
        public Player Player { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Players.Add(Player);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
