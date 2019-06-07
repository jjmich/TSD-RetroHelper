using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TSD_RetroHelper.Models;

namespace TSD_RetroHelper.Pages.RetroBoards1
{
    public class DeleteModel : PageModel
    {
        private readonly TSD_RetroHelper.Models.TSD_RetroHelperContext _context;

        public DeleteModel(TSD_RetroHelper.Models.TSD_RetroHelperContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            RetroBoard = await _context.RetroBoard.FindAsync(id);

            if (RetroBoard != null)
            {
                _context.RetroBoard.Remove(RetroBoard);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
