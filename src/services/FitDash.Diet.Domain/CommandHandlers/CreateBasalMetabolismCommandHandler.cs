using FitDash.Core.Mediator;
using FitDash.Core.Messages.Events;
using FitDash.Diet.Domain.Commands;
using FitDash.Diet.Domain.Entities;
using FitDash.Diet.Domain.Repositories;
using FluentValidation.Results;
using MediatR;

namespace FitDash.Diet.Domain.CommandHandlers
{
    public class CreateBasalMetabolismCommandHandler : IRequestHandler<CreateBasalMetabolismCommand, ValidationResult>
    {
        private readonly IBasalMetabolismRepository _basalMetabolismRepository;
      
        public CreateBasalMetabolismCommandHandler(IBasalMetabolismRepository basalMetabolismRepository, IMediatorHandler mediatorHandler)
        {
            _basalMetabolismRepository = basalMetabolismRepository;
        }

        public async Task<ValidationResult> Handle(CreateBasalMetabolismCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
                return request.ValidationResult!;

            var bm = new BasalMetabolism(request.Height, request.Weight, request.YearsOld, request.ActivityFactor, request.Gender);

            bm.AddEvent(new NewBasalMetabolismsCreatedEvent(bm.Id, bm.Height, bm.Weight, bm.YearsOld, bm.ActivityFactor, bm.Gender));

            await _basalMetabolismRepository.CreateAsync(bm);
            await _basalMetabolismRepository.UnitOfWork.Commit();

            return request.ValidationResult!;
        }
    }
}
