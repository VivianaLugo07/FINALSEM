using System.ComponentModel.DataAnnotations;
using ProyectoFinalSEMMM.Modelos;
namespace ProyectoFinalSEMMM.Modelos
{
    //este es como el de clasificación pero adaptado a mi proyecto
    public class Autor
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
        [StringLength(200, ErrorMessage = "El campo Nombre no puede tener más de 200 caracteres.")]
        public string? Nombre { get; set; }

        [Range(0, 100, ErrorMessage = "La edad debe ser un número válido.")]
        public int Edad { get; set; }

        [Required(ErrorMessage = "El campo Nacionalidad es obligatorio.")]
        [StringLength(200, ErrorMessage = "El campo Nacionalidad no puede tener más de 200 caracteres.")]
        public string? Nacionalidad { get; set; }



        //propiedad de navegación
        virtual public ICollection<Libro>? Libros { get; set; }
    }
}