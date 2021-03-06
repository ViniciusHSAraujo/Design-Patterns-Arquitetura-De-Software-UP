﻿using Arquitetura_De_Software_Patterns_2020_Vinicius_Araujo.Factory.Factory_Provedor_De_Informacoes.Entities;
using Arquitetura_De_Software_Patterns_2020_Vinicius_Araujo.Factory.Factory_Provedor_De_Informacoes.Entities.Interfaces;

namespace Arquitetura_De_Software_Patterns_2020_Vinicius_Araujo.Factory.Factory_Provedor_De_Informacoes.Factories
{
    public class ProvedorDeInformacoesPublicasFactory : ProvedorDeInformacoesFactory
    {
        public override IProvedorDeInformacoes ProverInformacoes()
        {
            return new ProvedorDeInformacoesPublicas();
        }
    }
}
