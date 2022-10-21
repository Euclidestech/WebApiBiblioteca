using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Models
{
  public class Livro
  {
    [Required]
    public int Id { get; set; }
    [Required]
    [Column(TypeName = "varchar(100)")]
    public string Nome { get; set; }
    [Required]
    [Column(TypeName = "text")]
    public string Categoria { get; set; }

    [Required]
    [Column(TypeName = "varchar(50)")]
    public string Autor { get; set; }

    [Required]
    public DateTime Ano { get; set; }
    [Required]
    public decimal Preco { get; set; }

    [Required]
    [Column(TypeName = "text")]
    public string Status { get; set; }

    public Pedido Pedido { get; set; }


}}