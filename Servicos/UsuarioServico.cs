using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblioteca.Dtos.Usuario;
using Biblioteca.Exececoes;
using Biblioteca.Models;
using Biblioteca.Repositorio;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Servicos
{
  public class UsuarioServico
  {
    private readonly UsuarioRepositorio _usuarioRepositorio;
    private readonly PerfilRepositorio _perfilRepositorio;
    public UsuarioServico([FromServices] UsuarioRepositorio repositorio,
    [FromServices] PerfilRepositorio pRepositorio
    )
    {
      _usuarioRepositorio = repositorio;
      _perfilRepositorio = pRepositorio;
    }


    public UsuarioResposta CriarUsuario(UsuarioCriarRequisicao novoUsuario)
    {
      var usuarioExistente = _usuarioRepositorio.BuscarUsuarioPeloCpf(novoUsuario.Cpf);
      if(usuarioExistente is not null)
      {
          throw new ExececaoCpfExistente();
      }
      var usuario = novoUsuario.Adapt<Usuario>();

      usuario.Senha = BCrypt.Net.BCrypt.HashPassword(usuario.Senha);

      usuario = _usuarioRepositorio.CriarUsuario(usuario);

      var usuarioResposta = usuario.Adapt<UsuarioResposta>();

      return usuarioResposta;
    }

    public List<UsuarioResposta> ListarUsuarios(){

      return _usuarioRepositorio.ListarUsuarios().Adapt<List<UsuarioResposta>>();
    }

    private Usuario BuscarPeloId(int id, bool tracking = true)
    {
      var usuario = _usuarioRepositorio.BuscarPeloId(id,tracking);
      if(usuario is null)
      {
        throw new Exception("Usuario não encontrado");
      }
      return usuario;
    }

    public UsuarioResposta BuscarUsuarioPeloId(int id)
    {
      return BuscarPeloId(id,false).Adapt<UsuarioResposta>();
    }

    public void ExcluirUsuario(int id)
    {
      var usuario = BuscarPeloId(id);
      _usuarioRepositorio.ExcluirUsuario(usuario);
    }

    public UsuarioResposta EditarUsuario(int id, AtualizarRequisicao usuarioEditado)
    {
      var usuario = BuscarPeloId(id);
      if(usuario.Cpf != usuarioEditado.Cpf)
      {
        var usuarioExistente = _usuarioRepositorio.BuscarUsuarioPeloCpf(usuarioEditado.Cpf);
        if(usuarioExistente is not null)
        {
          throw new ExececaoCpfExistente();
        }
      }


      usuarioEditado.Adapt(usuario);
      _usuarioRepositorio.EditarUsuario();

      var usuasrioResposta = usuario.Adapt<UsuarioResposta>();

      return usuasrioResposta;

    }

    public UsuarioResposta AtribuirPerfil(int usuarioId, int perfilId)
    {
      var usuario = BuscarPeloId(usuarioId);

      var perfil = _perfilRepositorio.BuscarPefilPeloId(perfilId);
      if(perfil is null)
      {
        throw new Exception("Perfil nao encontrado");
      }
      if(usuario.Perfis.Exists(perfil => perfil.Id == perfilId))
      {
        throw new Exception("Perfil ja associado");
      }
      usuario.Perfis.Add(perfil);
      _usuarioRepositorio.EditarUsuario();

      return usuario.Adapt<UsuarioResposta>();

    }

    public UsuarioResposta ExcluirPerfil(int usuarioId, int perfilId)
    {
      var usuario = BuscarPeloId(usuarioId);
      if(!usuario.Perfis.Exists(perfil => perfil.Id == perfilId))
      {
        throw new BadHttpRequestException("Perfil nao encontardor");

      }
      usuario.Perfis.RemoveAll(perfil => perfil.Id == perfilId);

      _usuarioRepositorio.EditarUsuario();
      return usuario.Adapt<UsuarioResposta>();
    }

    
  }
}