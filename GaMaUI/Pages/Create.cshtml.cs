using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GaMaUI.Models;

namespace GaMaUI.Pages
{
    public class CreateModel : PageModel
    {
        private readonly GaMaUI.Models.GaMaDbContext _context;

        public CreateModel(GaMaUI.Models.GaMaDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public GameManager GameManager { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.GameManagers.Add(GameManager);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
