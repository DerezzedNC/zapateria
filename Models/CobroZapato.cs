using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZapateriaAPI.Models
{
    [Table("CobroZapato")]
    public class CobroZapato
    {
        [Key]
        [Column("idCobro")]
        public int IdCobro { get; set; }

        [Column("tiempoEstimado")] // ✅ corregido aquí
        [MaxLength(50)]
        public string TiempoEstimado { get; set; }

        [Column("materialZapato")]
        [MaxLength(50)]
        public string MaterialZapato { get; set; }

        [Column("tipoZapato")]
        [MaxLength(20)]
        public string TipoZapato { get; set; }

        [Column("tipoTrabajo")]
        [MaxLength(30)]
        public string TipoTrabajo { get; set; }
    }
}
