using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblioteca.Dtos.Usuario;
using Biblioteca.Exececoes;
using Biblioteca.Servicos;
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
        return CreatedAtAction(nameof(GetUsuario),new {id = usuarioResposta.Id}, usuarioResposta);
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
    public ActionResult <UsuarioResposta> GetUsuario([FromRoute] int id)
    {
      try
      {
        return Ok(_usuarioServico.BuscarUsuarioPeloId(id));

      }catch (Exception e)
      {
        return NotFound(e.Message);

      }

    }
    [HttpDelete("{id:int}")]

    public ActionResult DeleteUsuario([FromRoute] int id)
    {
      try
      {
          _usuarioServico.ExcluirUsuario(id);
          return NoContent();
      }catch(Exception e)
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
          return Ok(_usuarioServico.EditarUsuario(id,usuarioEditado));

        }catch(ExececaoCpfExistente e)

        {
          return BadRequest(e.Message);

        }
        catch(Exception e)
        {
          return NotFound(e.Message);
        }
      }

  }
}