using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblioteca.Dtos.Pedidos;
using Biblioteca.Models;
using Biblioteca.Repositorio;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Servicos
{
  public class PedidoServico
  {
    private readonly PedidoRepositorio _pedidoRepositorio;

    public PedidoServico([FromServices] PedidoRepositorio repositorio)
    {
      _pedidoRepositorio = repositorio;
    }

    public PedidoResposta CriarPedido(PedidoCriaRequisicao novoPedido)
    {
      var pedido = novoPedido.Adapt<Pedido>();
      pedido = _pedidoRepositorio.CriarPedido(pedido);

      return pedido.Adapt<PedidoResposta>();
    }
  }
}