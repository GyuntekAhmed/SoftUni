﻿namespace FastFood.Core.Controllers
{
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using Data;
    using Models;
    using ViewModels.Positions;

    public class PositionsController : Controller
    {
        private readonly FastFoodContext context;
        private readonly IMapper mapper;

        public PositionsController(FastFoodContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreatePositionInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Error", "Home");
            }

            var position = mapper.Map<Position>(model);

            context.Positions.Add(position);

            context.SaveChanges();

            return RedirectToAction("All", "Positions");
        }

        public IActionResult All()
        {
            var positions = context.Positions
                .ProjectTo<PositionsAllViewModel>(mapper.ConfigurationProvider)
                .ToList();

            return View(positions);
        }
    }
}
