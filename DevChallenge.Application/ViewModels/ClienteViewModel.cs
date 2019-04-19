using System;
using System.Collections.Generic;
using System.Text;

namespace DevChallenge.Application.ViewModels
{
    public class ClienteViewModel : BaseViewModel
    {
        public string Nome { get; set; }
        public string DataNascimento { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public string Facebook { get; set; }
        public string Linkedin { get; set; }
        public string Twitter { get; set; }
        public string Instagram { get; set; }

        public virtual TelefoneViewModel Telefone { get; set; }
        public virtual EnderecoViewModel Endereco { get; set; }
    }
}
