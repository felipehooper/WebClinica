using FluentValidation.Results;
using Previdencia.Portabilidade.Domain.Core;
using WebClinica.Domain._2._1___AtendimentoModule.Aggregates.AtendimentoAggregate.Entities.Validations;

namespace WebClinica.Domain._2._1___AtendimentoModule.Aggregates.AtendimentoAggregate.Entities
{
    public  class Procedimento : Entity
    {
        public double Valor { get; private set; }
        public int Quantidade { get; set; }
        public string NumeroProcedimento { get; private set; }
        public bool Ativo { get; private set; }

        public Procedimento(string numeroProcedimento, double valor, int quantidade)
        {
            NumeroProcedimento = numeroProcedimento;
            Quantidade = quantidade;
            Ativo = true;
            Valor = valor;
        }

        public override bool EhValido()
        {
            ValidationResult = new ProcedimentoValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
