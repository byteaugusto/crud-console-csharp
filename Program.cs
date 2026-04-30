using System;
using System.Collections.Generic;
using System.IO;

namespace Crud 
{
    class Program 
    {
        static void Main(string[] args)
        {
            int i = 0;
            string caminho = "nomes.txt";
            List<Nomes> list = new List<Nomes>();
            if (File.Exists(caminho))
            {
                string[] linhas = File.ReadAllLines(caminho);
                foreach (string linha in linhas)
                {
                    list.Add(new Nomes { Nome = linha });
                }
            }

            while (i != 6)
            {
                Console.WriteLine("1- cadastrar novo nome  2- remover nome da lista 3- mostrar nomes na lista 4- editar nome na lista -6- sair  ");
                Console.WriteLine("digite uma opção");
                if (!int.TryParse(Console.ReadLine(), out i))
                {
                    Console.WriteLine("Digite um número válido!");
                    continue;
                }
                switch (i)
                {
                    case 1:
                        Nomes nomes = new Nomes();
                        Console.WriteLine("Digite um nome: ");
                        nomes.Nome = Console.ReadLine();
                        list.Add(nomes);
                        Salvar(list, caminho);
                        for (int indice = 0; indice < list.Count; indice++)
                        {
                            Console.WriteLine(indice + " - " + list[indice].Nome);
                        }
                        break;
                        case 2:
                        int remove = 0;
                        int numeroremocao = 0;
                        if (list.Count == 0)
                        {
                            Console.WriteLine("não há nada na lista");
                            break;
                        }
                        else
                        {
                            for (int indice = 0; indice < list.Count; indice++)
                            {
                                Console.WriteLine(indice + " - " + list[indice].Nome);
                            }
                            Console.WriteLine("qual nome deseja remover?");
                            int.TryParse(Console.ReadLine(), out remove);
                            if (remove >= 0 && remove < list.Count)
                            {
                                Console.WriteLine("tem certeza que quer remover este nome? 1- sim 2- não");
                                int.TryParse(Console.ReadLine(), out numeroremocao);
                                if (numeroremocao == 1)
                                {
                                    list.RemoveAt(remove);
                                    Salvar(list, caminho);
                                }
                                else
                                {
                                    Console.WriteLine("tente novamente");
                                }
                            }
                            else
                            {
                                Console.WriteLine("insira um número dentro do intervalo de indices");
                            }
                        }
                        break;
                    case 3:
                        if (list.Count == 0)
                        {
                            Console.WriteLine("não há nada na lista");
                            break;
                        }
                        else
                        {
                            for (int indice = 0; indice < list.Count; indice++)
                            {
                                Console.WriteLine(indice + " - " + list[indice].Nome);
                            }
                        }
                        break;
                    case 4:
                        int edit = 0;
                        int numeroedit = 0;
                        string novonome;
                        if (list.Count == 0)
                        {
                            Console.WriteLine("não há nada na lista");
                            break;
                        }
                        else
                        {
                            for (int indice = 0; indice < list.Count; indice++)
                            {
                                Console.WriteLine(indice + " - " + list[indice].Nome);
                            }
                            Console.WriteLine("qual nome deseja editar?");
                            int.TryParse(Console.ReadLine(), out edit);
                            if (edit >= 0 && edit < list.Count)
                            {
                                Console.WriteLine("tem certeza que quer editar este nome? 1- sim 2- não");
                                int.TryParse(Console.ReadLine(), out numeroedit);
                                if (numeroedit == 1)
                                {
                                    Console.WriteLine("digite o novo nome");
                                    novonome = Console.ReadLine();
                                    list[edit].Nome = novonome;
                                    Salvar(list, caminho);
                                }
                                else
                                {
                                    Console.WriteLine("tente novamente");
                                }
                            }
                            else
                            {
                                Console.WriteLine("insira um número dentro do intervalo de indices");
                            }
                            break;
                        }
                    default:
                        Console.WriteLine("opção invalida");
                        break;
                }
             }
        }
        public class Nomes { 
        public string Nome {  get; set; }
        }
        static void Salvar(List<Nomes> list, string caminho)
        {
            List<string> nomes = new List<string>();

            foreach (var item in list)
            {
                nomes.Add(item.Nome);
            }

            File.WriteAllLines(caminho, nomes);
        }
    }
}