using MediatR;

namespace Feature.Client
{
    public class ClientEmailNotification : INotification
    {
        public ClientEmailNotification(string origin, string destiny, string subject, string message)
        {
            Origin = origin;
            Destiny = destiny;
            Subject = subject;
            Message = message;
        }

        public string Origin { get; private set; }
        public string Destiny { get; private set; }
        public string Subject { get; private set; }
        public string Message { get; private set; }
    }
}
