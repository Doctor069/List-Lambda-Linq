using ByteBank.Models.Funcionarios.Authenticator;

namespace ByteBank.Models.Funcionarios
{
    public class GerenteDeConta : FuncionarioAutenticado
    {
        public GerenteDeConta(string _cpf, double _salario) : base(_cpf, _salario) { }

        public override double GetBonificacao()
        {
            return Salario *= 0.15;
        }

        public override void AumentarSalario()
        {
            this.Salario *= 0.20;
        }
    }
}
