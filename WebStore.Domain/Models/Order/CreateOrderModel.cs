using System;
using System.Collections.ObjectModel;
using WebStore.Domain.Entities;

namespace WebStore.Domain.Models.Order
{
    public class CreateOrderModel
    {
        public string Address { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public User User { get; set; }
        public string Phone { get; set; }
        public virtual Collection<OrderItem> OrderItems { get; set; }

    }
}
