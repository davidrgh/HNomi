using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
//using WebApiCore.Models;
using System.IO;
using System.Data;
using FastReport.Utils;
using FastReport;
using FastReport.Export.Html;
using FastReport.Export.Pdf;
using HNomi.Utils;

namespace HNomi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        private readonly IHostingEnvironment _hostingEnvironment;

        public ValuesController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        Reports[] reportItems = new Reports[]
        {
        new Reports { Id = 1, ReportName = "informe.frx" },
        };


        // Attribute has required id parameter
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromQuery] ReportQuery query)
        {
            string mime = "application/" + query.Format; // MIME header with default value
                                                         // Find report
            Reports reportItem = reportItems.FirstOrDefault((p) => p.Id == id); // we get the value of the collection by id
            if (reportItem != null)
            {
              //  var contentRoot = configuration.GetValue<string>(WebHostDefaults.ContentRootKey);
                string webRootPath = _hostingEnvironment.ContentRootPath; // determine the path to the wwwroot folder
                string reportPath = (webRootPath + "/Utils/" + reportItem.ReportName); // determine the path to the report
                string resultPath = (webRootPath + "/Utils/prueba.pdf"); // determine the path to the report
                string dataPath = (webRootPath + "/App_Data/nwind.xml");// determine the path to the database
                using (MemoryStream stream = new MemoryStream()) // Create a stream for the report
                {
                    try
                    {
                        using (DataSet dataSet = new DataSet())
                        {
                            List<DatosPrueba> datos = new List<DatosPrueba>();
                            datos.Add(new DatosPrueba("nombre1"));
                            datos.Add(new DatosPrueba("nombre2"));
                            datos.Add(new DatosPrueba("nombre3"));
                            datos.Add(new DatosPrueba("nombre4"));

                            // Fill the source by data
                            //dataSet.ReadXml(dataPath);
                            // Turn on web mode FastReport
                            Config.WebMode = true;
                            using (Report report = new Report())
                            {
                                report.Load(reportPath); // Download the report
                                report.RegisterData(datos, "datos"); // Register data in the report
                                FastReport.DataBand band1 = report.FindObject("data1") as FastReport.DataBand;
                                report.GetDataSource("datos").Enabled = true;
                                band1.DataSource = report.GetDataSource("datos");
                                if (query.Parameter != null)
                                {
                                    report.SetParameterValue("Parameter", query.Parameter); // Set the value of the report parameter if the parameter value is passed to the URL
                                }
                                report.Prepare();//Prepare the report
                                                 // If pdf format is selected
                                if (query.Format == "pdf")
                                {
                                    // Export report to PDF
                                    PDFExport pdf = new PDFExport();
                                    // Use the stream to store the report, so as not to create unnecessary files
                                    report.Export(pdf, resultPath);
                                }
                                // If html report format is selected
                                else if (query.Format == "html")
                                {
                                    // Export Report to HTML
                                    HTMLExport html = new HTMLExport();
                                    html.SinglePage = true; // Single page report
                                    html.Navigator = false; // Top navigation bar
                                    html.EmbedPictures = true; // Embeds images into a document
                                    report.Export(html, stream);
                                    mime = "text/" + query.Format; // Override mime for html
                                }
                            }
                        }
                        // Get the name of the resulting report file with the necessary extension var file = String.Concat(Path.GetFileNameWithoutExtension(reportPath), ".", query.Format);
                        // If the inline parameter is true, then open the report in the browser
                        if (query.Inline)
                            return File(stream.ToArray(), mime);
                        else
                            // Otherwise download the report file 
                            return File(stream.ToArray(), mime, resultPath); // attachment
                    }
                    // Handle exceptions
                    catch (Exception ex)
                    {
                        return new BadRequestObjectResult(ex.Message);
                    }
                    finally
                    {
                        stream.Dispose();
                    }
                }
            }
            else
                return NotFound();
        }


    }



    public class ReportQuery
    {
        // Format of resulting report: png, pdf, html
        public string Format { get; set; }
        // Enable Inline preview in browser (generates "inline" or "attachment")
        public bool Inline { get; set; }
        // Value of "Parameter" variable in report
        public string Parameter { get; set; }
    }
}