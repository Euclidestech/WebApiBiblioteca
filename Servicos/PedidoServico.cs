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

    public List<PedidoResposta> ListarPedidos(){
      var pedidos = _pedidoRepositorio.ListarPedidos();
      return pedidos.Adapt<List<PedidoResposta>>();

    }

    private Pedido BuscarPeloId(int id , bool tracking = true )
    {
      var pedido = _pedidoRepositorio.BuscarPedidoPeloId(id, tracking);
      if( pedido is null)
      {
        throw new Exception("Pedido nao encontrado!");
      }
      return pedido;
    }

    public PedidoResposta BuscarPedidoPeloId(int id)
    {
      var pedido = BuscarPeloId(id, false);
      return pedido.Adapt<PedidoResposta>();
    }

    public void RemoverPedido(int id)
    {
      var pedido = BuscarPeloId(id);
      _pedidoRepositorio.RemoverPedido(pedido);

    }
  }

}