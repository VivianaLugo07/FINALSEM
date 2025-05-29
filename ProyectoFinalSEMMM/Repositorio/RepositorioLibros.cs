// RepositorioLibros.cs
using Microsoft.EntityFrameworkCore;
using ProyectoFinalSEMMM.Modelos;

namespace ProyectoFinalSEMMM.Repositorios
{
    public class RepositorioLibros : IRepositorioLibros
    {
        private readonly BibliotecaDbContext _context;

        public RepositorioLibros(BibliotecaDbContext context)
        {
            _context = context;
        }

        public async Task<List<Libro>> GetAll()
        {
            return await _context.Libros
                .Include(l => l.Autor)
                .Include(l => l.Generos) // Muy importante
                .ToListAsync();
        }

        public async Task<Libro?> Get(int id)
        {
            return await _context.Libros
                .Include(l => l.Autor)
                .Include(l => l.Generos)
                .FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task Add(Libro libro)
        {
            _context.Add(libro);
            await _context.SaveChangesAsync();
        }
        public async Task Update(int id, Libro libro)
        {
            var libroExistente = await _context.Libros
                .Include(l => l.Generos)
                .FirstOrDefaultAsync(l => l.Id == id);

            if (libroExistente is not null)
            {
                libroExistente.Titulo = libro.Titulo;
                libroExistente.AnoPublicacion = libro.AnoPublicacion;
                libroExistente.Editorial = libro.Editorial;
                libroExistente.AutorId = libro.AutorId;

                // Actualizar géneros asociados
                libroExistente.Generos = libro.Generos;

                await _context.SaveChangesAsync();
            }
        }

        public async Task Delete(int id)
        {
            var libro = await _context.Libros.FindAsync(id);
            if (libro is not null)
            {
                _context.Libros.Remove(libro);
                await _context.SaveChangesAsync();
            }
        }
    }
}
