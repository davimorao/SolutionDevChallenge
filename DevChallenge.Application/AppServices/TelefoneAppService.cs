using AutoMapper;
using DevChallenge.Application.Interfaces;
using DevChallenge.Domain.Entities;
using DevChallenge.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevChallenge.Application.AppServices
{
    public class TelefoneAppService : AppServiceBase<Telefone>, ITelefoneAppService
    {
        private readonly IMapper _mapper;
        private readonly ITelefoneService _telefoneService;

        public TelefoneAppService
            (
                IMapper mapper,
                ITelefoneService telefoneService
            )
            : base(telefoneService, mapper)
        {
            _mapper = mapper;
            _telefoneService = telefoneService;
        }
    }
}
