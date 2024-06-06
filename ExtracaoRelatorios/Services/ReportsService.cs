using System.Xml.Linq;
using Models;
using Repositories;

namespace Services
{
    public class ReportsService
    {
        private readonly ReportsRepository _reportsRepository = new();

        public List<Car>? GetAllCars()
        {
            return _reportsRepository.GetAllCars();
        }

        public List<Service>? GetAllServices()
        {
            return _reportsRepository.GetAllServices();
        }

        public List<CarService>? GetAllCarServices()
        {
            return _reportsRepository.GetAllCarServices();
        }

        public string GenerateCarsReportXml(List<Car> cars)
        {
            var xml = new XElement("Carros",
                from car in cars
                select new XElement("Carro",
                    new XElement("Placa", car.Plate),
                    new XElement("Nome", car.Name),
                    new XElement("AnoModelo", car.YearModel),
                    new XElement("AnoFabricacao", car.YearModel),
                    new XElement("Cor", car.Color)
                )
            );

            return xml.ToString();
        }

        public string GenerateServiceReportXml(List<Service> services)
        {
            var xml = new XElement("Servicos",
                from service in services
                select new XElement("Sevico",
                    new XElement("ID", service.Id),
                    new XElement("Descricao", service.Description)
                )
            );

            return xml.ToString();
        }

        public string GenerateCarServiceReportXml(List<CarService> carServices)
        {
            var xml = new XElement("OrdensDeServico",
                from carService in carServices
                select new XElement("CarroServico",
                    new XElement("ID", carService.Id),
                    new XElement("Carro",
                            new XElement("Placa", carService.Car.Plate),
                            new XElement("Nome", carService.Car.Name),
                            new XElement("AnoModelo", carService.Car.YearModel),
                            new XElement("AnoFabricacao", carService.Car.YearModel),
                            new XElement("Cor", carService.Car.Color)
                        ),
                    new XElement("Servico", 
                            new XElement("ID", carService.Service.Id),
                            new XElement("Descricao", carService.Service.Description)
                        ),
                    new XElement("Status", carService.Status ? "Ativo" : "Inativo")
                )
            );

            return xml.ToString();
        }

        public bool SaveXml(string path, string fileName, string xml)
        {
            bool result;
            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                var xmlElement = XElement.Parse(xml);
                xmlElement.Save(path + fileName);
                result = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("XML ERROR: " + ex.Message);
                result = false;
            }
            return result;
        }
    }
}
