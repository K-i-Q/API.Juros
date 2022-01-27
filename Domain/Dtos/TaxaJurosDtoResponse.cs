using System;

namespace Domain.Dtos
{
    [Serializable]
    public class TaxaJurosDtoResponse
    {
        public decimal TaxaJuros { get; set; }
        public string Mensagem { get; set; }
    }

}
