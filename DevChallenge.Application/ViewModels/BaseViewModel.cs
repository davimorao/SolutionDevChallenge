using System;
using System.Collections.Generic;
using System.Text;

namespace DevChallenge.Application.ViewModels
{
    public class BaseViewModel
    {
        #region Properties

        public int Id { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataExclusao { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public int? IdUsuarioCadastro { get; set; }
        public int? IdUsuarioAlteracao { get; set; }
        public bool Status { get; set; }

        #endregion
    }
}
