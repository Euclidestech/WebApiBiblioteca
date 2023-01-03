using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblioteca.Data;
using Biblioteca.Dtos.Usuario;
using Biblioteca.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Repositorio
{
  public class UsuarioRepositorio
  {
    private readonly ContextoBD _contexto;
    public UsuarioRepositorio([FromServices] ContextoBD contexto)
    {
      _contexto = contexto;
    }
    public Usuario CriarUsuario(Usuario usuario)
    {
      _contexto.Usuarios.Add(usuario);
      _contexto.SaveChanges();
      return usuario;
    }
    public Usuario BuscarUsuarioPeloCpf(string cpf)
    {
      return _contexto.Usuarios.AsNoTracking()
      .FirstOrDefault(usuario => usuario.Cpf == cpf);

    }

    public List<Usuario> ListarUsuarios()
    {
      return _contexto.Usuarios
      .Include(usuario => usuario.Endereco)
      .AsNoTracking().ToList();
    }
    public Usuario BuscarPeloId(int id , bool tracking = true)
    {
      return tracking ?
      _contexto.Usuarios.Include(user => user.Endereco)
      .FirstOrDefault(user => user.Id == id):
      _contexto.Usuarios.Include(user => user.Endereco)
      .AsNoTracking().FirstOrDefault(user => user.Id == id);
    }

    public void ExcluirUsuario(Usuario usuario)
    {
      _contexto.Remove(usuario);
      _contexto.SaveChanges();
    }

    public void EditarUsuario( )
    {
        _contexto.SaveChanges();
    }
  }
}