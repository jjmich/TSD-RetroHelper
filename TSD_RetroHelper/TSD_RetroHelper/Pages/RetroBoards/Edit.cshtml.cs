using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TSD_RetroHelper.Models;

namespace TSD_RetroHelper.Pages.RetroBoards
{
    public class EditModel : PageModel
    {
        private readonly TSD_RetroHelper.Models.TSD_RetroHelperContext _context;

        public EditModel(TSD_RetroHelper.Models.TSD_RetroHelperContext context)
        {
            _context = context;
        }

        [BindProperty]
        public RetroBoard RetroBoard { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            RetroBoard = await _context.RetroBoard.FirstOrDefaultAsync(m => m.ID == id);

            if (RetroBoard == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(RetroBoard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RetroBoardExists(RetroBoard.ID))
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

        private bool RetroBoardExists(int id)
        {
            return _context.RetroBoard.Any(e => e.ID == id);
        }
    }
}
