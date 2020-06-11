using Bogus;
using System;
using System.Collections.Generic;
using System.Text;
using WebClinica.Domain._2._1___AtendimentoModule.Aggregates.AtendimentoAggregate.Entities;
using Xunit;

namespace WebClinica.Domain.Tests._2._1___ProcessoModule.Fixtures
{
    [CollectionDefinition(nameof(ProcessoCollection))]
    public class ProcessoCollection : ICollectionFixture<ProcessoTestsFixture>
    {

    }

    public class ProcessoTestsFixture
    {
        public IEnumerable<Procedimento> GerarProcedimentos(int quantidade)
        {
            var atendimentos = new Faker<Procedimento>("pt_BR")
                .CustomInstantiator(c => new Procedimento(Guid.NewGuid().ToString(), 10.0, quantidade));
            return atendimentos.Generate(quantidade);
        }
    }
}
