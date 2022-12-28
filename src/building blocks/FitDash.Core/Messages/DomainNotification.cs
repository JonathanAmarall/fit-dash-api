namespace FitDash.Core.Messages
{
    public class DomainNotification
    {
        public DomainNotification(DateTime timestamp, Guid domainNotificationId, string key, string value, int version)
        {
            Timestamp = timestamp;
            DomainNotificationId = domainNotificationId;
            Key = key;
            Value = value;
            Version = version;
        }

        public DateTime Timestamp { get; private set; }
        public Guid DomainNotificationId { get; private set; }
        public string Key { get; private set; }
        public string Value { get; private set; }
        public int Version { get; private set; }
    }


    public class DomainNotificationHandler
    {

    }
}
