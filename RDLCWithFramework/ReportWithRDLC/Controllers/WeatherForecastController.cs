using AspNetCore.Reporting;
using Microsoft.AspNetCore.Mvc;
using Report;

namespace ReportWithRDLC.Controllers
{
    //[ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly IWebHostEnvironment _webHostEnvironment;
        //protected readonly IUnitOfWorkRepository _iUnitOfWorkRepository;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;

            _webHostEnvironment = webHostEnvironment;
            // _iUnitOfWorkRepository = iUnitOfWorkRepository;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        [HttpGet(Name = "GetReport")]
        public IActionResult GetReport()
        {
            var path = $"{_webHostEnvironment.WebRootPath}\\Reports\\Report1.rdlc";
            //string path = Path.Combine(_webHostEnvironment.ContentRootPath, "bin", "Debug", "net6.0", "Reports", "Report.rdlc"); //or webHostEnvironment.WebRootPath if your report is in wwwroot folder

            //var userList = _iUnitOfWorkRepository.Users.GetAll().Select(a => new
            //{
            //    a.FirstName,
            //    a.LastName,
            //    a.Email
            //}).ToList();
            //Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            //Encoding.GetEncoding("UTF-8");
            var userList = (new[] {
                new { FirstName = "Sam1", LastName = "P", Email = "sam1@gmail.com" } ,
            new { FirstName = "Sam2", LastName = "P", Email = "sam2@gmail.com" } ,
            new { FirstName = "Sam3", LastName = "P", Email = "sam3@gmail.com" } ,
                new { FirstName = "Sam4", LastName = "P", Email = "sam4@gmail.com" } }).ToList();

            LocalReport localReport = new LocalReport(path);

            localReport.AddDataSource("DataSet1", userList);
            var results = localReport.Execute(RenderType.Pdf);
            return File(results.MainStream, "application/pdf");
        }
        //[HttpGet(Name = "GetWeatherForecast")]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = Random.Shared.Next(-20, 55),
        //        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}
    }
}