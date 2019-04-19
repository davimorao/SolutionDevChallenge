using DevChallenge.Domain.Entities;
using DevChallenge.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevChallenge.Infra.Data.Repository
{
    public class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
    {
        Cliente IRepositoryBase<Cliente>.Listar(int pId)
        {
            try
            {
                var objCliente = base.Db.Cliente.Where(x => !x.DataExclusao.HasValue)
                    .Include("Endereco")
                    .Include("Telefone")
                    .Where(x => x.Id == pId)
                    .AsNoTracking()
                    .FirstOrDefault();
                if(objCliente == null)
                {
                    throw new Exception("Nenhum registro encontrado.");
                }
                return
                    objCliente;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        void IRepositoryBase<Cliente>.Editar(Cliente pObj)
        {
            try
            {
                var objCliente = base.Db.Cliente.Where(x => !x.DataExclusao.HasValue)
                    .Include("Endereco")
                    .Include("Telefone")
                    .Where(x => x.Id == pObj.Id)
                    .FirstOrDefault();
                if (objCliente == null)
                {
                    throw new Exception("Nenhum registro encontrado.");
                }

                objCliente.Nome = pObj.Nome;
                objCliente.DataNascimento = pObj.DataNascimento;
                objCliente.Cpf = pObj.Cpf;
                objCliente.Rg = pObj.Rg;
                objCliente.Facebook = pObj.Facebook;
                objCliente.Linkedin = pObj.Linkedin;
                objCliente.Twitter = pObj.Twitter;
                objCliente.Instagram = pObj.Instagram;

                objCliente.Endereco.Cep = pObj.Endereco.Cep;
                objCliente.Endereco.Logradouro = pObj.Endereco.Logradouro;
                objCliente.Endereco.Numero = pObj.Endereco.Numero;
                objCliente.Endereco.Bairro = pObj.Endereco.Bairro;
                objCliente.Endereco.Cidade = pObj.Endereco.Cidade;
                objCliente.Endereco.Estado = pObj.Endereco.Estado;

                objCliente.Telefone.Celular = pObj.Telefone.Celular;
                objCliente.Telefone.Residencial = pObj.Telefone.Residencial;

                base.Db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        void IRepositoryBase<Cliente>.Excluir(int pId)
        {
            try
            {
                var objCliente = base.Db.Cliente.Where(x => !x.DataExclusao.HasValue)
                    .Include("Endereco")
                    .Include("Telefone")
                    .Where(x => x.Id == pId)
                    .FirstOrDefault();
                if (objCliente == null)
                {
                    throw new Exception("Nenhum registro encontrado.");
                }

                objCliente.DataExclusao = DateTime.Now;
                objCliente.Endereco.DataExclusao = DateTime.Now;
                objCliente.Telefone.DataExclusao = DateTime.Now;

                base.Db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
                var lstCliente = base.Db.Cliente
                    .Where(x => !x.DataExclusao.HasValue)
                    .Where(x => string.IsNullOrWhiteSpace(nome) || x.Nome.Contains(nome))
                    .Where(x => string.IsNullOrWhiteSpace(cpf) || x.Cpf.Contains(cpf))
                    .Where(x => string.IsNullOrWhiteSpace(rg) || x.Rg.Contains(rg))
                    .OrderByDescending(x => x.Id)
                    .AsNoTracking();

                return
                    lstCliente;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
