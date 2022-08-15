using DataTransferObject.Building.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Configuration.Validator.BuildingRequest
{
    /*
     * Fluent Validation Patterns For Each Home Entity if Needed
     */
    public class CreateBuildingInformationRequestValidator : AbstractValidator<CreateBuildingInformationRequest>
    {
        public CreateBuildingInformationRequestValidator()
        {
            RuleFor(x => x.HomeType).NotEmpty().WithMessage("Ev Tipi Boş Olamaz Örn:2+1");
            RuleFor(x => x.HomeType).Matches("^[0-7]+\\+[0-2]+$").WithMessage("Girilen Ev Tipi Formatı Geçerli Değil");

            RuleFor(x => x.Floor).Matches("[0-9]").MaximumLength(3).WithMessage("Girilen Kat Numarası Formatı Geçerli Değil Veya 3 Basamaktan Fazla Kat Numarası Girilemez");

            RuleFor(x => x.DoorNumber).Matches("[0-9]").MaximumLength(3).WithMessage("Girilen Kapı Numarası Formatı Geçerli Değil Veya 3 Basamaktan Fazla Kapı Numarası Girilemez");

            //RuleFor(x => x.User.Name).NotEmpty().WithMessage("İsim Alanı Boş Olamaz");
            //RuleFor(x => x.User.Name).Matches("^[a-zA-ZğüşöçİĞÜŞÖÇ]*").WithMessage("Soy İsim Formatı Doğru Değil");

            //RuleFor(x => x.HomeOwner.LastName).NotEmpty().WithMessage("Soy İsim Alanı Boş Olamaz");
            //RuleFor(x => x.User.LastName).Matches("^[a-zA-ZğüşöçİĞÜŞÖÇ]*").WithMessage("Soy İsim Formatı Doğru Değil");
        }
    }
}
