using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookBackEnd.Application.Features.CQRS.Queries.AboutQueries
{
    public class GetAboutByIdQuery
    {
        //Bize bir id değeri gerekiyor yani id değerine göre biz bir listeleme yapacağız
        public GetAboutByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
