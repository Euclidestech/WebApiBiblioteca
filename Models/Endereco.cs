using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Models
{
  public class Endereco
  {
    [Required]
    public int Id { get; set; }
    [Required]
    [Column(TypeName ="varchar(30)")]
    public string Rua { get; set; }
    [Required]
    [Column(TypeName ="varchar(10)")]
    public string Numero { get; set; }
    [Required]
    [Column(TypeName ="varchar(30)")]
    public string Bairro { get; set; }
    [Required]
    [Column(TypeName ="varchar(30)")]
    public string Cidade { get; set; }
    [Required]
    [Column(TypeName ="varchar(10)")]
    public string Cep { get; set; }

    public Usuario Usuario { get; set; }
    [Required]
    public int UsuarioId { get; set; }
  }
}