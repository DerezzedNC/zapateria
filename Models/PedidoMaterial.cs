using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZapateriaAPI.Models
{
    public class PedidoMaterial
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPedidoMaterial { get; set; }

        [Required]
        public int IdPedido { get; set; }

        [ForeignKey("IdPedido")]
        public Pedido? Pedido { get; set; }  // Ya no tiene [Required]

        [Required]
        public int IdMaterial { get; set; }

        [ForeignKey("IdMaterial")]
        public Material? Material { get; set; }  // Ya no tiene [Required]

        [Required]
        public int Cantidad { get; set; }
    }
}
