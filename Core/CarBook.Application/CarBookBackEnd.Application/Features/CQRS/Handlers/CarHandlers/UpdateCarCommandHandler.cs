﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarBookBackEnd.Application.Features.CQRS.Commands.BrandCommands;
using CarBookBackEnd.Application.Features.CQRS.Commands.CarCommands;
using CarBookBackEnd.Application.Interfaces;
using CarBookBackEnd.Domain.Entities;

namespace CarBookBackEnd.Application.Features.CQRS.Handlers.CarHandlers
{
    public class UpdateCarCommandHandler
    {
        private readonly IRepository<Car> _repository;
        public UpdateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateCarCommand command)
        {
            var values = await _repository.GetByIdAsync(command.BrandID);
            values.Fuel = command.Fuel;
            values.Transmission = command.Transmission;
            values.BigImageUrl = command.BigImageUrl;
            values.BrandID = command.BrandID;
            values.CoverImageUrl = command.CoverImageUrl;
            values.Km = command.Km;
            values.Luggage = command.Luggage;
            values.Model = command.Model;
            values.Seat = command.Seat;
            await _repository.UpdateAsync(values);
        }
    }
}