using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KafeAPI.Application.Dtos.MenuItemDtos;

namespace KafeAPI.Application.Dtos.CategoryDtos
{
    public class DetailCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CategoriesMenuItemDto> MenuItems   { get; set; } 
    }
}
