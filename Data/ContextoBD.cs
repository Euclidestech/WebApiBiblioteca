using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblioteca.Models;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Data
{
  public class ContextoBD : DbContext
  {
    //Construtor que vai receber configurações de acesso ao BD
    //Essas configurações virão do Program.cs
    public ContextoBD(DbContextOptions<ContextoBD> options) : base(options)
    {

    }

    //Tabelas
    public DbSet<Livro> Livros { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }
    public DbSet<Pedido> Pedidos { get; set; }
    public DbSet<Perfil> Perfis { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }

  }

}