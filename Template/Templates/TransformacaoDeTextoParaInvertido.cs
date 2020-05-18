using Arquitetura_De_Software_Patterns_2020_Vinicius_Araujo.Template.Abstracoes;
using System;
using System.Linq;

namespace Arquitetura_De_Software_Patterns_2020_Vinicius_Araujo.Template.Templates {
    public class TransformacaoDeTextoParaInvertido : TranformacaoDeTextoTemplate {
        public TransformacaoDeTextoParaInvertido(string texto) : base(texto) {
        }

        protected override void FormatarTexto() {
            Texto = new string(Texto.Reverse().ToArray());
            Console.WriteLine(Texto);
        }
    }
}
