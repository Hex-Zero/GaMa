﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GameManagerUi.Models;

namespace GameManagerUi.Pages.Players
{
    public class DetailsModel : PageModel
    {
        private readonly GameManagerUi.Models.GaMaDbContext _context;

        public DetailsModel(GameManagerUi.Models.GaMaDbContext context)
        {
            _context = context;
        }

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
            return Page();
        }
    }
}
