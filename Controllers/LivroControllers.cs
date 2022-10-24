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
        public void PostLivro([FromBody]LivroCriarAtualizarRequisicao novoLivro)
        {
            _livroServico.CriarLivro(novoLivro);

        }
    }
}