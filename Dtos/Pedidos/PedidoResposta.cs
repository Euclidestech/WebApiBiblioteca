using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblioteca.Dtos.Livro;
using Biblioteca.Dtos.Usuario;

namespace Biblioteca.Dtos.Pedidos
{
  public class PedidoResposta
  {
    public int Id { get; set; }

    public decimal Quantidade { get; set; }
    public int LivrosId { get; set; }
    public LivroResposta Livros { get; set; }
    public int UsuarioId { get; set; }
    public UsuarioResposta Usuarios { get; set; }
  }
}