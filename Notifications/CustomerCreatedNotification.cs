using MediatR;

namespace MediatorPatternExample.Notifications
{
    public class CustomerCreatedNotification : INotification
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
