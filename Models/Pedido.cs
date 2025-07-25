using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZapateriaAPI.Models
{
    [Table("Pedido")]
    public class Pedido
    {
        [Key]
        [Column("idPedido")]
        public int IdPedido { get; set; }

        [Required]
        [Column("costoCalzado")]
        public decimal CostoCalzado { get; set; }

        [Required]
        [Column("tipoCalzado")]
        [MaxLength(20)]
        public string TipoCalzado { get; set; }

        [Required]
        [Column("tipoServicio")]
        [MaxLength(30)]
        public string TipoServicio { get; set; }

        [Required]
        [Column("idCliente")]
        public int IdCliente { get; set; }

        [Required]
        [Column("idMetodoPago")]
        public int IdMetodoPago { get; set; }

        [Required]
        [Column("idSucursal")]
        public int IdSucursal { get; set; }

        [Column("fechaPedido")]
        public DateTime FechaPedido { get; set; }
    }
}
