using FluentValidation;
using InternBA.ViewModels;

namespace InternBA.Models.Validation
{
    public class MessageValidation : AbstractValidator<MessageViewModel>
    {
        public MessageValidation()
        {
            RuleFor(message => message.Content)
                .NotNull()
                .NotEmpty()
                .WithMessage("Content can not empty");
        }
    }
}
