using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarBookBackEnd.Application.Features.CQRS.Results.BrandResults;
using CarBookBackEnd.Application.Features.CQRS.Results.CategoryResults;
using CarBookBackEnd.Application.Interfaces;
using CarBookBackEnd.Domain.Entities;

namespace CarBookBackEnd.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class GetCategoryQueryHandler
    {
        private readonly IRepository<Category> _repository;
        public GetCategoryQueryHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetCategoryQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetCategoryQueryResult
            {
                Name = x.Name,
                CategoryID = x.CategoryID
            }).ToList();
        }
    }
}
