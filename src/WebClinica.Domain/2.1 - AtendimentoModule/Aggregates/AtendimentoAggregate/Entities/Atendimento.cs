using Previdencia.Portabilidade.Domain.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace WebClinica.Domain._2._1___AtendimentoModule.Aggregates.AtendimentoAggregate.Entities
{
    public class Atendimento : Entity
    {
        private readonly Collection<Procedimento> _procedimentos;
        public IReadOnlyCollection<Procedimento> Procedimentos => _procedimentos;

        public DateTime DataAtendimento { get; private set; }

        public string NumeroAtendimento { get; private set; }

        public Atendimento(string numeroAtendimento)
        {
            NumeroAtendimento = numeroAtendimento;
            _procedimentos = new Collection<Procedimento>();
            DataAtendimento = DateTime.Now;
        }

        public void AdicionarProcedimento(Procedimento procedimento)
        {
            if (Procedimentos.Count(s => s.NumeroProcedimento == procedimento.NumeroProcedimento) == 1)
                return;
            _procedimentos.Add(procedimento);
        }

        public double ValorTotal()
        {
           return _procedimentos.Sum(s => s.Valor * s.Quantidade);
        }

        public override bool EhValido()
        {
            throw new NotImplementedException();
        }
    }
}
