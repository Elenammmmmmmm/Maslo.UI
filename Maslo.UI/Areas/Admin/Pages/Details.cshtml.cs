using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KR.Domain.Entities;
using Maslo.UI.Data;

namespace Maslo.UI.Areas.Admin.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly Maslo.UI.Data.ApplicationDbContext _context;

        public DetailsModel(Maslo.UI.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Kros Kros { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kros = await _context.Kros.FirstOrDefaultAsync(m => m.KrosId == id);
            if (kros == null)
            {
                return NotFound();
            }
            else
            {
                Kros = kros;
            }
            return Page();
        }
    }
}
