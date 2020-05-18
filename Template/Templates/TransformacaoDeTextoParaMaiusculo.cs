using Arquitetura_De_Software_Patterns_2020_Vinicius_Araujo.Template.Abstracoes;
using System;

namespace Arquitetura_De_Software_Patterns_2020_Vinicius_Araujo.Template.Templates {
    public class TransformacaoDeTextoParaMaiusculo : TranformacaoDeTextoTemplate {
        public TransformacaoDeTextoParaMaiusculo(string texto) : base(texto) {
        }

        protected override void FormatarTexto() {
            Texto = Texto.ToUpper();
            Console.WriteLine(Texto);
        }
    }
}
