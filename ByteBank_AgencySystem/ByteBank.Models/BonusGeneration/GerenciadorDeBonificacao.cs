using ByteBank.Models.Funcionarios;

namespace ByteBank.Models.BonusGeneration
{
    public class GerenciadorDeBonificacao
    {
        private double _calculadoraDasBonificacaoDadaAosFuncionarios;

        public void RegistrarFuncionario(Funcionario funcionario)
        {
            _calculadoraDasBonificacaoDadaAosFuncionarios += funcionario.GetBonificacao();
        }

        public double GetTotalDeBonificacaoDada()
        {
            return _calculadoraDasBonificacaoDadaAosFuncionarios;
        }
    }
}
