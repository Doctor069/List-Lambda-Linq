using System;
using System.IO;

namespace ByteBank.Models.FileRead
{
    public class LeitorDeArquivos
    {
        public class LeitorDeArquivo
        {
            public string Arquivo { get; }

            public LeitorDeArquivo(string arquivo)
            {
                Arquivo = arquivo;

                Console.WriteLine("Abrindo arquivo: " + arquivo);
                throw new FileNotFoundException();
            }

            public string LerProximaLinha()
            {
                Console.WriteLine("Lendo linha...");
                return "Linha do arquivo";

                throw new IOException();
            }

            public void Fechar()
            {
                Console.WriteLine("Fechando arquivo.");
            }
        }
    }
}
