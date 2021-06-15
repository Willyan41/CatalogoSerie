using System;
using DIO.Series.Entidades;

namespace DIO.Series
{
    class Program
    {

        static SerieRepositorio repositorio = new SerieRepositorio();

        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X"){
                switch (opcaoUsuario)
                {
                    case "1" :
                    ListaSeries();
                    break;

                    case "2" :
                    InserirSerie();
                    break;

                    case "3" :
                    AtualizarSerie();
                    break;

                    case "4" :
                    ExcluirSerie();
                    break;

                    case "5" :
                    VisualizarSerie();
                    break;

                    case "C" :
                    Console.Clear();
                    break;

                    case "X" :
                    break;

                    default :
                    throw new ArgumentOutOfRangeException();
                }

            opcaoUsuario = ObterOpcaoUsuario();

            }

            

        }


        private static void ListaSeries(){
            System.Console.WriteLine("Listar séries");

            var lista = repositorio.Lista();

            if (lista.Count == 0){
                System.Console.WriteLine("Nenhuma série cadastrada.");
                return;
                
            }

            foreach (var serie in lista){
                System.Console.WriteLine("#ID {0}: - {1} - {2}", serie.retornaId(), serie.retornaTitulo(), serie.retornaExcluido() ? "Excluido" : "Ativo");
            }

        }

         private static void ExcluirSerie(){
            System.Console.Write("Digite o ID da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceSerie);

         }

          private static void VisualizarSerie(){
            System.Console.Write("Digite o ID da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

           var serie = repositorio.RetornaPorId(indiceSerie);

           System.Console.WriteLine(serie);

         }


        private static void AtualizarSerie(){
            System.Console.Write("Digite o ID da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero))){
                System.Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            System.Console.Write("Digite o genêro entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            System.Console.Write("Digite o Título da série: ");
            string entradaTitulo = Console.ReadLine();

            System.Console.Write("Digite o ano da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            System.Console.Write("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();


                Serie atualizaSerie = new Serie(id: indiceSerie,
                                                genero: (Genero)entradaGenero,
                                                titulo: entradaTitulo,
                                                ano : entradaAno,
                                                descricao : entradaDescricao
                                            );

            repositorio.Atualiza(indiceSerie, atualizaSerie);


        }


        private static void InserirSerie()
        {
        
            foreach (int i in Enum.GetValues(typeof(Genero))){
                System.Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }

            System.Console.Write("Digite o genêro entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            System.Console.Write("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();

            System.Console.Write("Digite o ano de início da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            System.Console.Write("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();


                Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                                genero: (Genero)entradaGenero,
                                                titulo: entradaTitulo,
                                                ano : entradaAno,
                                                descricao : entradaDescricao
                                            );

            repositorio.Insere(novaSerie);


        }


        private static string ObterOpcaoUsuario(){
            System.Console.WriteLine();
            System.Console.WriteLine("Bem Vindo ao catalogo de séries");
            System.Console.WriteLine("Por favor escolha a opção desejada:");

            System.Console.WriteLine("1 - Mostrar séries");
            System.Console.WriteLine("2 - Inserir nova série");
            System.Console.WriteLine("3 - Atualizar série");
            System.Console.WriteLine("4 - Excluir série");
            System.Console.WriteLine("5 - Visualizar série");
            System.Console.WriteLine("C - Limpar tela");
            System.Console.WriteLine("X - Sair");

            System.Console.WriteLine( );
            string opcaoUsuario = Console.ReadLine().ToUpper();
            System.Console.WriteLine();
            return opcaoUsuario;

        }



    }
}
