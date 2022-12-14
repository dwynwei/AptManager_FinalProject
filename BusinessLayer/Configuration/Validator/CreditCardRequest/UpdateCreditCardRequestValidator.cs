using DataTransferObject.CreditCard;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Configuration.Validator.CreditCardRequest
{
    /*
     * Fluent Validation Patterns For Each CreditCard Entity if Needed
     */
    public class UpdateCreditCardRequestValidator:AbstractValidator<UpdateCreditCardRequest>
    {
        public UpdateCreditCardRequestValidator()
        {
            RuleFor(x => x.expireDate).NotNull().WithMessage("Son Kullanım Tarihi Bölümü Boş Olamaz");
            RuleFor(x => x.CardNumber).NotNull().WithMessage("Kart Numarası Alanı Boş Geçilemez");
            RuleFor(x => x.Name).NotNull().WithMessage("İsim Alanı Boş Olamaz");
            RuleFor(x => x.LastName).NotNull().WithMessage("İsim Alanı Boş Olamaz");
            RuleFor(x => x.CVC).NotNull().WithMessage("CVC Alanı Boş Olamaz");

            RuleFor(x => x.CardNumber).Matches("([0-9]+(-[0-9]+)+)").WithMessage("Kart Numara Formatı Doğru Değil");
            RuleFor(x => x.CVC).Matches("^\\d{3}$").WithMessage("CVC Formatı Doğru Değil");
            RuleFor(x => x.Name).Matches("^[a-zA-ZğüşöçİĞÜŞÖÇ]*").WithMessage("İsim Formatı Doğru Değil");
            RuleFor(x => x.LastName).Matches("^[a-zA-ZğüşöçİĞÜŞÖÇ]*").WithMessage("İsim Formatı Doğru Değil");
            RuleFor(x => x.expireDate).Matches("^(0?[1-9]|[1][0-2])\\.[0-9]+").WithMessage("Tarih Formatı Yanlıştır Lütfen Düzeltiniz. Örn: 06.22");
            RuleFor(x => x.expireDate).Must(isDateGreater).WithMessage("Verilen Tarih Bugünün Tarihinden Eskidir. Lütfen Geçerli Bir Tarih Aralığı Giriniz");
        }

        protected bool isDateGreater(string givenDate)
        {
            bool flag = false;
            string current = DateTime.Now.ToString("MM.yy");
            var currentDate = DateTime.ParseExact(current, "MM.yy", CultureInfo.InvariantCulture);
            var gDate = DateTime.ParseExact(givenDate, "MM.yy", CultureInfo.InvariantCulture);

            if (gDate > currentDate)
            {
                flag = true;
            }

            return flag;
        }
    }
}
