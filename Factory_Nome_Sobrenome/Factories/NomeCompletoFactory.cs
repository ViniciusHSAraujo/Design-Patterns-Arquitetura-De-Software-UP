using Arquitetura_De_Software_Patterns_2020_Vinicius_Araujo.Factory.Factory_Nome_Sobrenome.Entities.Interfaces;

namespace Arquitetura_De_Software_Patterns_2020_Vinicius_Araujo.Factory.Factory_Nome_Sobrenome.Factories
{
    public abstract class NomeCompletoFactory
    {
        public abstract INomeCompleto Criar(string nome);
    }
}
