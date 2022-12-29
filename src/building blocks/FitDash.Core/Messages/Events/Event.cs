using FitDash.Core.Events;
using MediatR;

namespace FitDash.Core.Messages.Events
{
    public abstract class Event : Message, INotification
    {
        public DateTime Timestamp { get; private set; }

        protected Event()
        {
            Timestamp = DateTime.Now;
        }
    }

}
