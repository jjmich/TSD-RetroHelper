using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TSD_RetroHelper.Models;

namespace TSD_RetroHelper.Pages.RetroBoards
{
    public class DetailsModel : PageModel
    {
        private readonly TSD_RetroHelper.Models.TSD_RetroHelperContext _context;

        public DetailsModel(TSD_RetroHelper.Models.TSD_RetroHelperContext context)
        {
            _context = context;
        }

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
    }
}
