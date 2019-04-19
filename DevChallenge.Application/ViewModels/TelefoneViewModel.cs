using System;
using System.Collections.Generic;
using System.Text;

namespace DevChallenge.Application.ViewModels
{
    public class TelefoneViewModel : BaseViewModel
    {
        public string Residencial { get; set; }
        public string Celular { get; set; }

        public int IdCliente { get; set; }
        //public virtual ClienteViewModel Cliente { get; set; }
    }
}
