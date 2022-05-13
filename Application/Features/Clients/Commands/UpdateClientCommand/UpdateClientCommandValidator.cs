using FluentValidation;

namespace Application.Features.Clients.Commands.UpdateClientCommand
{
    public class UpdateClientCommandValidator : AbstractValidator<UpdateClientCommand>
    {
        public UpdateClientCommandValidator()
        {
            RuleFor(p => p.LastName)
                .NotEmpty().WithMessage("{PropertyName} no debe ser vacio.")
                .MaximumLength(20).WithMessage("{PropertyName} no exceder de {MaxLength} caracteres.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} no debe ser vacio.")
                .MaximumLength(20).WithMessage("{PropertyName} no exceder de {MaxLength} caracteres.");

            RuleFor(p => p.DateBirth)
                .NotEmpty().WithMessage("{PropertyName} no debe ser vacio.");

            RuleFor(p => p.PhoneNumber)
                .NotEmpty().WithMessage("{PropertyName} no debe ser vacio.")
                .MaximumLength(10).WithMessage("{PropertyName} no exceder de {MaxLength} caracteres.");

            RuleFor(p => p.Email)
                .EmailAddress().WithMessage("{PropertyName} debe ser una dirección de email valida.")
                .MaximumLength(30).WithMessage("{PropertyName} no exceder de {MaxLength} caracteres.");

            RuleFor(p => p.Address)
                .MaximumLength(30).WithMessage("{PropertyName} no exceder de {MaxLength} caracteres.");
        }
    }
}
