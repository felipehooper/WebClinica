using FluentValidation;

namespace WebClinica.Domain._2._1___AtendimentoModule.Aggregates.AtendimentoAggregate.Entities.Validations
{
    public class ProcedimentoValidation : AbstractValidator<Procedimento>
    {
        public ProcedimentoValidation()
        {
            RuleFor(c => c.Valor)
                .NotEqual(0).WithMessage("O campo {PropertyName} precisa ser maior do que zero");
            RuleFor(c => c.Ativo)
                .Equal(true).WithMessage("O campo {PropertyName} precisa estar ativo");
        }
    }
}
