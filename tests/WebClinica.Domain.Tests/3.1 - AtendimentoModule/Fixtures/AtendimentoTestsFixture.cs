using Bogus;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        public IEnumerable<Atendimento> GerarAtendimentosValidos(int quantidadeAtendimentos, int quantidadeProcedimentos)
        {
            var atendimentosFAKE = new Faker<Atendimento>("pt_BR")
                .CustomInstantiator(c => new Atendimento(Guid.NewGuid().ToString(), GerarProcedimentosValidos(quantidadeProcedimentos, 1).ToList()));
            return atendimentosFAKE.Generate(quantidadeAtendimentos);
        }

        public IEnumerable<Procedimento> GerarProcedimentosValidos(int quantidadeProcedimentosAtendimento, int quantidadeProcedimentosIguais)
        {
                var procedimentosFAKE = new Faker<Procedimento>("pt_BR")
                    .CustomInstantiator(c => new Procedimento(Guid.NewGuid().ToString(), 10.0, quantidadeProcedimentosIguais));
                return procedimentosFAKE.Generate(quantidadeProcedimentosAtendimento);
        }
    }
}
