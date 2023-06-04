using FluentValidation;

namespace MicroService.Ordering.Application.Features.Commands.CheckoutOrder;

public class CheckoutOrderCommandValidator : AbstractValidator<CheckoutOrderCommand>
{
    public CheckoutOrderCommandValidator()
    {
        RuleFor(p => p.CheckoutOrder.UserName)
            .NotEmpty().WithMessage("{UserName} is required.")
            .NotNull()
            .MaximumLength(50).WithMessage("{UserName} must not exceed 50 characters.");

        RuleFor(p => p.CheckoutOrder.EmailAddress)
            .NotEmpty().WithMessage("{EmailAddress} is required.");

        RuleFor(p => p.CheckoutOrder.TotalPrice)
            .NotEmpty().WithMessage("{TotalPrice} is required.")
            .GreaterThan(0).WithMessage("{TotalPrice} should be greater than zero."); 
    }
}