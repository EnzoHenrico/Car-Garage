using Models;
using Newtonsoft.Json;
using Repositories;
using Services;

namespace Controllers
{
    public class DataIngestionController
    {
        private readonly DataIngestionService _carIngestionService = new();

        public bool InsertCarsByJson(string jsonCars)
        {
            return _carIngestionService.InsertCarsByJson(jsonCars);
        }

        public string InsertCar(Car car)
        {
            return _carIngestionService.InsertCar(car);
        }

        public int InsertService(Service service)
        {
            return _carIngestionService.InsertService(service);
        }

        public int InsertCarService(CarService carService)
        {
            return _carIngestionService.InsertCarService(carService);
        }
    }
}
