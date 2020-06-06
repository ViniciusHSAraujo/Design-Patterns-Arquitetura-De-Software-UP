using Arquitetura_De_Software_Patterns_2020_Vinicius_Araujo.Factory.Factory_Nome_Sobrenome.Entities;
using Arquitetura_De_Software_Patterns_2020_Vinicius_Araujo.Factory.Factory_Nome_Sobrenome.Entities.Interfaces;

namespace Arquitetura_De_Software_Patterns_2020_Vinicius_Araujo.Factory.Factory_Nome_Sobrenome.Factories
{
    public class SobrenomeNomeFactory : NomeCompletoFactory
    {
        public override INomeCompleto Criar(string nome)
        {
            return new SobrenomeNome(nome);
        }
    }
}
