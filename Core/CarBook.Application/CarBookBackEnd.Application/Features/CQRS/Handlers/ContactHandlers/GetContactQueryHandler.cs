using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarBookBackEnd.Application.Features.CQRS.Results.ContactResults;
using CarBookBackEnd.Application.Interfaces;
using CarBookBackEnd.Domain.Entities;

namespace CarBookBackEnd.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class GetContactQueryHandler
    {
        private readonly IRepository<Contact> _repository;
        public GetContactQueryHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetContactQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetContactQueryResult
            {
                ContactID = x.ContactID,
                Name = x.Name,
                Email = x.Email,
                Message = x.Message,
                SendDate = x.SendDate,
                Subject = x.Subject
            }).ToList();
        }
    }
}
