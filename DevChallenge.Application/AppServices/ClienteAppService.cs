using AutoMapper;
using DevChallenge.Application.Interfaces;
using DevChallenge.Application.ViewModels;
using DevChallenge.Domain.Entities;
using DevChallenge.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevChallenge.Application.AppServices
{
    public class ClienteAppService : AppServiceBase<Cliente>, IClienteAppService
    {
        private readonly IMapper _mapper;
        private readonly IClienteService _clienteService;

        public ClienteAppService
            (
                IMapper mapper,
                IClienteService clienteService
            )
            : base(clienteService, mapper)
        {
            _mapper = mapper;
            _clienteService = clienteService;
        }

        /// <summary>
        /// Método responsável por retornar uma lista de objetos com base parametro.
        /// </summary>
        /// <typeparam name="TViewModel"></typeparam>
        /// <param name="nome"></param>
        /// <returns></returns>
        public IEnumerable<TViewModel> ListarPorNome<TViewModel>(string nome, string cpf, string rg) where TViewModel : BaseViewModel
        {
            try
            {
                if (nome == "null")
                {
                    nome = string.Empty;
                }
                if (cpf == "null")
                {
                    cpf = string.Empty;
                }
                if (rg == "null")
                {
                    rg = string.Empty;
                }
                var lstRetorno = this._mapper.Map<IEnumerable<Cliente>, IEnumerable<TViewModel>>(this._clienteService.ListarPorNome(nome, cpf, rg));
                return
                    lstRetorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
