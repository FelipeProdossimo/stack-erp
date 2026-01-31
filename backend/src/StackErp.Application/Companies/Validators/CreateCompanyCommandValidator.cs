using FluentValidation;

namespace StackErp.Application.Companies.Create
{
    public class CreateCompanyCommandValidator : AbstractValidator<CreateCompanyCommand>
    {
        public CreateCompanyCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(200).WithMessage("Name must not exceed 200 characters.");

            RuleFor(x => x.Document)
                .NotEmpty().WithMessage("Document is required.")
                .MaximumLength(20).WithMessage("Document must not exceed 20 characters.");
        }
    }
}