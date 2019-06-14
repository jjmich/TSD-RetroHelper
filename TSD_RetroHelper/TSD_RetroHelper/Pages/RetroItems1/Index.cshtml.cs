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
    public class IndexModel : PageModel
    {
        private readonly TSD_RetroHelper.Models.TSD_RetroHelperContext _context;

        public IndexModel(TSD_RetroHelper.Models.TSD_RetroHelperContext context)
        {
            _context = context;
        }

        public IList<RetroItem> RetroItem { get;set; }

        public async Task OnGetAsync()
        {
            RetroItem = await _context.RetroItem
                .Include(r => r.RetroBoard).ToListAsync();
        }
    }
}
