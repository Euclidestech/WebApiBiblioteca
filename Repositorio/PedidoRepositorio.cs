using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblioteca.Data;
using Biblioteca.Models;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Repositorio
{
  public class PedidoRepositorio
  {
    private readonly ContextoBD _contexto;

    public PedidoRepositorio([FromServices] ContextoBD contexto)
    {
      _contexto = contexto;
    }


    public Pedido CriarPedido(Pedido pedido)
    {
      _contexto.Pedidos.Add(pedido);
      _contexto.SaveChanges();
      return pedido;
    }
  }



}