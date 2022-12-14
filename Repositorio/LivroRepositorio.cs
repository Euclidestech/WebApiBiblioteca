using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblioteca.Data;
using Biblioteca.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Repositorio
{
  public class LivroRepositorio
  {
    private readonly ContextoBD _contexto;

    public LivroRepositorio([FromServices] ContextoBD contexto)
    {
      _contexto = contexto;
    }
    public Livro CriarLivro(Livro livro)
    {
      _contexto.Livros.Add(livro);
      _contexto.SaveChanges();

      return livro;
    }

    public List<Livro> ListarLivros()
    {
      return _contexto.Livros.AsNoTracking().ToList();
    }

    public Livro BuscarId(int id, bool tracking = true)
    {
      return (tracking) ?
       _contexto.Livros.FirstOrDefault(livro => livro.Id == id) :
          _contexto.Livros.AsNoTracking().FirstOrDefault(livro => livro.Id == id);
    }
    public void RemoverLivro(Livro livro)
    {
      _contexto.Remove(livro);
      _contexto.SaveChanges();
    }

    public void AtualizarLivro()
    {
      _contexto.SaveChanges();
    }
  }

}