using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarBookBackEnd.Application.Features.CQRS.Commands.CategoryCommands;
using CarBookBackEnd.Application.Interfaces;
using CarBookBackEnd.Domain.Entities;

namespace CarBookBackEnd.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class RemoveCategoryCommandHandler
    {
        private readonly IRepository<Category> _repository;
        public RemoveCategoryCommandHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveCategoryCommand command)
        {
            var value = await _repository.GetByIdAsync(command.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
