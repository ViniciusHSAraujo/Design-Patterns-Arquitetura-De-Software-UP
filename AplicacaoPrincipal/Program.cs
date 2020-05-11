using System;
using static System.Console;
using Arquitetura_De_Software_Patterns_2020_Vinicius_Araujo.Singleton;
using Arquitetura_De_Software_Patterns_2020_Vinicius_Araujo.Strategy;
using Arquitetura_De_Software_Patterns_2020_Vinicius_Araujo.Strategy.Estrategias;

namespace Arquitetura_De_Software_Patterns_2020_Vinicius_Araujo.AplicacaoPrincipal {
    class Program {
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
                WriteLine("0 - Sair");

                int opcao = RecuperaInteiro("");

                switch (opcao) {
                    case 1:
                        BuscarPróximoNumeroDeTicket();
                        ExibirMensagemDeRetornoAoMenu();
                        break;
                    case 2:
                        FormatarData();
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

        #region Singleton
        private static void BuscarPróximoNumeroDeTicket() {
            var ticket = TicketNumber.GetInstance().GetNextTicket();
            WriteLine($"Número do ticket: {ticket}");
        }

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
