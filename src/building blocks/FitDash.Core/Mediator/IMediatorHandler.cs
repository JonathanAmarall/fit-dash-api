using FitDash.Core.Messages;
using FitDash.Core.Messages.Events;
using FluentValidation.Results;

namespace FitDash.Core.Mediator
{
    public interface IMediatorHandler
    {
        Task PublishEvent<T>(T evento) where T : Event;
        Task<ValidationResult> SendCommand<T>(T comando) where T : Command;
        Task PublishNotification<T>(T notification);
    }
}
