using FluentValidation;
using Microsoft.Extensions.Localization;
using PersonDirectoryApi.Controllers.Resources;
using PersonDirectoryApi.Resources;
using System;
using System.Text.RegularExpressions;

namespace PersonDirectoryApi.Validation
{
    public class FluentValidator : AbstractValidator<PersonResource>
    {
        public FluentValidator(IStringLocalizer<SharedResource> stringLocalizer)
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage(stringLocalizer["Required"].Value);
            RuleFor(x => x.FirstName).Must(ValidationHelper.HasLatinOrGeorgianLettersOnly).WithMessage(stringLocalizer["OnlyLatinOrGeorgian"].Value);
            RuleFor(x => x.FirstName).Must(a => !ValidationHelper.HasMixedLanguage(a)).WithMessage(stringLocalizer["MixedLanguage"].Value);
            RuleFor(x => x.FirstName).MinimumLength(2).WithMessage(string.Format(stringLocalizer["NameTooshort"].Value, 2));
            RuleFor(x => x.FirstName).MaximumLength(50).WithMessage(string.Format(stringLocalizer["NameTooLong"].Value, 50));

            RuleFor(x => x.LastName).NotEmpty().WithMessage(stringLocalizer["Required"].Value);
            RuleFor(x => x.LastName).Must(ValidationHelper.HasLatinOrGeorgianLettersOnly).WithMessage(stringLocalizer["OnlyLatinOrGeorgian"].Value);
            RuleFor(x => x.LastName).Must(a => !ValidationHelper.HasMixedLanguage(a)).WithMessage(stringLocalizer["MixedLanguage"].Value);
            RuleFor(x => x.LastName).MinimumLength(2).WithMessage(string.Format(stringLocalizer["NameTooshort"].Value, 2));
            RuleFor(x => x.LastName).MaximumLength(50).WithMessage(string.Format(stringLocalizer["NameTooLong"].Value, 50));


            RuleFor(x => x.PersonalIdNumber).NotEmpty().WithMessage(stringLocalizer["Required"].Value);
            RuleFor(x => x.PersonalIdNumber).Length(11).WithMessage(string.Format(stringLocalizer["ShouldBe11Characters"].Value, 11));
            RuleFor(x => x.PersonalIdNumber).Must(ValidationHelper.HasDigitsOnly).WithMessage(stringLocalizer["ShouldBeDigitsOnly"].Value);


            RuleFor(x => x.Gender).IsInEnum().WithMessage(stringLocalizer["InvalidGenderValue"]);

            RuleFor(x => x.BirthDate).NotEmpty().WithMessage(stringLocalizer["Required"].Value);
            RuleFor(x => x.BirthDate).Must(a => (DateTime.Now - a).TotalDays > (365 * 18)).WithMessage(string.Format(stringLocalizer["Age18OrOlder"].Value));
        }
    }
}
