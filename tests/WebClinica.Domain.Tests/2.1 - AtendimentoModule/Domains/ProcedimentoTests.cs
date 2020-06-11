using System.Linq;
using WebClinica.Domain.Tests._2._1___AtendimentoModule.Fixtures;
using WebClinica.Domain.Tests._2._1___ProcessoModule.Fixtures;
using Xunit;

namespace WebClinica.Domain.Tests._2._1___AtendimentoModule.Domains
{
    [Collection(nameof(ProcessoCollection))]
    public class ProcedimentoTests
    {
        private readonly ProcessoTestsFixture _procedimentoFixtures;
        public ProcedimentoTests(ProcessoTestsFixture procedimentoFixtures)
        {
            _procedimentoFixtures = procedimentoFixtures;
        }

        [Fact(DisplayName = "Criar Novo Procedimento Deve Estar Ativo")]
        [Trait("Procedimento", "Procedimento Testes")]
        public void Procedimento_NovoProcedimento_ProcedimentoDeveEstarAtivo()
        {
            //Arrange && Act
            var procedimento = _procedimentoFixtures.GerarProcedimento(2, 2, 10.0);
            //Assert
            Assert.True(procedimento.Ativo);
            Assert.True(procedimento.EhValido());
        }

        [Fact(DisplayName = "Criar Novo Procedimento Deve Possuir Valor Maior Do Que Zero")]
        [Trait("Procedimento", "Procedimento Testes")]
        public void Procedimento_NovoProcedimento_ProcedimentoDevePossuirValorMaiorDoQueZero()
        {
            //Arrange && Act
            var procedimento = _procedimentoFixtures.GerarProcedimentosValorMaiorQueZero(1, 1);
            //Assert
            Assert.NotEqual(0, procedimento.Valor);
            Assert.True(procedimento.EhValido());
        }
    }
}
