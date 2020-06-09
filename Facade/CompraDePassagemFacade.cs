using Arquitetura_De_Software_Patterns_2020_Vinicius_Araujo.Facade.Entities;
using Arquitetura_De_Software_Patterns_2020_Vinicius_Araujo.Facade.Services;
using Arquitetura_De_Software_Patterns_2020_Vinicius_Araujo.Facade.Services.Interfaces;
using System;

namespace Arquitetura_De_Software_Patterns_2020_Vinicius_Araujo.Facade {
    public class CompraDePassagemFacade {

        private readonly IPassageiroService _passageiroService;
        private readonly IPassagemService _passagemService;

        public CompraDePassagemFacade() {
            _passageiroService = new PassageiroService();
            _passagemService = new PassagemService();
        }

        public void ComprarPassagem(CompraDePassagemRequest compra) {

            _passageiroService.ValidaCPF(compra.Passageiro.CPF);

            if (compra.Passageiro.Nascimento > DateTime.Now.AddYears(-16)) {
                _passageiroService.ValidaDocumentacoesMenorNaoAcompanhado(compra.Passageiro.DocumentacoesAdicionais);
            }

            if (compra.Passageiro.Nascimento > DateTime.Now.AddYears(-5)) {
                _passageiroService.ValidaAcompanhantes(compra.Passageiro.Acompanhantes);
            }

            _passagemService.ReservarPassagem(compra.Passagem.DataSaida, compra.Passagem.DataRetorno);

            if (compra.Passagem.BagagemExtra) {
                _passagemService.ReservarBagagem();
            }

            Console.WriteLine("Passagem reservada com sucesso!");

        }

    }
}
