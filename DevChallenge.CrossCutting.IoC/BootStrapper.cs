using AutoMapper;
using DevChallenge.Application.AppServices;
using DevChallenge.Application.AutoMapper;
using DevChallenge.Application.Interfaces;
using DevChallenge.Domain.Interfaces.Repositories;
using DevChallenge.Domain.Interfaces.Services;
using DevChallenge.Domain.Services;
using DevChallenge.Infra.Data.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DevChallenge.CrossCutting.IoC
{
    public class BootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            #region Application

            services.AddSingleton<IConfigurationProvider>(AutoMapperConfiguration.RegisterMappings());
            services.AddScoped<IMapper>(x => new Mapper(x.GetRequiredService<IConfigurationProvider>(), x.GetService));

            #endregion

            #region AppService
            
            services.AddScoped<IClienteAppService, ClienteAppService>();
            services.AddScoped<IEnderecoAppService, EnderecoAppService>();
            services.AddScoped<ITelefoneAppService, TelefoneAppService>();

            #endregion

            #region Service

            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<ITelefoneService, TelefoneService>();
            services.AddScoped<IEnderecoService, EnderecoService>();

            #endregion

            #region Infra - Data

            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<ITelefoneRepository, TelefoneRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();


            #endregion


        }
    }
}
