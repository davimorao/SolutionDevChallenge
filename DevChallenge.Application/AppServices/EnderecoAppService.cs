using AutoMapper;
using DevChallenge.Application.Interfaces;
using DevChallenge.Domain.Entities;
using DevChallenge.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevChallenge.Application.AppServices
{
    public class EnderecoAppService : AppServiceBase<Endereco>, IEnderecoAppService
    {
        private readonly IMapper _mapper;
        private readonly IEnderecoService _enderecoService;

        public EnderecoAppService
            (
                IMapper mapper,
                IEnderecoService enderecoService
            )
            : base(enderecoService, mapper)
        {
            _mapper = mapper;
            _enderecoService = enderecoService;
        }


    }
}
