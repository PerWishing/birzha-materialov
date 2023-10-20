using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirzhaMaterialov.Application.Sellers.Commands.UpdateSeller
{
    public class UpdateSellerCommandValidator:AbstractValidator<UpdateSellerCommand>
    {
        public UpdateSellerCommandValidator()
        {
            RuleFor(updateSellerCommand => updateSellerCommand.Name).NotEmpty();
        }
    }
}
