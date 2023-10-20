using BirzhaMaterialov.Application.Sellers.Commands.CreateSeller;
using BirzhaMaterialov.Application.Sellers.Commands.DeleteSeller;
using BirzhaMaterialov.Application.Sellers.Commands.UpdateSeller;
using BirzhaMaterialov.Application.Sellers.Queries.GetSeller;
using BirzhaMaterialov.Application.Sellers.Queries.GetSellers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BirzhaMaterialov.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class SellerController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<SellersVm>> GetAll()
        {
            var vm = await Mediator.Send(new GetSellersQuery());

            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SellerVm>> Get(int id)
        {
            var query = new GetSellerQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateSellerCommand command)
        {
            var sellerId = await Mediator.Send(command);
            return Created(sellerId.ToString(), sellerId);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateSellerCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteSellerCommand
            {
                Id = id,
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
