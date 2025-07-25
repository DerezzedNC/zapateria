using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZapateriaAPI.Models
{
    [Table("Sucursal")]
    public class Sucursal
    {
        [Key]
        [Column("idSucursal")]
        public int IdSucursal { get; set; }

        [Required]
        [Column("direccion")] // ✅ sin tilde
        public string Direccion { get; set; }
    }
}
