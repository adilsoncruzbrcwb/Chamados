using NovoProjeto.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NovoProjeto.Contexts
{
    public class EFContext : DbContext
    {
        public EFContext() : base("Nova_Aplicacao")
        {
        }
        public DbSet<Chamado> Chamados { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
  
    }
}