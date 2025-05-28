using System.ComponentModel.DataAnnotations;
using ProyectoFinalSEMMM.Modelos;
namespace ProyectoFinalSEMMM.Modelos
{
    public class Libro
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Título es obligatorio.")]
        [StringLength(200, ErrorMessage = "El campo Título no puede tener más de 200 caracteres.")]
        public string? Titulo { get; set; }

        [Range(0, 9999, ErrorMessage = "El año debe ser un número válido.")]
        public int AnoPublicacion { get; set; }

        [Required(ErrorMessage = "El campo Editorial es obligatorio.")]
        [StringLength(200, ErrorMessage = "El campo Editorial* no puede tener más de 200 caracteres.")]
        public string? Editorial { get; set; }

        //para identificar que un autor esta relacionado a un libro
        //se agrega una propiedad llamada igual que la clase pero con Id
        //propiedad de navegación EF
        public int AutorId { get; set; }
        //leer el contenido desde la tabla persona
        virtual public Autor? Autor { get; set; }

    }
}
