using ArticlesAppProject.Application.Handlers.Articles.Queries.Helper;
using FluentValidation;

namespace ArticlesAppProject.Application.Handlers.Articles.Commands.Create;

public class CreateArticleCommandValidator : AbstractValidator<CreateArticleCommand>
{
    public CreateArticleCommandValidator()
    {
        RuleFor(x => x.Title)
            .MinimumLength(5)
            .WithMessage("Name of the product must be at least 5 characters");
        RuleFor(x => x.Title)
            .MaximumLength(50)
            .WithMessage("Name of the product can not exceed 50 characters");
        RuleFor(x => x.Price)
            .GreaterThan(0)
            .WithMessage("Articles cant be free or negative value");
    }
}
