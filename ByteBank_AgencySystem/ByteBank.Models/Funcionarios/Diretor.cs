using ByteBank.Models.Funcionarios.Authenticator;

namespace ByteBank.Models.Funcionarios
{
    public class Diretor : FuncionarioAutenticado
    {
        public Diretor(string _cpf, double _salario) : base(_cpf, _salario)
        {
        }

        public override void AumentarSalario()
        {
            Salario *= 0.15;
        }

        public override double GetBonificacao()
        {
            return Salario *= 0.10;
        }
    }
}
