using Microsoft.EntityFrameworkCore;
using ProyectoFinalSEMMM.Modelos;

namespace ProyectoFinalSEMMM.Repositorio
{
    public class RepositorioGeneros : IRepositorioGeneros
    {
        private readonly BibliotecaDbContext context;

        public RepositorioGeneros(BibliotecaDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Genero>> GetAll()
        {
            return await context.Generos.OrderBy(x => x.Nombre).ToListAsync();
        }

        public async Task<Genero?> Get(int id)
        {
            return await context.Generos.FirstOrDefaultAsync(g => g.Id == id);
        }

        public async Task<Genero> Add(Genero genero)
        {
            context.Add(genero);
            await context.SaveChangesAsync();
            return genero;
        }

        public async Task Update(int id, Genero genero)
        {
            context.Update(genero);
            await context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var genero = await context.Generos.FindAsync(id);
            if (genero is not null)
            {
                context.Remove(genero);
                await context.SaveChangesAsync();
            }
        }
    }
}



