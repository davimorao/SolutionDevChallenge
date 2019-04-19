using DevChallenge.Domain.Entities;
using DevChallenge.Domain.Interfaces.Repositories;
using DevChallenge.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevChallenge.Domain.Services
{
    public class EnderecoService : ServiceBase<Endereco>, IEnderecoService
    {
        private readonly IEnderecoRepository _enderecoRepository;

        public EnderecoService(
            IEnderecoRepository enderecoRepository
            ) : base(enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }
    }
}
