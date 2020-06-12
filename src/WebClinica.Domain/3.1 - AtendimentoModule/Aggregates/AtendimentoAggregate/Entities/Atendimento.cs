using Previdencia.Portabilidade.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using WebClinica.Domain._2._1___AtendimentoModule.Aggregates.AtendimentoAggregate.Entities.Validations;

namespace WebClinica.Domain._2._1___AtendimentoModule.Aggregates.AtendimentoAggregate.Entities
{
    public class Atendimento : Entity
    {
        private readonly List<Procedimento> _procedimentos;
        public IReadOnlyCollection<Procedimento> Procedimentos => _procedimentos;

        public DateTime DataAtendimento { get; private set; }

        public string NumeroAtendimento { get; private set; }

        public bool Ativo { get; private set; }

        public double ValorTotal => CalcularValorTotal();

        public Atendimento(string numeroAtendimento, List<Procedimento> procedimentos)
        {
            NumeroAtendimento = numeroAtendimento;
            _procedimentos = procedimentos;
            DataAtendimento = DateTime.Now.Date;
            Ativo = true;

            //foreach (var error in ValidationResult.Errors)
            //{
            //    _mediator.Publish(new DomainNotification(message.MessageType, error.ErrorMessage));
            //}
        }

        public void AdicionarProcedimento(Procedimento procedimento)
        {
            //TODO: TENTAR VALIDAR COM FLUENT VALIDATION OS PROCEDIMENTOS REPETIDOS 
            if (Procedimentos.Count(s => s.NumeroProcedimento == procedimento.NumeroProcedimento) == 1)
                return;
            _procedimentos.Add(procedimento);
        }

        private double CalcularValorTotal()
        {
            return _procedimentos.Sum(s => s.Valor * s.Quantidade);
        }

        public override bool EhValido()
        {
            ValidationResult = new AtendimentoValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
