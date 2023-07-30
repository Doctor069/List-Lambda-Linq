using System.Collections.Generic;

namespace ByteBank.Extensoes
{
    // criando um metetado do tipo generico
    // no caso se refere a um metado que pode receber entre string, bool, int
    // vamos setar esse valor quado formos declarar no main
    // --- esse T receber a uma convensao --- mas pode ser qualquer nome
    // onde estiver esse T, vai ser um local de variavel, que sera dado na hora da criação

    //PS --- nao podemos usar o --- this --- na criação da classe - no caso na AdicionarVarios como estava
    //public static void AdicionarVarios(List<T> lista, params T[] itens)

    //Caso for usar o this pode colocar o generico na classe
    //public static void AdicionarVarios<T>(this List<T> lista, params T[] itens)
    //                                   |
    //                               aqui esta

    public static class ListExtensoes
    {
        //metado de extensao nao permite usar generico na classe --- this --- na classe ListExtensoes<T> --- dara erro
        //isso obriga sempre escrever o nome da classe caso a classe seja generica, nao o metado criado
        //se quiser - apenas vai precisar definir o tipo de variavel seja usada quando criar algo
        //isso acontece por conta que os dois T de AdicionarVarios<T> e List<T> - sao os mesmos --- ja é reconhecido pelo var
        // se caso List<string> --- voce deve declarar se vai usar outro tipo como int
        // ps, tem que colocar o using das extensoes agora --- using ByteBank_PT_8.Extensoes;
        //da mesma forma que usa uma classe de extensao, o metado de extensao tem que colocar o using

        // o this serve como metado de exteção --- disso nao precisa ser um ListExtensoes
        // no caso nos criamos uma extensao do tipo idade

        //por conta do this ja deixa explicito o metado que nos estamos usando
        //preencher apenas a partir do segundo argumento --- params T[] itens
        public static void AdicionarVarios<T>(this List<T> lista, params T[] itens)
        {
            foreach (T item in itens)   // atalho para foreach --- foreach CodeSmith
            {
                lista.Add(item);
            }
        }
    }
}
