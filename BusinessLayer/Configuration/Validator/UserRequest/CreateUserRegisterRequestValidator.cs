using DataTransferObject.User.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Configuration.Validator.UserRequest
{
    public class CreateUserRegisterRequestValidator : AbstractValidator<CreateUserRegisterRequest>
    {
        public CreateUserRegisterRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim Alanı Boş Olamaz");

            RuleFor(x => x.LastName).NotEmpty().WithMessage("Soy İsim Alanı Boş Olamaz");

            RuleFor(x => x.NationalityId).NotEmpty().WithMessage("Kimlik Numarası Alanı Boş Bırakılamaz.");
            RuleFor(x => x.NationalityId).Matches("^[1-9]{1}[0-9]{9}[02468]{1}$").WithMessage("Girilen Kimlik Numarası Şablonu Doğru Değil!");

            RuleFor(x => x.UserPassword).NotEmpty().WithMessage("Şifre Numarası Alanı Boş Bırakılamaz.");
            RuleFor(x => x.UserPassword).Matches("^(?=.*[A-Za-z])(?=.*\\d)(?=.*[@$!%*#?&])[A-Za-z\\d@$!%*#?&]{6,}$").WithMessage("Şifre En Az 6 Karakter, en az bir harf ve bir özel karakter içermelidir.");

            RuleFor(x => x.VerifyPassword).Equal(x => x.UserPassword).WithMessage("Doğrulamak için girilen şifre Ana Şifre ile eşleşmiyor");
        }
    }
}
