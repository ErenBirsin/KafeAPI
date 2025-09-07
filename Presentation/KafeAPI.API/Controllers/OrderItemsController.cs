//using KafeAPI.Application.Dtos.OrderItemDtos;
//using KafeAPI.Application.Services.Abstract;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace KafeAPI.API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class OrderItemsController : BaseController
//    {

//        private readonly IOrderItemService _orderItemService;

//        public OrderItemsController(IOrderItemService orderItemService)
//        {
//            _orderItemService = orderItemService;
//        }

//        //[HttpGet]
//        //public async Task<IActionResult> GetAllOrderItems()
//        //{
//        //    var result = await _orderItemService.GetAllOrderItems();
//        //    return CreateResponse(result);
//        //}
//        //[HttpGet("{id}")]
//        //public async Task<IActionResult> GetOrderItemById(int id)
//        //{
//        //    var result = await _orderItemService.GetOrderItemById(id);
//        //    return CreateResponse(result);
//        //}

//        //[HttpPost]
//        //public async Task<IActionResult> AddOrderItem(CreateOrderItemDto dto)
//        //{
//        //    var result = await _orderItemService.AddOrderItem(dto);
//        //    return CreateResponse(result);
//        //}

//        //[HttpPut]
//        //public async Task<IActionResult> UpdateOrderItem(UpdateOrderItemDto dto)
//        //{
//        //    var result = await _orderItemService.UpdateOrderItem(dto);
//        //    return CreateResponse(result);
//        //}

//        //[HttpDelete]
//        //public async Task<IActionResult> DeleteOrderItem(int id)
//        //{
//        //    var result = await _orderItemService.DeleteOrderItem(id);
//        //    return CreateResponse(result);
//        //}
//    }
//}
