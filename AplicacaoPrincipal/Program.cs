using System;
using static System.Console;
using Arquitetura_De_Software_Patterns_2020_Vinicius_Araujo.Singleton;
using Arquitetura_De_Software_Patterns_2020_Vinicius_Araujo.Strategy;
using Arquitetura_De_Software_Patterns_2020_Vinicius_Araujo.Strategy.Estrategias;
using Arquitetura_De_Software_Patterns_2020_Vinicius_Araujo.Template.Implementacoes;
using Arquitetura_De_Software_Patterns_2020_Vinicius_Araujo.Template.Templates;
using Arquitetura_De_Software_Patterns_2020_Vinicius_Araujo.Factory.Factory_Nome_Sobrenome.Entities;
using Arquitetura_De_Software_Patterns_2020_Vinicius_Araujo.Factory.Factory_Nome_Sobrenome.Entities.Enums;
using Arquitetura_De_Software_Patterns_2020_Vinicius_Araujo.Factory.Factory_Nome_Sobrenome.Entities.Interfaces;
using System.Collections.Generic;

namespace Arquitetura_De_Software_Patterns_2020_Vinicius_Araujo.AplicacaoPrincipal {
    class Program {

        private static List<INomeCompleto> _nomes = new List<INomeCompleto>();

        #region Menu
        static void Main(string[] args) {
            ExecutarMenu();
        }
       
        private static void ExecutarMenu() {
            bool continuar = true;
            do {
                Clear();
                Title = "Menu da aplicação";
                WriteLine("Escolha uma das opções abaixo para executar o Design Pattern correspondente:");
                WriteLine("1 - Singleton (Buscar próximo número de ticket)");
                WriteLine("2 - Strategy (Formatar data)");
                WriteLine("3 - Template (Formatar textos)");
                WriteLine("4 - Factory 01 - Formatacao de Nomes");
                WriteLine("5 - Factory 01 - Listagem de Nomes");
                WriteLine("0 - Sair");

                int opcao = RecuperaInteiro("");

                switch (opcao) {
                    case 1:
                        Clear();
                        BuscarPróximoNumeroDeTicket();
                        ExibirMensagemDeRetornoAoMenu();
                        break;
                    case 2:
                        Clear();
                        FormatarData();
                        ExibirMensagemDeRetornoAoMenu();
                        break;
                    case 3:
                        Clear();
                        FormatarTextos();
                        ExibirMensagemDeRetornoAoMenu();
                        break;
                    case 4:
                        Clear();
                        EscreverNomes();
                        ExibirMensagemDeRetornoAoMenu();
                        break;
                    case 5:
                        Clear();
                        ListarNomes();
                        ExibirMensagemDeRetornoAoMenu();
                        break;
                    case 0:
                        continuar = false;
                        break;
                    default:
                        WriteLine("Opção inválida!");
                        break;
                }

            } while (continuar);
        }

        #endregion

        #region Singleton
        private static void BuscarPróximoNumeroDeTicket() {
            var ticket = TicketNumber.GetInstance().GetNextTicket();
            WriteLine($"Número do ticket: {ticket}");
        }

        #endregion

        #region Strategy

        private static void FormatarData() {
            var formatacaoDeData = new FormatacaoDeData();

            var data = RecuperaStringNaoVazia("Qual é a data que você deseja formatar ? Utilize o padrão \"dd/mm/aaaa\"");
            formatacaoDeData.SelecionarData(data);

            WriteLine("Escolha uma das opções abaixo para executar a formatação da data:");
            WriteLine("1 - Internacional");
            WriteLine("2 - Brasileiro");
            WriteLine("3 - Europeu");
            var opcaoEscolhida = RecuperaInteiro("Digite o número correspondente ao padrão de data que você deseja aplicar:");

            switch (opcaoEscolhida) {
                case 1:
                    formatacaoDeData.EscolherEstrategiaDeFormatacao(new FormatacaoDeDataInternacional());
                    formatacaoDeData.FormatarData();
                    break;
                case 2:
                    formatacaoDeData.EscolherEstrategiaDeFormatacao(new FormatacaoDeDataBrasileiro());
                    formatacaoDeData.FormatarData();
                    break;
                case 3:
                    formatacaoDeData.EscolherEstrategiaDeFormatacao(new FormatacaoDeDataEuropeu());
                    formatacaoDeData.FormatarData();
                    break;
            }

        }
        #endregion

