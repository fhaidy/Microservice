using FluentValidation;

namespace MicroService.Ordering.Application.Features.Commands.UpdateOrder;

public class UpdateOrderValidator : AbstractValidator<UpdateOrderCommand>
{
    public UpdateOrderValidator()
    {
        RuleFor(p => p.Order.UserName)
            .NotEmpty().WithMessage("{UserName} is required.")
            .NotNull()
            .MaximumLength(50).WithMessage("{UserName} must not exceed 50 characters.");

        RuleFor(p => p.Order.BillingAddress.EmailAddress)
            .NotEmpty().WithMessage("{EmailAddress} is required.");

        RuleFor(p => p.Order.TotalPrice)
            .NotEmpty().WithMessage("{TotalPrice} is required.")
            .GreaterThan(0).WithMessage("{TotalPrice} should be greater than zero.");
    }
}