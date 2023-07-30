using ByteBank.Models.Exceptions;
using ByteBank.Models.FunctionalityForCurrentAccount;
using System;

namespace ByteBank.Models
{
    /// <summary>
    /// Classe para definição/criação de uma <see cref="CurrentAccount"/> do Banco ByteBank
    /// </summary>
    public class CurrentAccount : FuncionalidadesEDeclaracoesDaContaCorrente, IComparable
    {
        public int NumeroDaAgencia { get; }
        public int NumeroDaConta { get; }

        public override double Saldo
        {
            get
            {
                return _saldo;
            }
            set
            {
                if (value < 0)
                {
                    return;
                }

                _saldo = value;
            }
        }

        /// <summary>
        /// Cria uma instancia para as definições da <see cref="CurrentAccount"/> com os argumentos utilizados
        /// Ps. Os argumentos se valem apenas a numeros, alem de ser obrigario serem maior que 0.
        /// </summary>
        /// <param name="numeroDaAgencia">Representa o valor da propriedade <see cref="NumeroDaAgencia"/> </param>
        /// <param name="numeroDaConta">Representa o valor da propriedade <see cref="NumeroDaConta"/> </param>
        public CurrentAccount(int numeroDaAgencia, int numeroDaConta)
        {
            if (numeroDaConta <= 0 && numeroDaAgencia <= 0)
            {
                throw new ArgumentException("ArgumentoException: Numero da Angencia e Numero da conta deve ser maiores que 0.", nameof(numeroDaConta) + " + " + nameof(numeroDaAgencia));
            }
            if (numeroDaConta <= 0)
            {
                throw new ArgumentException("ArgumentoException: Numero da Conta deve ser maior que 0", nameof(numeroDaConta));
            }
            if (numeroDaAgencia <= 0)
            {
                throw new ArgumentException("ArgumentoException: Numero da Agencia deve ser maior que 0", nameof(numeroDaAgencia));
            }


            this.NumeroDaAgencia = numeroDaAgencia;
            this.NumeroDaConta = numeroDaConta;

            TotalDeContasCriadas++;
            CobrancaDaTaxaDeTransferencia = 30 / TotalDeContasCriadas;
        }

        /// <summary>
        /// Função usada para a <see cref="Sacar"/> o <see cref="Saldo"/> existente na <see cref="CurrentAccount"/> 
        /// </summary>
        /// <param name="valor">Valor definido para o <see cref="Sacar"/>. Não podendo ser negativo</param>
        /// <exception cref="ArgumentException">Lançada quando ha o uso do <paramref name="valor"/> menor que zero</exception>
        public override void Sacar(double valor)
        {
            if (valor < 0)
            {
                throw new ArgumentException("O valor de Sacar nao pode ser menor que zero.", nameof(valor));
            }

            if (_saldo < valor)
            {
                ContadorDeSaquesInvalidos_SemSaldo++;
                throw new SaldoInsuficienteException(_saldo, valor);
            }

            _saldo -= valor;
        }

        /// <summary>
        /// Função <see cref="Depositar"/> usada para armazenar mais <see cref="Saldo"/>
        /// </summary>
        /// <param name="valor">Valor definido para o <see cref="Depositar"/>. Não podendo ser negativo</param>
        public override void Depositar(double valor)
        {
            _saldo += valor;
        }

        /// <summary>
        /// Função usada para a transferencia de dinherio - <see cref="Saldo"/> - de uma <see cref="CurrentAccount"/> para outra
        /// </summary>
        /// <param name="valor">Valor definido para o <see cref="Transferir"/>. Não podendo ser negativo</param>
        /// <param name="contaDestino">Referente para uma <see cref="CurrentAccount"/> diferente da que esta sendo usada para <see cref="Transferir"/></param>
        public override void Transferir(double valor, CurrentAccount contaDestino)
        {
            if (valor < 0)
            {
                throw new ArgumentException("Transferencia invalida. Valor não permitido para menores que zero. ", nameof(valor));
            }
            try
            {
                Sacar(valor);
            }
            catch (SaldoInsuficienteException ex)
            {
                ContadorDeTransferenciasInvalidos_SemSaldo++;
                throw new OperacaoFinanceiraInvalidaException("Operação de tranferencia invalida", ex);
            }
            contaDestino.Depositar(valor);
        }

        public override string ToString()
        {
            // obs que usa o $ no começo para explecitar
            // nao precisando corta mais a string
            // contenação de expressao
            return $"Número da Conta: {NumeroDaConta}, Numero da Agência: {NumeroDaAgencia}, Saldo: {Saldo}";
        }

        public override bool Equals(object obj)
        {
            CurrentAccount outraConta = obj as CurrentAccount; // caso seja (CurrentAccount)obj - lançará i,a execeção

            if (outraConta == null) return false;

            /*if (NumeroDaConta == outraConta.NumeroDaConta
                && NumeroDaAgencia == outraConta.NumeroDaAgencia) return true;
            else return false; */
            return NumeroDaConta == outraConta.NumeroDaConta
                && NumeroDaAgencia == outraConta.NumeroDaAgencia; // mesma coisa que acima
        }

        public int CompareTo(object obj)
        {
            // é necessario retorna negativo quando a instancia precede o obj
            // caso a instancia e obj forem equivalentes, retorna zero
            // caso o obj seja precedente, retorna positivo --- maior que zero

            var outraConta = obj as CurrentAccount; // uso do --- as --- caso falhe, a outraConta sera nula
                                                    // var se refere a CurrentAccount --- apenas para simplificar 

            // precedencias --- pode ser escolhida / alterada, nao havera problemas
            if(outraConta == null)
            {
                return -1; // precedencia no nulo no começo, caso de erro, ja mandara antes de exercultar varias linhas
            }
            
            if(NumeroDaConta < outraConta.NumeroDaConta)
            {
                return -1; // por exemplo, um numero tem 120 e outra 340, a 120 ficara na frente
            }
            if(NumeroDaConta == outraConta.NumeroDaConta)
            {
                return 0; // casos de equivalencia -- == --
            }

            return 1; // caso o NumeroDaConta seja maior que da outraconta
        }
    }
}
