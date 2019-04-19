using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DevChallenge.Domain.Interfaces.Services
{
    public interface IServiceBase<T> : IDisposable where T : class
    {
        /// <summary>
        /// Método responsável por adicionar uma entidade no banco de dados.
        /// </summary>
        /// <param name="pObj">Entidade que será adicionada.</param>
        void Adicionar(T pObj);

        /// <summary>
        /// Método responsável por adicionar objetos da entidade genérica no banco de dados.
        /// </summary>
        /// <param name="pObj">Entidade que será salva.</param>
        void Adicionar(IEnumerable<T> plstObj);

        /// <summary>
        /// Método responsável por listar todos os registros de uma entidade
        /// com com includes, filtros e ordenação.
        /// </summary>
        /// <param name="filter">filtro - Ex.: x => x.Ativo == true</param>
        /// <param name="orderBy">ordenação - Ex.: x => x.OrderBy(p => p.Nome)</param>
        /// <param name="includes">entidades relacionadas - Ex.: x => x.Perfil, x.Modulo, etc...</param>
        /// <returns></returns>
        IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null,
           Func<IQueryable<T>,
           IOrderedQueryable<T>> orderBy = null,
           params Expression<Func<T, object>>[] includes);

        /// <summary>
        /// Método responsável por listar um registro de acordo com o Id.
        /// </summary>
        /// <param name="pId">Id utilizado para filtro.</param>
        /// <returns>Entidade correspondente ao Id passado por parâmetro.</returns>
        T Listar(int pId);

        /// <summary>
        /// Lista objeto com filtro, ordenação e inclusão de tabelas filhas.
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        IEnumerable<T> Listar(Expression<Func<T, bool>> filter = null,
           Func<IQueryable<T>,
           IOrderedQueryable<T>> orderBy = null,
           params Expression<Func<T, object>>[] includes);

        /// <summary>
        /// Método responsável por listar todos os registros de uma entidade.
        /// </summary>
        /// <returns>Lista de entidades.</returns>
        IEnumerable<T> Listar();

        /// <summary>
        /// Realiza a paginação em uma collection.
        /// </summary>
        /// <param name="pCollection">Collection que será paginada.</param>
        /// <param name="pPaginaSolicitada">Página solicitada na paginação.</param>
        /// <param name="pQuantidadePaginas">Quantidade de páginas na paginação.</param>
        /// <param name="pQuantidadeRegistros">Quantidade de registros por página.</param>
        /// <returns>Collection paginada.</returns>
        IEnumerable<T> Paginar(IEnumerable<T> pCollection, ref int pPaginaSolicitada, ref int pQuantidadePaginas, int pQuantidadeRegistros);

        /// <summary>
        /// Método responsável por editar um registro.
        /// </summary>
        /// <param name="pObj">Entidade que será editada.</param>
        void Editar(T pObj);

        /// <summary>
        /// Método responsável por excluir um registro.
        /// </summary>
        /// <param name="pObj">Registro que será excluído.</param>
        void Excluir(int pId);

        /// <summary>
        /// Método responsável por filtrar de acordo com os parâmetros passados.
        /// </summary>
        /// <param name="pLstFiltro">Lista de filtros.</param>
        /// <returns>Lista filtrada.</returns>
        //IEnumerable<T> Filtrar(List<Filtro> pLstFiltro, bool pProxyCreationEnabled = false, bool pLazyLoadingEnabled = true);

        T Obter(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includes);
    }
}
