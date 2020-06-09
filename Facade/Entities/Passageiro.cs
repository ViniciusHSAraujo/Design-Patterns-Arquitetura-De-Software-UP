using System;
using System.Collections.Generic;

namespace Arquitetura_De_Software_Patterns_2020_Vinicius_Araujo.Facade.Entities {
    public class Passageiro {
        public string Nome { get; set; }

        public string CPF { get; set; }

        public string Telefone { get; set; }

        public DateTime Nascimento { get; set; }

        public IList<DocumentacaoAdicional> DocumentacoesAdicionais { get; set; }
        public IList<Passageiro> Acompanhantes { get; set; }
    }
}
