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
        public Procedimento GerarProcedimento(int quantidadeProcedimentosAtendimento, int quantidadeProcedimentosIguais,double valor)
        {
            var procedimentosFAKE = new Faker<Procedimento>("pt_BR")
                .CustomInstantiator(c => new Procedimento(Guid.NewGuid().ToString(), valor, quantidadeProcedimentosIguais));
            return procedimentosFAKE;
        }

        public Procedimento GerarProcedimentosValorMaiorQueZero(int quantidadeProcedimentosAtendimento, int quantidadeProcedimentosIguais)
        {
            return GerarProcedimento(1,1, 10.0);
        }
    }
}
