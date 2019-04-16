using System.Threading;
using System.Threading.Tasks;
using MediatorPatternExample.Domain.Customer.Command;
using MediatorPatternExample.Domain.Customer.Entity;
using MediatorPatternExample.Infra;
using MediatorPatternExample.Notifications;
using MediatR;

namespace MediatorPatternExample.Domain.Customer.Handler
{
    public class CustomerHandler :
        IRequestHandler<CustomerCreateCommand, string>,
        IRequestHandler<CustomerUpdateCommand, string>,
        IRequestHandler<CustomerDeleteCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly ICustomerRepository _customerRepository;

        public CustomerHandler(IMediator mediator, ICustomerRepository customerRepository)
        {
            _mediator = mediator;
            _customerRepository = customerRepository;
        }

        public async Task<string> Handle(CustomerCreateCommand request, CancellationToken cancellationToken)
        {
            var customer = new CustomerEntity(request.Id, request.FirstName, request.LastName, request.Email, request.Phone);
            await _customerRepository.Save(customer);

            await _mediator.Publish(new CustomerCreatedNotification
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email
            }, cancellationToken);

            return await Task.FromResult("Cliente registrado com sucesso");
        }

        public async Task<string> Handle(CustomerUpdateCommand request, CancellationToken cancellationToken)
        {
            var customer = new CustomerEntity(request.Id, request.FirstName, request.LastName, request.Email, request.Phone);
            await _customerRepository.Update(request.Id, customer);

            await _mediator.Publish(new CustomerCreatedNotification
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email
            }, cancellationToken);

            return await Task.FromResult("Cliente atualizado com sucesso");
        }

        public async Task<string> Handle(CustomerDeleteCommand request, CancellationToken cancellationToken)
        {
            await _customerRepository.Delete(request.Id);
            return await Task.FromResult("Cliente excluido com sucesso");
        }
    }
}