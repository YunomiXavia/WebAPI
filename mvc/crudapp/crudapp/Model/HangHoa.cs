using System.ComponentModel.DataAnnotations;

namespace crudapp.Model
{
    public class HangHoa
    {
        [Key]
        [StringLength(9)]
        public required string MaHangHoa { get; set; }

        [Required]
        public required string TenHangHoa { get; set; }

        public int SoLuong { get; set; }

        public string? GhiChu { get; set; }
    }
}
