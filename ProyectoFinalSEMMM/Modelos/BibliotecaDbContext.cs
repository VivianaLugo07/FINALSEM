using Microsoft.EntityFrameworkCore;
using ProyectoFinalSEMMM.Modelos;

namespace ProyectoFinalSEMMM.Modelos
{
    public class BibliotecaDbContext : DbContext
    {
        public BibliotecaDbContext(DbContextOptions<BibliotecaDbContext> options) : base(options)
        {
        }
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Genero> Generos { get; set; }
    }
}