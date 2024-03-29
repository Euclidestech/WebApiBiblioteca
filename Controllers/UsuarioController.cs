using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblioteca.Dtos.Usuario;
using Biblioteca.Exececoes;
using Biblioteca.Servicos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
  [ApiController]
  [Route("usuarios")]
  public class UsuarioController : ControllerBase
  {
    private readonly UsuarioServico _usuarioServico;
    public UsuarioController([FromServices] UsuarioServico servico)
    {
      _usuarioServico = servico;
    }

    [HttpPost]
    public ActionResult<UsuarioResposta> PostUsuario([FromBody] UsuarioCriarRequisicao novoUsuario)
    {
      try
      {
        var usuarioResposta = _usuarioServico.CriarUsuario(novoUsuario);
        return CreatedAtAction(nameof(GetUsuario), new { id = usuarioResposta.Id }, usuarioResposta);
      }
      catch (ExececaoCpfExistente e)
      {
        return BadRequest(e.Message);

      }
    }
    [HttpGet]

    public ActionResult<List<UsuarioResposta>> GetUsuarios()
    {
      return Ok(_usuarioServico.ListarUsuarios());
    }
    [HttpGet("{id:int}")]
    public ActionResult<UsuarioResposta> GetUsuario([FromRoute] int id)
    {
      try
      {
        return Ok(_usuarioServico.BuscarUsuarioPeloId(id));

      }
      catch (Exception e)
      {
        return NotFound(e.Message);

      }

    }
    [Authorize(Roles = "Administrador")]
    [HttpDelete("{id:int}")]

    public ActionResult DeleteUsuario([FromRoute] int id)
    {
      try
      {
        _usuarioServico.ExcluirUsuario(id);
        return NoContent();
      }
      catch (Exception e)
      {
        return NotFound(e.Message);

      }
    }

    [HttpPut("{id:int}")]
    public ActionResult<UsuarioResposta>
      PutUsuario([FromRoute] int id, [FromBody] AtualizarRequisicao usuarioEditado)
    {
      try
      {
        return Ok(_usuarioServico.EditarUsuario(id, usuarioEditado));

      }
      catch (ExececaoCpfExistente e)

      {
        return BadRequest(e.Message);

      }
      catch (Exception e)
      {
        return NotFound(e.Message);
      }
    }
    [Authorize(Roles = "Administrador")]
    [HttpPut("{usuarioId:int}/perfil/{perfilId:int}")]
    public ActionResult<UsuarioResposta> PutUsuarioPerfil([FromRoute] int usuarioId,
     [FromRoute] int perfilId)
    {
      try
      {

        return Ok(_usuarioServico.AtribuirPerfil(usuarioId, perfilId));

      }
      catch (BadHttpRequestException e)
      {
        return BadRequest(e.Message);
      }
      catch (Exception e)
      {
        return NotFound(e.Message);
      }
    }
    [Authorize(Roles = "Administrador")]
    [HttpDelete("{usuarioId:int}/perfil/{perfilId:int}")]

    public ActionResult<UsuarioResposta> DeletePerfil([FromRoute] int usuarioId, int perfilId)
    {
      try
      {
        return Ok(_usuarioServico.ExcluirPerfil(usuarioId, perfilId));
      }
      catch (BadHttpRequestException e)
      {
        return BadRequest(e.Message);
      }
      catch (Exception e)
      {
        return NotFound(e.Message);
      }
    }
  }
}