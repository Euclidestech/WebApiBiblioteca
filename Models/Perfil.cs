using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca.Models
{
    public class Perfil
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [Column(TypeName ="varchar(20)")]
        public string Tipo { get; set; }

        public List<Usuario> Usuarios { get; set; }

    }
}