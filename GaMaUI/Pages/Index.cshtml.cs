using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GaMaUI.Models;

namespace GaMaUI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly GaMaUI.Models.GaMaDbContext _context;

        public IndexModel(GaMaUI.Models.GaMaDbContext context)
        {
            _context = context;
        }

        public IList<GameManager> GameManager { get;set; }

        public async Task OnGetAsync()
        {
            GameManager = await _context.GameManagers.ToListAsync();
        }
    }
}
