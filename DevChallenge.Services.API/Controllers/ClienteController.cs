using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevChallenge.Application.Interfaces;
using DevChallenge.Application.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevChallenge.Services.API.Controllers
{
    /// <summary>
    /// Api de Cliente.
    /// </summary>
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteAppService _clienteAppService;
        /// <summary>
        /// Construtor com injeção de dependências.
        /// </summary>
        /// <param name="clienteAppService">Injeção de IClienteAppService.</param>
        public ClienteController(IClienteAppService clienteAppService)
        {
            _clienteAppService = clienteAppService;
        }
        /// <summary>
        /// Lista Cliente.
        /// </summary>
        /// <returns>Lista de Clientes.</returns>
        [HttpGet]
        public IEnumerable<ClienteViewModel> Get()
        {
            var lstClienteViewModel = this._clienteAppService.Listar<ClienteViewModel>();
            return lstClienteViewModel;
        }
        /// <summary>
        /// Lista Cliente por Id.
        /// </summary>
        /// <param name="id">Id do Cliente.</param>
        /// <returns>Cliente.</returns>
        [HttpGet("{id}")]
        public ClienteViewModel Get(int id)
        {
            //carrega os selects
            var objClienteViewModel = this._clienteAppService.Listar<ClienteViewModel>(id);
            return objClienteViewModel;
        }
        /// <summary>
        /// Lista Cliente por nome.
        /// </summary>
        /// <param name="nome">Nome do Cliente.</param>
        /// <param name="cpf">Cpf do Cliente.</param>
        /// <param name="rg">Rg do Cliente.</param>
        /// <returns>Lista de Clientes.</returns>
        [HttpGet("GetByName/{nome}/{cpf}/{rg}")]
        public IEnumerable<ClienteViewModel> GetByName(string nome, string cpf, string rg)
        {
            //carrega os selects
            var lstClienteViewModel = this._clienteAppService.ListarPorNome<ClienteViewModel>(nome, cpf, rg);
            return lstClienteViewModel;
        }
        /// <summary>
        /// Adiciona um novo Cliente.
        /// </summary>
        /// <param name="value">Dados do novo Cliente.</param>
        /// <returns>Id do Cliente adicionado.</returns>
        [HttpPost]
        public IActionResult Post([FromBody] ClienteViewModel value)
        {
            try
            {
                this._clienteAppService.Adicionar<ClienteViewModel>(ref value);
                return Ok(value.Id);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    return BadRequest(ex.InnerException.Message);
                }
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Edita um Cliente.
        /// </summary>
        /// <param name="id">Id do Cliente.</param>
        /// <param name="value">Dados que serão editados.</param>
        /// <returns>Id do Cliente editado.</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ClienteViewModel value)
        {
            this._clienteAppService.Editar<ClienteViewModel>(ref value);
            return Ok(value.Id);
        }
        /// <summary>
        /// Exclui um Cliente.
        /// </summary>
        /// <param name="id">Id do Cliente.</param>
        /// <returns>Id do Cliente excluído.</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            this._clienteAppService.Excluir(id);
            return Ok(id);
        }
    }
}