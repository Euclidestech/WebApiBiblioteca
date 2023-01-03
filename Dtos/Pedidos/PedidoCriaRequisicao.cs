using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Dtos.Pedidos
{
  public class PedidoCriaRequisicao
  {
    public decimal Quantidade { get; set; }
    public int LivroId { get; set; }
    public int UsuarioId { get; set; }
  }
}