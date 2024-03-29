using FinalProject.BLL.RequestModels;
using FluentValidation;

namespace FinalProject.BLL.Validators
{
    public class TagRequestValidator : AbstractValidator<TagRequest>
    {
        public TagRequestValidator()
        {
            RuleFor(x => x.TagName).NotEmpty().MaximumLength(50);
        }
    }
}