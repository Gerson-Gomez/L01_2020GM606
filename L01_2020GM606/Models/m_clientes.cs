using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace L01_2020GM606.Models
{
    public class m_clientes
    {
        [Key]
        public int clienteId { get; set; }
        public string? nombreCliente { get; set; }
        public string? direccion { get; set; }
    }
}
