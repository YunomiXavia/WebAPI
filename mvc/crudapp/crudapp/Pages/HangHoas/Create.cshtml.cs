using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using crudapp.Data;
using crudapp.Model;

namespace crudapp.Pages.HangHoas
{
    public class CreateModel : PageModel
    {
        private readonly crudapp.Data.crudappContext _context;

        public CreateModel(crudapp.Data.crudappContext context)
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
