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
                Console.WriteLine("");
                Console.WriteLine("1. Carregar dados do arquivo JSON");
                Console.WriteLine("2. Cadastrar novo carro");
                Console.WriteLine("3. Entrar com novo serviço");
                Console.WriteLine("0. Exit");
                Console.Write("Select an option: ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        var jsonInsertResult = controller.InsertCarsByJson(filePath);
                        Console.WriteLine($"{(jsonInsertResult ? "Registros Inseridos com sucesso!" : "Registros não inseridos...")}");
                        break;
                    case "2":
                        var carInsertResult = controller.InsertCar(InputCarInfo());
                        Console.WriteLine($"{(carInsertResult != string.Empty ? "Carro cadastrado com sucesso!" : "Registro não inserido...")}");
                        break;
                    case "3":
                        var serviceInsertResult = controller.InsertCarService(InputCarServiceInfo());
                        Console.WriteLine($"{(serviceInsertResult > 0 ? "Serviço cadastrado com sucesso!" : "Registro não inserido...")}");
                        break;
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

        static Car InputCarInfo()
        {
            Console.Write("Cadastro de novo carro:\n");
         
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

        static CarService InputCarServiceInfo()
        {
            Console.Write("Entrada de novo serviço:\n");

            Console.Write("Digite a polaca do carro: ");
            string carPlate = Console.ReadLine();
            
            Console.Write("Qual a descrição do serviço: ");
            string descricaoServico = Console.ReadLine();

            return new(); // TODO: Regra de negócio para inserção do serviço e relacionar ao carro
        }
    }
}
