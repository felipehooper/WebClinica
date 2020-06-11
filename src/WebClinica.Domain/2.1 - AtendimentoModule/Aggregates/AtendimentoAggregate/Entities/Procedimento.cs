using Previdencia.Portabilidade.Domain.Core;

namespace WebClinica.Domain._2._1___AtendimentoModule.Aggregates.AtendimentoAggregate.Entities
{
    public  class Procedimento : Entity
    {
        public double Valor { get; private set; }
        public int Quantidade { get; set; }
        public string NumeroProcedimento { get; private set; }

        public Procedimento(string numeroProcedimento, double valor, int quantidade)
        {
            NumeroProcedimento = numeroProcedimento;
            Valor = valor;
            Quantidade = quantidade;
        }

        public override bool EhValido()
        {
            throw new System.NotImplementedException();
        }
    }
}
