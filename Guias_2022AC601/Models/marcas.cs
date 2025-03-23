using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Guias_2022AC601.Models
{
    public class marcas
    {
        [Key]
        [DisplayName("ID")]
       
        public int id_marcas { get; set; }
        [Required(ErrorMessage ="El nombre de la marca NO es opcional")]
        [DisplayName("Nombre de la Marca")]
        public string? nombre_marca { get; set; }

        [DisplayName("Estado")]
        [StringLength(1, ErrorMessage ="La cantidad máxima de caracteres válida es {1}")]
        public string? estados { get; set; }


    }
}
