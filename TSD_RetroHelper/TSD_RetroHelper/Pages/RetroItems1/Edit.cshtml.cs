using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TSD_RetroHelper.Models;

namespace TSD_RetroHelper.Pages.RetroItems1
{
    public class EditModel : PageModel
    {
        private readonly TSD_RetroHelper.Models.TSD_RetroHelperContext _context;

        public EditModel(TSD_RetroHelper.Models.TSD_RetroHelperContext context)
        {
            _context = context;
        }

        [BindProperty]
        public RetroItem RetroItem { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            RetroItem = await _context.RetroItem
                .Include(r => r.RetroBoard).FirstOrDefaultAsync(m => m.Id == id);

            if (RetroItem == null)
            {
                return NotFound();
            }
           ViewData["RetroBoardRefId"] = new SelectList(_context.RetroBoard, "ID", "ID");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(RetroItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RetroItemExists(RetroItem.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            var retroItemId = RetroItem.RetroBoardRefId;

            return Redirect($"/RetroItems1?id={retroItemId}");
        }

        private bool RetroItemExists(int id)
        {
            return _context.RetroItem.Any(e => e.Id == id);
        }
    }
}
