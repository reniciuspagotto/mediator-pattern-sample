using MediatR;

namespace MediatorPatternExample.Domain.Customer.Command
{
    public class CustomerDeleteCommand : IRequest<string>
    {
        public int Id { get; set; }
    }
}
