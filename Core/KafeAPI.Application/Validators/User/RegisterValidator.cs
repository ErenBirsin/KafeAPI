using FluentValidation;
using KafeAPI.Application.Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KafeAPI.Application.Validators.User
{
    public class RegisterValidator : AbstractValidator<RegisterDto>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("İsim alanı boş geçilemez.")
                .MinimumLength(2)
                .WithMessage("İsim alanı en az 2 karakter olmalıdır.");
            RuleFor(x => x.Surname)
                .NotEmpty()
                .WithMessage("Soyisim alanı boş geçilemez.")
                .MinimumLength(2)
                .WithMessage("Soyisim alanı en az 2 karakter olmalıdır.");
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email alanı boş geçilemez.")
                .EmailAddress()
                .WithMessage("Geçersiz email adresi.");
            //RuleFor(x => x.Password)
            //    .NotEmpty()
            //    .WithMessage("Parola alanı boş geçilemez.")
            //    .MinimumLength(6)
            //    .WithMessage("Parola alanı en az 6 karakter olmalıdır.")
            //     .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{6,}$")
            //    .WithMessage("Parola en az bir büyük harf, bir küçük harf ve bir rakam içermelidir.");


        }
    }
}
