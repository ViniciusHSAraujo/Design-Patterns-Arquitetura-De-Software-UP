using Arquitetura_De_Software_Patterns_2020_Vinicius_Araujo.Composite.Abstracoes;

namespace Arquitetura_De_Software_Patterns_2020_Vinicius_Araujo.Composite.Composicoes
{
    public class PacoteSimples : Produto
    {
        public PacoteSimples(string nome) : base(nome)
        {
        }

        public override string Operar()
        {
            return $"{NomePacote}";
        }

        public override bool IsComposicao()
        {
            return false;
        }
    }
}
