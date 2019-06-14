using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TSD_RetroHelper.Models;

namespace TSD_RetroHelper.Pages.RetroItems1
{
    public class DetailsModel : PageModel
    {
        private readonly TSD_RetroHelper.Models.TSD_RetroHelperContext _context;

        public DetailsModel(TSD_RetroHelper.Models.TSD_RetroHelperContext context)
        {
            _context = context;
        }

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
            return Page();
        }
    }
}
