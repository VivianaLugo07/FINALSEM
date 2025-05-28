using Microsoft.EntityFrameworkCore;
using ProyectoFinalSEMMM.Modelos;

namespace ProyectoFinalSEMMM.Repositorio
{
    public class RepositorioLibros : IRepositorioLibros
    {
        private readonly BibliotecaDbContext _contexto;

        public RepositorioLibros(BibliotecaDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<Libro> Add(Libro libro)
        {
            await _contexto.Libros.AddAsync(libro);
            await _contexto.SaveChangesAsync();
            return libro;
        }

        public async Task Delete(int id)
        {
            var libro = await _contexto.Libros.FindAsync(id);
            if (libro != null)
            {
                _contexto.Libros.Remove(libro);
                await _contexto.SaveChangesAsync();
            }
        }

        public async Task<Libro?> Get(int id)
        {
            return await _contexto.Libros
                .Include(l => l.Autor) // <- para que también funcione al editar
                .FirstOrDefaultAsync(l => l.Id == id);
        }


        public async Task<List<Libro>> GetAll()
        {
            return await _contexto.Libros.ToListAsync();
        }

        public async Task Update(int id, Libro libro)
        {
            var libroActual = await _contexto.Libros.FindAsync(id);
            if (libroActual != null)
            {
                libroActual.Titulo = libro.Titulo;
                libroActual.AnoPublicacion = libro.AnoPublicacion;
                libroActual.Editorial = libro.Editorial;

                await _contexto.SaveChangesAsync();
            }
        }
    }
}
