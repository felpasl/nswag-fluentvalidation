using FluentValidation;

namespace ZymLabs.NSwag.FluentValidation.Tests
{
    public class MockValidationTargetValidator : AbstractValidator<MockValidationTarget>
    {
        public MockValidationTargetValidator()
        {
            RuleFor(sample => sample.Length).MinimumLength(10).MaximumLength(20);

            RuleFor(sample => sample.NotNull).NotNull();
            RuleFor(sample => sample.NotEmpty).NotEmpty();
            RuleFor(sample => sample.EmailAddress).EmailAddress();
            RuleFor(sample => sample.RegexField).Matches(@"(\d{4})-(\d{2})-(\d{2})");

            RuleFor(sample => sample.ValueInRange).GreaterThanOrEqualTo(5).LessThanOrEqualTo(10);
            RuleFor(sample => sample.ValueInRangeExclusive).GreaterThan(5).LessThan(10);

            RuleFor(sample => sample.ValueInRangeFloat).InclusiveBetween(1.1f, 5.3f);
            RuleFor(sample => sample.ValueInRangeDouble).ExclusiveBetween(2.2, 7.5f);

            Include(new MockValidationTargetIncludeValidator());
        }
    }
}