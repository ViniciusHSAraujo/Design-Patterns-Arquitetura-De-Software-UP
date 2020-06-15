using Arquitetura_De_Software_Patterns_2020_Vinicius_Araujo.Composite.Abstracoes;
using System.Collections.Generic;

namespace Arquitetura_De_Software_Patterns_2020_Vinicius_Araujo.Composite.Composicoes
{
    public class PacoteComposto : Produto
    {
        protected List<Produto> _subProdutos = new List<Produto>();

        public PacoteComposto(string nome) : base(nome)
        {
        }

        public override void Adicionar(Produto produto)
        {
            this._subProdutos.Add(produto);
        }

        public override void Remover(Produto produto)
        {
            this._subProdutos.Remove(produto);
        }

        public override string Operar()
        {
            int i = 0;
            string result = $"{NomePacote} ( ";

            foreach (var produto in _subProdutos)
            {
                result += produto.Operar();
                if (i != this._subProdutos.Count - 1)
                {
                    result += " + ";
                }
                i++;
            }

            return result + " ) ";
        }
    }
}
