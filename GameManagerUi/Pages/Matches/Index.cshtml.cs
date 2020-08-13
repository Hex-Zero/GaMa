using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GameManagerUi.Models;

namespace GameManagerUi.Pages.Matches
{
    public class IndexModel : PageModel
    {
        private readonly GameManagerUi.Models.GaMaDbContext _context;

        public IndexModel(GameManagerUi.Models.GaMaDbContext context)
        {
            _context = context;
        }

        public IList<Match> Match { get;set; }

        public async Task OnGetAsync(int id)
        {
            if (ManagerId.Id == 0)
            {
                ManagerId.Name = _context.GameManagers.Single(c => c.GameManagerId == id).Name;
                ManagerId.Id = id;
            }
           var matchList = await _context.Matches.Where(c=> c.ManagerId == ManagerId.Id).ToListAsync();
           foreach (var match in matchList)
           {
               match.HomeTeam = _context.Teams.Single(c => c.TeamId == match.HomeTeamId);
               match.AwayTeam = _context.Teams.Single(c => c.TeamId == match.AwayTeamId);
           }
           Match = matchList;
        }
    }
}
