using System;
namespace AppSerie
{
    class Program
    {
        static SeriesRepositorio repositorio = new SeriesRepositorio();
        static FilmesRepositorio repositoriof = new FilmesRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();
            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                    ListarSeries();
                    break;
                    case "2":
                    ListarFilmes();
                    break;
                    case "3":
                    InserirSeries();
                    break;
                    case "4":
                    InserirFilmes();
                    break;
                    case "5":
                    AtualizarSeries();
                    break;
                    case "6":
                    AtualizarFilmes();
                    break;
                    case "7":
                    ExcluirSeries();
                    break;
                    case "8":
                    ExcluirFilmes();
                    break;
                    case "9":
                    VizualizarSeries();
                    break;
                    case "10":
                    VizualizarFilmes();
                    break;
                    case "C":
                    Console.Clear();
                    break;

                    default:
                    throw new ArgumentOutOfRangeException();

                }
                opcaoUsuario = ObterOpcaoUsuario();
            } 
            System.Console.WriteLine("Obrigado por utilizar nossos serviços");
            Console.ReadLine();
        }
        private static void ExcluirSeries()
        {
            System.Console.Write("Digite o id da série: ");
            int indiceSeries = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceSeries);
        }
        private static void ExcluirFilmes()
        {
            System.Console.Write("Digite o id do filme: ");
            int indiceFilmes = int.Parse(Console.ReadLine());

            repositoriof.Exclui(indiceFilmes);
        }
        private static void VizualizarSeries()
        {
            System.Console.Write("Digite o id da série: ");
            int indiceSeries = int.Parse(Console.ReadLine());

            var series = repositorio.RetornaPorId(indiceSeries);

            System.Console.WriteLine(series);
        }
        private static void VizualizarFilmes()
        {
            System.Console.Write("Digite o id do filme: ");
            int indiceFilmes = int.Parse(Console.ReadLine());

            var filmes = repositoriof.RetornaPorId(indiceFilmes);

            System.Console.WriteLine(filmes);
        }
        private static void AtualizarSeries()
        {
            System.Console.Write("Digite o id da série: ");
            int indiceSeries = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                System.Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }

            System.Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            System.Console.Write("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();

            System.Console.Write("Digite o ano de início da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            System.Console.Write("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Series atualizaSeries = new Series(id: indiceSeries, 
                                           genero: (Genero)entradaGenero,
                                           titulo: entradaTitulo,
                                           ano: entradaAno,
                                           descricao: entradaDescricao);
            
            repositorio.Atualiza(indiceSeries, atualizaSeries);
        }
        private static void AtualizarFilmes()
        {
            System.Console.Write("Digite o id do filme: ");
            int indiceFilmes = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                System.Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }

            System.Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            System.Console.Write("Digite o título do filme: ");
            string entradaTitulo = Console.ReadLine();

            System.Console.Write("Digite o ano de lançamento do filme: ");
            int entradaAno = int.Parse(Console.ReadLine());

            System.Console.Write("Digite a descrição do filme: ");
            string entradaDescricao = Console.ReadLine();
           
            System.Console.Write("Digite o elenco principal do filme: ");
            string entradaElenco = Console.ReadLine();
            
            System.Console.Write("Digite a direção do filme: ");
            string entradaDirecao = Console.ReadLine();
            Filmes atualizaFilmes = new Filmes(id: indiceFilmes, 
                                           genero: (Genero)entradaGenero,
                                           titulo: entradaTitulo,
                                           ano: entradaAno,
                                           descricao: entradaDescricao,
                                           elenco: entradaElenco,
                                           direcao: entradaDirecao);
            
            repositoriof.Atualiza(indiceFilmes, atualizaFilmes);
        }
        private static void ListarSeries()
        {
            System.Console.WriteLine("Listar séries");
            var lista = repositorio.Lista();
            
            if (lista.Count == 0)
            {
                System.Console.WriteLine("Nenhuma série cadastrada");
                return;
            }

            foreach (var series in lista)
            {
                var excluido = series.retornaExcluido();
                
                System.Console.WriteLine("#ID {0}: - {1} {2}", series.retornaId(), series.retornaTitulo(), (excluido ? "Excluido*" : ""));
            }
        }
        private static void ListarFilmes()
        {
            System.Console.WriteLine("Listar filmes");
            var lista = repositoriof.Lista();
            
            if (lista.Count == 0)
            {
                System.Console.WriteLine("Nenhum filme cadastrado");
                return;
            }

            foreach (var filmes in lista)
            {
                var excluido = filmes.retornaExcluido();
                
                System.Console.WriteLine("#ID {0}: - {1} {2}", filmes.retornaId(), filmes.retornaTitulo(), (excluido ? "Excluido*" : ""));
            }
        }
        private static void InserirSeries()
        {
            System.Console.WriteLine("Inserir nova série");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
              System.Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }

            System.Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();

            System.Console.WriteLine("Digite o ano de início da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Series novaSeries = new Series(id: repositorio.ProximoId(), 
                                           genero: (Genero)entradaGenero,
                                           titulo: entradaTitulo,
                                           ano: entradaAno,
                                           descricao: entradaDescricao);

            repositorio.Insere(novaSeries);
        }
        private static void InserirFilmes()
        {
            System.Console.WriteLine("Inserir novo filme");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
              System.Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }

            System.Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite o título do filme: ");
            string entradaTitulo = Console.ReadLine();

            System.Console.WriteLine("Digite o ano de lançamento do filme: ");
            int entradaAno = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite a descrição do filme: ");
            string entradaDescricao = Console.ReadLine();

            System.Console.Write("Digite o elenco principal do filme: ");
            string entradaElenco = Console.ReadLine();

            System.Console.Write("Digite a direção do filme: ");
            string entradaDirecao = Console.ReadLine();

            Filmes novoFilmes = new Filmes(id: repositoriof.ProximoId(), 
                                           genero: (Genero)entradaGenero,
                                           titulo: entradaTitulo,
                                           ano: entradaAno,
                                           descricao: entradaDescricao,
                                           elenco: entradaElenco,
                                           direcao: entradaDirecao);

            repositoriof.Insere(novoFilmes);
        }
        private static string ObterOpcaoUsuario()
        {
            System.Console.WriteLine();
            System.Console.WriteLine("APPSERIE um mundo de entretenimento na palma da sua mão");
            System.Console.WriteLine("Informe a opção desejada: ");

            System.Console.WriteLine("1- Listar Séries");
            System.Console.WriteLine("2- Listar Filmes");
            System.Console.WriteLine("3- Inserir nova série");
            System.Console.WriteLine("4- Inserir novo filme");
            System.Console.WriteLine("5- Atualizar série");
            System.Console.WriteLine("6- Atualizar filme");
            System.Console.WriteLine("7- Excluir série");
            System.Console.WriteLine("8- Excluir filme");
            System.Console.WriteLine("9- Vizualizar série");
            System.Console.WriteLine("10- Vizualizar filme");
            System.Console.WriteLine("C- Limpar Tela");
            System.Console.WriteLine("X- Sair");
            System.Console.WriteLine();
            
            string opcaoUsuario = Console.ReadLine().ToUpper();
            System.Console.WriteLine();
            return opcaoUsuario;
        }   
    }
}

