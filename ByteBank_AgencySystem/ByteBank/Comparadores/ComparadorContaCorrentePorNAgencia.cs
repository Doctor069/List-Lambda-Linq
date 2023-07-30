using ByteBank.Models;
using System.Collections.Generic;

namespace ByteBank.Comparadores
{
    public class ComparadorContaCorrentePorNAgencia : IComparer<CurrentAccount>
    {
        public int Compare(CurrentAccount x, CurrentAccount y) // nao compara as instancia - como o IComparable
        {                                                     // compara dois itens/objetos nesse caso o IComparer
            if (x == y)
            {
                return 0; // mesma referencia de apontação --- duas referencias ao mesmo objeto, ha equivalencia
            }

            if (x == null)
            {
                return 1; // Null fica no final
            }

            if (y == null)
            {
                return -1; // Null fica na frente
            }

            return x.NumeroDaAgencia.CompareTo(y.NumeroDaAgencia);

            /*if (x.NumeroDaAgencia < y.NumeroDaAgencia)
            {
                return -1; - X na frente de Y
            }

            if (x.NumeroDaAgencia == y.NumeroDaAgencia)
            {
                return 0;
            } */
        }
    }
}
