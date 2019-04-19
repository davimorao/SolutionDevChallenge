using DevChallenge.Domain.Entities;
using DevChallenge.Infra.Data.Extensions;
using DevChallenge.Infra.Data.Mappings;

using FluentValidation.Results;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DevChallenge.Infra.Data.Context
{
    public class CadastroContext : DbContext
    {
        #region DbSet

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Telefone> Telefone { get; set; }
        public DbSet<Endereco> Endereco { get; set; }

        #endregion

        #region Methods
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfiguration(new ClienteMapping());
            modelBuilder.AddConfiguration(new TelefoneMapping());
            modelBuilder.AddConfiguration(new EnderecoMapping());

            modelBuilder.Ignore<ValidationResult>();
            CarregarEntidades(modelBuilder);
        }

        /// <summary>
        /// Preenche os dados das entidades.
        /// </summary>
        /// <param name="modelBuilder"></param>
        private void CarregarEntidades(ModelBuilder modelBuilder)
        {
            // seed

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            #region Data Cadastro

            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }

            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataAlteracao") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataAlteracao").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataAlteracao").CurrentValue = DateTime.Now;

                }
            }



            #endregion

            #region Status

            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("Status") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("Status").CurrentValue = true;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("Status").IsModified = false;
                }
            }

            #endregion

            #region FK State

            foreach (var item in ChangeTracker.Entries())
            {
                string PrimaryKey = item.Entity.GetType().GetProperties().Single(p => p.Name == "Id").Name;

                if (Convert.ToInt32(item.Entity.GetType().GetProperty(PrimaryKey).GetValue(item.Entity)) > 0 && item.State == EntityState.Added)
                {
                    item.State = EntityState.Modified;
                }
            }

            #endregion

            return base.SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environmentName}.json", optional: true)
                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"))
                .EnableSensitiveDataLogging();
        }

        #endregion
    }
}
