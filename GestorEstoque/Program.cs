using System.Reflection.Metadata;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Authentication;
using System.Text.Json;

namespace GestorEstoque
{
    internal class Program
    {

        static List<IEstoque> produtos = new List<IEstoque>();
        enum Menu { Listar = 1, Adicionar, Remover, Entrada, Saida, Sair }
        static void Main(string[] args)
        {
            bool escolheuSair = false;
            while (escolheuSair == false)
            {
                Console.WriteLine("Sistema de Estoque");
                Console.WriteLine("1-Listar\n2-Adicionar\n3-Remover\n4-Registrar Entrada\n5-Registar Saída\n6-Sair ");
                string opStr = Console.ReadLine();
                int opInt = int.Parse(opStr);
                Menu escolha = (Menu)opInt;

                if (opInt > 0 && opInt < 7)
                {

                    switch (escolha)
                    {
                        case Menu.Listar:
                            Listagem();
                            break;
                        case Menu.Adicionar:
                            Cadastro();
                            break;
                        case Menu.Remover:
                            Remover();
                            break;
                        case Menu.Entrada:
                            AdicionarEntrada();
                            break;
                        case Menu.Saida:
                            AdicionarSaida();
                            break;
                        case Menu.Sair:
                            escolheuSair = true;
                            break;
                    }

                }
                else
                {
                    escolheuSair = true;
                }
                Console.Clear();

            }




        }
        static void Listagem()
        {
            Console.WriteLine("lista de produtos");
            int i = 0;
            foreach(IEstoque produto in produtos)
            {
                Console.WriteLine("ID: " + i);
                produto.exibir();
                i++;
            }
            Console.ReadLine();

        }
        static void Remover()
        {
            Listagem();
            Console.WriteLine("Digite o ID que você quer remover");
            int id = int.Parse(Console.ReadLine());
            if (id >= 0 && id < produtos.Count) 
            {
                produtos.RemoveAt(id);
                Salvar();
            }
        }

        static void Cadastro()
        {
            Console.WriteLine("Cadastro de produtos");
            Console.WriteLine("1-Produto Físico\n2-Ebook\n3-Curso");
            string opStr = Console.ReadLine();
            int escolhaInt = int.Parse(opStr);
            switch (escolhaInt)
            {
                case 1:
                    CadastrarPFisico();
                    break;
                case 2:
                    CadastrarEbook();
                    break;
                case 3:
                    CadastrarCurso();
                    break;

            }

        }

        static void CadastrarPFisico()
        {
            Console.WriteLine("Cadastrando Produto Físico");
            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("preço: ");
            float preco = float.Parse(Console.ReadLine());
            Console.WriteLine("frete: ");
            float frete = float.Parse(Console.ReadLine());
            ProdutoFisico pf = new ProdutoFisico(nome, preco, frete);
            produtos.Add(pf);
            Salvar();
        }
        static void CadastrarEbook()
        {
            Console.WriteLine("Cadastrando Ebook");
            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("preço: ");
            float preco = float.Parse(Console.ReadLine());
            Console.WriteLine("Autor: ");
            string autor = Console.ReadLine();

            Ebook eb = new Ebook(nome, preco, autor);
            produtos.Add(eb);
            Salvar();

        }
        static void AdicionarEntrada()
        {
            Listagem();
            Console.WriteLine("Digite o ID que você quer dar entrada: ");
            int id = int.Parse(Console.ReadLine());
            if (id >= 0 && id < produtos.Count)
            {
                produtos[id].AdicionarEntrada();
                Salvar();
            }
        }
        static void AdicionarSaida()
        {
            Listagem();
            Console.WriteLine("Digite o ID que você quer dar baixa: ");
            int id = int.Parse(Console.ReadLine());
            if (id >= 0 && id < produtos.Count)
            {
                produtos[id].AdicionarSaida();
                Salvar();
            }
        }

            static void CadastrarCurso()
        {
            Console.WriteLine("Cadastrando curso");
            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("preço: ");
            float preco = float.Parse(Console.ReadLine());
            Console.WriteLine("Autor: ");
            string autor = Console.ReadLine();

            Curso cs = new Curso(nome, preco, autor);
            produtos.Add(cs);
            Salvar();

        }
        static void Salvar()

        {

            try

            {

                string json = JsonSerializer.Serialize(produtos);

                File.WriteAllText("produtos.json", json);

                Console.WriteLine("Dados salvos com sucesso!");

            }

            catch (Exception ex)

            {

                Console.WriteLine($"Erro ao salvar os dados: {ex.Message}");

            }

        }

        static void Carregar()

            {

                try

                {

                    if (File.Exists("produtos.json"))

                    {

                        string json = File.ReadAllText("produtos.json");
                        produtos = JsonSerializer.Deserialize<List<IEstoque>>(json);

                    }

                }

                catch (Exception ex)

                {

                        Console.WriteLine($"Erro ao carregar os dados: {ex.Message}");

                }

            }

        }

    }

