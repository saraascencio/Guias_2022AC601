using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Guias_2022AC601.Models
{
    public class usuarios
    {
        [Key]
        public int id_usuario { get; set; }

        [StringLength(200)]
        public string? nombre { get; set; }

        [StringLength(50)]
        public string? documento { get; set; }

        [StringLength(50)]
        public string? carnet { get; set; }

        public int? carrera_id { get; set; }

        [StringLength(250)]
        public string? email { get; set; }

        [StringLength(50)]
        public string? contrasenia { get; set; }

        [StringLength(50)]
        public string? tipo_usuario { get; set; }

        [Column(TypeName = "char(1)")]
        public char? bloqueado { get; set; }

        public DateTime? ultimo_login { get; set; }

        [Column(TypeName = "char(1)")]
        public char? activo { get; set; }
    }
}
