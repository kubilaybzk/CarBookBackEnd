using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarBookBackEnd.Domain.Entities;

namespace CarBookBackEnd.Application.Interfaces.CarInterfaces
{
    public interface ICarRepository
    {
        List<Car> GetCarsListWithBrands();
        List<Car> GetLast5CarsWithBrands();
       
    }
}
