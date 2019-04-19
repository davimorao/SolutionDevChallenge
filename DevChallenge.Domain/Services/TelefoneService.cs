using DevChallenge.Domain.Entities;
using DevChallenge.Domain.Interfaces.Repositories;
using DevChallenge.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevChallenge.Domain.Services
{
    public class TelefoneService : ServiceBase<Telefone>, ITelefoneService
    {
        private readonly ITelefoneRepository _telefoneRepository;

        public TelefoneService(
            ITelefoneRepository telefoneRepository
            ) : base(telefoneRepository)
        {
            _telefoneRepository = telefoneRepository;
        }
    }
}
