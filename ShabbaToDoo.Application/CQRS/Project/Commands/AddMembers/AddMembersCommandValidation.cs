using FluentValidation;

namespace ShabbaToDoo.Application.CQRS.Project.Commands.AddMembers
{
    public class AddMembersCommandValidation : AbstractValidator<AddMembersCommand>
    {
        public AddMembersCommandValidation()
        {
            RuleFor(x => x.UserIds).NotEmpty();
        }
    }
}
