using System;
using System.Threading;
using System.Threading.Tasks;
using MediatorPatternExample.Notifications;
using MediatR;

namespace MediatorPatternExample.EventsHandler
{
    public class EmailHandler : INotificationHandler<CustomerActionNotification>
    {
        public Task Handle(CustomerActionNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine("O cliente {0} {1} foi {2} com sucesso", notification.FirstName, notification.LastName, notification.Action.ToString().ToLower());
            });
        }
    }
}