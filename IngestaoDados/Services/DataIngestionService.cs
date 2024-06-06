using Models;
using Newtonsoft.Json;
using Repositories;

namespace Services
{
    public class DataIngestionService
    {
        private readonly CarIngestionRepository _carIngestionRepository = new();
        private readonly ServiceIngestionRepository _serviceIngestionRepository = new();
        private readonly CarServiceIngestionRepository _carServiceIngestionRepository = new();

        public bool InsertCarsByJson(string filePath)
        {
            bool result;
            try
            {
                var jsonCars = string.Empty;
                using (var reader = new StreamReader(filePath))
                {
                    jsonCars = reader.ReadToEnd();
                }

                var cars = JsonConvert.DeserializeObject<List<Car>>(jsonCars);
                foreach (var car in cars)
                {
                    _carIngestionRepository.InsertOne(car);
                }
                result = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("FILE ERROR: " + ex.Message);
                result = false;
            }
            return result;
        }

        public string InsertCar(Car car)
        {
            return _carIngestionRepository.InsertOne(car);
        }

        public int InsertService(Service service)
        {
            return _serviceIngestionRepository.InsertOne(service);
        }

        public int InsertCarService(CarService carService)
        {
            return _carServiceIngestionRepository.InsertOne(carService);
        }

        public List<Service>? GetAllServices()
        {
            return _serviceIngestionRepository.SelectAll();
        }

        public List<CarService>? GetAllCarServices()
        {
            return _carServiceIngestionRepository.SelectAll();
        }
    }
}
