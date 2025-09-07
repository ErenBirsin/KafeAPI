using FluentValidation;
using KafeAPI.Application.Dtos.CafeInfoDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KafeAPI.Application.Validators.CafeInfo
{
    public class AddCafeInfoValidate : AbstractValidator<CreateCafeInfoDto>
    {
        public AddCafeInfoValidate()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Kafe adı boş olamaz.")
            .MaximumLength(100).WithMessage("Kafe adı en fazla 100 karakter olabilir.");
            RuleFor(x => x.Address)
                .NotEmpty()
                .WithMessage("Adres boş olamaz.")
                .MaximumLength(500).WithMessage("Kafe adresi en fazla 500 karakter olabilir.");
            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .WithMessage("Kafe telefon numarası boş olamaz.")
                .Matches(@"^\+?[0-9]{10,15}$").WithMessage("Kafe telefon numarası geçerli bir formatta olmalı.");
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email boş olamaz.")
                .EmailAddress()
                .WithMessage("Kafe telefon numarası geçerli bir formatta email adresi olmalı.");
            RuleFor(x => x.OpeningHours)
                .NotEmpty()
                .WithMessage("Çalışma saatleri boş olamaz.");
        }
    }
}
