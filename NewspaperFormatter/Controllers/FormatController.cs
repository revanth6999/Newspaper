using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using NewspaperFormatter.Models.Concrete;
using NewspaperFormatter.Models.Interfaces;
using NewspaperFormatter.Models.Services;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace NewspaperFormatter.Controllers
{
    [ApiController]
    public class FormatController : ControllerBase
    {
        private readonly IHostEnvironment _environment;
        private IStreamReader _streamReader;
        private IConfiguration _config;
        private NewspaperFactoriesScanner _scanner;
        public FormatController(IConfiguration configuration, IHostEnvironment environment,
            IStreamReader streamReader, NewspaperFactoriesScanner scanner)
        {
            _config = configuration;
            _environment = environment;
            _streamReader = streamReader;
            _scanner = scanner;
        }

        [HttpPost]
        [Route("api/format")]
        public async Task<IActionResult> Format()
        {
            try
            {
                IFormFile file = Request.Form.Files[0];

                String NewspaperPrinterAddress = _config.GetValue<String>("NewspaperPrinterApiAddress");
                String inputFolderPath = _environment.ContentRootPath + _config.GetValue<String>("InputFolder");
                String inputFilePath = inputFolderPath + FileNameGenerator.getName(6) + _config.GetValue<String>("IoFileType");

                int choice, readabilityLevel, noOfCols, noOfRows, widthOfPage, columnSpacing;

                if (!int.TryParse(Request.Form["choice"], out choice))
                    choice = 1;
                if (!int.TryParse(Request.Form["noOfCols"], out noOfCols))
                    noOfCols = 3;
                if (!int.TryParse(Request.Form["noOfRows"], out noOfRows))
                    noOfRows = 20;
                if (!int.TryParse(Request.Form["widthOfPage"], out widthOfPage))
                    widthOfPage = 80;
                if (!int.TryParse(Request.Form["columnSpacing"], out columnSpacing))
                    columnSpacing = 3;
                if (!int.TryParse(Request.Form["readabilityLevel"], out readabilityLevel))
                    readabilityLevel = 2;

                if (!Directory.Exists(inputFolderPath))
                    Directory.CreateDirectory(inputFolderPath);

                if (file.Length > 0)
                {
                    using (var stream = System.IO.File.Create(inputFilePath))
                    {
                        await file.CopyToAsync(stream);
                    }
                }

                _streamReader.setPath(inputFilePath);
                String text = _streamReader.read();

                Content content = new Content(text);

                NewspaperProperties newspaperProperties =
                    new NewspaperProperties(noOfCols, noOfRows, widthOfPage,
                    (NewspaperProperties.ReadabilityLevel)readabilityLevel, columnSpacing);

                NewspaperMachine newspaperMachine = new NewspaperMachine(choice, content, newspaperProperties);
                Newspaper newspaper = newspaperMachine.getNewspaper();

                string newspaperString = JsonSerializer.Serialize(newspaper);

                PostRequestHandler postRequestHandler = new PostRequestHandler();

                HttpResponseMessage response = await postRequestHandler.send(NewspaperPrinterAddress, newspaperString);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return Ok("Newspaper printed!");
                }
                else
                    return NotFound("Newspaper printing failed!");

            }
            catch (ArgumentOutOfRangeException)
            {
                return BadRequest("Please attach input file!");
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
