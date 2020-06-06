using Arquitetura_De_Software_Patterns_2020_Vinicius_Araujo.Factory.Factory_Provedor_De_Informacoes.Entities.Interfaces;
using System;
using System.IO;

namespace Arquitetura_De_Software_Patterns_2020_Vinicius_Araujo.Factory.Factory_Provedor_De_Informacoes.Entities
{
    public class ProvedorDeInformacoesPublicas : IProvedorDeInformacoes
    {
        private static string _filePath = Path.Combine(Path.GetPathRoot("C:/"), @"ArquiteturaDeSoftware\UP\2020\SegundoBimestre\1827575\");
        public void LerArquivo()
        {
            string informacoes = File.ReadAllText(Path.Combine(_filePath, "publico.txt"));
            Console.WriteLine(informacoes);
        }
    }
}
