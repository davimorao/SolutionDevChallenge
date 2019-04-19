using DevChallenge.Application.ViewModels;
using DevChallenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevChallenge.Application.Interfaces
{
    public interface IClienteAppService : IAppServiceBase<Cliente>
    {
        /// <summary>
        /// Método responsável por retornar uma lista de objetos com base parametro.
        /// </summary>
        /// <typeparam name="TViewModel"></typeparam>
        /// <param name="nome"></param>
        /// <returns></returns>
        IEnumerable<TViewModel> ListarPorNome<TViewModel>(string nome, string cpf, string rg) where TViewModel : BaseViewModel;
    }
}
