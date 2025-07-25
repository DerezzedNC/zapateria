using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZapateriaAPI.Models
{
    [Table("Material")]
    public class Material
    {
        [Key]
        [Column("idMaterial")]
        public int IdMaterial { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("nombreMaterial")]
        public string NombreMaterial { get; set; }
    }
}
