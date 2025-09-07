﻿using System.Formats.Asn1;
using KafeAPI.Application.Dtos.OrderDtos;
using KafeAPI.Application.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KafeAPI.API.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : BaseController
    {

        private readonly IOrderServices _orderServices;

        public OrdersController(IOrderServices orderServices)
        {
            _orderServices = orderServices;
        }
        [Authorize(Roles ="admin,employee")]
        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var result = await _orderServices.GetAllOrders();
            return CreateResponse(result);
        }

        [Authorize(Roles = "admin,employee")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var result = await _orderServices.GetOrderById(id);
            return CreateResponse(result);
        }

        [Authorize(Roles = "admin,employee")]
        [HttpPost]
        public async Task<IActionResult> AddOrder(CreateOrderDto dto)
        {
            var result = await _orderServices.AddOrder(dto);
            return CreateResponse(result);
        }

        [Authorize(Roles = "admin,employee")]
        [HttpPut]
        public async Task<IActionResult> UpdateOrder(UpdateOrderDto dto)
        {
            var result = await _orderServices.UpdateOrder(dto);
            return CreateResponse(result);
        }

        [Authorize(Roles = "admin,employee")]
        [HttpDelete]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var result = await _orderServices.DeleteOrder(id);
            return CreateResponse(result);
        }

        [Authorize(Roles = "admin,employee")]
        [HttpGet("withdetails")]
        public async Task<IActionResult> GetAllOrdersWithDetail()
        {
            var result = await _orderServices.GetAllOrdersWithDetail();
            return CreateResponse(result);
        }

        [Authorize(Roles = "admin,employee")]
        [HttpPut("status/hazir")]
        public async Task<IActionResult> UpdateOrderStatusHazir(int orderId)
        {
            var result = await _orderServices.UpdateOrderStatusHazir(orderId);
            return CreateResponse(result);
        }

        [Authorize(Roles = "admin,employee")]
        [HttpPut("status/teslimedildi")]
        public async Task<IActionResult> UpdateOrderStatusTeslimEdildi(int orderId)
        {
            var result = await _orderServices.UpdateOrderStatusTeslimEdildi(orderId);
            return CreateResponse(result);
        }

        [Authorize(Roles = "admin,employee")]
        [HttpPut("status/iptaledildi")]
        public async Task<IActionResult> UpdateOrderStatusIptalEdildi(int orderId)
        {
            var result = await _orderServices.UpdateOrderStatusIptalEdildi(orderId);
            return CreateResponse(result);
        }

        //[HttpPut("addOrderItemByOrder")]

        //public async Task<IActionResult> AddOrderItemByOrder(AddOrderItemByOrderDto dto)
        //{
        //    var result = await _orderServices.AddOrderItemByOrderId(dto);
        //    return CreateResponse(result);
        //}

        [Authorize(Roles = "admin,employee")]
        [HttpPut("status/odendi")]
        public async Task<IActionResult> UpdateOrderStatusOdendi(int orderId)
        {
            var result = await _orderServices.UpdateOrderStatusOdendi(orderId);
            return CreateResponse(result);
        }
    }
}
