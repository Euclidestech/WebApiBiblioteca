using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblioteca.Data;
using Biblioteca.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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


    public List<Pedido> ListarPedidos()
    {
      return _contexto.Pedidos
      .Include(a => a.Usuario)
      .Include(a => a.Livro)
      .AsNoTracking().ToList();
    }

    public Pedido BuscarPedidoPeloId(int id, bool tracking = true)
    {
      return
      tracking ? _contexto.Pedidos
      .Include(a => a.Usuario)
      .Include(a => a.Livro).
      FirstOrDefault(a =>a.Id == id)
      :_contexto.Pedidos.AsNoTracking()
      .Include(a => a.Usuario)
      .Include(a => a.Livro)
      .FirstOrDefault(a => a.Id == id);
    }

    public void RemoverPedido(Pedido pedido)
    {
      _contexto.Remove(pedido);
      _contexto.SaveChanges();
    }
  }



}