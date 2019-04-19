using DevChallenge.Domain.Interfaces.Repositories;
using DevChallenge.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DevChallenge.Domain.Services
{
    public class ServiceBase<T> : IDisposable, IServiceBase<T> where T : class
    {
        public ServiceBase(IRepositoryBase<T> pRepository)
        {
            this._repository = pRepository;
        }

        private readonly IRepositoryBase<T> _repository;


        /// <summary>
        /// Método responsável por adicionar uma entidade no banco de dados.
        /// </summary>
        /// <param name="pObj">Entidade que será adicionada.</param>
        public void Adicionar(T pObj)
        {
            try
            {
                this._repository.Adicionar(pObj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método responsável por adicionar objetos da entidade genérica no banco de dados.
        /// </summary>
        /// <param name="pObj">Entidade que será salva.</param>
        public void Adicionar(IEnumerable<T> plstObj)
        {
            try
            {
                this._repository.Adicionar(plstObj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método responsável por listar todos os registros de uma entidade
        /// com com includes, filtros e ordenação.
        /// </summary>
        /// <param name="filter">filtro - Ex.: x => x.Ativo == true</param>
        /// <param name="orderBy">ordenação - Ex.: x => x.OrderBy(p => p.Nome)</param>
        /// <param name="includes">entidades relacionadas - Ex.: x => x.Perfil, x.Modulo, etc...</param>
        /// <returns></returns>
        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, params Expression<Func<T, object>>[] includes)
        {
            try
            {
                return this._repository.GetAll(filter, orderBy, includes);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método responsável por listar um registro de acordo com o Id.
        /// </summary>
        /// <param name="pId">Id utilizado para filtro.</param>
        /// <returns>Entidade correspondente ao Id passado por parâmetro.</returns>
        public T Listar(int pId)
        {
            try
            {
                return
                    this._repository.Listar(pId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Lista objeto com filtro, ordenação e inclusão de tabelas filhas.
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        public IEnumerable<T> Listar(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, params Expression<Func<T, object>>[] includes)
        {
            try
            {
                return
                    this._repository.Listar(filter, orderBy, includes);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método responsável por listar todos os registros de uma entidade.
        /// </summary>
        /// <returns>Lista de entidades.</returns>
        public IEnumerable<T> Listar()
        {
            try
            {
                return
                    this._repository.Listar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Realiza a paginação em uma collection.
        /// </summary>
        /// <param name="pCollection">Collection que será paginada.</param>
        /// <param name="pPaginaSolicitada">Página solicitada na paginação.</param>
        /// <param name="pQuantidadePaginas">Quantidade de páginas na paginação.</param>
        /// <param name="pQuantidadeRegistros">Quantidade de registros por página.</param>
        /// <returns>Collection paginada.</returns>
        public IEnumerable<T> Paginar(IEnumerable<T> pCollection, ref int pPaginaSolicitada, ref int pQuantidadePaginas, int pQuantidadeRegistros)
        {
            try
            {
                return
                    this._repository.Paginar(pCollection, ref pPaginaSolicitada, ref pQuantidadePaginas, pQuantidadeRegistros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método responsável por editar um registro.
        /// </summary>
        /// <param name="pObj">Entidade que será editada.</param>
        public void Editar(T pObj)
        {
            try
            {
                this._repository.Editar(pObj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método responsável por excluir um registro.
        /// </summary>
        /// <param name="pObj">Registro que será excluído.</param>
        public void Excluir(int pId)
        {
            try
            {
                this._repository.Excluir(pId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Dispose ServiceBase.
        /// </summary>
        public void Dispose()
        {
            try
            {
                this._repository.Dispose();
                GC.SuppressFinalize(this);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public T Obter(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includes)
        {
            return _repository.Obter(where, includes);
        }
    }
}
