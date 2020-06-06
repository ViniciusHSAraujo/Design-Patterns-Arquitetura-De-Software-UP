using Arquitetura_De_Software_Patterns_2020_Vinicius_Araujo.Factory.Factory_Nome_Sobrenome.Entities.Enums;
using Arquitetura_De_Software_Patterns_2020_Vinicius_Araujo.Factory.Factory_Nome_Sobrenome.Entities.Interfaces;
using Arquitetura_De_Software_Patterns_2020_Vinicius_Araujo.Factory.Factory_Nome_Sobrenome.Factories;
using System.Collections.Generic;

namespace Arquitetura_De_Software_Patterns_2020_Vinicius_Araujo.Factory.Factory_Nome_Sobrenome.Entities
{
    public class Nome
    {
        private readonly Dictionary<Formatos, NomeCompletoFactory> _factories;

        public Nome()
        {
            _factories = new Dictionary<Formatos, NomeCompletoFactory>{
                { Formatos.NomeSobrenome, new NomeSobrenomeFactory() },
                { Formatos.SobrenomeNome, new SobrenomeNomeFactory() }
            };
        }

        public INomeCompleto ExecutarCriacao(Formatos formato, string nome)
        {
            return _factories[formato].Criar(nome);
        }
    }
}
