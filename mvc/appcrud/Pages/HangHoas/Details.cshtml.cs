using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using appcrud.Data;
using appcrud.Model;

namespace appcrud.Pages.HangHoas
{
    public class DetailsModel : PageModel
    {
        private readonly appcrud.Data.appcrudContext _context;

        public DetailsModel(appcrud.Data.appcrudContext context)
        {
            _context = context;
        }

        public HangHoa HangHoa { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hanghoa = await _context.HangHoa.FirstOrDefaultAsync(m => m.id == id);
            if (hanghoa == null)
            {
                return NotFound();
            }
            else
            {
                HangHoa = hanghoa;
            }
            return Page();
        }
    }
}
