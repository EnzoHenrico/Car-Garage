using System.Threading.Channels;
using Controllers;
using Models;

namespace IngestaoDados
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var controller = new DataIngestionController();
            var filePath = @"C:\Garagem\cars.json";
            while (true)
            {
                Console.WriteLine("Entrada de dados para os serviços: \n");
                Console.WriteLine("1. Carregar dados do arquivo JSON");
                Console.WriteLine("2. Cadastrar novo carro");
                Console.WriteLine("3. Entrar com nova ordem de serviço");
                Console.WriteLine("4. Cadastrar novo serviço");
                Console.WriteLine("0. Exit");
                var services = controller.GetAllServices();
                if (services.Count < 1)
                {
                    Console.WriteLine("\nAVISO: Não há nenhum serviço cadastrado, cadastre pelo menos 1 para criar ordens de serviço\n");
                }
                Console.Write("Selecione uma opção: ");
                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        var jsonInsertResult = controller.InsertCarsByJson(filePath);
                        Console.WriteLine($"{(jsonInsertResult ? "Registros Inseridos com sucesso!" : "Registros não inseridos...")}");
                        break;
                    case "2":
                        Console.WriteLine("Cadastro de novo carro:\n");
                        var carInsertResult = controller.InsertCar(InputCar());
                        Console.WriteLine($"{(carInsertResult != string.Empty ? "Carro cadastrado com sucesso!" : "Registro não inserido...")}");
                        break;
                    case "3":
                        Console.WriteLine("Entrada de ordem de serviço:\n Servicos disponiveis:");
                        services.ForEach(service => Console.WriteLine("- " + service));
                        var carServiceInsertResult = controller.InsertCarService(InputCarService());
                        Console.WriteLine($"{(carServiceInsertResult != 0 ? "Serviço cadastrado com sucesso!" : "Registro não inserido...")}");
                        break;
                    case "4":
                        Console.WriteLine("Cadastro de novo servico:\n");
                        var serviceInsertResult = controller.InsertService(InputService());
                        Console.WriteLine($"{(serviceInsertResult != 0 ? "Serviço cadastrado com sucesso!" : "Registro não inserido...")}");
                        return;
                    case "0":
                        Console.WriteLine("Saindo...");
                        return;
                    default:
                        Console.WriteLine("Opção Inválida, tente novamente...");
                        break;
                }
                Console.ReadKey();
            }
        }

        static Car InputCar()
        {
            Console.Write("Placa do carro: ");
            string plate = Console.ReadLine();

            Console.Write("Nome (Marca/Modelo): ");
            string name = Console.ReadLine();

            Console.Write("Ano (Modelo): ");
            int yearModel = int.Parse(Console.ReadLine());

            Console.Write("Ano (Fabricação): ");
            int yearProduction = int.Parse(Console.ReadLine());

            Console.Write("Cor do carro: ");
            string color = Console.ReadLine();

            return new Car { Plate = plate, Name = name, YearModel = yearModel, YearProduction = yearProduction, Color = color };
        }

        static Service InputService()
        {
            Console.Write("Descrição do serviço: ");
            string description = Console.ReadLine();

            return new Service {  Description = description };
        }

        static CarService InputCarService()
        {
            Console.Write("Digite a placa do carro que será feito o serviço: ");
            string carPlate = Console.ReadLine();
            
            Console.Write("Qual o id do servico: ");
            int serviceId = int.Parse(Console.ReadLine());

            return new()
            {
                Car = new Car { Plate = carPlate },
                Service = new Service { Id = serviceId },
                Status = false
            };
        }
    }
}
