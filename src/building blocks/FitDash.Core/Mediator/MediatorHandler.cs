using FitDash.Core.Messages;
using FitDash.Core.Messages.Events;
using FluentValidation.Results;
using MediatR;

namespace FitDash.Core.Mediator
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public MediatorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<ValidationResult> SendCommand<T>(T comando) where T : Command
        {
            return await _mediator.Send(comando);
        }

        public async Task PublishEvent<T>(T evento) where T : Event
        {
            await _mediator.Publish(evento);
        }

        public Task PublishNotification<T>(T notification)
        {
            throw new NotImplementedException();
        }
    }
}
