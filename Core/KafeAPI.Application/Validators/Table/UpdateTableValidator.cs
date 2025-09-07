using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using KafeAPI.Application.Dtos.TableDtos;

namespace KafeAPI.Application.Validators.Table
{
    public class UpdateTableValidator : AbstractValidator<UpdateTableDto>
    {
        public UpdateTableValidator()
        {
            RuleFor(x => x.TableNumber)
                .NotEmpty()
                .WithMessage("Masa Numarası Boş Bırakılamaz.")
                .GreaterThan(0)
                .WithMessage("Masa Numarası 0'dan Büyük Olmalıdır.");
            RuleFor(x => x.Capacity)
                .NotEmpty()
                .WithMessage("Kapasite Boş Bırakılamaz")
                .GreaterThan(0)
                .WithMessage("Kapasite 0'dan Büyük Olmak Zorundadır.");
        }
    }
}
