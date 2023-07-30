using System;

namespace ByteBank.Models.Exceptions
{
    public class SaldoInsuficienteException : Exception
    {
        public double Saldo { get; }
        public double ValorDoSaque { get; }


        public SaldoInsuficienteException() { }

        public SaldoInsuficienteException(string message) : base(message) { }

        public SaldoInsuficienteException(string message, Exception innerException) : base(message, innerException) { }

        public SaldoInsuficienteException(double saldo, double valorDoSaque)
        {
            Saldo = saldo;
            ValorDoSaque = valorDoSaque;
        }
    }
}
