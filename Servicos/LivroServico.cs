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
     ConverterRequisicaoModelo(novoLivro,livro);

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

    public LivroResposta BuscarId(int id)
    {
      var livro = _livroRepositorio.BuscarId(id);

      return ConverteModeloResposta(livro);

    }

    public void RemoverLivro(int id)
    {
      var livro = _livroRepositorio.BuscarId(id);
      if(livro is null)
      {
        return ;
      }
      _livroRepositorio.RemoverLivro(livro);
    }
    public LivroResposta AtualizarLivro
    (int id, LivroCriarAtualizarRequisicao LivroEditado)
    {
      var livro = _livroRepositorio.BuscarId(id);
      if(livro is null)
      {
        return null;
      }
      ConverterRequisicaoModelo(LivroEditado , livro);

      _livroRepositorio.AtualizarLivro();

      return ConverteModeloResposta(livro);

    }



    
    private void ConverterRequisicaoModelo
    (LivroCriarAtualizarRequisicao requisicao , Livro modelo)
    {
      modelo.Nome =requisicao.Nome;
      modelo.Categoria =requisicao.Categoria;
      modelo.Autor =requisicao.Autor;
      modelo.Preco =requisicao.Preco;
      modelo.Status =requisicao.Status;

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