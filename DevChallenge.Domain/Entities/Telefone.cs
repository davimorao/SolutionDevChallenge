using DevChallenge.CrossCutting.Extension;
using DevChallenge.Domain.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevChallenge.Domain.Entities
{
    public class Telefone : EntityBase<Telefone>
    {
        private Validation validation = new Validation();

        public Telefone(){}


        #region Properties

        public string Residencial { get; set; }
        public string Celular { get; set; }

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