        #region Template
        private static void FormatarTextos() {
            var texto = RecuperaStringNaoVazia("Qual é o texto que você deseja formatar ?");
            Console.WriteLine("\n -----------------");
            Console.WriteLine("\nConvertendo para minúsculo:\n");
            TransformadorDeTexto.ConverterTexto(new TransformacaoDeTextoParaMinusculo(texto));
            Console.WriteLine("\nConvertendo para maiúsculo:\n");
            TransformadorDeTexto.ConverterTexto(new TransformacaoDeTextoParaMaiusculo(texto));
            Console.WriteLine("\nDuplicando texto:\n");
            TransformadorDeTexto.ConverterTexto(new TransformacaoDeTextoParaDuplicado(texto));
            Console.WriteLine("\nInvertendo texto:\n");
            TransformadorDeTexto.ConverterTexto(new TransformacaoDeTextoParaInvertido(texto));

        }
        #endregion

        #region Factory

        #region Factory - Nome Sobrenome

        private static void EscreverNomes()
        {
            WriteLine("Formatos de nomes aceitos:");
            WriteLine("Nome Sobrenome");
            WriteLine("Sobrenome, Nome");
            var nomeEscolhido = RecuperaStringNaoVazia("Digite o nome que você deseja guardar, de acordo com os formatos aceitos pela aplicação:");
            
            INomeCompleto nome;

            if (nomeEscolhido.Contains(","))
            {
                nome = new Nome().ExecutarCriacao(Formatos.SobrenomeNome, nomeEscolhido);
            }
            else
            {
                nome = new Nome().ExecutarCriacao(Formatos.NomeSobrenome, nomeEscolhido);
            }

            _nomes.Add(nome);

        }

        private static void ListarNomes()
        {
            foreach (var nome in _nomes)
            {
                nome.Escrever();
            }
        }

        #endregion

        #endregion

        #region Métodos de funcionamento do menu

        private static void ExibirMensagemDeRetornoAoMenu() {
            WriteLine("\n\nPressione qualquer tecla para voltar ao menu..");
            ReadKey();
        }

        /**
         * Método responsável por recuperar valores decimais no console e tratar possíveis tentativas de fornecimento de valores inconsistentes (strings, por exemplo).
         * Recebe via parâmetro a descrição que ele vai apresentar ao usuário na solicitação do valor.
         * Retorna um valor em double que o usuário informou.
         */
        private static double RecuperaDecimal(string descricao) {
            double valor;

            try {
                WriteLine(descricao);
                valor = Convert.ToDouble(ReadLine());
            } catch (Exception) {
                WriteLine("Valor inválido!");
                valor = RecuperaDecimal(descricao);
            }
            return valor;
        }

        /**
         * Método responsável por recuperar valores inteiros no console e tratar possíveis tentativas de fornecimento de valores inconsistentes (strings, por exemplo).
         * Recebe via parâmetro a descrição que ele vai apresentar ao usuário na solicitação do valor.
         * Retorna um valor em int que o usuário informou.
         */
        private static int RecuperaInteiro(string descricao) {
            int valor;

            try {
                WriteLine(descricao);
                valor = Convert.ToInt32(ReadLine());
            } catch (Exception) {
                WriteLine("Valor inválido!");
                valor = RecuperaInteiro(descricao);
            }
            return valor;
        }

        /**
         * Método responsável por recuperar valores de texto no console e tratar possíveis tentativas de fornecimento de valores inconsistentes (string em branco, nula ou espaço).
         * Recebe via parâmetro a descrição que ele vai apresentar ao usuário na solicitação do valor.
         * Retorna um valor em int que o usuário informou.
         */
        private static string RecuperaStringNaoVazia(string descricao) {
            string informacao;

            WriteLine(descricao);
            informacao = ReadLine();
            if (string.IsNullOrWhiteSpace(informacao)) {
                WriteLine("Valor inválido!");
                informacao = RecuperaStringNaoVazia(descricao);
            }
            return informacao;
        }
        #endregion
    }
}
