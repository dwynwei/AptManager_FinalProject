using DataTransferObject.User;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Configuration.Validator.UserRequest
{
    public class UpdateHomeOwnerRequestValidation : AbstractValidator<UpdateHomeOwnerRequest>
    {
        public UpdateHomeOwnerRequestValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim Alanı Boş Olamaz");
            RuleFor(x => x.Name).Matches("[a-z][A-Z]").WithMessage("Girilen İsim Alanı Formatı Geçerli Değil");

            RuleFor(x => x.LastName).NotEmpty().WithMessage("Soy İsim Alanı Boş Olamaz");
            RuleFor(x => x.LastName).Matches("[a-z][A-Z]").WithMessage("Girilen Soy İsim Alanı Formatı Geçerli Değil");

            RuleFor(x => x.NationalityId).NotEmpty().WithMessage("Kimlik Numarası Alanı Boş Olamaz");
            RuleFor(x => x.NationalityId).Matches("^[1-9]{1}[0-9]{9}[02468]{1}$").WithMessage("Girilen Kimlik Numarası Şablonu Doğru Değil!");

            RuleFor(x => x.Email).NotEmpty().WithMessage("E-Posta Alanı Boş Olamaz");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Girilen E-Posta Alanı Formatı Geçerli Değil");

            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Telefon Numarası Alanı Boş Olamaz");
            RuleFor(x => x.PhoneNumber).Matches("^\\+?[1-9][0-9]{7,14}$").WithMessage("Girilen Telefon Numarası Şablonu Geçerli Değildir.");

            RuleFor(x => x.CarPlateId).Matches("/^$|^(0[1-9]|[1-7][0-9]|8[01])(([A-PR-VYZ])(\\d{4,5})|([A-PR-VYZ]{2})(\\d{3,4})|([A-PR-VYZ]{3})(\\d{2,3}))$/").When(x => !string.IsNullOrEmpty(x.CarPlateId)).WithMessage("Girilen Plaka Alanı Formatı Geçerli Değil örn: 34-FF-528 ");
        }
    }
}
