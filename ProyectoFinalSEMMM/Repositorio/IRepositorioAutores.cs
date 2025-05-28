using ProyectoFinalSEMMM.Modelos;

public interface IRepositorioAutores
{
    Task<List<Autor>> GetAll();
    Task<Autor?> Get(int id);
    Task<Autor> Add(Autor autor);
    Task Update(int id, Autor autor);
    Task Delete(int id);
}
