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
    public class PerfilRepositorio
    {
        private readonly ContextoBD _contexto;

        public PerfilRepositorio([FromServices] ContextoBD contexto)
        {
            _contexto = contexto;
        }

        public Perfil BuscarPefilPeloId(int id)

        {
            return _contexto.Perfis.AsNoTracking().FirstOrDefault(p => p.Id == id); 

       }       
    }
}