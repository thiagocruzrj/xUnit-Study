using Feature.Core;
using FluentValidation;
using System;

namespace Feature.Client
{
    public class Client : Entity
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public DateTime BirthDate { get; private set; }
        public DateTime RegisterDate { get; private set; }
        public string Email { get; private set; }
        public bool Active { get; private set; }
        
        protected Client() { }

        public Client(Guid id, string name, string surname, DateTime birthDate, DateTime registerDate, string email, bool active)
        {
            Id = id;
            Name = name;
            Surname = surname;
            BirthDate = birthDate;
            RegisterDate = registerDate;
            Email = email;
            Active = active;
        }

        public string FullName()
        {
            return $"{Name} {Surname}";
        }

        public bool IsSpecial()
        {
            return RegisterDate < DateTime.Now.AddYears(-3) && Active;
        }

        public void Deactive()
        {
            Active = false;
        }

        public override bool IsValid()
        {
            ValidationResult = new ClientValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public static bool HaveMinimumAge(DateTime bDate)
        {
            return bDate <= DateTime.Now.AddYears(-18);
        }

        public class ClientValidation : AbstractValidator<Client>
        {
            public ClientValidation()
            {
                RuleFor(c => c.Name)
                    .NotEmpty().WithMessage("Por favor, certifique-se de ter inserido o nome")
                    .Length(2, 150).WithMessage("O nome deve ter entre 2 e 150 caracteres");

                RuleFor(c => c.Surname)
                    .NotEmpty().WithMessage("Por favor, certifique-se de ter inserido o sobrenome")
                    .Length(2, 150).WithMessage("O Sobrenome deve ter entre 2 e 150 caracteres");

                RuleFor(c => c.BirthDate)
                    .NotEmpty()
                    .Must(HaveMinimumAge)
                    .WithMessage("O cliente deve ter 18 anos ou mais");

                RuleFor(c => c.Email)
                    .NotEmpty()
                    .EmailAddress();

                RuleFor(c => c.Id)
                    .NotEqual(Guid.Empty);
            }
        }
    }
}
