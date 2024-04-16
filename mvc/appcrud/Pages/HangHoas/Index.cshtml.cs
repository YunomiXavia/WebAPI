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
    public class IndexModel : PageModel
    {
        private readonly appcrud.Data.appcrudContext _context;

        public IndexModel(appcrud.Data.appcrudContext context)
        {
            _context = context;
        }

        public IList<HangHoa> HangHoa { get;set; } = default!;

        public async Task OnGetAsync()
        {
            HangHoa = await _context.HangHoa.ToListAsync();
        }
    }
}
