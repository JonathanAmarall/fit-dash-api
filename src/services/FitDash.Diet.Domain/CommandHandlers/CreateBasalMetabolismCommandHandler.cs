using FitDash.Diet.Domain.Commands;
using FluentValidation.Results;
using MediatR;

namespace FitDash.Diet.Domain.CommandHandlers
{
    public class CreateBasalMetabolismCommandHandler : IRequestHandler<CreateBasalMetabolismCommand, ValidationResult>
    {
        public async Task<ValidationResult> Handle(CreateBasalMetabolismCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
                return request.ValidationResult!;

            await Task.CompletedTask;
            
            return request.ValidationResult!;
        }
    }
}
