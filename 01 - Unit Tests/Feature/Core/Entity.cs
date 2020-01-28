using FluentValidation.Results;
using System;

namespace Feature.Core
{
    public abstract class Entity
    {
        public Guid Id { get; private set; }
        public ValidationResult ValidationResult { get; protected set; }

        public virtual bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
