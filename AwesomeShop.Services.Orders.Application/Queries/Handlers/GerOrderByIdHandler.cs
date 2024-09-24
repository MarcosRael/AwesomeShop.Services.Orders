using AwesomeShop.Services.Orders.Application.ViewModels;
using AwesomeShop.Services.Orders.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeShop.Services.Orders.Application.Queries.Handlers
{
    public class GerOrderByIdHandler : IRequestHandler<GetOrderById, OrderViewModel>
    {

        private readonly IOrderRepository _orderRepository;

        public GerOrderByIdHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<OrderViewModel> Handle(GetOrderById request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetByAsync(request.Id);

            var orderViewModel = OrderViewModel.FromEntity(order);

            return orderViewModel;
        }
    }
}
