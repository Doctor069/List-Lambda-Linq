using System;

namespace ByteBank
{
    public class ObjectList
    {
        private object[] _itens;
        private int _proximaPosicao; // ao passe de conta na hora da criação

        public int Tamanho { get { return _proximaPosicao; } }

        public ObjectList()
        {
            _itens = new object[3];
            _proximaPosicao = 0;
        }

        public void AdicionarObject(object item)
        {
            VerificadorCapacidade(_proximaPosicao + 1); // nesse caso ( + 1 != ++ )

            Console.WriteLine($"Item sendo adicionado na psoção : {_proximaPosicao}");

            _itens[_proximaPosicao] = item;
            _proximaPosicao++;
        }


        //verificador da quantidade da lista criada se ultrapassa o limite
        private void VerificadorCapacidade(int tamanhoArray)
        {
            if (_itens.Length >= tamanhoArray)
            {
                return;
            }

            Console.WriteLine("Tamanho de arraw ultrapassado, aumentando array.");
            int novoTamanhoArray = _itens.Length * 2;
            if (novoTamanhoArray < tamanhoArray)
            {
                novoTamanhoArray = tamanhoArray;
            }

            object[] novoArray = new object[novoTamanhoArray];

            for (int indece = 0; indece < _itens.Length; indece++)
            {
                novoArray[indece] = _itens[indece];
            }

            _itens = novoArray;

        }

        public object GetIndexObject(int index)
        {
            if (index < 0 || index >= _proximaPosicao)
            {
                throw new ArgumentOutOfRangeException("The argument is out of the range - ", nameof(index));
            }

            return _itens[index];
        }

        //metado .Remove
        public void Remover(object item)
        {
            int indeceItem = -1; // tipo de valor invalido --- para dizer que nao inicializou

            for (int i = 0; i < _proximaPosicao; i++)
            {
                object itemAtual = _itens[i];
                if (itemAtual.Equals(item))
                {
                    indeceItem = i;
                    break;
                }
            }

            for (int i = indeceItem; i < _proximaPosicao; i++)
            {
                _itens[i] = _itens[i + 1];
            }

            _proximaPosicao--;
            _itens[_proximaPosicao] = null;
        }

        public void AdicionarVariasObjects(params object[] itens) // observe o --- params ---
        {
            /*for(int i = 0; i < itens.Length; i++)
            {
                Adicionar(itens[i]);
            }*/
            foreach (object item in itens) // para cada --- como o for acima - so nao se preocupa com o index
            {
                AdicionarObject(item);
            }
        }

        public object this[int index]
        {
            get // sixtax de indexador 
            {
                return GetIndexObject(index);
            }
        }
    }
}
