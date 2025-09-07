using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KafeAPI.Application.Dtos.MenuItemDtos;
using KafeAPI.Application.Dtos.MenuItemsDtos;
using KafeAPI.Application.Dtos.ResponseDtos;

namespace KafeAPI.Application.Services.Abstract
{
    public interface IMenuItemServices
    {

        Task<ResponseDto<List<ResultMenuItemDto>>> GetAllMenuItems();
        Task<ResponseDto<DetailMenuItemDto>> GetByIdMenuItem(int id);
        Task <ResponseDto<object>>AddMenuItem(CreateMenuItemDto dto);
        Task <ResponseDto<object>>UpdateMenuItem(UpdateMenuItemDto dto);
        Task <ResponseDto<object>> DeleteMenuItem(int id);
    }
}
