using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirzhaMaterialov.Application.Materials.Commands.CreateMaterial
{
    public class CreateMaterialCommandValidator : AbstractValidator<CreateMaterialCommand>
    {
        public CreateMaterialCommandValidator()
        {
            RuleFor(createMaterialCommand => createMaterialCommand.Name).NotEmpty();
            RuleFor(createMaterialCommand => createMaterialCommand.Price).GreaterThanOrEqualTo(0);
        }
    }
}
