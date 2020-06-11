using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebClinica.Domain._2._1___AtendimentoModule.Aggregates.AtendimentoAggregate.Entities.Validations
{
    public class AtendimentoValidation : AbstractValidator<Atendimento>
    {
        public AtendimentoValidation()
        {
            RuleFor(c => c.Procedimentos.Count).NotEqual(0).WithMessage("O Atendimento Deve Conter ao menos Um Procedimento");
            RuleFor(c => c.ValorTotal).NotEqual(0).WithMessage("O campo {PropertyName} deve ser maior do que Zero");
            RuleFor(c => c.DataAtendimento).Equal(DateTime.Now.Date).WithMessage("O campo {PropertyName} deve ser igual à Data Atual");
            RuleFor(c => c.Ativo).Equal(true).WithMessage("O Atendimento deve estar Ativo");
        }
    }
}
