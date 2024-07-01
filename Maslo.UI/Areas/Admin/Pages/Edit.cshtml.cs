using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KR.Domain.Entities;
using Maslo.UI.Data;

namespace Maslo.UI.Areas.Admin.Pages
{
    public class EditModel : PageModel
    {
        private readonly Maslo.UI.Data.ApplicationDbContext _context;

        public EditModel(Maslo.UI.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Kros Kros { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kros =  await _context.Kros.FirstOrDefaultAsync(m => m.KrosId == id);
            if (kros == null)
            {
                return NotFound();
            }
            Kros = kros;
           ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "GroupName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Kros).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KrosExists(Kros.KrosId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool KrosExists(int id)
        {
            return _context.Kros.Any(e => e.KrosId == id);
        }
    }
}
