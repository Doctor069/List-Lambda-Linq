using System;
using System.Collections.Generic;
using System.Linq;
using ByteBank.Models;
using ByteBank.Models.BonusGeneration;
using ByteBank.Comparadores;
using ByteBank.Extensoes;

namespace ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            var contas = new List<CurrentAccount>()
            {
                new CurrentAccount(5, 66),
                null,
                new CurrentAccount(8, 95),
                new CurrentAccount(4, 54),
                new CurrentAccount(3, 13),
                new CurrentAccount(9, 44)
            };

            // pode ser apenas o var tambem
            IEnumerable<CurrentAccount> contasNaoNulas = contas.Where(conta => conta != null);


            // chamada completa do OrderBy - como exemplo, não é necessario excreve-la
            // ps, o int se refere ao tipo de propriedade do NumeroDaConta
            IOrderedEnumerable<CurrentAccount> contasOrdenda =
               contas.Where(conta => conta != null)
               .OrderBy<CurrentAccount, int>(conta => conta.NumeroDaConta);

            foreach (var conta in contasNaoNulas)
            {
                Console.WriteLine
                ($"O numero da conta é : {conta.NumeroDaConta}. O numero da agencia é {conta.NumeroDaAgencia}");
            }

            Console.WriteLine("\n Entrando em outra diretiva \n");

            List<int> list = new List<int>
            {
                1,
                2,
                40
            };
            list.Remove(40);

            foreach (int i in list)
            {
                Console.WriteLine(i);
            }

            Console.ReadLine();
            
        }
        public void usandoOWhere()
        {
            var contas = new List<CurrentAccount>()
            {
                new CurrentAccount(5, 66),
                null,
                new CurrentAccount(8, 95),
                new CurrentAccount(4, 54),
                new CurrentAccount(3, 13),
                new CurrentAccount(9, 44)
            };

            // pode ser apenas o var tambem
            // IEnumerable - devolução do where
            IEnumerable<CurrentAccount> contasNaoNulas = contas.Where(conta => conta != null); // conta != null sera true

            IOrderedEnumerable<CurrentAccount> contasOrdenda =
                contasNaoNulas.OrderBy(conta => conta.NumeroDaConta);

            foreach (var item in contasOrdenda)
            {
                Console.WriteLine
                ($"O numero da conta é : {item.NumeroDaConta}. O numero da agencia é {item.NumeroDaAgencia}");
            }
        }
        public void evitandoReferenciasNulasPTI()
        {
            var contas = new List<CurrentAccount>()
            {
                new CurrentAccount(5, 66),
                null,
                new CurrentAccount(8, 95),
                new CurrentAccount(4, 54),
                new CurrentAccount(3, 13),
                new CurrentAccount(9, 44)
            };

            var listaSemNulo = new List<CurrentAccount>(); // para evitar as referencias nulas

            foreach (var contaNaoNula in contas)
            {
                if (contaNaoNula != null)
                {
                    listaSemNulo.Add(contaNaoNula);
                }
            }

            IOrderedEnumerable<CurrentAccount> contasOrdenda =
                listaSemNulo.OrderBy(conta => conta.NumeroDaConta);

            foreach (var item in contasOrdenda)
            {
                Console.WriteLine
                ($"O numero da conta é : {item.NumeroDaConta}. O numero da agencia é {item.NumeroDaAgencia}");
            }
        } 
        public static void maisSobreExpressaoLambda() // faltar escrever
        {
            var contas = new List<CurrentAccount>()
            {
                new CurrentAccount(5, 66),
                null, // erro de tipo referencia nula
                new CurrentAccount(8, 95),
                new CurrentAccount(4, 54),
                new CurrentAccount(3, 13),
                new CurrentAccount(9897, 99)
            };

            IOrderedEnumerable<CurrentAccount> contasOrdenda =
                contas.OrderBy(conta => 
                {
                    if (conta == null) 
                    { return int.MaxValue; } // como so é um dado, podemos declarar na mesma linha
                    // no usamos o maior numero inteiro para garantir que sempre sera o primeiro
                    // o int.MaxValue trara o maior valor    ---   disso ficara na ultima linha quando execultar e ler o programa
                    // no caso as contas nulas expressa de acordo com o foreach feito, ficara abaixo
                    //caso use o valor minimo, ela ficara entre as primeiras

                    return conta.NumeroDaConta; //colocando apenas isso iria compilar, mas acima verifica se ha nulos
                }); // tipo de expressao lambda -- => --

            foreach (var item in contasOrdenda)
            {
                if (item == null) // apenas para testes 
                                  //pode criar apenas if(item != null) e o texto desejado
                { //aqui nao ta resolvendo o problema, mas acima esta com o OrderBy
                    Console.WriteLine("Conta nula encontrada");
                }
                else
                {
                    Console.WriteLine
                    ($"O numero da conta é : {item.NumeroDaConta}. O numero da agencia é {item.NumeroDaAgencia}");
                }
            }
        }
        public void usandoOrderBypt2()
        {
            var contas = new List<CurrentAccount>()
            {
                new CurrentAccount(5, 66),
                new CurrentAccount(8, 95),
                new CurrentAccount(4, 54),
                new CurrentAccount(3, 13),
                new CurrentAccount(9, 44)
            };

            IOrderedEnumerable<CurrentAccount> contasOrdenda =
                contas.OrderBy(conta => conta.NumeroDaConta); // ps, a depender da escolha é diferente

            foreach (var item in contasOrdenda)
            {
                Console.WriteLine
                    ($"O numero da conta é : {item.NumeroDaConta}. O numero da agencia é {item.NumeroDaAgencia}");
            }
        }
        public void usandoOrderBy()
        {
            // ordernando as contas criadas
            var contas = new List<CurrentAccount>()
            {
                new CurrentAccount(5, 66),
                new CurrentAccount(8, 95),
                new CurrentAccount(4, 54),
                new CurrentAccount(3, 13),
                new CurrentAccount(9, 44)
            };

            //enves da configuração feita do Sort() --- que é da agencia, aqui nos pode usar qualquer um
            IOrderedEnumerable<CurrentAccount> contasOrdenda = // é obrigatorio usar essa declaração para funcionar - não dará erro sem, mas tambem nao vai organizar de acordo com o argumento dado, no caso vai ficar como original
                contas.OrderByDescending(conta => conta.NumeroDaConta); // NumeroDaConta pode alterar a ordenação
                           //em conta - selecione a conta e veja o NumeroDaConta
            foreach (var item in contasOrdenda)
            {
                Console.WriteLine
                    ($"O numero da conta é : {item.NumeroDaConta}. O numero da agencia é {item.NumeroDaAgencia}");
            }
        }
        public void erroDeICompable()
        {
            // caso de erro sem o ICompable - caso compare duas informações em um unico objeto
            List<CurrentAccount> contas = new List<CurrentAccount>()
            {
                new CurrentAccount(454, 545),
            };

            contas.Sort(new ComparadorContaCorrentePorNAgencia());
            foreach (var item in contas)
            {
                Console.WriteLine($"O numero é : {item.NumeroDaConta}. O nome é {item.NumeroDaAgencia}");
            }
        }
        public void usandoSORT_ORGANIZAR() 
        {
            // ordenando lista --- alfabeto, numero do menor ao maior...

            List<int> contas = new List<int>() { 90544, 1, 4564, 20, 9 };
            List<string> nomes = new List<string>();
            nomes.AddRange(new string[] { "Nicolas", "Encelado", "Lobinho", "Gordo", "Vi" });

            for (int i = 0; i < contas.Count && i < nomes.Count; i++)
            {
                Console.WriteLine($"O numero é : {contas[i]}. O nome é {nomes[i]}");
            }
            
            Console.WriteLine();

            // sort --- Organizar
            // ps - para utilizar ele é necessairo que a clase possua uma instancia de ICompareble
            // usando o foreach
            contas.Sort(); // não é possivel comporar dois elementos na matriz/array
            nomes.Sort();
            foreach (var item in nomes)
            {
                Console.WriteLine(item);
            }

            foreach (var item in contas)
            {
                Console.WriteLine(item);
            }
        }
        public void Conhecendo_VAR()
        {
            //na criação de uma CurrentAccont voce primeiro declara uma variavel e dps o atreibuto
            // var conta = new CurrentAccont();

            //dar alinhamento com o uso do var com os nomes de variaveis

            // o var ja diz que esta criando uma variavel
            // o compilador ja sabe o que esta sendo atribuido

            // o tipo var "variavel" - serve para um conceito amplo
            //pode receber quanto uma string, int, bool...
            // nao é possivel criar uma var sem ter atribuição - é necessario informar o tipo (nao é possivel criar variaveis do tipo implicito)
            var carro = 1;
            var marca = "ferrari";

            // serve tambem para as classes
            // pode ser util caso o nome seja muito grande
            var contaI = new CurrentAccount(344, 4545);
            // var = CurrentAccount

            //nome ultrapassa o limite da tela - o var encutor
            var gerenciadores = new List<GerenciadorDeBonificacao>();
            // var = List<GerenciadorDeBonificacao>()

        }
        public void PARTEI_REMOVE()
        {
            // ps --- conflitos de nomes entre o list do programar
            // e o list criado --- impossibilitou usar o Add
            List<int> idades = new List<int>
            {
                1,
                5,
                14,
                25,
                38,
                61
            };
            
            //adicionar varios pela forma do proprio programa
            idades.AddRange(new int[] { 1, 226, 56 }); // tem que criar o array primeiro (new int[]) --- nos criamos uma extensao dela para nao fazer isso (ListExtensoes)
            //varios de nosso modo criado
            idades.AdicionarVarios(54, 454, 45);

            idades.Remove(0);

            for (int i = 0; i < idades.Count; i++) // enves de Tamanho --- Count
            {
                Console.WriteLine(idades[i]);
            }

            ListExtensoes.AdicionarVarios(idades, 544, 545, 454, 545); // nova forma --- video I
            idades.AdicionarVarios(565, 646, 464); // melhorada por conta do this --- a partir de uma referencia da lista
        }

    }
}
