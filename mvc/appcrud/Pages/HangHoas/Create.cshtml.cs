using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using appcrud.Data;
using appcrud.Model;

namespace appcrud.Pages.HangHoas
{
    public class CreateModel : PageModel
    {
        private readonly appcrud.Data.appcrudContext _context;

        public CreateModel(appcrud.Data.appcrudContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public HangHoa HangHoa { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.HangHoa.Add(HangHoa);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
