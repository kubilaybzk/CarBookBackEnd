using CarBookBackEnd.Application.Features.CQRS.Commands.CarCommands;
using CarBookBackEnd.Application.Features.CQRS.Handlers.CarHandlers;
using CarBookBackEnd.Application.Features.CQRS.Queries.CarQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly CreateCarCommandHandler _createCarCommandHandler;
        private readonly GetCarByIdQueryHandler _getCarByIdQueryHandler;
        private readonly GetCarQueryHandler _getCarQueryHandler;
        private readonly UpdateCarCommandHandler _updateCarCommandHandler;
        private readonly RemoveCarCommandHandler _removeCarCommandHandler;
        private readonly GetCarWithBrandQueryHandler _getCarWithBrandQueryHandler;

        public CarsController(CreateCarCommandHandler createCarCommandHandler, GetCarByIdQueryHandler getCarByIdQueryHandler, GetCarQueryHandler getCarQueryHandler, UpdateCarCommandHandler updateCarCommandHandler, RemoveCarCommandHandler removeCarCommandHandler, GetCarWithBrandQueryHandler getCarWithBrandQueryHandler)
        {
            _createCarCommandHandler = createCarCommandHandler;
            _getCarByIdQueryHandler = getCarByIdQueryHandler;
            _getCarQueryHandler = getCarQueryHandler;
            _updateCarCommandHandler = updateCarCommandHandler;
            _removeCarCommandHandler = removeCarCommandHandler;
            _getCarWithBrandQueryHandler = getCarWithBrandQueryHandler;
        }

        [HttpGet("GetCarList")]
        public async Task<IActionResult> CarList()
        {
            var values = await _getCarQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("GetCarByid/{id}")]
        public async Task<IActionResult> GetCarByid(int id)
        {
            var value = await _getCarByIdQueryHandler.Handle(new GetCarByIdQuery(id));
            return Ok(value);
        }

        [HttpPost("CreateCar")]
        public async Task<IActionResult> CreateCar(CreateCarCommand command)
        {
            await _createCarCommandHandler.Handle(command);
            return Ok("Araba Bilgisi Eklendi");
        }

        [HttpDelete("RemoveCar/{id}")]
        public async Task<IActionResult> RemoveCar(int id)
        {
            await _removeCarCommandHandler.Handle(new RemoveCarCommand(id));
            return Ok("Araba Bilgisi Silindi");
        }

        [HttpPut("UpdateCar")]
        public async Task<IActionResult> UpdateCar(UpdateCarCommand command)
        {
            await _updateCarCommandHandler.Handle(command);
            return Ok("Araba Bilgisi Güncellendi");
        }


        [HttpGet("GetCarWithBrand")]
        public async Task<IActionResult> GetCarWithBrand()
        {
            var value =  _getCarWithBrandQueryHandler.Handle();
            return Ok(value);
        }

    }
}
