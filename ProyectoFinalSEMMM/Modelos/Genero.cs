using System.ComponentModel.DataAnnotations;

namespace ProyectoFinalSEMMM.Modelos
{
    public class Genero
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
        [StringLength(200, ErrorMessage = "El campo Nombre no puede tener más de 200 caracteres.")]

        public string? Nombre { get; set; }

        [Required(ErrorMessage = "El campo Descripción es obligatorio.")]
        [StringLength(200, ErrorMessage = "El campo Descripción no puede tener más de 200 caracteres.")]
        public string? Descripcion { get; set; }

        virtual public ICollection<Libro>? Libros { get; set; }

    }
}