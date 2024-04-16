using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using appcrud.Model;

namespace appcrud.Data
{
    public class appcrudContext : DbContext
    {
        public appcrudContext (DbContextOptions<appcrudContext> options)
            : base(options)
        {
        }

        public DbSet<appcrud.Model.HangHoa> HangHoa { get; set; } = default!;
    }
}
