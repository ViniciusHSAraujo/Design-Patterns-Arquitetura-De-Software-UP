namespace Arquitetura_De_Software_Patterns_2020_Vinicius_Araujo.Template.Abstracoes {
    public abstract class TranformacaoDeTextoTemplate {

        public string Texto { get; protected set; }

        protected TranformacaoDeTextoTemplate(string texto) {
            Texto = texto;
        }

        public void ImprimirTextoFormatado() {
            FormatarTexto();
        }

        protected abstract void FormatarTexto();

    }
}
