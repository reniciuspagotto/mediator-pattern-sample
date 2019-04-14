using System;
using System.Threading;
using System.Threading.Tasks;
using MediatorPatternExample.Notifications;
using MediatR;

namespace MediatorPatternExample.EventsHandler
{
    public class EmailHandler : INotificationHandler<CustomerCreatedNotification>
    {
        public Task Handle(CustomerCreatedNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine("Email send");
            });
        }
    }
}