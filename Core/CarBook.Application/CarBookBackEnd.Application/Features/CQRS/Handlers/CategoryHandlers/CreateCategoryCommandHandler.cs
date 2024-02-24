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
    public class CreateCategoryCommandHandler
    {
        private readonly IRepository<Category> _repository;
        public CreateCategoryCommandHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateCategoryCommand command)
        {
            await _repository.CreateAsync(new Category
            {
                Name = command.Name
            });
        }
    }
}
