using System;
using Arquitetura_De_Software_Patterns_2020_Vinicius_Araujo.Facade.Services.Interfaces;

namespace Arquitetura_De_Software_Patterns_2020_Vinicius_Araujo.Facade.Services {
    public class PassagemService : IPassagemService {
        public void ReservarPassagem(DateTime dataSaida, DateTime dataRetorno) {
            Console.WriteLine($"Reservando passagem.\nData de saída: {dataSaida.ToShortDateString()}\nData de retorno: {dataRetorno.ToShortDateString()}");
        }

        public void ReservarBagagem() {
            Console.WriteLine("Reservando bagagens.");
        }
    }
}
