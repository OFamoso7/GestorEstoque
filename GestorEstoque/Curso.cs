using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEstoque
{
    [System.Serializable]
    internal class Curso : Produto, IEstoque
    {
        public string autor;
        private int vagas;

        public Curso(string nome, float preco, string autor)
        {
            this.nome = nome;
            this.preco = preco;
            this.autor = autor;
        }

        public void AdicionarEntrada()
        {
            Console.WriteLine($"Adicionar baga no curso {nome}");
            Console.WriteLine("Digite a quantidade de vagas que você quer dar entrada: ");
            int entrada = int.Parse(Console.ReadLine());
            //estoque = estoque + entrada;
            vagas += entrada;
            Console.WriteLine("Entrada registrada !");
            Console.ReadLine();

        }

        public void AdicionarSaida()
        {
            Console.WriteLine($"Adicionar baga no curso {nome}");
            Console.WriteLine("Digite a quantidade de vagas que você quer dar saida: ");
            int entrada = int.Parse(Console.ReadLine());
            //estoque = estoque + entrada;
            vagas -= entrada;
            Console.WriteLine("Saida registrada !");
            Console.ReadLine();
        }

        public void exibir()
        {
            Console.WriteLine("CURSO");
            Console.WriteLine($"Nome: {nome}");
            Console.WriteLine($"autor: {autor}");
            Console.WriteLine($"Preço: {preco}");
            Console.WriteLine($"vagas restantes: {vagas}");
            Console.WriteLine("===============================");
            
        }
    }   
}
