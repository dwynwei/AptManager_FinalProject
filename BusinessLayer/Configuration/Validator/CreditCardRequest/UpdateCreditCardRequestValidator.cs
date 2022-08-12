using DataTransferObject.CreditCard;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Configuration.Validator.CreditCardRequest
{
    public class UpdateCreditCardRequestValidator:AbstractValidator<UpdateCreditCardRequest>
    {
        public UpdateCreditCardRequestValidator()
        {
            RuleFor(x => x.ExpireMonth).NotNull().WithMessage("Son Kullanım Tarihi Ay Bölümü Boş Olamaz");
            RuleFor(x => x.ExpireYear).NotNull().WithMessage("Son Kullanım Tarihi Yıl Bölümü Boş Olamaz");
            RuleFor(x => x.CardNumber).NotNull().WithMessage("Kart Numarası Alanı Boş Geçilemez");
            RuleFor(x => x.Name).NotNull().WithMessage("İsim Alanı Boş Olamaz");
            RuleFor(x => x.LastName).NotNull().WithMessage("İsim Alanı Boş Olamaz");
            RuleFor(x => x.CVC).NotNull().WithMessage("CVC Alanı Boş Olamaz");

            RuleFor(x => x.CardNumber).Matches("([0-9]+(-[0-9]+)+)").WithMessage("Kart Numara Formatı Doğru Değil");
            RuleFor(x => x.CVC).Matches("^\\d{3}$").WithMessage("CVC Formatı Doğru Değil");
            RuleFor(x => x.Name).Matches("^[a-zA-ZğüşöçİĞÜŞÖÇ]*").WithMessage("İsim Formatı Doğru Değil");
            RuleFor(x => x.LastName).Matches("^[a-zA-ZğüşöçİĞÜŞÖÇ]*").WithMessage("İsim Formatı Doğru Değil");
        }
    }
}
