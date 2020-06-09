using System.Collections.Generic;
using Arquitetura_De_Software_Patterns_2020_Vinicius_Araujo.Facade.Entities;

namespace Arquitetura_De_Software_Patterns_2020_Vinicius_Araujo.Facade.Services.Interfaces {
    public interface IPassageiroService {
        void ValidaCPF(string cpf);
        void ValidaDocumentacoesMenorNaoAcompanhado(IList<DocumentacaoAdicional> documentacoesAdicionais);
        void ValidaAcompanhantes(IList<Passageiro> acompanhantes);
    }
}
