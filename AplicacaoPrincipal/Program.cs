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
using System.IO;
using Arquitetura_De_Software_Patterns_2020_Vinicius_Araujo.Factory.Factory_Provedor_De_Informacoes.Entities.Interfaces;
using Factory_Provedor_De_Informacoes.Entities;
using Arquitetura_De_Software_Patterns_2020_Vinicius_Araujo.Factory.Factory_Provedor_De_Informacoes.Entities.Enums;
using Arquitetura_De_Software_Patterns_2020_Vinicius_Araujo.Facade.Entities;
using Arquitetura_De_Software_Patterns_2020_Vinicius_Araujo.Facade;

namespace Arquitetura_De_Software_Patterns_2020_Vinicius_Araujo.AplicacaoPrincipal
{
    class Program
    {

        private static List<INomeCompleto> _nomes = new List<INomeCompleto>();
        private static string _filePath = Path.Combine(Path.GetPathRoot("C:/"), @"ArquiteturaDeSoftware\UP\2020\SegundoBimestre\1827575\");

        #region Menu
        static void Main(string[] args)
        {
            ExecutarMenu();
        }

        private static void ExecutarMenu()
        {
            bool continuar = true;
            do
            {
                Clear();
                Title = "Menu da aplicação";
                WriteLine("Escolha uma das opções abaixo para executar o Design Pattern correspondente:");
                WriteLine("1 - Singleton (Buscar próximo número de ticket)");
                WriteLine("2 - Strategy (Formatar data)");
                WriteLine("3 - Template (Formatar textos)");
                WriteLine("4 - Factory 01 - Formatacao de Nomes");
                WriteLine("5 - Factory 01 - Listagem de Nomes");
                WriteLine("6 - Factory 02 - Leitura de Arquivos");
                WriteLine("7 - Facade - Compra de Passagem");
                WriteLine("0 - Sair");

                int opcao = RecuperaInteiro("");

                switch (opcao)
                {
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
                    case 6:
                        Clear();
                        ProverInformacoes();
                        ExibirMensagemDeRetornoAoMenu();
                        break;
                    case 7:
                        ComprarPassagem();
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
        private static void BuscarPróximoNumeroDeTicket()
        {
            var ticket = TicketNumber.GetInstance().GetNextTicket();
            WriteLine($"Número do ticket: {ticket}");
        }

        #endregion

        #region Strategy

        private static void FormatarData()
        {
            var formatacaoDeData = new FormatacaoDeData();

            var data = RecuperaStringNaoVazia("Qual é a data que você deseja formatar ? Utilize o padrão \"dd/mm/aaaa\"");
            formatacaoDeData.SelecionarData(data);

            WriteLine("Escolha uma das opções abaixo para executar a formatação da data:");
            WriteLine("1 - Internacional");
            WriteLine("2 - Brasileiro");
            WriteLine("3 - Europeu");
            var opcaoEscolhida = RecuperaInteiro("Digite o número correspondente ao padrão de data que você deseja aplicar:");

            switch (opcaoEscolhida)
            {
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
        private static void FormatarTextos()
        {
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

        #region Factory - Provedor de Informações

        private static void ProverInformacoes()
        {
            if (VerificarArquivos())
            {

                IProvedorDeInformacoes provedor;

                var senha = RecuperaStringNaoVazia("Digite sua senha de acesso: (Para as informações públicas, digite qualquer coisa)");

                if (senha.Equals("designpatterns"))
                {
                    provedor = new ProvedorDeInformacoes().CriarProvedor(Provedores.Confidencial);
                }
                else
                {
                    provedor = new ProvedorDeInformacoes().CriarProvedor(Provedores.Publico);
                }

                provedor.LerArquivo();
            }
        }

        #region Verificação e gravação dos arquivos necessários
        
        private static bool VerificarArquivos()
        {
            try
            {
                VerificarEGravarPastaNoDiscoLocalC(_filePath);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
        
        private static void VerificarEGravarPastaNoDiscoLocalC(string FilePath)
        {
            if (!Directory.Exists(FilePath))
            {
                Console.WriteLine("Ops.. Não encontrei a pasta com os arquivos necessários para a execução da aplicação em sua máquina. Começando a gravação dos mesmos.");
                try
                {
                    Directory.CreateDirectory(FilePath);

                    Console.WriteLine("Pasta criada com sucesso em seu disco local.");

                    using (StreamWriter outputFile = new StreamWriter(Path.Combine(FilePath, "confidencial.txt")))
                    {
                        outputFile.WriteLine("Estas são informações confidenciais,o que significa que você provavelmente sabe a palavra secreta!");
                    }

                    Console.WriteLine("Primeiro arquivo criado com sucesso em sua máquina.");

                    using (StreamWriter outputFile = new StreamWriter(Path.Combine(FilePath, "publico.txt")))
                    {
                        outputFile.WriteLine("Estas são informações públicas sobre qualquer coisa. Todo mundo pode ver este arquivo.");
                    }
                    Console.WriteLine("Segundo arquivo criado com sucesso em sua máquina.");

                    Console.WriteLine("Agora sim! Tudo pronto para a execução da aplicação.");

                    Console.WriteLine("Pressione qualquer tecla para contiuar..");

                    ReadKey();
                    Clear();

                }
                catch (Exception)
                {
                    throw new Exception($"Não foi possível gravar os arquivos TXT em sua máquina!! Infelizmente a aplicação não funcionará! \nTente criar os arquivos no diretório: \"{FilePath}\" e executar a aplicação novamente.");
                }
            }
            else
            {
                VerificarEGravarConfidencialTXT(FilePath);
                VerificarEGravarPublicoTXT(FilePath);
            }
        }

        private static void VerificarEGravarConfidencialTXT(string FilePath)
        {
            if (!File.Exists(Path.Combine(FilePath, "confidencial.txt")))
            {
                Console.WriteLine("Ops.. Não encontrei um dos arquivos necessários para a execução da aplicação em sua máquina! Começando a gravação do mesmo.");
                try
                {
                    using (StreamWriter outputFile = new StreamWriter(Path.Combine(FilePath, "confidencial.txt")))
                    {
                        outputFile.WriteLine("Estas são informações confidenciais,o que significa que você provavelmente sabe a palavra secreta!");
                    }
                    Console.WriteLine("Arquivo criado com sucesso em sua máquina.");
                    Console.WriteLine("Pressione qualquer tecla para contiuar..");

                    ReadKey();
                    Clear();
                }
                catch (Exception)
                {
                    throw new Exception($"Não foi possível gravar o arquivo \"confidencia.txt\" \nTente criar o arquivo manualmente no diretório: \"{FilePath}\" e executar a aplicação novamente.");
                }
            }
        }

        private static void VerificarEGravarPublicoTXT(string FilePath)
        {
            if (!File.Exists(Path.Combine(FilePath, "publico.txt")))
            {
                Console.WriteLine("Ops.. Não encontrei um dos arquivos necessários para a execução da aplicação em sua máquina! Começando a gravação do mesmo.");
                try
                {
                    using (StreamWriter outputFile = new StreamWriter(Path.Combine(FilePath, "publico.txt")))
                    {
                        outputFile.WriteLine("Estas são informações públicas sobre qualquer coisa. Todo mundo pode ver este arquivo.");
                    }
                    Console.WriteLine("Arquivo criado com sucesso em sua máquina.");
                    Console.WriteLine("Pressione qualquer tecla para contiuar..");

                    ReadKey();
                    Clear();
                }
                catch (Exception)
                {
                    throw new Exception($"Não foi possível gravar o arquivo \"publico.txt\" \nTente criar o arquivo manualmente no diretório: \"{FilePath}\" e executar a aplicação novamente.");
                }
            }
        }

        #endregion

        #endregion

        #endregion

        #region Facade
        private static void ComprarPassagem() {
            var passageiro = new Passageiro();
            var passagem = new Passagem();

            passageiro.Nome = RecuperaStringNaoVazia("Digite o nome do passageiro:");
            passageiro.CPF = RecuperaStringNaoVazia("Digite o CPF do passageiro:");
            passageiro.Nascimento = RecuperaDatas("Digite a data de nascimento do passageiro:");
            passageiro.DocumentacoesAdicionais = new List<DocumentacaoAdicional>();
            passageiro.Acompanhantes = new List<Passageiro>();

            passagem.DataSaida = RecuperaDatas("Digite a data de saída do voo:");
            passagem.DataRetorno = RecuperaDatas("Digite a data de retorno do voo:");
            passagem.BagagemExtra = RecuperaStringNaoVazia("Necessita de bagagens? Digite \"SIM\", senão digite \"NÃO\"").Equals("SIM", StringComparison.InvariantCultureIgnoreCase);

            var request = new CompraDePassagemRequest() { Passageiro = passageiro, Passagem = passagem };

            var facade = new CompraDePassagemFacade();

            facade.ComprarPassagem(request);

        }

        #endregion

        #region Métodos de funcionamento do menu

        private static void ExibirMensagemDeRetornoAoMenu()
        {
            WriteLine("\n\nPressione qualquer tecla para voltar ao menu..");
            ReadKey();
        }

        /**
         * Método responsável por recuperar valores decimais no console e tratar possíveis tentativas de fornecimento de valores inconsistentes (strings, por exemplo).
         * Recebe via parâmetro a descrição que ele vai apresentar ao usuário na solicitação do valor.
         * Retorna um valor em double que o usuário informou.
         */
        private static double RecuperaDecimal(string descricao)
        {
            double valor;

            try
            {
                WriteLine(descricao);
                valor = Convert.ToDouble(ReadLine());
            }
            catch (Exception)
            {
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
        private static int RecuperaInteiro(string descricao)
        {
            int valor;

            try
            {
                WriteLine(descricao);
                valor = Convert.ToInt32(ReadLine());
            }
            catch (Exception)
            {
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
        private static string RecuperaStringNaoVazia(string descricao)
        {
            string informacao;

            WriteLine(descricao);
            informacao = ReadLine();
            if (string.IsNullOrWhiteSpace(informacao))
            {
                WriteLine("Valor inválido!");
                informacao = RecuperaStringNaoVazia(descricao);
            }
            return informacao;
        }

        private static DateTime RecuperaDatas(string descricao) {
            DateTime valor;

            try {
                WriteLine(descricao);
                valor = DateTime.Parse(ReadLine());
            } catch (Exception) {
                WriteLine("Valor inválido!");
                valor = RecuperaDatas(descricao);
            }
            return valor;
        }

        #endregion
    }
}
