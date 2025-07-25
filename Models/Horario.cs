using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZapateriaAPI.Models
{
    [Table("Horario")]
    public class Horario
    {
        [Key]
        [Column("idHorario")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdHorario { get; set; }

        [Required]
        [Column("horaEntrada")]
        public TimeSpan HoraEntrada { get; set; }

        [Required]
        [Column("horaSalida")]
        public TimeSpan HoraSalida { get; set; }

        [Required]
        [Column("diasTrabajo")]
        [MaxLength(100)]
        public string DiasTrabajo { get; set; }
    }
}
