using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblioteca.Data;
using Biblioteca.Models;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Repositorio
{
  public class LivroRepositorio
  {
    private ContextoBD _contexto;

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
        return _contexto.Livros.ToList();
    }
  }
  
}