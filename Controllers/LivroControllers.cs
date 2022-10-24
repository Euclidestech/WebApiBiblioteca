using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblioteca.Dtos.Livro;
using Biblioteca.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers{

    [ApiController]
    [Route("livros")]
    public class LivroControllers : ControllerBase
    {
        private LivroServico _livroServico;
        public LivroControllers([FromServices] LivroServico servico)
        {
            _livroServico = servico;

        }

        [HttpPost]
        public LivroResposta PostLivro([FromBody]LivroCriarAtualizarRequisicao novoLivro)
        {
            return _livroServico.CriarLivro(novoLivro);

        }

        [HttpGet]
        public List<LivroResposta> GetLivros()
        {
            return _livroServico.ListarLivros();

        }

        [HttpGet("{id}")]
        public LivroResposta GetLivro([FromRoute] int id)
        {
            return _livroServico.BuscarId(id);
        }
        [HttpDelete("{id:int}")]
        public void DeleteLivro([FromRoute]int id)
        {
            _livroServico.RemoverLivro(id);
        }

        [HttpPut("{id:int}")]
        public LivroResposta PutLivro
        ([FromRoute]int id, [FromBody] LivroCriarAtualizarRequisicao livroEditado)
        {
           return _livroServico.AtualizarLivro(id,livroEditado); 
        }

    }
}