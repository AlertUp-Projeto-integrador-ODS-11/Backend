using AlertUp.Model;
using FluentValidation;

namespace AlertUp.Validator
{
    public class TemaValidator : AbstractValidator<Tema>
    {
        public TemaValidator()
        {
            RuleFor(p => p.Titulo)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(100);

            RuleFor(p => p.Descricao)
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(300);
        }
    }
}
