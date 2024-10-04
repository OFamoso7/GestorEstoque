using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEstoque
{
    [System.Serializable]
    internal class Ebook : Produto, IEstoque
    {
        public string autor;
        private int vendas;

        public Ebook(string nome, float preco, string autor)
        {
            this.nome = nome;
            this.preco = preco;
            this.autor = autor;
            
        }

        public void AdicionarEntrada()
        {
            Console.WriteLine("Não é possível dar entrada no estoque de um ebook: ");
            Console.ReadLine();
        }

        public void AdicionarSaida()
        {
            Console.WriteLine($"Adicionar venda no E-book {nome}");
            Console.WriteLine("Digite a quantidade de vendas que você quer dar entrada: ");
            int entrada = int.Parse(Console.ReadLine());
            //estoque = estoque + entrada;
            vendas += entrada;
            Console.WriteLine("Saidaregistrada !");
            Console.ReadLine();
        }

        public void exibir()
        {
            Console.WriteLine("EBOOK");
            Console.WriteLine($"Nome: {nome}");
            Console.WriteLine($"autor: {autor}");
            Console.WriteLine($"Preço: {preco}");
            Console.WriteLine($"vendas: {vendas}");
            Console.WriteLine("===============================");
        }
    }
}
