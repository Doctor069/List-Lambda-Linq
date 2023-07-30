namespace ByteBank.Models.Funcionarios
{
    public abstract class Funcionario
    {
        public static int ContadorDeFuncionarios { get; private set; }

        public string Nome { get; }
        public string CPF { get; }
        public double Salario { get; protected set; }

        public Funcionario(string _cpf, double _salario)
        {
            Salario= _salario;
            CPF = _cpf;

            ContadorDeFuncionarios++;
        }


        public abstract double GetBonificacao();
        public abstract void AumentarSalario();
    }
}
