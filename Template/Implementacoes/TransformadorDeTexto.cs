using Arquitetura_De_Software_Patterns_2020_Vinicius_Araujo.Template.Abstracoes;

namespace Arquitetura_De_Software_Patterns_2020_Vinicius_Araujo.Template.Implementacoes {
    public class TransformadorDeTexto {
        public static void ConverterTexto(TranformacaoDeTextoTemplate template) {
            template.ImprimirTextoFormatado();
        }

    }
}
