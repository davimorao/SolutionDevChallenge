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
    /// Api de Telefone.
    /// </summary>
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class TelefoneController : ControllerBase
    {
        private readonly ITelefoneAppService _telefoneAppService;
        /// <summary>
        /// Construtor com injeção de dependências.
        /// </summary>
        /// <param name="telefoneAppService">Injeção de ITelefoneAppService.</param>
        public TelefoneController(ITelefoneAppService telefoneAppService)
        {
            _telefoneAppService = telefoneAppService;
        }
        /// <summary>
        /// Lista Telefone.
        /// </summary>
        /// <returns>Lista Telefone.</returns>
        [HttpGet]
        public IEnumerable<TelefoneViewModel> Get()
        {
            var lstTelefoneViewModel = this._telefoneAppService.Listar<TelefoneViewModel>();

            return lstTelefoneViewModel;
        }
        /// <summary>
        /// Lista Telefone por Id.
        /// </summary>
        /// <param name="id">Id do Telefone.</param>
        /// <returns>Telefone.</returns>
        [HttpGet("{id}")]
        public TelefoneViewModel Get(int id)
        {
            //carrega os selects
            var objTelefoneViewModel = this._telefoneAppService.Listar<TelefoneViewModel>(id);

            return objTelefoneViewModel;
        }

        /// <summary>
        /// Adiciona um novo Telefone.
        /// </summary>
        /// <param name="value">Dados do novo Telefone.</param>
        /// <returns>Id do Telefone adicionado.</returns>
        [HttpPost]
        public IActionResult Post([FromBody] TelefoneViewModel value)
        {
            this._telefoneAppService.Adicionar<TelefoneViewModel>(ref value);

            return Ok(value.Id);
        }

        /// <summary>
        /// Edita um Telefone.
        /// </summary>
        /// <param name="id">Id do Telefone.</param>
        /// <param name="value">Dados que serão editados.</param>
        /// <returns>Id do Telefone editado.</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TelefoneViewModel value)
        {
            value.Id = id;
            this._telefoneAppService.Editar<TelefoneViewModel>(ref value);

            return Ok(value.Id);
        }

        /// <summary>
        /// Exclui um Telefone.
        /// </summary>
        /// <param name="id">Id do Telefone.</param>
        /// <returns>Dados que serão editados.</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            this._telefoneAppService.Excluir(id);

            return Ok();
        }
    }
}