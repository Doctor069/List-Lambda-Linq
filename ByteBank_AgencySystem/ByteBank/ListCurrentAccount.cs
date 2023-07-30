using ByteBank.Models;
using System;

namespace ByteBank
{
    public class ListCurrentAccount
    {
        //criando nossa lista de contas --- simplificado
        private CurrentAccount[] _itens;
        private int _proximaPosicao; // ao passe de conta na hora da criação

        public int Tamanho { get { return _proximaPosicao; } }

        public ListCurrentAccount()
        {
            _itens = new CurrentAccount[3];
            _proximaPosicao = 0;
        }

        public void Adicionar(CurrentAccount item) 
        {
            VerificadorCapacidade(_proximaPosicao + 1); // nesse caso ( + 1 != ++ )

            Console.WriteLine($"Item sendo adicionado na psoção : {_proximaPosicao}");

            _itens[_proximaPosicao] = item;
            _proximaPosicao++;
        }


        //verificador da quantidade da lista criada se ultrapassa o limite
        private void VerificadorCapacidade(int tamanhoArray)
        {
            if(_itens.Length >= tamanhoArray)
            {
                return;
            }

            Console.WriteLine("Tamanho de arraw ultrapassado, aumentando array.");
            int novoTamanhoArray = _itens.Length * 2;
            if(novoTamanhoArray < tamanhoArray)
            {
                novoTamanhoArray = tamanhoArray;
            }

            CurrentAccount[] novoArray = new CurrentAccount[novoTamanhoArray];

            for(int indece = 0; indece < _itens.Length; indece++)
            {
                novoArray[indece] = _itens[indece];
            }

            _itens = novoArray;

        }

        public CurrentAccount GetIndexCurrentAccount(int index)
        {
            if(index < 0 || index >= _proximaPosicao)
            {
                throw new ArgumentOutOfRangeException("The argument is out of the range - ", nameof(index));
            }

            return _itens[index];
        }

        //metado .Remove
        public void Remover(CurrentAccount item)
        {
            int indeceItem = -1; // tipo de valor invalido --- para dizer que nao inicializou

            for (int i = 0; i < _proximaPosicao; i++)
            {
                CurrentAccount itemAtual = _itens[i];
                if (itemAtual.Equals(item))
                {
                    indeceItem = i;
                    break;
                }
            }

            for(int i = indeceItem; i < _proximaPosicao ; i++)
            {
                _itens[i] = _itens[i + 1];
            }

            _proximaPosicao--;
            _itens[_proximaPosicao] = null;
        }

        public void AdicionarVariasContas(params CurrentAccount[] itens) // observe o --- params ---
        {
            /*for(int i = 0; i < itens.Length; i++)
            {
                Adicionar(itens[i]);
            }*/
            foreach(CurrentAccount conta in itens) // para cada --- como o for acima - so nao se preocupa com o index
            {
                Adicionar(conta);
            }
        }

        public CurrentAccount this[int index]
        {
            get // sixtax de indexador 
            { 
                return GetIndexCurrentAccount(index);
            }
        }
    }
}
