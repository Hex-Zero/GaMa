using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GameManagerUi.Models;
using Microsoft.EntityFrameworkCore;

namespace GameManagerUi.Pages.Matches
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
                where team.Name != "Free Agent"
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
        public Match Match { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Match.ManagerId = ManagerId.Id;
            _context.Matches.Add(Match);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
