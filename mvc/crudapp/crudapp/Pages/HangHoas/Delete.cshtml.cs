using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using crudapp.Data;
using crudapp.Model;

namespace crudapp.Pages.HangHoas
{
    public class DeleteModel : PageModel
    {
        private readonly crudapp.Data.crudappContext _context;

        public DeleteModel(crudapp.Data.crudappContext context)
        {
            _context = context;
        }

        [BindProperty]
        public HangHoa HangHoa { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hanghoa = await _context.HangHoa.FirstOrDefaultAsync(m => m.MaHangHoa == id);

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

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hanghoa = await _context.HangHoa.FindAsync(id);
            if (hanghoa != null)
            {
                HangHoa = hanghoa;
                _context.HangHoa.Remove(HangHoa);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
