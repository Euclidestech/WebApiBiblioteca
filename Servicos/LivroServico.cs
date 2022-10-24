using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblioteca.Dtos.Livro;
using Biblioteca.Models;
using Biblioteca.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Servicos
{
    
    public class LivroServico
    {

        private LivroRepositorio _livroRepositorio;
        public LivroServico([FromServices]LivroRepositorio repositorio)
        {
            _livroRepositorio = repositorio;
        }
        public void CriarLivro(LivroCriarAtualizarRequisicao novoLivro)
        {
            var livro = new Livro();
            livro.Nome = novoLivro.Nome;
            livro.Categoria = novoLivro.Categoria;
            livro.Autor = novoLivro.Autor;
            livro.Preco = novoLivro.Preco;
            livro.Status = novoLivro.Status;

            _livroRepositorio.CriarLivro(livro);


        }
    }
}