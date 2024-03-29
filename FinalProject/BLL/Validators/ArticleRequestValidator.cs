using FinalProject.BLL.RequestModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.BLL.Validators
{
    public class ArticleRequestValidator : AbstractValidator<ArticleRequest>
    {
        public ArticleRequestValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MaximumLength(500);
            RuleFor(x => x.BodyText).NotEmpty();
        }

    }
}