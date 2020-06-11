using FluentValidation.Results;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Previdencia.Portabilidade.Domain.Core
{
    public abstract class Entity
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; protected set; }

        [NotMapped]
        public ValidationResult ValidationResult { get; protected set; }

        public abstract bool EhValido();
    }
}
