using ByteBank.Models.Interface_System;

namespace ByteBank.Models.PartnerBesiness
{
    public class ParceiroComercial : IAutenticador
    {
        private AutenticacaoHelper _autenticacaoHelper = new AutenticacaoHelper();
        public string Senha { private get; set; }

        public bool Autenticar(string _senha)
        {
            return _autenticacaoHelper.CompararSenhas(Senha, _senha);
        }
    }
}
