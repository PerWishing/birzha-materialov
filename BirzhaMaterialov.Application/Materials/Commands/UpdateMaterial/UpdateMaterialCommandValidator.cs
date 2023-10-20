using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirzhaMaterialov.Application.Materials.Commands.UpdateMaterial
{
    public class UpdateMaterialCommandValidator:AbstractValidator<UpdateMaterialCommand>
    {
        public UpdateMaterialCommandValidator()
        {
            RuleFor(updateMaterialCommand => updateMaterialCommand.Name).NotEmpty();
            RuleFor(updateMaterialCommand => updateMaterialCommand.Price).GreaterThanOrEqualTo(0);
        }
    }
}
