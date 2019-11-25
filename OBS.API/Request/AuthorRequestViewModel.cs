using FluentValidation;

namespace OBS.API.Request
{
    public class AuthorRequestViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class AddAuthorRequestViewModelValidator : AbstractValidator<AuthorRequestViewModel>
    {
        public AddAuthorRequestViewModelValidator()
        {
            RuleFor(x => x.FirstName).NotNull().MaximumLength(20);
            RuleFor(x => x.LastName).NotNull().MaximumLength(20);
        }
    }
    
    public class UpdateAuthorRequestViewModelValidator : AbstractValidator<AuthorRequestViewModel>
    {
        public UpdateAuthorRequestViewModelValidator()
        {
            RuleFor(x => x.FirstName).NotNull().MaximumLength(20);
            RuleFor(x => x.LastName).NotNull().MaximumLength(20);
        }
    }
}