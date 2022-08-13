using DataTransferObject.Building.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Configuration.Validator.BuildingRequest
{
    public class UpdateBuildingInformationRequestValidator : AbstractValidator<UpdateBuildingInformationRequest>
    {
        public UpdateBuildingInformationRequestValidator()
        {
            RuleFor(x => x.HomeType).NotEmpty().WithMessage("Ev Tipi Boş Olamaz Örn:2+1");
            RuleFor(x => x.HomeType).Matches("^\\d+\\+^\\d+\\$").WithMessage("Girilen Ev Tipi Formatı Geçerli Değil");

            RuleFor(x => x.Floor).Matches("[0-9]").MaximumLength(3).WithMessage("Girilen Kat Numarası Formatı Geçerli Değil Veya 3 Basamaktan Fazla Kat Numarası Girilemez");

            RuleFor(x => x.DoorNumber).Matches("[0-9]").MaximumLength(3).WithMessage("Girilen Kapı Numarası Formatı Geçerli Değil Veya 3 Basamaktan Fazla Kapı Numarası Girilemez");

            //RuleFor(x => x.User.Name).NotEmpty().WithMessage("İsim Alanı Boş Olamaz");
            //RuleFor(x => x.User.Name).Matches("[a-z][A-Z]").WithMessage("Girilen İsim Alanı Formatı Geçerli Değil");

            //RuleFor(x => x.User.LastName).NotEmpty().WithMessage("Soy İsim Alanı Boş Olamaz");
            //RuleFor(x => x.User.LastName).Matches("[a-z][A-Z]").WithMessage("Girilen Soy İsim Alanı Formatı Geçerli Değil");
        }
    }
}
