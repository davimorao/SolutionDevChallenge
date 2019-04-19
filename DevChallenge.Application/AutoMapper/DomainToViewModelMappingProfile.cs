using AutoMapper;
using DevChallenge.Application.ViewModels;
using DevChallenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevChallenge.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            #region Cadastro
            CreateMap<Cliente, ClienteViewModel>().ForMember(x => x.DataNascimento, y => y.MapFrom(c => c.DataNascimento.ToString("dd/MM/yyyy")));
            CreateMap<Telefone, TelefoneViewModel>();
            CreateMap<Endereco, EnderecoViewModel>();
            #endregion

            #region Enum

            #endregion
        }
    }
}
