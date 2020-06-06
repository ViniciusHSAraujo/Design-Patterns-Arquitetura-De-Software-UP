using Arquitetura_De_Software_Patterns_2020_Vinicius_Araujo.Factory.Factory_Provedor_De_Informacoes.Entities.Enums;
using Arquitetura_De_Software_Patterns_2020_Vinicius_Araujo.Factory.Factory_Provedor_De_Informacoes.Entities.Interfaces;
using Arquitetura_De_Software_Patterns_2020_Vinicius_Araujo.Factory.Factory_Provedor_De_Informacoes.Factories;
using System.Collections.Generic;

namespace Factory_Provedor_De_Informacoes.Entities
{
    public class ProvedorDeInformacoes
    {
        private readonly Dictionary<Provedores, ProvedorDeInformacoesFactory> _factories;

        public ProvedorDeInformacoes()
        {
            _factories = new Dictionary<Provedores, ProvedorDeInformacoesFactory>{
                { Provedores.Publico, new ProvedorDeInformacoesPublicasFactory() },
                { Provedores.Confidencial, new ProvedorDeInformacoesConfidenciaisFactory() }
            };
        }

        public IProvedorDeInformacoes CriarProvedor(Provedores provedor)
        {
            return _factories[provedor].ProverInformacoes();
        }
    }
}
