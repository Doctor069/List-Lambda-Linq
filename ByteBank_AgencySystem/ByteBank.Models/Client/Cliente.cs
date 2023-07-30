namespace ByteBank.Models.Client
{
    public class Cliente
    {
        private string _cpf;
        public string Profissao { get; set; }
        public string Nome { get; set; }

        public string CPF
        {
            get
            {
                return _cpf;
            }
            set
            {
                _cpf = value;
            }
        }

        public override bool Equals(object obj)
        {
            Cliente clienteComparavel = obj as Cliente;

            if (clienteComparavel == null)
            {
                return false;
            }

            return CPF == clienteComparavel.CPF 
                && Nome == clienteComparavel.Nome 
                && Profissao == clienteComparavel.Profissao;
        }
    }
}
