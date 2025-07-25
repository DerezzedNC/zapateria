using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZapateriaAPI.Models
{
    [Table("Zapato")]
    public class Zapato
    {
        [Key]
        [Column("idZapato")]
        public int IdZapato { get; set; }

        [Required]
        [Column("tipo")]
        public string Tipo { get; set; }

        [Required]
        [Column("color")]
        public string Color { get; set; }

        [Required]
        [Column("estado")]
        public string Estado { get; set; }
    }
}
