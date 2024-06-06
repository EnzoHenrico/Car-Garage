using Controllers;

namespace ExtracaoRelatorios
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var path = @"C:\Garagem\";
            var carsFileName = "cars.xml";
            var servicesFileName = "services.xml";
            var carServicesFileName = "carServices.xml";
            var controller = new ReportsController();

            // create
            var t1 = new Thread(() =>
            {
                var result = controller.CreateCarsReport(path, carsFileName);
                Console.WriteLine($"{(result ? carsFileName + " criado com sucesso..." : "Erro ao criar " + carsFileName)}");
            });
            var t2 = new Thread(() =>
            {
                var result = controller.CreateServicesReport(path, servicesFileName);
                Console.WriteLine($"{(result ? servicesFileName + " criado com sucesso..." : "Erro ao criar " + servicesFileName)}");
            });
            var t3 = new Thread(() =>
            {
                var result = controller.CreateCarServiceReport(path, carServicesFileName);
                Console.WriteLine($"{(result ? carServicesFileName + " criado com sucesso..." : "Erro ao criar " + carServicesFileName)}");
            });

            // start
            t1.Start();
            t2.Start();
            t3.Start();

            // wait
            t1.Join();
            t2.Join();
            t3.Join();
        }
    }
}
