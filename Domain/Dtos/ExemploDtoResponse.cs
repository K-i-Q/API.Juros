using System;

namespace Domain.Dtos
{
    [Serializable]
    public class ExemploDtoResponse
    {
        public decimal saldo { get; set; }
        public string mensagem { get; set; }
    }

}
