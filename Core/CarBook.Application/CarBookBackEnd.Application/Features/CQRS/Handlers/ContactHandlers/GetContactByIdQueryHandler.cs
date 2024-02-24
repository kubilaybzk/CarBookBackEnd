using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarBookBackEnd.Application.Features.CQRS.Queries.ContactQueries;
using CarBookBackEnd.Application.Features.CQRS.Results.ContactResults;
using CarBookBackEnd.Application.Interfaces;
using CarBookBackEnd.Domain.Entities;

namespace CarBookBackEnd.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class GetContactByIdQueryHandler
    {
        private readonly IRepository<Contact> _repository;
        public GetContactByIdQueryHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }
        public async Task<GetContactByIdQueryResult> Handle(GetContactByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);
            return new GetContactByIdQueryResult
            {
                ContactID = values.ContactID,
                Name = values.Name,
                Email = values.Email,
                Subject = values.Subject,
                SendDate = values.SendDate,
                Message = values.Message
            };
        }
    }
}
