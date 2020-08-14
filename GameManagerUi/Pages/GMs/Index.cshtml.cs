using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GameManagerUi.Models;

namespace GameManagerUi.Pages.GMs
{
    public class IndexModel : PageModel
    {
        private readonly GameManagerUi.Models.GaMaDbContext _context;

        public IndexModel(GameManagerUi.Models.GaMaDbContext context)
        {
            _context = context;
        }

        public IList<GameManager> GameManager { get;set; }

        public async Task OnGetAsync()
        {
            ManagerId.Id = 0;
            GameManager = await _context.GameManagers.ToListAsync();
        }
    }
}
