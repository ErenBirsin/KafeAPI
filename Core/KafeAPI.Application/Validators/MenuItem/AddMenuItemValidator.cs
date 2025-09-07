using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using KafeAPI.Application.Dtos.MenuItemsDtos;

namespace KafeAPI.Application.Validators.MenuItem
{
    public class AddMenuItemValidator : AbstractValidator<CreateMenuItemDto>
    {
        public AddMenuItemValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Menü Item Adı Boş Olamaz.")
            .Length(2,40).WithMessage("Menü Item Adı 2 ile 40 Karakter Arasında Olmak Zorundadır.");
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Menü Item Açıklaması Boş Olamaz.")
                .Length(5,100).WithMessage("Menü Item Açıklaması 5 ile 100 Karakter Arasında Olmak Zorundadır.");
            RuleFor(x => x.Price)
                .NotEmpty().WithMessage("Menü Item Fiyatı Boş Olamaz")
            .GreaterThan(0).WithMessage("Menü Item Fiyatı 0'dan Büyük Olmak Zorundadır.");
            RuleFor(x => x.ImageUrl)
                .NotEmpty().WithMessage("Menü Item Resim Url'si Boş Olamaz.");
        }
    }
}
