using FluentValidation;

namespace ShabbaToDoo.Application.CQRS.Project.Commands.Update
{
    public class UpdateProjectCommandValidator : AbstractValidator<UpdateProjectCommand>
    {
        public UpdateProjectCommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
        }
    }
}
