using DevChallenge.CrossCutting.Extension;
using DevChallenge.Domain.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevChallenge.Domain.Entities
{

    public class Endereco : EntityBase<Endereco>
    {
        private Validation validation = new Validation();

        public Endereco(){}

        #region Properties

        public int Cep { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        public int IdCliente { get; set; }
        public virtual Cliente Cliente { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Validações do objeto.
        /// </summary>
        /// <returns></returns>
        public override bool IsValid()
        {
            ValidationResult = base.Validate(this);

            return base.ValidationResult.IsValid;
        }

        #endregion
    }
}
