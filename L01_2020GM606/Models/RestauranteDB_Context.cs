using Microsoft.EntityFrameworkCore;
namespace L01_2020GM606.Models
{
    public class RestauranteDB_Context :DbContext
    {
        public RestauranteDB_Context(DbContextOptions<RestauranteDB_Context> options) : base(options)
        {
        }
        public DbSet<p_platos> platos { get; set;}
        public DbSet<m_pedidos> pedidos { get; set; }
        public DbSet<m_clientes> clientes  { get; set; }
    }
}
