using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblioteca.Dtos.Pedidos;
using Biblioteca.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
  [ApiController]
  [Route("pedidos")]
  public class PedidoController : ControllerBase
  {

    private readonly PedidoServico _pedidoServico;
    public PedidoController([FromServices] PedidoServico servico)
    {
      _pedidoServico = servico;
    }

    [HttpPost]
    public ActionResult<PedidoResposta>
    PostPedido([FromBody] PedidoCriaRequisicao novopedido)
    {
      try
      {
        return StatusCode(201, _pedidoServico.CriarPedido(novopedido));

      }
      catch (BadHttpRequestException e)
      {
        return BadRequest(e.Message);
      }

    }
  }
}