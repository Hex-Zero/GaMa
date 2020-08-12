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
    public class DetailsModel : PageModel
    {
        private readonly GaMaUI.Models.GaMaDbContext _context;

        public DetailsModel(GaMaUI.Models.GaMaDbContext context)
        {
            _context = context;
        }

        public GameManager GameManager { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            GameManager = await _context.GameManagers.FirstOrDefaultAsync(m => m.Id == id);

            if (GameManager == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
