namespace ByteBank.Models.Funcionarios
{
    public class Design : Funcionario
    {
        public Design(string _cpf, double _salario) : base(_cpf, _salario)  { }

        public override double GetBonificacao()
        {
            return Salario *= 0.05;
        }

        public override void AumentarSalario()
        {
            this.Salario *= 0.10;
        }
    }
}
