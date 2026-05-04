using System;
using System.Collections.Generic;
using System.IO;

namespace Crud 
{
    class Program 
    {
        static void Main(string[] args)
        {
            int option = 0;
            string filepath = "nome.txt";
            List<Nome> names = new List<Nome>();
            ArquivoRepository.Carregar(names, filepath);

            while (option != 6)
            {
                Console.WriteLine("===== MENU =====\r\n1 - Cadastrar nome\r\n2 - Remover nome\r\n3 - Listar nomes\r\n4 - Editar nome\r\n6 - Sair\r\n================\r\nEscolha uma opção:");
                if (!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("Digite um número válido!");
                    continue;
                }
                switch (option)
                {
                    case 1:
                        Nome nome = new Nome();
                        Console.WriteLine("=== CADASTRAR NOME ===\r\nDigite um nome: ");
                        nome.Name = Console.ReadLine();
                        names.Add(nome);
                        ArquivoRepository.Salvar(names, filepath);
                        NomeIndice(names);
                        Console.WriteLine("Nome cadastrado com sucesso!");
                        Console.WriteLine("Pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                        case 2:
                        int remove = 0;
                        int numeroremocao = 0;
                        if (names.Count == 0)
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
                            NomeIndice(names);
                            Console.Write("Digite o índice do nome que deseja remover: ");
                                if (!int.TryParse(Console.ReadLine(), out remove))
                                {
                                    Console.WriteLine("Entrada inválida!");
                                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                                }
                                if (remove >= 0 && remove < names.Count)
                                {
                                Console.WriteLine("tem certeza que quer remover este nome? 1- sim 2- não");
                                int.TryParse(Console.ReadLine(), out numeroremocao);
                                if (numeroremocao == 1)
                                {
                                    names.RemoveAt(remove);
                                    ArquivoRepository.Salvar(names, filepath);
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
                        if (names.Count == 0)
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
                            NomeIndice(names);
                            Console.WriteLine("Pressione qualquer tecla para continuar...");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;
                    case 4:
                        int edit = 0;
                        int numeroedit = 0;
                        string novonome;
                        if (names.Count == 0)
                        {
                            Console.WriteLine("não há nada na lista");
                            Console.WriteLine("Pressione qualquer tecla para continuar...");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                        else
                        {
                            NomeIndice(names);
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
                            if (edit >= 0 && edit < names.Count)
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
                                    names[edit].Name = novonome;
                                    ArquivoRepository.Salvar(names, filepath);
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
        }static void NomeIndice(List<Nome> list)
        {
            for (int indice = 0; indice < list.Count; indice++)
            {
                Console.WriteLine(indice + " - " + list[indice].Name);
            }
        }
    }
}