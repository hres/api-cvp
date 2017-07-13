using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using cvpWebApi.Models;
using cvp;
using Newtonsoft.Json;
using System.Data;
using System.IO;
using System.Net.Http.Headers;
using System.Text;

namespace cvpWebApi.Controllers
{
    public class CSVController : ApiController
    {
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage DownloadCSV(string dataType, string lang)
        {
            DBConnection dbConnection = new DBConnection(lang);
            var jsonResult = string.Empty;
            var fileNameDate = string.Format("{0}{1}{2}",
                           DateTime.Now.Year.ToString(),
                           DateTime.Now.Month.ToString().PadLeft(2, '0'),
                           DateTime.Now.Day.ToString().PadLeft(2, '0'));
            var fileName = string.Format(dataType + "_{0}.csv", fileNameDate);
            byte[] outputBuffer = null;
            string resultString = string.Empty;
            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);

            var json = string.Empty;

            switch (dataType)
            {
                case "ingredient":
                    var ingredients = dbConnection.GetAllDrugProductIngredient(lang).ToList();
                    if (ingredients.Count > 0)
                    {
                        json = JsonConvert.SerializeObject(ingredients);

                    }
                    break;

                case "products":
                    var products = dbConnection.GetAllDrugProduct(lang).ToList();
                    if (products.Count > 0)
                    {
                        json = JsonConvert.SerializeObject(products);

                    }
                    break;

                case "gender":
                    var genders = dbConnection.GetAllGender(lang).ToList();
                    if (genders.Count > 0)
                    {
                        json = JsonConvert.SerializeObject(genders);

                    }
                    break;

                case "outcome":
                    var outcomes = dbConnection.GetAllOutcome(lang).ToList();
                    if (outcomes.Count > 0)
                    {
                        json = JsonConvert.SerializeObject(outcomes);

                    }
                    break;

                case "reaction":
                    var reactions = dbConnection.GetAllReaction(lang).ToList();
                    if (reactions.Count > 0)
                    {
                        json = JsonConvert.SerializeObject(reactions);

                    }
                    break;

                case "reportDrug":
                    var reportDrugs = dbConnection.GetAllReportDrug(lang).ToList();
                    if (reportDrugs.Count > 0)
                    {
                        json = JsonConvert.SerializeObject(reportDrugs);
                    }
                    break;

                case "reportLink":
                    var reportLinks = dbConnection.GetAllReportLink(lang).ToList();
                    if (reportLinks.Count > 0)
                    {
                        json = JsonConvert.SerializeObject(reportLinks);
                    }
                    break;

                case "reportType":
                    var reportTypes = dbConnection.GetAllReportType(lang).ToList();
                    if (reportTypes.Count > 0)
                    {
                        json = JsonConvert.SerializeObject(reportTypes);

                    }
                    break;

                case "report":
                    var reports = dbConnection.GetAllReport(lang).ToList();
                    if (reports.Count > 0)
                    {
                        json = JsonConvert.SerializeObject(reports);

                    }
                    break;

                case "drugName":
                    var drugNames = dbConnection.GetAllReportDrug(lang).ToList();
                    if (drugNames.Count > 0)
                    {
                        json = JsonConvert.SerializeObject(drugNames);

                    }
                    break;

                case "seriousness":
                    var seriousness = dbConnection.GetAllSeriousness(lang).ToList();
                    if (seriousness.Count > 0)
                    {
                        json = JsonConvert.SerializeObject(seriousness);

                    }
                    break;

                case "source":
                    var source = dbConnection.GetAllSource(lang).ToList();
                    if (source.Count > 0)
                    {
                        json = JsonConvert.SerializeObject(source);

                    }
                    break;

                case "info":
                    var info = dbConnection.GetAllReport(lang).ToList();
                    if (info.Count > 0)
                    {
                        json = JsonConvert.SerializeObject(info);

                    }
                    break;
            }

            if (!string.IsNullOrWhiteSpace(json))
            {
                DataTable dt = JsonConvert.DeserializeObject<DataTable>(json);
                if (dt.Rows.Count > 0)
                {
                    using (MemoryStream stream = new MemoryStream())
                    {
                        using (StreamWriter writer = new StreamWriter(stream))
                        {
                            UtilityHelper.WriteDataTable(dt, writer, true);
                            outputBuffer = stream.ToArray();
                            resultString = Encoding.UTF8.GetString(outputBuffer, 0, outputBuffer.Length);
                        }
                    }
                    result.Content = new StringContent(resultString);
                    result.Content.Headers.ContentType = new MediaTypeHeaderValue("text/csv");
                    result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment") { FileName = fileName };
                }
            }

            return result;
        }
    }
}
