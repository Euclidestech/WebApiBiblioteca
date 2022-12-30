using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Dtos.Usuario
{
  public class UsuarioCriarRequisicao
  {
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public string Senha { get; set; }
    public EnderecoCriarAtualizarRequisicao Endereco { get; set; }
  }
  public class EnderecoCriarAtualizarRequisicao
  {
    public string Rua { get; set; }
    public string Numero { get; set; }
    public string Bairro { get; set; }
    public string Cidade { get; set; }
    public string Cep { get; set; }
  }
}