using BirzhaMaterialov.Application.Materials.Commands.CreateMaterial;
using BirzhaMaterialov.Application.Materials.Commands.DeleteMaterial;
using BirzhaMaterialov.Application.Materials.Commands.UpdateMaterial;
using BirzhaMaterialov.Application.Materials.Queries.GetMaterial;
using BirzhaMaterialov.Application.Materials.Queries.GetMaterials;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BirzhaMaterialov.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class MaterialController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<MaterialsVm>> GetAll()
        {
            var vm = await Mediator.Send(new GetMaterialsQuery());

            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MaterialVm>> Get(int id)
        {
            var query = new GetMaterialQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateMaterialCommand command)
        {
            var materialId = await Mediator.Send(command);
            return Created(materialId.ToString(), materialId);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateMaterialCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteMaterialCommand
            {
                Id = id,
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
