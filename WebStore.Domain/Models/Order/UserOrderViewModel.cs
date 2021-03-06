﻿using System.ComponentModel.DataAnnotations;

namespace WebStore.Domain.Models.Order
{
    public class UserOrderViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required,
         DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Required]
        public string Address { get; set; }

        public decimal TotalSum { get; set; }
    }
}
