using ProyectoFinalSEMMM.Modelos;


namespace ProyectoFinalSEMMM.Repositorio
{
    public interface IRepositorioGeneros
    {
        Task<List<Genero>> GetAll();
        Task<Genero?> Get(int id);
        Task<Genero> Add(Genero genero);
        Task Update(int id, Genero genero);
        Task Delete(int id);
    }
}

