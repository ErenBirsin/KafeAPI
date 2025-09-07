using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KafeAPI.Application.Dtos.OrderItemDtos;
using KafeAPI.Domain.Entities;

namespace KafeAPI.Application.Dtos.OrderDtos
{
    public class CreateOrderDto
    {

       
        public int TableId { get; set; }
        //public decimal TotalPrice { get; set; }
        //public DateTime CreatedAt { get; set; } = DateTime.Now;
        //public DateTime? UpdateAt { get; set; }
        //public string Status { get; set; } // buraya biz servisten gönderim sağlayacağız
        public List<CreateOrderItemDto> OrderItems { get; set; }

    }
}
