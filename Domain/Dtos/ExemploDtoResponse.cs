using System;

namespace Domain.Dtos
{
    [Serializable]
    public class ExemploDtoResponse
    {
        public decimal Saldo { get; set; }
        public string Mensagem { get; set; }
    }

}
