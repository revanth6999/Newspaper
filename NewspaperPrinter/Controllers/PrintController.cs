using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using NewspaperPrinter.Models.Concrete;
using NewspaperPrinter.Models.Interfaces;
using NewspaperPrinter.Models.Services;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Net.Http;

namespace NewspaperPrinter.Controllers
{

    [ApiController]
    public class PrintController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IHostEnvironment _environment;
        private readonly IStreamWriter _streamWriter;
        public PrintController(IConfiguration configuration, IHostEnvironment environment, IStreamWriter streamWriter)
        {
            _config = configuration;
            _environment = environment;
            _streamWriter = streamWriter;
        }

        [HttpPost]
        [Route("api/print")]
        public HttpResponseMessage Print()
        {
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                String outputFolderPath = _environment.ContentRootPath + "\\Outputs\\";
                String outputFilePath = outputFolderPath + FileNameGenerator.getName(6) + _config.GetValue<String>("IoFileType");

                var newsString = Request.Form["newspaper"];

                var newspaper = JsonConvert.DeserializeObject<Newspaper>(newsString);

                if (!Directory.Exists(outputFolderPath))
                    Directory.CreateDirectory(outputFolderPath);

                _streamWriter.setPath(outputFilePath);
                newspaper.printNewspaper(_streamWriter);

                response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception e)
            {
                response.StatusCode = HttpStatusCode.InternalServerError;

            }
            return response;
        }
    }
}

