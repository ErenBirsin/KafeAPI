using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using KafeAPI.Application.Dtos.CategoryDtos;

namespace KafeAPI.Application.Validators.Category
{
    public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryDto>
    {
        public UpdateCategoryValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Kategori adı boş olamaz.")
                .Length(3, 30).WithMessage("Kategori adının uzunluğu 3 ile 30 karakter arasında olmalıdır.");
        }
    }
}
