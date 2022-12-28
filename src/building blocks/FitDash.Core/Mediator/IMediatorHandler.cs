using FitDash.Core.Events;
using FitDash.Core.Messages;
using System.ComponentModel.DataAnnotations;

namespace FitDash.Core.Mediator
{
    public interface IMediatorHandler
    {
        Task PublishEvent<T>(T evento) where T : Event;
        Task<ValidationResult> SendCommand<T>(T comando) where T : Command;
    }
}
