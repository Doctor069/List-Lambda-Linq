using System;

namespace ByteBank
{
    public class ExtratorParaValoresArgumentosURL
    {
        private readonly string _argumentos;
        public string URL { get; } 
        
        public ExtratorParaValoresArgumentosURL(string url) 
        {   
            if (string.IsNullOrEmpty(url))
            {
                    throw new ArgumentException("O argumento da url não pode ser NULO ou Vazio.", nameof(url));
            }
            int indeceInterrogação = url.IndexOf('?'); 
            _argumentos = url.Substring(indeceInterrogação + 1);
            URL = url;
        }

        public string GetValor(string nomeDoParametro)
        {
            nomeDoParametro = nomeDoParametro.ToUpper();
            string argumentosEmCaixaAlta = _argumentos.ToUpper();

            string termo = nomeDoParametro + "=";
            int indeceTermo = argumentosEmCaixaAlta.IndexOf(termo);

            string resultado = _argumentos.Substring(indeceTermo + termo.Length);

            int indeceEComercial = resultado.IndexOf('&');

            if (indeceEComercial == -1)
            {
                return resultado;
            }

            return resultado.Remove(indeceEComercial);
        }
    }
}
