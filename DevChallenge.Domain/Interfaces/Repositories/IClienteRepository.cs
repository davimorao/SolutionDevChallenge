﻿using DevChallenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevChallenge.Domain.Interfaces.Repositories
{
    public interface IClienteRepository : IRepositoryBase<Cliente>
    {
        /// <summary>
        /// Método responsável por retornar uma lista de objetos com base parametro.
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        IEnumerable<Cliente> ListarPorNome(string nome, string cpf, string rg);
    }
}