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
    public class IndexModel : PageModel
    {
        private readonly crudapp.Data.crudappContext _context;

        public IndexModel(crudapp.Data.crudappContext context)
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
