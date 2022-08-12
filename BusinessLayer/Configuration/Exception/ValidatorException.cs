using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Configuration.Exception
{
    public static class ValidatorException
    {
        public static void ThrowIfException(this FluentValidation.Results.ValidationResult validationResult)
        {
            if (validationResult.IsValid)
                return;

            var message = string.Join(',', validationResult.Errors.Select(x => x.ErrorMessage));
            throw new ValidationException(message); 
        }
    }
}
