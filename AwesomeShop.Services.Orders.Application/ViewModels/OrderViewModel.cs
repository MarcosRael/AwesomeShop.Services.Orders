using AwesomeShop.Services.Orders.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeShop.Services.Orders.Application.ViewModels
{
    public class OrderViewModel
    {
        public OrderViewModel(Guid id, decimal totalPrice, DateTime createAt, string status)
        {
            Id = id;
            TotalPrice = totalPrice;
            CreateAt = createAt;
            this.status = status;
        }

        public Guid Id { get; set; }

        public decimal TotalPrice { get; set; }

        public DateTime CreateAt { get; set; }

        public string status { get; set; }

        public static OrderViewModel FromEntity(Order order)
        {
            return new OrderViewModel(order.Id, order.TotalPrice, order.CreatedAt, order.Status.ToString());
        }

    }
}
