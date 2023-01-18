using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Dtos.Usuario;
using Biblioteca.Models;
using Biblioteca.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Biblioteca.Servicos
{
  public class AutenticacaoServico
  {
    private readonly UsuarioRepositorio _usuarioRepositorio;
    private readonly IConfiguration _configuration;

    public AutenticacaoServico([FromServices] UsuarioRepositorio repositorio,
    [FromServices] IConfiguration configuration)

    {
      _usuarioRepositorio = repositorio;
      _configuration = configuration;
    }
    public string Login(UsuarioLoginRequisicao usuarioLogin)
    {
      var usuario = _usuarioRepositorio.BuscarUsuarioPeloCpf(usuarioLogin.Cpf);
      System.Console.WriteLine("aquis");
      System.Console.WriteLine(usuario.Nome);

      if ((usuario is null) || (!BCrypt.Net.BCrypt.Verify(usuarioLogin.Senha, usuario.Senha)))
      {
        throw new Exception("Usuario ou senha incorretos");
      }

      System.Console.WriteLine("aqui2");

      var tokenJWT = GerarJWT(usuario);

      return tokenJWT;


    }


    private String GerarJWT(Usuario usuario)
    {
      //Pegando a chave JWT
      var JWTChave = Encoding.ASCII.GetBytes(_configuration["JWTChave"]);

      //Criando as credenciais
      var credenciais = new SigningCredentials(
              new SymmetricSecurityKey(JWTChave),
              SecurityAlgorithms.HmacSha256);

      var claims = new List<Claim>();

      //System.Console.WriteLine(usuario.Perfis.Count);

      claims.Add(new Claim(ClaimTypes.Name, usuario.Nome));
      claims.Add(new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()));
      foreach (var perfil in usuario.Perfis)
      {
        //System.Console.WriteLine(perfil.Tipo);
        claims.Add(new Claim(ClaimTypes.Role, perfil.Tipo));
      }
      //Criando o token
      var tokenJWT = new JwtSecurityToken(
          expires: DateTime.Now.AddHours(8),
          signingCredentials: credenciais,
          claims: claims
      );

      //Escrevendo o token e retornando
      return new JwtSecurityTokenHandler().WriteToken(tokenJWT);
    }
  }
}