using Microsoft.EntityFrameworkCore;
using ProyectoFinalSEMMM.Modelos;

namespace ProyectoFinalSEMMM.Repositorio
{
    public class RepositorioAutores : IRepositorioAutores
    {
        private readonly BibliotecaDbContext _contexto;

        public RepositorioAutores(BibliotecaDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<Autor> Add(Autor autor)
        {
            await _contexto.Autores.AddAsync(autor);
            await _contexto.SaveChangesAsync();
            return autor;
        }

        public async Task Delete(int id)
        {
            var autor = await _contexto.Autores.FindAsync(id);
            if (autor != null)
            {
                _contexto.Autores.Remove(autor);
                await _contexto.SaveChangesAsync();
            }
        }

        public async Task<Autor?> Get(int id)
        {
            return await _contexto.Autores.FindAsync(id);
        }

        public async Task<List<Autor>> GetAll()
        {
            return await _contexto.Autores.ToListAsync();
        }

        public async Task Update(int id, Autor autor)
        {
            var autorActual = await _contexto.Autores.FindAsync(id);
            if (autorActual != null)
            {
                autorActual.Nombre = autor.Nombre;
                autorActual.Edad = autor.Edad;
                autorActual.Nacionalidad = autor.Nacionalidad;

                await _contexto.SaveChangesAsync();
            }
        }
    }
}
