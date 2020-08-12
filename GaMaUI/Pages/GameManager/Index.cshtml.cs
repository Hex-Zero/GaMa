using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GaMaDataAccess.Models;

namespace GaMaUI.Pages.GameManager
{
    public class IndexModel : PageModel
    {
        private readonly GaMaDataAccess.Models.GaMaDbContext _context;

        public IndexModel(GaMaDataAccess.Models.GaMaDbContext context)
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
