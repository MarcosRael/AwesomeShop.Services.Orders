using AwesomeShop.Services.Orders.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AwesomeShop.Services.Orders.Core.Entities
{
    public class AggregateRoot : IEntityBase
    {
        public Guid Id { get; protected set; }
       
        private List<IDomainEvent> _events = new List<IDomainEvent>();

        public Guid MyProperty { get; private set; }

        public IEnumerable<IDomainEvent> Events => _events;


        protected void AddEvent(IDomainEvent @event)
        {
            if (_events == null)
                _events = new List<IDomainEvent>();

            _events.Add(@event);
        }
    }
}