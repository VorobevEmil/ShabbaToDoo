using FluentValidation;

namespace ShabbaToDoo.Application.CQRS.Project.Commands.Create
{
    public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
    {
        public CreateProjectCommandValidator()
        {
            RuleFor(x => x.Project.Title).NotEmpty();
        }
    }
}
