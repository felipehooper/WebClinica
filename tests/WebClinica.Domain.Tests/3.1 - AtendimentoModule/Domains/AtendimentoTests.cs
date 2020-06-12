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
        private readonly List<Atendimento> _atendimentos;
        private readonly List<Procedimento> _procedimentos;
        private readonly AtendimentoTestsFixture _atendimentoFixtures;

        public AtendimentoTests(AtendimentoTestsFixture atendimentoFixtures)
        {
            _atendimentoFixtures = atendimentoFixtures;
            _atendimentos = _atendimentoFixtures.GerarAtendimentosValidos(1, 1).ToList();
            _procedimentos = _atendimentoFixtures.GerarProcedimentosValidos(1, 1).ToList();
        }

        [Fact(DisplayName = "Criar Novo Atendimento Com Um Procedimento")]
        [Trait("Atendimento", "Atendimento Testes")]
        public void CriarAtendimento_NovoAtendimento_DeveConterAoMenosUmProcedimento()
        {
            //Arrange && Act
            var atendimento = _atendimentos.FirstOrDefault();
            //Assert
            Assert.NotNull(atendimento.Procedimentos);
            Assert.Equal(1, atendimento.Procedimentos.Count);
            Assert.True(atendimento.EhValido());
        }

        [Fact(DisplayName = "Adicionar Novo Procedimento Deve Atualizar Valor Total")]
        [Trait("Atendimento", "Atendimento Testes")]
        public void Atendimento_NovoProcedimento_DeveAtualizarValorTotal()
        {
            //Arrange
            var atendimento = _atendimentos.FirstOrDefault();
            var procedimento = _procedimentos.FirstOrDefault();
            //Act
            atendimento.AdicionarProcedimento(procedimento);
            //Assert
            Assert.NotEqual(0, atendimento.ValorTotal);
            Assert.True(atendimento.ValorTotal > 0);
            Assert.True(atendimento.EhValido());
        }

        [Fact(DisplayName = "Criar Novo Atendimento Com Data Atual")]
        [Trait("Atendimento", "Atendimento Testes")]
        public void Atendimento_NovoAtendimento_DataDoAtendimentoDeveSerDataAtual()
        {
            //Arrange
            var atendimento = _atendimentos.FirstOrDefault();
            //Act
            var dataAtual = atendimento.DataAtendimento.Date;
            //Assert
            Assert.Equal(DateTime.Now.Date, dataAtual);
            Assert.True(atendimento.EhValido());
        }

        [Fact(DisplayName = "Adicionar Novo Procedimento Sem Repetição")]
        [Trait("Atendimento", "Atendimento Testes")]
        public void Atendimento_AdicionarProcedimento_NaoDevePoderAdicionarProcedimentoRepetidoComMesmoNumero()
        {
            //Arrange
            var atendimento = _atendimentos.FirstOrDefault();
            //Act
            var procedimento = _procedimentos.FirstOrDefault();
            atendimento.AdicionarProcedimento(procedimento);
            atendimento.AdicionarProcedimento(procedimento);
            //Assert
            Assert.Equal(1, atendimento.Procedimentos.Count(s => s.NumeroProcedimento == procedimento.NumeroProcedimento));
            Assert.Equal(2, atendimento.Procedimentos.Count());
            Assert.True(atendimento.EhValido());
        }

        [Fact(DisplayName = "Adicionar Procedimentos Diferentes no Mesmo Atendimento")]
        [Trait("Atendimento", "Atendimento Testes")]
        public void Atendimento_AdicionarProcedimento_DevePoderAdicionarProcedimentosComNumerosDiferentes()
        {
            //Arrange
            var atendimento = _atendimentos.FirstOrDefault();
            var procedimentos = _procedimentos;
            //Act
            procedimentos.ForEach(p=> atendimento.AdicionarProcedimento(p));
            //Assert
            Assert.True(atendimento.Procedimentos.Count() > 1);
            Assert.Equal(2, atendimento.Procedimentos.Count());
            Assert.True(atendimento.EhValido());
        }

        [Fact(DisplayName = "Adicionar Novo Procedimento O Atendimento  Deve Estar Ativo")]
        [Trait("Atendimento", "Atendimento Testes")]
        public void Atendimento_AdicionarProcedimentos_AtendimentoDeveEstarAtivo()
        {
            //Arrange
            var atendimento = _atendimentos.FirstOrDefault();
            var procedimentos = _procedimentos;
            //Act
            procedimentos.ForEach(p => atendimento.AdicionarProcedimento(p));
            //Assert
            Assert.True(atendimento.Ativo);
            Assert.True(atendimento.EhValido());
        }

        [Fact(DisplayName = "Adicionar Novo Procedimento O Mesmo Deve Estar Ativo")]
        [Trait("Atendimento", "Atendimento Testes")]
        public void Atendimento_AdicionarProcedimentos_ProcedimentosDevemEstarAtivosAoSeremAdicionados()
        {
            //Arrange
            var atendimento = _atendimentos.FirstOrDefault();
            var procedimentos = _procedimentos;
            //Act
            procedimentos.ForEach(p => atendimento.AdicionarProcedimento(p));
            //Assert
            Assert.Equal(2, atendimento.Procedimentos.Count(s => s.Ativo));
            Assert.True(atendimento.EhValido());
        }

        [Fact(DisplayName = "Criar Novo Atendimento Deve Ter Status Ativo Ao Adicionar Procedimentos")]
        [Trait("Atendimento", "Atendimento Testes")]
        public void Atendimento_AdicionarProcedimento_AtendimentoDeveEstarAtivoAoTentarAdicionarProcedimentos()
        {
            //Arrange
            var atendimento =_atendimentos.FirstOrDefault();
            //Act
            _procedimentos.ForEach(p => atendimento.AdicionarProcedimento(p));
            //Assert
            Assert.True(atendimento.Ativo);
            Assert.Equal(2, atendimento.Procedimentos.Count());

        }

        [Fact(DisplayName = "Adicionar Novo Procedimento O Mesmo Deve Possuir Valor Maior Do Que Zero")]
        [Trait("Atendimento", "Atendimento Testes")]
        public void Atendimento_AdicionarProcedimento_ProcedimentoDevePossuirValorMaiorDoQueZeroAoSerAdicionado()
        {
            //Arrange
            var atendimento = _atendimentos.FirstOrDefault();
            var procedimento = _procedimentos.FirstOrDefault();
            //Act
            atendimento.AdicionarProcedimento(procedimento);
            //Assert
            Assert.Equal(0, atendimento.Procedimentos.Count(s=>s.Valor == 0));
        }
    }
}
