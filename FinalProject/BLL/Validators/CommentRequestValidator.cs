using FinalProject.BLL.RequestModels;
using FluentValidation;

namespace FinalProject.BLL.Validators
{
    public class CommentRequestValidator : AbstractValidator<CommentRequest>
    {
        public CommentRequestValidator()
        {
            RuleFor(x => x.BodyText).NotEmpty().MaximumLength(500);
        }
    }
}