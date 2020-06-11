using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebClinica.Domain._2._1___AtendimentoModule.Aggregates.AtendimentoAggregate.Entities;
using WebClinica.Domain.Tests._2._1___AtendimentoModule.Fixtures;
using Xunit;

namespace WebClinica.Domain.Tests._2._1___AtendimentoModule.Domains
{
    [Collection(nameof(AtendimentoCollection))]
    public class AtendimentoTests
    {
        private readonly AtendimentoTestsFixture _atendimentoFixtures;
        public AtendimentoTests(AtendimentoTestsFixture atendimentoFixtures)
        {
            _atendimentoFixtures = atendimentoFixtures;
        }

        [Fact(DisplayName ="Criar Novo Atendimento Com Um Atendimento")]
        [Trait("Atendimento", "Atendimento Testes")]
        public void CriarAtendimento_NovoAtendimento_DeveConterAoMenosUmAtendimento()
        {
            //Arrange
            var atendimento = _atendimentoFixtures.GerarAtendimentos(1).FirstOrDefault();
            var procedimento = _atendimentoFixtures.GerarProcedimentos(1).FirstOrDefault();
            //Act
            atendimento.AdicionarProcedimento(procedimento);
            //Assert
            Assert.NotNull(atendimento.Procedimentos);
            Assert.Equal(1, atendimento.Procedimentos.Count);
        }

        [Fact(DisplayName = "Criar Novo Procedimento")]
        [Trait("Atendimento", "Atendimento Testes")]
        public void Atendimento_AdicionarProcedimento_DeveAtualizarValorTotal()
        {
            //Arrange
            var atendimento = _atendimentoFixtures.GerarAtendimentos(1).FirstOrDefault();
            var procedimento = _atendimentoFixtures.GerarProcedimentos(1).FirstOrDefault();
            //Act
            atendimento.AdicionarProcedimento(procedimento);
            //Assert
            Assert.NotEqual(0, atendimento.ValorTotal());
            Assert.True(atendimento.ValorTotal() > 0);
        }

        [Fact(DisplayName = "Criar Novo Atendimento Com Data Atual")]
        [Trait("Atendimento", "Atendimento Testes")]
        public void Atendimento_NovoAtendimento_DataDoAtendimentoDeveSerDataAtual()
        {
            //Arrange
            var atendimento = _atendimentoFixtures.GerarAtendimentos(1).FirstOrDefault();
            //Act
            var dataAtual = atendimento.DataAtendimento.Date;
            //Assert
            Assert.Equal(DateTime.Now.Date, dataAtual);
        }

        [Fact(DisplayName = "Criar Novo Procedimento Sem Repetição")]
        [Trait("Atendimento", "Atendimento Testes")]
        public void Atendimento_NovoProcedimento_NaoDevePoderAdicionarProcedimentoRepetidoComMesmoNumero()
        {
            //Arrange
            var atendimento = _atendimentoFixtures.GerarAtendimentos(1).FirstOrDefault();
            //Act
            var procedimento = _atendimentoFixtures.GerarProcedimentos(2).FirstOrDefault();
            atendimento.AdicionarProcedimento(procedimento);
            atendimento.AdicionarProcedimento(procedimento);
            //Assert
            Assert.True(atendimento.Procedimentos.Count(s => s.NumeroProcedimento == procedimento.NumeroProcedimento) == 1);
        }

        [Fact(DisplayName = "Criar Procedimentos Diferentes no Mesmo Atendimento")]
        [Trait("Atendimento", "Atendimento Testes")]
        public void Atendimento_NovoProcedimento_DevePoderAdicionarProcedimentosComNumerosDiferentes()
        {
            //Arrange
            var atendimento = _atendimentoFixtures.GerarAtendimentos(1).FirstOrDefault();
            //Act
            var procedimento = _atendimentoFixtures.GerarProcedimentos(1).FirstOrDefault();
            atendimento.AdicionarProcedimento(procedimento);
            procedimento = _atendimentoFixtures.GerarProcedimentos(1).FirstOrDefault();
            atendimento.AdicionarProcedimento(procedimento);
            //Assert
            Assert.True(atendimento.Procedimentos.Count() > 1);
        }
    }
}
