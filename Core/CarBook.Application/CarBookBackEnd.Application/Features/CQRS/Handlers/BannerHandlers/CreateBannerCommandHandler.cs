using CarBookBackEnd.Application.Interfaces;
using CarBookBackEnd.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CarBookBackEnd.Application.Features.CQRS.Commands.BannerCommands;


namespace CarBookBackEnd.Application.Features.CQRS.Handlers.BannerHandlers
{
    public class CreateBannerCommandHandler
    {
        private readonly IRepository<Banner> _repository;
        public CreateBannerCommandHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateBannerCommand command)
        {
            await _repository.CreateAsync(new Banner
            {
                Description = command.Description,
                Title = command.Title,
                VideoDescription = command.VideoDescription,
                VideoUrl = command.VideoUrl
            });
        }
    }
}
