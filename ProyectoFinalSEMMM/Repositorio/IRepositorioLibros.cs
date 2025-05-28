using ProyectoFinalSEMMM.Modelos;

public interface IRepositorioLibros
{
    Task<List<Libro>> GetAll();
    Task<Libro?> Get(int id);
    Task<Libro> Add(Libro libro);
    Task Update(int id, Libro libro);
    Task Delete(int id);
}