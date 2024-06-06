using Services;

namespace Controllers
{
    public class ReportsController
    {
        private readonly ReportsService _reportsService = new();

        public bool CreateCarsReport(string path, string file)
        {
            var reportData = _reportsService.GetAllCars();
            var reportXml = _reportsService.GenerateCarsReportXml(reportData);
            return _reportsService.SaveXml(path, file, reportXml);
        }

        public bool CreateServicesReport(string path, string file)
        {
            var reportData = _reportsService.GetAllServices();
            var reportXml = _reportsService.GenerateServiceReportXml(reportData);
            return _reportsService.SaveXml(path, file, reportXml);
        }

        public bool CreateCarServiceReport(string path, string file)
        {
            var reportData = _reportsService.GetAllCarServices();
            var reportXml = _reportsService.GenerateCarServiceReportXml(reportData);
            return _reportsService.SaveXml(path, file, reportXml);
        }
    }
}
