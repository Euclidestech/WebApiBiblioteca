using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Dtos.Usuario
{
  public class UsuarioLoginRequisicao
  {
    [Required]
    [StringLength(50)]
    public string Cpf { get; set; }

    [Required]
    public string Senha { get; set; }
  }
}