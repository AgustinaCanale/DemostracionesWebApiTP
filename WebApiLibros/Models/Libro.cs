using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiLibros.Models
{
    [Table("Libro")]
    public class Libro
    {
        public int Id { get; set; }

        [Required]
        [Column (TypeName ="varchar(50)")]
        public string Titulo { get; set; }

        public string Descripcion { get; set; }

        public int IdAutor { get; set; }

        [ForeignKey("IdAutor")]
        public Autor Autor { get; set; }
    }
}
