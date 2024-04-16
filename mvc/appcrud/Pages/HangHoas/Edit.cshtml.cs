using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using appcrud.Data;
using appcrud.Model;

namespace appcrud.Pages.HangHoas
{
    public class EditModel : PageModel
    {
        private readonly appcrud.Data.appcrudContext _context;

        public EditModel(appcrud.Data.appcrudContext context)
        {
            _context = context;
        }

        [BindProperty]
        public HangHoa HangHoa { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hanghoa =  await _context.HangHoa.FirstOrDefaultAsync(m => m.id == id);
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
                if (!HangHoaExists(HangHoa.id))
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

        private bool HangHoaExists(int id)
        {
            return _context.HangHoa.Any(e => e.id == id);
        }
    }
}
