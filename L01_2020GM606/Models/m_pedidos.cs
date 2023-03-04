using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace L01_2020GM606.Models
{
    public class m_pedidos 
    {
        [Key]
        public int pedidoId { get; set; }
        public int motoristaId { get; set; }
        public int clienteId { get; set; }
        public int platoId { get; set; }
        public int cantidad { get; set; }
        public decimal precio { get; set; }

    }
}
