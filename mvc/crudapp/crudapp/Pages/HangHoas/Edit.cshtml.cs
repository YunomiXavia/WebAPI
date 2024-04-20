using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using crudapp.Data;
using crudapp.Model;

namespace crudapp.Pages.HangHoas
{
    public class EditModel : PageModel
    {
        private readonly crudapp.Data.crudappContext _context;

        public EditModel(crudapp.Data.crudappContext context)
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

            var hanghoa =  await _context.HangHoa.FirstOrDefaultAsync(m => m.MaHangHoa == id);
            if (hanghoa == null)
            {
                return NotFound();
            }
            HangHoa = hanghoa;
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

            _context.Attach(HangHoa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HangHoaExists(HangHoa.MaHangHoa))
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

        private bool HangHoaExists(string id)
        {
            return _context.HangHoa.Any(e => e.MaHangHoa == id);
        }
    }
}
