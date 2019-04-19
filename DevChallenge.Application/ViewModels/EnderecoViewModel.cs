using System;
using System.Collections.Generic;
using System.Text;

namespace DevChallenge.Application.ViewModels
{
    public class EnderecoViewModel : BaseViewModel
    {
        public string Rotulo { get; set; }
        public int? Cep { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        public int IdCliente { get; set; }
        //public virtual ClienteViewModel Cliente { get; set; }
    }
}
