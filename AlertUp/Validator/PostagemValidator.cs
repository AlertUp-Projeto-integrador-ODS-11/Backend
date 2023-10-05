using AlertUp.Model;
using FluentValidation;

namespace AlertUp.Validator
{
    public class PostagemValidator : AbstractValidator<Postagem>
    {
        public PostagemValidator()
        {
            RuleFor(p => p.Titulo)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(100);

            RuleFor(p => p.Descricao)
                    .NotEmpty()
                    .MinimumLength(5)
                    .MaximumLength(1000);


            RuleFor(p => p.Foto)
                    .MaximumLength(5000);

            RuleFor(p => p.Municipio)
                    .NotEmpty()
                    .MinimumLength(2)
                    .MaximumLength(100);
        }
    }
}
