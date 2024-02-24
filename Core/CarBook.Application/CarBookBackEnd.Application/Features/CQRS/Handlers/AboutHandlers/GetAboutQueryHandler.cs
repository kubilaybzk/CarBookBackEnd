using CarBookBackEnd.Application.Features.CQRS.Results.AboutResults;
using CarBookBackEnd.Application.Interfaces;
using CarBookBackEnd.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookBackEnd.Application.Features.CQRS.Handlers.AboutHandlers
{
    public class GetAboutQueryHandler
    {
        private readonly IRepository<About> _repository;

        public GetAboutQueryHandler(IRepository<About> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAboutQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetAboutQueryResult
            {
                AboutID = x.AboutID,
                Description = x.Description,
                Title = x.Title,
                ImageUrl = x.ImageUrl
            }).ToList();
        }
    }
}
