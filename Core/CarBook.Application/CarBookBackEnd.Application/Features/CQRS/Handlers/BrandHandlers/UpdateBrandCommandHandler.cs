using CarBookBackEnd.Application.Interfaces;
using CarBookBackEnd.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarBookBackEnd.Application.Features.CQRS.Commands.BrandCommands;


namespace CarBookBackEnd.Application.Features.CQRS.Handlers.BrandHandlers
{
    public class UpdateBrandCommandHandler
    {
        private readonly IRepository<Brand> _repository;
        public UpdateBrandCommandHandler(IRepository<Brand> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateBrandCommand command)
        {
            var values = await _repository.GetByIdAsync(command.BrandID);
            values.Name = command.Name;
            await _repository.UpdateAsync(values);
        }
    }
}
