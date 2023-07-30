using System;

namespace ByteBank.Models.Exceptions
{
    public class OperacaoFinanceiraInvalidaException : Exception
    {
        public OperacaoFinanceiraInvalidaException() { }

        public OperacaoFinanceiraInvalidaException(string message) : base(message) { }

        public OperacaoFinanceiraInvalidaException(string message, Exception innerException) : base(message, innerException) { }
    }
}
