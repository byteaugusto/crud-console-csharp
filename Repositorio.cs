using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Crud
{
    public class ArquivoRepository
    {
        public static void Salvar(List<Nome> list, string caminho)
        {
        List<string> linhas = new List<string>();
            foreach (Nome nome in list)
            {
                linhas.Add(nome.Name);
            }
        File.WriteAllLines(caminho, linhas);
    }
        public static void Carregar(List<Nome> list, string caminho)
        {
            if (File.Exists(caminho))
            {
                string[] linhas = File.ReadAllLines(caminho);
                foreach (string linha in linhas)
                {
                    list.Add(new Nome { Name = linha });
                }
            }
        }
    }
}