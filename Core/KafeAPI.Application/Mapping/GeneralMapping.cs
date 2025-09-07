using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using KafeAPI.Application.Dtos.CafeInfoDtos;
using KafeAPI.Application.Dtos.CategoryDtos;
using KafeAPI.Application.Dtos.MenuItemDtos;
using KafeAPI.Application.Dtos.MenuItemsDtos;
using KafeAPI.Application.Dtos.OrderDtos;
using KafeAPI.Application.Dtos.OrderItemDtos;
using KafeAPI.Application.Dtos.ReviewDtos;
using KafeAPI.Application.Dtos.TableDtos;
using KafeAPI.Application.Dtos.UserDtos;
using KafeAPI.Domain.Entities;

namespace KafeAPI.Application.Mapping
{
    public class GeneralMapping : Profile
    {
        // AutoMapper’ın “hangi sınıf hangi sınıfa nasıl dönüşsün” bilgisini tanımlayan bir mapping profili.
        public GeneralMapping()
        {
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, ResultCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
            CreateMap<Category, DetailCategoryDto>().ReverseMap();
            CreateMap<Category, ResultCategoriesWithMenuDto>().ReverseMap();

            CreateMap<MenuItem, CreateMenuItemDto>().ReverseMap();
            CreateMap<MenuItem, ResultMenuItemDto>().ReverseMap();
            CreateMap<MenuItem, UpdateMenuItemDto>().ReverseMap(); 
            CreateMap<MenuItem, DetailMenuItemDto>().ReverseMap();
            CreateMap<MenuItem, CategoriesMenuItemDto>().ReverseMap();

            CreateMap<Table,ResultTableDto>().ReverseMap();
            CreateMap<Table,DetailTableDto>().ReverseMap();
            CreateMap<Table,CreateTableDto>().ReverseMap();
            CreateMap<Table,UpdateTableDto>().ReverseMap();

            CreateMap<OrderItem, ResultOrderItemDto>().ReverseMap();
            CreateMap<OrderItem, DetailOrderItemDto>().ReverseMap();
            CreateMap<OrderItem, CreateOrderItemDto>().ReverseMap();
            CreateMap<OrderItem, UpdateOrderItemDto>().ReverseMap();

            CreateMap<Order, ResultOrderDto>().ReverseMap();
            CreateMap<Order, DetailOrderDto>().ReverseMap();
            CreateMap<Order, CreateOrderDto>().ReverseMap();
            CreateMap<Order, UpdateOrderDto>().ReverseMap();

           // CreateMap<AppIdentityUser, RegisterDto>().ReverseMap();

            CreateMap<CafeInfo, ResultCafeInfoDto>().ReverseMap();
            CreateMap<CafeInfo, DetailCafeInfoDto>().ReverseMap();
            CreateMap<CafeInfo, CreateCafeInfoDto>().ReverseMap();
            CreateMap<CafeInfo, UpdateCafeInfoDto>().ReverseMap();

            CreateMap<Review, ResultReviewDto>().ReverseMap();
            CreateMap<Review, DetailReviewDto>().ReverseMap();
            CreateMap<Review, CreateReviewDto>().ReverseMap();
            CreateMap<Review, UpdateReviewDto>().ReverseMap();
        }
    }
}
