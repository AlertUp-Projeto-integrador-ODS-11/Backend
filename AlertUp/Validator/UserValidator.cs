using AlertUp.Model;
using FluentValidation;


namespace AlertUp.Validator
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.Nome)
                .NotEmpty()
                .MinimumLength(1)
                .MaximumLength(100);

            RuleFor(u => u.Email)
                    .NotEmpty()
                    .MinimumLength(5)
                    .MaximumLength(100);

            RuleFor(u => u.Senha)
                    .NotEmpty()
                    .MinimumLength(5)
                    .MaximumLength(300);
        }
    }
}
