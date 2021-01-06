using FluentValidation;

namespace Users.Contracts.Users
{
    public class CreateUserContract
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }

    public class CreateUserContractValidator : AbstractValidator<CreateUserContract>
    {
        public CreateUserContractValidator()
        {
            RuleFor(p => p.FirstName).NotEmpty().MaximumLength(250);
            RuleFor(p => p.LastName).NotEmpty().MaximumLength(250);
            RuleFor(p => p.Phone).MaximumLength(100);
            RuleFor(p => p.Email).MaximumLength(150);
        }
    }
}
