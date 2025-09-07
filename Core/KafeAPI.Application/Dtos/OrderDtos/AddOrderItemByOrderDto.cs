using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KafeAPI.Application.Dtos.OrderItemDtos;
using KafeAPI.Domain.Entities;

namespace KafeAPI.Application.Dtos.OrderDtos
{
    public class AddOrderItemByOrderDto
    {

        public int OrderId { get; set; }
        public  CreateOrderItemDto OrderItem { get; set; } 

    }
}
