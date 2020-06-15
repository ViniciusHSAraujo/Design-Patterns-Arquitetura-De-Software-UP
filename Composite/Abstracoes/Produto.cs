using System;

namespace Arquitetura_De_Software_Patterns_2020_Vinicius_Araujo.Composite.Abstracoes
{
    public abstract class Produto
    {

        public string NomePacote { get; private set; }
        protected Produto(string nome) {
            NomePacote = nome;
        }

        public abstract string Operar();

        public virtual void Adicionar(Produto produto)
        {
            throw new NotImplementedException();
        }

        public virtual void Remover(Produto produto)
        {
            throw new NotImplementedException();
        }

        public virtual bool IsComposicao()
        {
            return true;
        }
    }
}
