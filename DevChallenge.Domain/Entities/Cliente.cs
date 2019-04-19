using System;
using System.Collections.Generic;
using System.Text;
using DevChallenge.CrossCutting.Extension;
using DevChallenge.Domain.Interfaces.Entities;
using FluentValidation;

namespace DevChallenge.Domain.Entities
{
    public class Cliente : EntityBase<Cliente>
    {
        private Validation validation = new Validation();

        public Cliente()
        {
        }

        #region Properties

        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }

        public string Facebook { get; set; }
        public string Linkedin { get; set; }
        public string Twitter { get; set; }
        public string Instagram { get; set; }
        
        public virtual Telefone Telefone { get; set; }
        public virtual Endereco Endereco { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Validações do objeto.
        /// </summary>
        /// <returns></returns>
        public override bool IsValid()
        {
            ValidarCpf();
            ValidarUrls();

            
            return base.ValidationResult.IsValid;
        }
        
        private void ValidarCpf()
        {
            RuleFor(c => c.Cpf)
                 .NotEmpty().WithMessage("O CPF está vazio.")
                 .MaximumLength(14).WithMessage("CPF máximo 14 caracteres")
                 .Must(validation.ValidaCpf).WithMessage("CPF inválido.");

            ValidationResult = base.Validate(this);
        }
        private void ValidarUrls()
        {
            if (!string.IsNullOrWhiteSpace(this.Facebook))
            {
                RuleFor(c => c.Facebook)
                    .Must(validation.ValidarUrl).WithMessage("Link de Facebook inválido.");
            }
            if (!string.IsNullOrWhiteSpace(this.Instagram))
            {
                RuleFor(c => c.Instagram)
                    .Must(validation.ValidarUrl).WithMessage("Link de Instagram inválido.");
            }
            if (!string.IsNullOrWhiteSpace(this.Linkedin))
            {
                RuleFor(c => c.Linkedin)
                    .Must(validation.ValidarUrl).WithMessage("Link de Linkedin inválido.");
            }
            if (!string.IsNullOrWhiteSpace(this.Twitter))
            {
                RuleFor(c => c.Twitter)
                    .Must(validation.ValidarUrl).WithMessage("Link de Twitter inválido.");
            }
        }

        #endregion
    }
}
