using Arquitetura_De_Software_Patterns_2020_Vinicius_Araujo.Strategy.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arquitetura_De_Software_Patterns_2020_Vinicius_Araujo.Strategy.Estrategias {
    public class FormatacaoDeDataBrasileiro : FormatacaoDeDataStrategy {
        public override string Formatar(DateTime data) {
            return data.ToString("dd/MM/yyy");
        }
    }
}
