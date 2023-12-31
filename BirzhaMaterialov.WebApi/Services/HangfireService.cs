﻿using BirzhaMaterialov.Application.Materials.Commands.UpdateMaterialsPrices;
using BirzhaMaterialov.Application.Materials.Queries.GetMaterials;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BirzhaMaterialov.WebApi.Services
{
    /// <summary>
    /// Service for Application command and queries execution by Hangfire jobs.
    /// </summary>
    public class HangfireService
    {
        private IMediator? _mediator;

        public HangfireService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public void UpdateMaterialsPrices()
        {
            _mediator!.Send(new UpdateMaterialsPricesCommand()).GetAwaiter().GetResult();
        }
    }
}
