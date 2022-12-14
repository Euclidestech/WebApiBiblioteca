using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblioteca.Dtos.Livro;
using Biblioteca.Models;
using Biblioteca.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Mapster;

namespace Biblioteca.Servicos
{

  public class LivroServico
  {

    private readonly LivroRepositorio _livroRepositorio;
    public LivroServico([FromServices] LivroRepositorio repositorio)
    {
      _livroRepositorio = repositorio;
    }
    public LivroResposta CriarLivro(LivroCriarAtualizarRequisicao novoLivro)
    {

      var livro = novoLivro.Adapt<Livro>();

      _livroRepositorio.CriarLivro(livro);

      var livroResposta = livro.Adapt<LivroResposta>();
      return livroResposta;

    }

    public List<LivroResposta> ListarLivros()
    {
      var Livros = _livroRepositorio.ListarLivros();
       var livroRespostas = Livros.Adapt<List<LivroResposta>>();
    
      return livroRespostas;

    }

    public LivroResposta BuscarId(int id)
    {
      var livro = BuscaPeloId(id,false);

      return livro.Adapt<LivroResposta>();

    }

    public void RemoverLivro(int id)
    {
      var livro = BuscaPeloId(id);

      _livroRepositorio.RemoverLivro(livro);
    }
    public LivroResposta AtualizarLivro
    (int id, LivroCriarAtualizarRequisicao LivroEditado)
    {
      var livro = BuscaPeloId(id);

    //  ConverterRequisicaoModelo(LivroEditado, livro);
      LivroEditado.Adapt(livro);
      _livroRepositorio.AtualizarLivro();

      return livro.Adapt<LivroResposta>(); //ConverteModeloResposta(livro);

    }
    private Livro BuscaPeloId(int id,bool tracking = true)
    {
      var livro = _livroRepositorio.BuscarId(id,tracking);
      if (livro is null)
      {
        throw new Exception("Livro não encontrado!");
      }
      return livro;

    }



/*
    private void ConverterRequisicaoModelo
    (LivroCriarAtualizarRequisicao requisicao, Livro modelo)
    {
      modelo.Nome = requisicao.Nome;
      modelo.Categoria = requisicao.Categoria;
      modelo.Autor = requisicao.Autor;
      modelo.Preco = requisicao.Preco;
      modelo.Status = requisicao.Status;

    }
    private LivroResposta ConverteModeloResposta(Livro modelo)

    {
      var livroResposta = new LivroResposta();
      livroResposta.Id = modelo.Id;
      livroResposta.Nome = modelo.Nome;
      livroResposta.Categoria = modelo.Categoria;
      livroResposta.Autor = modelo.Autor;
      livroResposta.Preco = modelo.Preco;
      livroResposta.Status = modelo.Status;

      return livroResposta;
    }*/
    
  }
}