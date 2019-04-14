using System.Threading;
using System.Threading.Tasks;
using MediatorPatternExample.Domain.Customer.Command;
using MediatorPatternExample.Notifications;
using MediatR;

namespace MediatorPatternExample.Domain.Customer.Handler
{
    public class CustomerHandler : IRequestHandler<CustomerCreateCommand, string>
    {
        private readonly IMediator _mediator;

        public CustomerHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<string> Handle(CustomerCreateCommand request, CancellationToken cancellationToken)
        {
            await _mediator.Publish(new CustomerCreatedNotification
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email
            }, cancellationToken);

            return await Task.FromResult("Cliente registrado com sucesso");
        }
    }
}