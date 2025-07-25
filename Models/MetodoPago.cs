using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZapateriaAPI.Models
{
    [Table("MetodoPago")]
    public class MetodoPago
    {
        [Key]
        [Column("idMetodoPago")]
        public int IdMetodoPago { get; set; }

        [Required]
        [MaxLength(20)]
        [Column("tipoPago")]
        public string TipoPago { get; set; }
    }
}
