using System;

namespace Arquitetura_De_Software_Patterns_2020_Vinicius_Araujo.Facade.Services.Interfaces {
    public interface IPassagemService {
        void ReservarBagagem();
        void ReservarPassagem(DateTime dataSaida, DateTime dataRetorno);
    }
}
