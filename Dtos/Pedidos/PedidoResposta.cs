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
    public int LivroId { get; set; }
    public LivroResposta Livro { get; set; }
    public int UsuarioId{ get; set; }
    public UsuarioResposta Usuario{ get; set; }
  }
}