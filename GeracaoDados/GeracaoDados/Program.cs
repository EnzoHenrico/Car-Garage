using Models;
using Newtonsoft.Json;

namespace GeracaoDados
{
    public class Program
    {
        private static List<string> CarNames = new()
        {
            "Fiat Uno",
            "Fiat Palio",
            "Fiat Siena",
            "Fiat Strada",
            "Chevrolet Celta",
            "Chevrolet Onix",
            "Chevrolet Prisma",
            "Chevrolet Spin",
            "Volkswagen Gol",
            "Volkswagen Fox",
            "Volkswagen Voyage",
            "Volkswagen Saveiro",
            "Volkswagen Polo",
            "Ford Ka",
            "Ford Fiesta",
            "Ford EcoSport",
            "Ford Ranger",
            "Renault Sandero",
            "Renault Logan",
            "Renault Duster",
            "Renault Kwid",
            "Honda Fit",
            "Honda Civic",
            "Honda HR-V",
            "Toyota Corolla",
            "Toyota Etios",
            "Hyundai HB20",
            "Hyundai Creta",
            "Nissan Kicks",
            "Jeep Renegade",
        };

        private static List<string> CarColors = new()
        {
            "Preto",
            "Branco",
            "Prata",
            "Cinza",
            "Vermelho",
            "Azul",
            "Verde",
            "Amarelo",
            "Marrom",
            "Bordô"
        };

        static void Main(string[] args)
        {
            // Cria nova lista de carros aleatórios
            var quantity = 30;
            var generatedCars = new List<Car>();
            for (int i = 0; i < quantity; i++)
            {
                var plate = GenerateRandomCarPlate();
                var name = CarNames[new Random().Next(0, CarNames.Count)];
                var yearModel = new Random().Next(1980, 2024);
                var yearProduction = yearModel - (new Random().Next(1, 2));
                var color = CarColors[new Random().Next(0, CarColors.Count)];

                while (generatedCars.Find(p => p.Plate == plate) != null)
                {
                    plate = GenerateRandomCarPlate();
                }

                generatedCars.Add(new Car()
                {
                    Plate = plate,
                    Name = name,
                    YearModel = yearModel,
                    YearProduction = yearProduction,
                    Color = color
                });
            }

            // Gera um Json e escreve o arquivo
            var path = @"C:\Garagem\";
            var fileName = "cars.json";
            try
            {
                var json = GenerateJson(generatedCars);
               
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                using var writer = new StreamWriter(path + fileName);
                writer.WriteLine(json);
                
                Console.WriteLine($"Criado arquivos com sucesso em: {path + fileName}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao criar arquivo: " + ex.Message);
                throw;
            }
        }

        static string GenerateJson(List<Car> cars)
        {
            return JsonConvert.SerializeObject(cars, Formatting.Indented);
        }

        static string GenerateRandomCarPlate()
        {
            var random = new Random();
            var letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var numbers = "0123456789";

            var position1= letters[random.Next(letters.Length)];
            var position2= letters[random.Next(letters.Length)];
            var position3= letters[random.Next(letters.Length)];
            var position4= numbers[random.Next(numbers.Length)];
            var position5= numbers[random.Next(numbers.Length)];
            var position6= numbers[random.Next(numbers.Length)];
            var position7= numbers[random.Next(numbers.Length)];

            return $"{position1}{position2}{position3}{position4}{position5}{position6}{position7}";
        }
    }
}
