using ModelGen.Application.Contracts.Business;
using ModelGen.Application.Contracts.Persistence;

namespace ModelGen.Infrastructure.Services;

public class OrderService(IOrderRepository orderRepository) : IOrderService
{
}