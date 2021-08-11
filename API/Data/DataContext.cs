using System.Data.SqlTypes;
using System;
using System.Collections.Generic;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) {}
        public DbSet<Atendimento> Atendimentos {get; set;}
        public DbSet<Gestor> Gestores {get; set;}
        public DbSet<Tecnico> Tecnicos {get; set;}
        public DbSet<TipoDeAtendimento> TiposDeAtendimento {get; set;}
         protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Login>()
                .HasKey(AD => new { AD.TecnicoId, AD.GestorId });
            builder.Entity<Atendimento>()
                .HasData(new List<Atendimento>() {
                    new Atendimento() {Id = 1, NomeCliente = "Maria Aparecida", DataExecucao = DateTime.Parse("segunda-feira, 09 de agosto de 2021 1:45 PM"), Observacao = "Resolvido", TipoDeAtendimentoTipo = "Telefone", TecnicoNome = " Ana Couto" }
                });
            builder.Entity<Gestor>()
                .HasData(new List<Gestor>() {
                    new Gestor() {Id = 1, Nome = "Joaguim Pedrosa", Senha = "qwe345" }
                });
            builder.Entity<Tecnico>()
                .HasData(new List<Tecnico>() {
                    new Tecnico() {Id = 0001, Nome = " Francisco Couto", Senha = "asd123", Ativo = true },
                    new Tecnico() {Id = 0002, Nome = " Ana Couto", Senha = "fgh456", Ativo = true },
                    new Tecnico() {Id = 0003, Nome = " Arthur Menezes", Senha = "jkl789", Ativo = true },
                    new Tecnico() {Id = 0004, Nome = " Flavia Santos", Senha = "zxc012", Ativo = true }
                });
            builder.Entity<TipoDeAtendimento>()
                .HasData(new List<TipoDeAtendimento>() {
                    new TipoDeAtendimento() {Id = 1, Tipo = "Presencial", Ativo = true },
                    new TipoDeAtendimento() {Id = 2, Tipo = "Telefone", Ativo = true },
                    new TipoDeAtendimento() {Id = 3, Tipo = "Email", Ativo = true },
                    new TipoDeAtendimento() {Id = 4, Tipo = "Chat", Ativo = true },
                    new TipoDeAtendimento() {Id = 5, Tipo = "Redes Sociais", Ativo = true }
                });
        }

        
    }
}