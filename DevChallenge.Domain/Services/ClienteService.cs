using DevChallenge.Domain.Entities;
using DevChallenge.Domain.Interfaces.Repositories;
using DevChallenge.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevChallenge.Domain.Services
{
    public class ClienteService : ServiceBase<Cliente>, IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(
            IClienteRepository clienteRepository
            ) : base(clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        /// <summary>
        /// Método responsável por retornar uma lista de objetos com base parametro.
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        public IEnumerable<Cliente> ListarPorNome(string nome, string cpf, string rg)
        {
            try
            {
                return
                    this._clienteRepository.ListarPorNome(nome, cpf, rg);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
