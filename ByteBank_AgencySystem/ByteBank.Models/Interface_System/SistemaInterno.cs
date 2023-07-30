using System;

namespace ByteBank.Models.Interface_System
{
    public class SistemaInterno
    {
        public bool Logar(IAutenticador _funcionario, string _senha)
        {
            bool usuarioAutenticado = _funcionario.Autenticar(_senha);
            if(usuarioAutenticado)
            {
                Console.WriteLine(_funcionario + " Bem-Vindo ao sistema interno do Banco ByteBank");
                return true;
            }
            else 
            {
                Console.WriteLine(_funcionario + " a senha digitada esta incorreta. Tente novamente, ou altere de senha atual.");
                return false; 
            }
        }
    }
}
