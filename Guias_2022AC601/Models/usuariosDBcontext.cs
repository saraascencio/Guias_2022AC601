using Microsoft.EntityFrameworkCore;

namespace Guias_2022AC601.Models
{
    public class usuariosDBcontext : DbContext

    {

        public usuariosDBcontext(DbContextOptions<usuariosDBcontext> options) : base(options)
        {

        }

        public DbSet<marcas> marcas { get; set; }
        public DbSet<usuarios> usuarios { get; set; }

    }
}
