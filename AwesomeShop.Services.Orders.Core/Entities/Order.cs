using AwesomeShop.Services.Orders.Core.Enums;
using AwesomeShop.Services.Orders.Core.Events;
using AwesomeShop.Services.Orders.Core.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AwesomeShop.Services.Orders.Core.Entities
{
    public class Order : AggregateRoot
    {
        public Order(decimal totalPrice, Customer customer, DeliveryAddress deliveryAddress, PaymentAddress paymentAddress, PaymentInfo paymentInfo, DateTime createdAt) 
        {
            Id = Guid.NewGuid();
            TotalPrice = Items.Sum(i => i.Quantity * i.Price);
            TotalPrice = totalPrice;
            Customer = customer;
            DeliveryAddress = deliveryAddress;
            PaymentAddress = paymentAddress;
            PaymentInfo = paymentInfo;
            CreatedAt = createdAt;

            AddEvent(new OrderCreated(Id, TotalPrice, PaymentInfo, Customer.FullName, Customer.Email));
   
        }
        
        public decimal TotalPrice { get; private set; }

        public Customer Customer { get; private set; }

        public DeliveryAddress DeliveryAddress { get; private set; }

        public PaymentAddress PaymentAddress { get; private set; }

        public PaymentInfo PaymentInfo { get; private set; }

        public List<OrderItem> Items { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public OrderStatus Status { get; private set; }

        public void SetAsCompleted()
        {
            Status = OrderStatus.Completed; 
        }

        public void SetAsRejected()
        {
            Status = OrderStatus.Rejected; 
        }

    }
}