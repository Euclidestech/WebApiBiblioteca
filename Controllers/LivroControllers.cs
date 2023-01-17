using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblioteca.Dtos.Livro;
using Biblioteca.Servicos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{

  [ApiController]
  [Route("livros")]
  public class LivroControllers : ControllerBase
  {
    private readonly LivroServico _livroServico;
    public LivroControllers([FromServices] LivroServico servico)
    {
      _livroServico = servico;

    }

    [HttpPost]
    public ActionResult< LivroResposta> PostLivro([FromBody] LivroCriarAtualizarRequisicao novoLivro)
    {
        var livroResposta = _livroServico.CriarLivro(novoLivro);
        return CreatedAtAction(nameof(GetLivro),new {Id = livroResposta.Id},
        livroResposta);
    }

    [HttpGet]
    public ActionResult<List<LivroResposta>> GetLivros()
    {
      return Ok(_livroServico.ListarLivros());

    }

    [HttpGet("{id}")]
    public ActionResult< LivroResposta> GetLivro([FromRoute] int id)
    {
      try
      {
        return Ok( _livroServico.BuscarId(id));
      }
      catch (Exception e)
      {
        return NotFound(e.Message);
      }

    }
    [Authorize(Roles = "Administrador")]
    [HttpDelete("{id:int}")]
    public ActionResult DeleteLivro([FromRoute] int id)
    {
      try
      {
        _livroServico.RemoverLivro(id);
        return NoContent();
      }
      catch (Exception e)
      {
        return NotFound(e.Message);

      }
    }

    [HttpPut("{id:int}")]
    public ActionResult< LivroResposta> PutLivro
    ([FromRoute] int id, [FromBody] LivroCriarAtualizarRequisicao livroEditado)
    {
      try
      {
        return Ok(_livroServico.AtualizarLivro(id, livroEditado));
      }
      catch (Exception e)
      {
        return NotFound(e.Message);
      }
    }

  }
}