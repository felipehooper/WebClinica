using FluentValidation;
using WebClinica.Application._2._1___AtendimentoModule.Commands;

namespace WebClinica.Application._2._1___AtendimentoModule.Validations
{
    public class AdicionarProcedimentoAtendimentoValidation : AbstractValidator<AdicionarProcedimentoAtendimentoCommand>
    {
        public AdicionarProcedimentoAtendimentoValidation()
        {
            //RuleFor(r => r.ProcedimentoId).NotNull().NotEmpty().WithMessage("O Código do Procedimento Deve estar Preenchido");
            //RuleFor(r => r.NumeroAtendimento).NotNull().NotEmpty().WithMessage("O Número do Atendimento Deve estar Preenchido");
            RuleFor(c => c.ProcedimentoAtivo)
                .Equal(true).WithMessage("O Procedimento deve estar Ativo");
            RuleFor(c => c.Valor)
                .NotEqual(0).WithMessage("O campo {PropertyName} precisa ser maior do que zero");
        }
    }
}
