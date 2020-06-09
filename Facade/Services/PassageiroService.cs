using System;
using System.Collections.Generic;
using Arquitetura_De_Software_Patterns_2020_Vinicius_Araujo.Facade.Entities;
using Arquitetura_De_Software_Patterns_2020_Vinicius_Araujo.Facade.Services.Interfaces;

namespace Arquitetura_De_Software_Patterns_2020_Vinicius_Araujo.Facade.Services {
    public class PassageiroService : IPassageiroService {
        public void ValidaAcompanhantes(IList<Passageiro> acompanhantes) {
            Console.WriteLine($"\n\nValidando acompanhantes do passageiro.");
        }

        public void ValidaCPF(string cpf) {
            Console.WriteLine($"Validando CPF do passageiro.");
        }

        public void ValidaDocumentacoesMenorNaoAcompanhado(IList<DocumentacaoAdicional> documentacoesAdicionais) {
            Console.WriteLine($"Validando documentações de menor não acompanhado.");
        }
    }
}
