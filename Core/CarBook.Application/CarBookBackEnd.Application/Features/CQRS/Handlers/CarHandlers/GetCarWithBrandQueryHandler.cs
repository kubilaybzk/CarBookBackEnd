using CarBookBackEnd.Application.Features.CQRS.Results.CarResults;
using CarBookBackEnd.Application.Interfaces;
using CarBookBackEnd.Application.Interfaces.CarInterfaces;
using CarBookBackEnd.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CarBookBackEnd.Application.Features.CQRS.Handlers.CarHandlers
{


    //Burada biz araba listesiyle beraber marka bilgilerinide göndermek istiyoruz.
    //var values = await _repository.GetAllAsync();

    #region LinkQ kullanarak bir birleştirme işlemi gerçekleştirebiliriz.

    //var values2 = await _repository2.GetAllAsync();
    //var result = from car in values
    //             join brand in values2 on car.BrandID equals brand.BrandID
    //             select car;



    //var SendResult= result.Select(x => new GetCarWithBrandQueryResult
    //{
    //    BrandName=x.Brand.Name,
    //    BrandID = x.BrandID,
    //    BigImageUrl = x.BigImageUrl,
    //    CarID = x.CarID,
    //    CoverImageUrl = x.CoverImageUrl,
    //    Fuel = x.Fuel,
    //    Km = x.Km,
    //    Luggage = x.Luggage,
    //    Model = x.Model,
    //    Seat = x.Seat,
    //    Transmission = x.Transmission
    //}).ToList();

    #endregion

    //Yada bu şekilde bir interface ile erişme sağlayabiliriz.

    public class GetCarWithBrandQueryHandler
    {
        private readonly ICarRepository _repository;

        public GetCarWithBrandQueryHandler(ICarRepository repository)
        {
            _repository = repository;
        }
        public List<GetCarWithBrandQueryResult> Handle()
        {
            var values = _repository.GetCarsListWithBrands();
            return values.Select(x => new GetCarWithBrandQueryResult
            {
                BrandName = x.Brand.Name,
                BrandID = x.BrandID,
                BigImageUrl = x.BigImageUrl,
                CarID = x.CarID,
                CoverImageUrl = x.CoverImageUrl,
                Fuel = x.Fuel,
                Km = x.Km,
                Luggage = x.Luggage,
                Model = x.Model,
                Seat = x.Seat,
                Transmission = x.Transmission
            }).ToList();
        }
    }

}

