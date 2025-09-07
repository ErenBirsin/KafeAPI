using KafeAPI.Application.Dtos.ResponseDtos;
using KafeAPI.Application.Dtos.TableDtos;
using KafeAPI.Application.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KafeAPI.API.Controllers
{
    [Route("api/tables")]
    [ApiController]
    public class TablesController : BaseController
    {
        private readonly ITableServices _tableServices;

        public TablesController(ITableServices tableServices)
        {
            _tableServices = tableServices;
        }

        [Authorize(Roles = "admin,employee")]
        [HttpGet]
        public async Task<IActionResult> GetAllTables()
        {
            var result = await _tableServices.GetAllTables();
            return CreateResponse(result);
        }

        [Authorize(Roles = "admin,employee")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdtable(int id)
        {
            var result = await _tableServices.GetByIdTable(id);
            return CreateResponse(result);
        }

        [Authorize(Roles = "admin,employee")]
        [HttpGet("tablenumber")]

        public async Task<IActionResult> GetByTableNumber([FromQuery]int tableNumber)
        {
            var result = await _tableServices.GetByTableNumber(tableNumber);
            return CreateResponse(result);
        }

        [Authorize(Roles = "admin,employee")]
        [HttpPost]
        public async Task<IActionResult> AddTables(CreateTableDto dto)
        {
            var result = await _tableServices.AddTable(dto);
            return CreateResponse(result);
        }

        [Authorize(Roles = "admin,employee")]
        [HttpPut]
        public async Task<IActionResult> UpdateTable(UpdateTableDto dto)
        {
            var result = await _tableServices.UpdateTable(dto);
            return CreateResponse(result);
        }

        [Authorize(Roles = "admin,employee")]
        [HttpDelete]

        public async Task<IActionResult> DeleteTable(int id)
        {
            var result = await _tableServices.DeleteTable(id);
            return CreateResponse(result);
        }

        //[Authorize(Roles = "admin,employee")]
        //[HttpGet("isactivetables")]
        //public async Task<IActionResult> GetAllIsActiveTablesGeneric()
        //{
        //    var result = await _tableServices.GetAllActiveTablesGeneric();
        //    return CreateResponse(result);
        //}

        [Authorize(Roles = "admin,employee")]
        [HttpGet("isactivetables")]
        public async Task<IActionResult> GetAllIsActiveTables()
        {
            var result = await _tableServices.GetAllActiveTables();
            return CreateResponse(result);
        }

        [Authorize(Roles = "admin,employee")]
        [HttpPut("statusbyid")]
        public async Task<IActionResult> UpdateTableStatusById(int id)
        {
            var result = await _tableServices.UpdateTableStatusById(id);
            return CreateResponse(result);
        }

        [Authorize(Roles = "admin,employee")]
        [HttpPut("statusbytablenumber")]
        public async Task<IActionResult> UpdateTableStatusByTableNumber(int tableNumber)
        {
            var result = await _tableServices.UpdateTableStatusByTableNumber(tableNumber);
            return CreateResponse(result);
        }
    }
}