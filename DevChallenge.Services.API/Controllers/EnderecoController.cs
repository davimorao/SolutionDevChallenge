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
    /// Api de Endereço.
    /// </summary>
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoAppService _enderecoAppService;

        /// <summary>
        /// Construtor com injeção de dependências.
        /// </summary>
        /// <param name="enderecoAppService">Injeção de dependência de IEnderecoAppService.</param>
        public EnderecoController(IEnderecoAppService enderecoAppService)
        {
            _enderecoAppService = enderecoAppService;
        }
        /// <summary>
        /// Lista Endereço.
        /// </summary>
        /// <returns>Lista de Endereços.</returns>
        [HttpGet]
        public IEnumerable<EnderecoViewModel> Get()
        {
            var lstEnderecoViewModel = this._enderecoAppService.Listar<EnderecoViewModel>();

            return lstEnderecoViewModel;
        }
        /// <summary>
        /// Lista Endereço por Id.
        /// </summary>
        /// <param name="id">Id do Endereço.</param>
        /// <returns>Endereço.</returns>
        [HttpGet("{id}")]
        public EnderecoViewModel Get(int id)
        {
            //carrega os selects
            var objEnderecoViewModel = this._enderecoAppService.Listar<EnderecoViewModel>(id);

            return objEnderecoViewModel;
        }
        /// <summary>
        /// Adiciona um novo Endereço.
        /// </summary>
        /// <param name="value">Dados do novo Endereço.</param>
        /// <returns>Id do Endereço adicionado.</returns>
        [HttpPost]
        public IActionResult Post([FromBody] EnderecoViewModel value)
        {
            this._enderecoAppService.Adicionar<EnderecoViewModel>(ref value);

            return Ok(value.Id);
        }
        /// <summary>
        /// Edita um Endereço.
        /// </summary>
        /// <param name="id">Id do Endereço.</param>
        /// <param name="value">Dados que serão editados.</param>
        /// <returns>Id do Endereço editado.</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] EnderecoViewModel value)
        {
            value.Id = id;
            this._enderecoAppService.Editar<EnderecoViewModel>(ref value);

            return Ok(value.Id);
        }
        /// <summary>
        /// Exclui um Endereço.
        /// </summary>
        /// <param name="id">Id do Endereço.</param>
        /// <returns>Id do Cliente excluído.</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            this._enderecoAppService.Excluir(id);

            return Ok(id);
        }
    }
}