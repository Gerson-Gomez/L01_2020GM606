using System.ComponentModel.DataAnnotations;
namespace L01_2020GM606.Models
{
    public class p_platos
    {
        [Key]
        public int platoId { get; set; }
        public string? nombrePlato { get; set; }
        public decimal precio { get; set;}

    }

}