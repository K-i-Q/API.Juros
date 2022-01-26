using System;

namespace Domain.Dtos
{
    [Serializable]
    public class TaxaJurosDtoResponse
    {
        public decimal Saldo { get; set; }
        public string Mensagem { get; set; }
    }

}
