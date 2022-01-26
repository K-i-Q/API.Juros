using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class TaxaJuros : Entity
    {
        #region Propriedades
        private decimal Taxa { get; set; }
        #endregion Propriedades

        #region Construtores
        public TaxaJuros(){}

        public TaxaJuros(decimal taxa)
        {
            Taxa = taxa;
        }
        #endregion Construtores

        #region Privados
        public void AlterarTaxa(decimal taxa)
        {
            Taxa = taxa;
        }
        #endregion Privados

        #region Públicos
        public override bool Equals(object obj)
        {
            return obj is TaxaJuros juros &&
                   Taxa == juros.Taxa;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Taxa);
        }
        #endregion Públicos

    }
}
