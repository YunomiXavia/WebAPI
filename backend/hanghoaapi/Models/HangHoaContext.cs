using Microsoft.EntityFrameworkCore;

namespace hanghoaapi.Models
{
    public class HangHoaContext: DbContext
    {
        //Constructor
        public HangHoaContext(DbContextOptions<HangHoaContext> options): base(options)
        {
        }

        //Add Property
        public DbSet<HangHoa> HangHoas { get; set; }
    }
}
