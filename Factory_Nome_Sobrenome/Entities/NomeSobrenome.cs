using Arquitetura_De_Software_Patterns_2020_Vinicius_Araujo.Factory.Factory_Nome_Sobrenome.Entities.Interfaces;
using System;

namespace Arquitetura_De_Software_Patterns_2020_Vinicius_Araujo.Factory.Factory_Nome_Sobrenome.Entities
{
    public class NomeSobrenome : INomeCompleto
    {
        private readonly string _nome;

        private readonly string _sobrenome;

        public NomeSobrenome(string nome)
        {
            var nomeQuebrado = nome.Split(' ');
            _nome = nomeQuebrado[0].Trim();
            _sobrenome = nomeQuebrado[1].Trim();
        }

        public void Escrever()
        {
            Console.WriteLine($"{_nome} {_sobrenome}");
        }
    }
}
