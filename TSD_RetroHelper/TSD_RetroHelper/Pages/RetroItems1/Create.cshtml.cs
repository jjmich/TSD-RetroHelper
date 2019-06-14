using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TSD_RetroHelper.Models;

namespace TSD_RetroHelper.Pages.RetroItems1
{
    public class CreateModel : PageModel
    {
        private readonly TSD_RetroHelper.Models.TSD_RetroHelperContext _context;

        public CreateModel(TSD_RetroHelper.Models.TSD_RetroHelperContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["RetroBoardRefId"] = new SelectList(_context.RetroBoard, "ID", "ID");
            //ViewData["ColumnId"] = Request.QueryString("ColumnId")
            return Page();
        }

        [BindProperty]
        public RetroItem RetroItem { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.RetroItem.Add(RetroItem);
            await _context.SaveChangesAsync();
            string blahID = string.Empty;

            var retroItemId = RetroItem.RetroBoardRefId;

            return Redirect($"/RetroItems1?id={retroItemId}");
        }
    }
}