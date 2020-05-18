using Arquitetura_De_Software_Patterns_2020_Vinicius_Araujo.Template.Abstracoes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arquitetura_De_Software_Patterns_2020_Vinicius_Araujo.Template.Templates {
    public class TransformacaoDeTextoParaMinusculo : TranformacaoDeTextoTemplate {
        public TransformacaoDeTextoParaMinusculo(string texto) : base(texto) {
        }

        protected override void FormatarTexto() {
            Texto = Texto.ToLower();
            Console.WriteLine(Texto);
        }
    }
}
