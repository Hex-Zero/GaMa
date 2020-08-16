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

        public IActionResult OnGet()
        {
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
            Team.ManagerId = ManagerId.Id;
            _context.Teams.Add(Team);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
