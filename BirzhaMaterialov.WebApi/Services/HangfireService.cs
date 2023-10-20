using BirzhaMaterialov.Application.Materials.Queries.GetMaterials;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BirzhaMaterialov.WebApi.Services
{
    public class HangfireService
    {
        private IMediator? _mediator;

        public HangfireService(IMediator mediator)
        {
            _mediator = mediator;
        }
        //test
        public void SetUpdateDbEveryDay()
        {
            var vm = _mediator!.Send(new GetMaterialsQuery()).GetAwaiter().GetResult();
            Console.WriteLine($"Count: {vm.Materials!.Count}");
        }
    }
}
