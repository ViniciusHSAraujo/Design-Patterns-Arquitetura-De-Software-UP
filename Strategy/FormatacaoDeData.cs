using Arquitetura_De_Software_Patterns_2020_Vinicius_Araujo.Strategy.Interfaces;
using System;
using System.Globalization;

namespace Arquitetura_De_Software_Patterns_2020_Vinicius_Araujo.Strategy {
    public class FormatacaoDeData {

        private DateTime Data;

        private FormatacaoDeDataStrategy _formatacaoDeDataStrategy;

        public void EscolherEstrategiaDeFormatacao(FormatacaoDeDataStrategy formatacaoDeDataStrategy) {
            _formatacaoDeDataStrategy = formatacaoDeDataStrategy;
        }

        public void SelecionarData(string data) {
            DateTime.TryParseExact(data, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out Data);
        }

        public void FormatarData() {
            var dataFormatada = _formatacaoDeDataStrategy.Formatar(Data);
            Console.WriteLine($"Data formatada: {dataFormatada}");
        }
    }
}
