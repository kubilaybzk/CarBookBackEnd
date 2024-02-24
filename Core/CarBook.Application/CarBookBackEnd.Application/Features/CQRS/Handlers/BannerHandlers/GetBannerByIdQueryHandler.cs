using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarBookBackEnd.Application.Features.CQRS.Queries.AboutQueries;
using CarBookBackEnd.Application.Features.CQRS.Queries.BannerQueries;
using CarBookBackEnd.Application.Features.CQRS.Results.AboutResults;
using CarBookBackEnd.Application.Features.CQRS.Results.BannerResults;
using CarBookBackEnd.Application.Interfaces;
using CarBookBackEnd.Domain.Entities;

namespace CarBookBackEnd.Application.Features.CQRS.Handlers.BannerHandlers
{
    public class GetBannerByIdQueryHandler
    {
        private readonly IRepository<Banner> _repository;
        public GetBannerByIdQueryHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }
        public async Task<GetBannerByIdQueryResult> Handle(GetBannerByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);
            return new GetBannerByIdQueryResult
            {
                BannerID = values.BannerID,
                Description = values.Description,
                Title = values.Title,
                VideoDescription = values.VideoDescription,
                VideoUrl = values.VideoUrl
            };
        }
    }
}
