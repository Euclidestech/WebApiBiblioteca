using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Models
{

  [Index(nameof(Cpf), IsUnique = true)]
  public class Usuario
  {
    [Required]
    public int Id { get; set; }
    [Required]
    [Column(TypeName = "varchar(50)")]
    public string Cpf { get; set; }
    [Required]
    [Column(TypeName = "varchar(30)")]
    public string Nome { get; set; }
    [Required]
    [Column(TypeName = "varchar(50)")]
    public string Senha { get; set; }

    public Endereco Endereco { get; set; }

    public List<Pedido> Pedidos { get; set; }
    [Required]

    public List<Perfil> Perfis { get; set; }

    // public int LivroId{get;set;}

  }
}