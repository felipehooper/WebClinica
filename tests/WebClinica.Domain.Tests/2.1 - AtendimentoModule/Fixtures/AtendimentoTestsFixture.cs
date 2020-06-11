using Bogus;
using System;
using System.Collections;
using System.Collections.Generic;
using WebClinica.Domain._2._1___AtendimentoModule.Aggregates.AtendimentoAggregate.Entities;
using Xunit;

namespace WebClinica.Domain.Tests._2._1___AtendimentoModule.Fixtures
{
    [CollectionDefinition(nameof(AtendimentoCollection))]
    public class AtendimentoCollection : ICollectionFixture<AtendimentoTestsFixture>
    {

    }

    public class AtendimentoTestsFixture
    {
        public IEnumerable<Atendimento> GerarAtendimentos(int quantidade)
        {
            var atendimentos = new Faker<Atendimento>("pt_BR")
                .CustomInstantiator(c => new Atendimento(Guid.NewGuid().ToString()));
            return atendimentos.Generate(quantidade);
        }

        public IEnumerable<Procedimento> GerarProcedimentos(int quantidade)
        {
            var atendimentos = new Faker<Procedimento>("pt_BR")
                .CustomInstantiator(c => new Procedimento(Guid.NewGuid().ToString(), 10.0, quantidade));
            return atendimentos.Generate(quantidade);
        }
    }
}
