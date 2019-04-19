using AutoMapper;
using DevChallenge.Application.Interfaces;
using DevChallenge.Domain.Interfaces.Entities;
using DevChallenge.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DevChallenge.Application.ViewModels;

namespace DevChallenge.Application.AppServices
{
    public class AppServiceBase<T> : IDisposable, IAppServiceBase<T> where T : EntityBase<T>
    {
        private readonly IServiceBase<T> _serviceBase;
        private readonly IMapper _mapper;

        public AppServiceBase(IServiceBase<T> pServiceBase, IMapper mapper)
        {
            this._serviceBase = pServiceBase;
            this._mapper = mapper;
        }


        #region Methods        

        /// <summary>
        /// Método responsável por adicionar uma entidade no banco de dados.
        /// </summary>
        /// <param name="pObj">Entidade que será adicionada.</param>
        public void Adicionar<TViewModel>(ref TViewModel pObj) where TViewModel : BaseViewModel
        {
            try
            {
                var objModel = this._mapper.Map<T>(pObj);
                if (objModel.IsValid())
                {
                    this._serviceBase.Adicionar(objModel);
                    pObj = this._mapper.Map<TViewModel>(objModel);
                }
                else
                {

                    List<Exception> excepcoes = new List<Exception>();
                    foreach (var item in objModel.ValidationResult.Errors.ToList())
                    {
                        excepcoes.Add(new ArgumentException(item.ErrorMessage));
                    }
                    throw new AggregateException(excepcoes);
                }
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
                this._serviceBase.Adicionar(plstObj);
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
                return this._serviceBase.GetAll(filter, orderBy, includes);
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
        public TViewModel Listar<TViewModel>(int pId) where TViewModel : BaseViewModel
        {
            try
            {
                var objRetorno =
                        this._mapper.Map<T, TViewModel>(this._serviceBase.Listar(pId));
                return
                        objRetorno;
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
                return this._serviceBase.Listar(filter, orderBy, includes);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Objeto com filtro, ordenação e inclusão de tabelas filhas.
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        public T Obter(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includes)
        {
            try
            {
                return this._serviceBase.Obter(filter, includes);
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
        public IEnumerable<TViewModel> Listar<TViewModel>() where TViewModel : BaseViewModel
        {
            try
            {
                var lstRetorno = this._mapper.Map<IEnumerable<T>, IEnumerable<TViewModel>>(this._serviceBase.Listar());
                return
                    lstRetorno;
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
                return this._serviceBase.Paginar(pCollection, ref pPaginaSolicitada, ref pQuantidadePaginas, pQuantidadeRegistros);
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
        public void Editar<TViewModel>(ref TViewModel pObj) where TViewModel : BaseViewModel
        {
            try
            {
                var objModel = this._mapper.Map<T>(pObj);
                if (objModel.IsValid())
                {
                    this._serviceBase.Editar(objModel);
                    pObj = this._mapper.Map<TViewModel>(objModel);
                }
                else
                {

                    List<Exception> excepcoes = new List<Exception>();
                    foreach (var item in objModel.ValidationResult.Errors.ToList())
                    {
                        excepcoes.Add(new ArgumentException(item.ErrorMessage));
                    }
                    throw new AggregateException(excepcoes);
                }

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
                this._serviceBase.Excluir(pId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Dispose AppServiceBase.
        /// </summary>
        public void Dispose()
        {
            try
            {
                this._serviceBase.Dispose();
                GC.SuppressFinalize(this);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
