using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hanghoaapi.Models
{
    public class HangHoa
    {
        [Key]
        public int id { get; set; }

        [Required]
        [MaxLength(9)]
        [Column(TypeName = "char(9)")]
        public string ma_hanghoa { get; set; }

        [Required]
        [MaxLength(50)]
        [Column(TypeName = "nvarchar(50)")]
        public string ten_hanghoa { get; set; }

        [Column(TypeName = "int")]
        public int so_luong { get; set; }

        [Column(TypeName = "nvarchar(75)")]
        public string? ghi_chu { get; set; }
    }
}
