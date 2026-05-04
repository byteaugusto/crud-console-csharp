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
            ArquivoRepository.Carregar(list, caminho);

            while (i != 6)
            {
                Console.WriteLine("===== MENU =====\r\n1 - Cadastrar nome\r\n2 - Remover nome\r\n3 - Listar nomes\r\n4 - Editar nome\r\n6 - Sair\r\n================\r\nEscolha uma opção:");
                if (!int.TryParse(Console.ReadLine(), out i))
                {
                    Console.WriteLine("Digite um número válido!");
                    continue;
                }
                switch (i)
                {
                    case 1:
                        Nomes nomes = new Nomes();
                        Console.WriteLine("=== CADASTRAR NOME ===\r\nDigite um nome: ");
                        nomes.Nome = Console.ReadLine();
                        list.Add(nomes);
                        ArquivoRepository.Salvar(list, caminho);
                        NomeIndice(list);
                        Console.WriteLine("Nome cadastrado com sucesso!");
                        Console.WriteLine("Pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                        case 2:
                        int remove = 0;
                        int numeroremocao = 0;
                        if (list.Count == 0)
                        {
                            Console.WriteLine("não há nada na lista");
                            Console.WriteLine("Pressione qualquer tecla para continuar...");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("=== REMOVER NOME ===");
                            NomeIndice(list);
                            Console.Write("Digite o índice do nome que deseja remover: ");
                                if (!int.TryParse(Console.ReadLine(), out remove))
                                {
                                    Console.WriteLine("Entrada inválida!");
                                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                                }
                                if (remove >= 0 && remove < list.Count)
                                {
                                Console.WriteLine("tem certeza que quer remover este nome? 1- sim 2- não");
                                int.TryParse(Console.ReadLine(), out numeroremocao);
                                if (numeroremocao == 1)
                                {
                                    list.RemoveAt(remove);
                                    ArquivoRepository.Salvar(list, caminho);
                                    Console.WriteLine("Nome removido!");
                                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                                    Console.ReadKey();
                                    Console.Clear();
                                }
                                else
                                {
                                    Console.WriteLine("tente novamente");
                                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                                    Console.ReadKey();
                                    Console.Clear();
                                }
                            }
                            else
                            {
                                Console.WriteLine("insira um número dentro do intervalo de indices");
                                Console.WriteLine("Pressione qualquer tecla para continuar...");
                                Console.ReadKey();
                                Console.Clear();
                            }
                        }
                        break;
                    case 3:
                        if (list.Count == 0)
                        {
                            Console.WriteLine("=== LISTAR NOMES ===");
                            Console.WriteLine("não há nada na lista");
                            Console.WriteLine("Pressione qualquer tecla para continuar...");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("=== LISTAR NOMES ===");
                            NomeIndice(list);
                            Console.WriteLine("Pressione qualquer tecla para continuar...");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;
                    case 4:
                        int edit = 0;
                        int numeroedit = 0;
                        string novonome;
                        if (list.Count == 0)
                        {
                            Console.WriteLine("não há nada na lista");
                            Console.WriteLine("Pressione qualquer tecla para continuar...");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                        else
                        {
                            NomeIndice(list);
                            Console.WriteLine("=== EDITAR NOME ===");
                            Console.Write("Digite o índice do nome que deseja editar: ");
                            if (!int.TryParse(Console.ReadLine(), out edit))
                            {                                
                                    Console.WriteLine("Entrada inválida!");
                                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;                                
                            }
                            if (edit >= 0 && edit < list.Count)
                                {
                                Console.WriteLine("tem certeza que quer editar este nome? 1- sim 2- não");
                                if (!int.TryParse(Console.ReadLine(), out numeroedit))
                                {
                                    Console.WriteLine("Entrada inválida!");
                                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                                }
                                if (numeroedit == 1)
                                {
                                    Console.WriteLine("digite o novo nome");
                                    novonome = Console.ReadLine();
                                    list[edit].Nome = novonome;
                                    ArquivoRepository.Salvar(list, caminho);
                                    Console.WriteLine("Nome atualizado!");
                                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                                    Console.ReadKey();
                                    Console.Clear();

                                }
                                else
                                {
                                    Console.WriteLine("tente novamente");
                                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                                    Console.ReadKey();
                                    Console.Clear();
                                }
                            }
                            else
                            {
                                Console.WriteLine("insira um número dentro do intervalo de indices");
                                Console.WriteLine("Pressione qualquer tecla para continuar...");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            break;
                        }
                    default:
                        Console.WriteLine("opção invalida");
                        Console.WriteLine("Pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
             }
        }static void NomeIndice(List<Nomes> list)
        {
            for (int indice = 0; indice < list.Count; indice++)
            {
                Console.WriteLine(indice + " - " + list[indice].Nome);
            }
        }
    }
}