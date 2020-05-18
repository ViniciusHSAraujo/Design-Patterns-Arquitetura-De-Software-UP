using Arquitetura_De_Software_Patterns_2020_Vinicius_Araujo.Template.Abstracoes;
using System;

namespace Arquitetura_De_Software_Patterns_2020_Vinicius_Araujo.Template.Templates {
    public class TransformacaoDeTextoParaDuplicado : TranformacaoDeTextoTemplate {
        public TransformacaoDeTextoParaDuplicado(string texto) : base(texto) {
        }

        protected override void FormatarTexto() {
            Texto = $"{Texto}{Texto}";
            Console.WriteLine(Texto);
        }
    }
}
