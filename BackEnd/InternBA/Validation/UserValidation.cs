using FluentValidation;
using InternBA.ViewModels;

namespace InternBA.Models.Validation
{
    public class UserValidation : AbstractValidator<UserViewModel>
    {
        public UserValidation()
        {
            
            RuleFor(user => user.Username).NotEmpty().Length(1,50).WithMessage("Username must range from 1 to 50");
            RuleFor(user => user.Email).EmailAddress().WithMessage("Email is not right");
            RuleFor(user => user.Password).NotEmpty().WithMessage("Your password cannot be empty")
                    .MinimumLength(8).WithMessage("Your password length must be at least 8.")
                    .MaximumLength(16).WithMessage("Your password length must not exceed 16.")
                    .Matches(@"[A-Z]+").WithMessage("Your password must contain at least one uppercase letter.")
                    .Matches(@"[a-z]+").WithMessage("Your password must contain at least one lowercase letter.")
                    .Matches(@"[0-9]+").WithMessage("Your password must contain at least one number.")
                    .Matches(@"[\!\?\*\.]+").WithMessage("Your password must contain at least one (!? *.).");
        }
    }
}
