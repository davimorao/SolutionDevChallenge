using DevChallenge.Domain.Interfaces;
using DevChallenge.Domain.Interfaces.Entities;
using DevChallenge.Domain.Interfaces.Repositories;
using DevChallenge.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DevChallenge.Infra.Data.Repository
{
    public class RepositoryBase<T> : IDisposable, IRepositoryBase<T> where T : EntityBase<T>
    {
        protected CadastroContext Db = new CadastroContext();

        /// <summary>
        /// Método responsável por adicionar uma entidade genérica no banco de dados.
        /// </summary>
        /// <param name="obj">Entidade que será salva.</param>
        public void Adicionar(T obj)
        {
            try
            {
                obj.GetType().GetProperty("DataCadastro").SetValue(obj, DateTime.Now);
                obj.GetType().GetProperty("DataAlteracao").SetValue(obj, DateTime.Now);
                Db.Set<T>().Add(obj);
                Db.SaveChanges();
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
                //Db.Configuration.ProxyCreationEnabled = pProxyCreationEnabled;
                //Db.Configuration.LazyLoadingEnabled = pLazyLoadingEnabled;
                Db.Set<T>().AddRange(plstObj);
                Db.SaveChanges();
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
                IQueryable<T> query = Db.Set<T>();

                if (includes != null)
                {
                    foreach (Expression<Func<T, object>> include in includes)
                        query = query.Include(include);
                }

                if (filter != null)
                    query = query.Where(filter);

                if (orderBy != null)
                    query = orderBy(query);

                return query.AsNoTracking();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Método responsável por listar uma entidade genérica no banco de dados de acordo com o Id.
        /// </summary>
        /// <param name="pId">Id da entidade.</param>
        /// <returns>Entidade correspondente ao Id passado por parâmetro.</returns>
        public T Listar(int pId)
        {
            try
            {
                var obj =
                    Db.Set<T>().AsNoTracking().FirstOrDefault(x => x.Id == pId);

                if (obj != null && !((DateTime?)obj.GetType().GetProperty("DataExclusao").GetValue(obj)).HasValue)
                {
                    return obj;
                }
                throw new Exception("Nenhum registro encontrado.");
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
        public IEnumerable<T> Listar(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = Db.Set<T>();

            if (includes != null)
            {
                foreach (Expression<Func<T, object>> include in includes)
                    query = query.Include(include);
            }

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
                query = orderBy(query);

            return query;
        }

        /// <summary>
        /// Método responsável por retornar uma lista de entidade genérica.
        /// </summary>
        /// <returns>Lista de entidades.</returns>
        public IEnumerable<T> Listar()
        {
            try
            {
                return
                    Db.Set<T>().AsNoTracking().Where(x => !((DateTime?)x.GetType().GetProperty("DataExclusao").GetValue(x)).HasValue).OrderByDescending(x => x.Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método responsável por realizar a paginação.
        /// </summary>
        /// <param name="pCollection">Collection que será paginada.</param>
        /// <param name="pPaginaSolicitada">Página solicitada.</param>
        /// <param name="pQuantidadePaginas">Quantidade de páginas.</param>
        /// <param name="pQuantidadeRegistros">Quantidade de registros.</param>
        /// <returns>Collection paginada.</returns>
        public IEnumerable<T> Paginar(IEnumerable<T> pCollection, ref int pPaginaSolicitada, ref int pQuantidadePaginas, int pQuantidadeRegistros)
        {
            try
            {
                double pQuantidadePaginasComPrecisao = (double)pCollection.Count() / (double)pQuantidadeRegistros;
                pQuantidadePaginas = pCollection.Count() / pQuantidadeRegistros;
                if (pQuantidadePaginas < pQuantidadePaginasComPrecisao)
                {
                    pQuantidadePaginas++;
                }

                if (pPaginaSolicitada <= 0)
                {
                    pPaginaSolicitada = 1;
                }
                else if (pPaginaSolicitada > pQuantidadePaginas)
                {
                    pPaginaSolicitada = pQuantidadePaginas;
                }

                var lstRetorno = pCollection.Skip((pPaginaSolicitada - 1) * pQuantidadeRegistros)
                                            .Take(pQuantidadeRegistros)
                                            .AsParallel()
                                            .ToList();
                return
                    lstRetorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método responsável por editar uma entidade genérica no banco de dados.
        /// </summary>
        /// <param name="pObj">Entidade que será editada.</param>
        public void Editar(T pObj)
        {
            try
            {
                pObj.GetType().GetProperty("DataAlteracao").SetValue(pObj, DateTime.Now);
                Db.Set<T>().Update(pObj);
                Db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método responsável por excluir uma entidade genérica no banco de dados.
        /// </summary>
        /// <param name="pObj">Entidade que será excluída.</param>
        public void Excluir(int pId)
        {
            try
            {
                var pObj = this.Listar(pId);
                pObj.GetType().GetProperty("DataExclusao").SetValue(pObj, DateTime.Now);
                this.Editar(pObj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método responsável por dar dispose na instância da classe.
        /// </summary>
        public void Dispose()
        {
            try
            {
                this.Db.Dispose();
                GC.SuppressFinalize(this);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public T Obter(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includes)
        {
            try
            {
                IQueryable<T> query = Db.Set<T>().AsNoTracking();

                if (includes != null)
                {
                    foreach (Expression<Func<T, object>> include in includes)
                        query = query.Include(include);
                }

                T response = query.FirstOrDefault(where);

                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
