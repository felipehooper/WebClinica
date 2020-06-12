using System;
using System.Collections.Generic;
using System.Text;
using WebClinica.Application._2._1___AtendimentoModule.Commands;
using Xunit;

namespace WebClinica.Application.Tests._2._1___AtendimentoModule.Commands
{
    public class AdicionarProcedimentoAtendimentoCommandTests
    {
        [Fact(DisplayName ="Adicionar Novo Procedimento O Mesmo Deve Estar Ativo")]
        [Trait("AdicionarProcedimentoCommand", "Adicionar Procedimento Tests")]
        public void AdicionarProcedimentoCommand_NovoProcedimento_ProcedimentoDeveEstarAtivo()
        {
            //Arrange && Act
            var procedimentoCommand = new AdicionarProcedimentoAtendimentoCommand(10.0);

            //Assert
            Assert.True(procedimentoCommand.EhValido());
        }

        [Fact(DisplayName = "Adicionar Novo Procedimento Deve Possuir Valor Maior Do Que Zero")]
        [Trait("AdicionarProcedimentoCommand", "Adicionar Procedimento Tests")]
        public void AdicionarProcedimentoAtendimentoCommand_NovoProcedimento_ProcedimentoDeveTerValorMaiorQueZero()
        {
            //Arrange && Act
            var procedimentoCommand = new AdicionarProcedimentoAtendimentoCommand(10);

            //Assert
            Assert.True(procedimentoCommand.EhValido());
        }
    }
}
