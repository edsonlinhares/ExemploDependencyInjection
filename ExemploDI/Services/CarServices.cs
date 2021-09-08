using System;
using ExemploDI.Stores;
using Microsoft.Extensions.Logging;

namespace ExemploDI.Services
{
    public class CarServices
    {
        private readonly ICarStore _carStore;
        private readonly ILogger<CarServices> _logger;

        public CarServices(ICarStore carStore, ILogger<CarServices> logger)
        {
            _carStore = carStore;
            _logger = logger;
        }

        public void List()
        {
            _logger.LogTrace("List all cars");

            var cars = _carStore.List();

            foreach (var car in cars)
            {
                _logger.LogInformation($"Id: {car.Id}, Year: {car.Year}, Model: {car.Model}, Brand: {car.Brand}");
            }
        }

        public void Get(int id)
        {
            _logger.LogTrace($"Get car with id: {id}");

            var car = _carStore.Get(id);

            _logger.LogInformation($"Id: {car.Id}, Year: {car.Year}, Model: {car.Model}, Brand: {car.Brand}");
        }
    }
}
