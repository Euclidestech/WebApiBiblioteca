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
    public LivroServico([FromServices] LivroRepositorio repositorio)
    {
      _livroRepositorio = repositorio;
    }
    public LivroResposta CriarLivro(LivroCriarAtualizarRequisicao novoLivro)
    {
      var livro = new Livro();
      livro.Nome = novoLivro.Nome;
      livro.Categoria = novoLivro.Categoria;
      livro.Autor = novoLivro.Autor;
      livro.Preco = novoLivro.Preco;
      livro.Status = novoLivro.Status;

      _livroRepositorio.CriarLivro(livro);


      var livroResposta = ConverteModeloResposta(livro);
      return livroResposta;


    }

    public List<LivroResposta> ListarLivros()
    {
      var Livros = _livroRepositorio.ListarLivros();

      List<LivroResposta> livroRespostas = new();

      foreach (var livro in Livros)
      {
        var livroResposta = ConverteModeloResposta(livro);

        livroRespostas.Add(livroResposta);


      }
      return livroRespostas;

    }
    private LivroResposta ConverteModeloResposta(Livro modelo)

    {
      var livroResposta = new LivroResposta();
      livroResposta.id = modelo.Id;
      livroResposta.Nome = modelo.Nome;
      livroResposta.Categoria = modelo.Categoria;
      livroResposta.Autor = modelo.Autor;
      livroResposta.Preco = modelo.Preco;
      livroResposta.Status = modelo.Status;

      return livroResposta;
    }
  }
}