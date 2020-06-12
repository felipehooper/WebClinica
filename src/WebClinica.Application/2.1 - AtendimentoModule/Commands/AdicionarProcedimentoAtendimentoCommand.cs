using WebClinica.Application._2._1___AtendimentoModule.Validations;
using WebClinica.Core;

namespace WebClinica.Application._2._1___AtendimentoModule.Commands
{
    public class AdicionarProcedimentoAtendimentoCommand: Command
    {
        //public Guid ProcedimentoId { get; private set; }

        //public string NumeroAtendimento { get; private set; }

        public double Valor { get; private set; }

        public bool ProcedimentoAtivo { get; private set; }


        public AdicionarProcedimentoAtendimentoCommand(double valor)//(Guid procedimentoId, string numeroAtendimento)
        {
            //ProcedimentoId = procedimentoId;
            //NumeroAtendimento = numeroAtendimento;
            Valor = valor;
            ProcedimentoAtivo = true;
        }

        public override bool EhValido()
        {
            ValidationResult = new AdicionarProcedimentoAtendimentoValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
