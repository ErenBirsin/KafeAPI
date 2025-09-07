using FluentValidation;
using KafeAPI.Application.Dtos.ReviewDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KafeAPI.Application.Validators.Review
{
    public class UpdateReviewValidator : AbstractValidator<UpdateReviewDto>
    {
        public UpdateReviewValidator()
        {
            RuleFor(x => x.Comment)
                .NotEmpty()
                .WithMessage("Yorum alanı boş olamaz.")
                .Length(5, 500)
                .WithMessage("Yorum alanı 5 karakter, en fazla 500 karakter olması gereklidir.");
            RuleFor(x => x.Rating)
                .NotNull()
                .WithMessage("Yıldız değeri boş olamaz.")
                .InclusiveBetween(1, 5)
                .WithMessage("Yıldız değeri 1 ile 5 arasında olmalıdır.");
        }
    }
}
