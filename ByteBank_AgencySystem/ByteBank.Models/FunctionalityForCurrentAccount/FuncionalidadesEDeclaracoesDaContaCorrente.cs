using ByteBank.Models.Client;

namespace ByteBank.Models.FunctionalityForCurrentAccount
{
    public abstract class FuncionalidadesEDeclaracoesDaContaCorrente
    {
        public Cliente Titular { get; set; }

        public static int TotalDeContasCriadas { get; protected set; }
        public int ContadorDeSaquesInvalidos_SemSaldo { get; protected set; }
        public int ContadorDeTransferenciasInvalidos_SemSaldo { get; protected set; }

        public static double CobrancaDaTaxaDeTransferencia { get; protected set; }
        protected double _saldo;

        public virtual double Saldo
        {
            get
            {
                return _saldo;
            }
            set
            {
            }
        }

        public virtual void Sacar(double valor) { }

        public virtual void Depositar(double valor) {  }
        
        public virtual void Transferir(double valor, CurrentAccount contaDestino) { }
    }
}
