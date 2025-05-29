using ProyectoFinalSEMMM.Modelos;


namespace ProyectoFinalSEMMM.Repositorios
{
    public interface IRepositorioLibros
    {
        Task<List<Libro>> GetAll();
        Task<Libro> Get(int id);
        Task Add(Libro libro);
        Task Update(int id, Libro libro);
        Task Delete(int id);
    }
}

