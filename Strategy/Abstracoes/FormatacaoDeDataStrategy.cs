using System;
using System.Collections.Generic;
using System.Text;

namespace Arquitetura_De_Software_Patterns_2020_Vinicius_Araujo.Strategy.Interfaces {
    public abstract class FormatacaoDeDataStrategy {
        public abstract string Formatar(DateTime data);

    }
}
