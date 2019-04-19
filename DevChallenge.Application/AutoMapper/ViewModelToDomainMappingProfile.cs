using AutoMapper;
using DevChallenge.Application.ViewModels;
using DevChallenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevChallenge.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            #region Cadastro
            CreateMap<ClienteViewModel, Cliente>();
            CreateMap<TelefoneViewModel, Telefone>();
            CreateMap<EnderecoViewModel, Endereco>();
            #endregion

            #region Enum

            #endregion
        }
    }
}
