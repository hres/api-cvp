using cvpWebApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;

namespace cvp
{
    /// <summary>
    /// Summary description for Common
    /// </summary>
    public static class UtilityHelper
    {
        public static void SetDefaultCulture(string lang)
        {
            if (lang == "en")
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-CA");
                Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en-CA");
            }
            else
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("fr-FR");
                Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("fr-FR");
            }
        }

        public static List<Report> GetAllReportList(string lang)
        {
            var items = new List<Report>();
            var filteredList = new List<Report>();
            var json = string.Empty;

            // var postData = new Dictionary<string, string>();
            var dpdJsonUrl = string.Format("{0}&lang={1}", ConfigurationManager.AppSettings["dpdJsonUrl"].ToString(), lang);

            try
            {
                using (var webClient = new System.Net.WebClient())
                {
                    json = webClient.DownloadString(dpdJsonUrl);
                    if (!string.IsNullOrWhiteSpace(json))
                    {
                        items = JsonConvert.DeserializeObject<List<Report>>(json);

                    }
                }
            }
            catch (Exception ex)
            {
                var errorMessages = string.Format("UtilityHelper - GetJSonDataFromDPDAPI()- Error Message:{0}", ex.Message);
                ExceptionHelper.LogException(ex, errorMessages);
            }
            finally
            {

            }
            return items;
        }
        public static List<Report> GetReportByCriteria(string lang, string term)
        {
            var items = new List<Report>();
            var filteredList = new List<Report>();
            var json = string.Empty;
            var drugname = term;
            var reportJsonUrl = string.Format("{0}&drugname={1}&lang={2}", ConfigurationManager.AppSettings["reportJsonUrl"].ToString(), drugname, lang);
            try
            {
                using (var webClient = new System.Net.WebClient())
                {
                    json = webClient.DownloadString(reportJsonUrl);
                    if (!string.IsNullOrWhiteSpace(json))
                    {
                        items = JsonConvert.DeserializeObject<List<Report>>(json);
                    }
                }
            }
            catch (Exception ex)
            {
                var errorMessages = string.Format("UtilityHelper - GetReportByCriteria()- Error Message:{0}", ex.Message);
                ExceptionHelper.LogException(ex, errorMessages);
            }
            finally
            {

            }
            return items;
        }

        public static Report GetReportByID(string reportId, string lang)
        {
            // CertifySSL.EnableTrustedHosts();
            var item = new Report();
            var json = string.Empty;
            var postData = new Dictionary<string, string>();
            var reportJsonUrlbyID = string.Format("{0}&id={1}&lang={2}", ConfigurationManager.AppSettings["reportJsonUrl"].ToString(), reportId, lang);

            try
            {
                using (var webClient = new System.Net.WebClient())
                {
                    json = webClient.DownloadString(reportJsonUrlbyID);
                    if (!string.IsNullOrWhiteSpace(json))
                    {
                        item = JsonConvert.DeserializeObject<Report>(json);
                    }
                }
            }
            catch (Exception ex)
            {
                var errorMessages = string.Format("UtilityHelper - GetReportByID()- Error Message:{0}", ex.Message);
                ExceptionHelper.LogException(ex, errorMessages);
            }
            finally
            {

            }
            return item;
        }

        public static List<ReportDrug> GetReportDrugsById(string reportId, string lang)
        {
            var reportDrugs = new List<ReportDrug>();
            var reportDrug = new ReportDrug();

            var filteredList = new List<ReportDrug>();
            var json = string.Empty;
            var id = reportId;
            var reportDrugJsonUrl = string.Format("{0}&reportId={1}&lang={2}", ConfigurationManager.AppSettings["reportDrugJsonUrl"].ToString(), id, lang);
            try
            {
                using (var webClient = new System.Net.WebClient())
                {
                    json = webClient.DownloadString(reportDrugJsonUrl);

                    if (!string.IsNullOrWhiteSpace(json))
                    {
                        var token = JToken.Parse(json);
                        if (token is JArray)
                        {
                            reportDrugs = JsonConvert.DeserializeObject<List<ReportDrug>>(json);
                        }
                        else //is single Object
                        {
                            reportDrug = JsonConvert.DeserializeObject<ReportDrug>(json);
                            reportDrugs.Add(reportDrug);                            
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                var errorMessages = string.Format("UtilityHelper - GetReportDrugsById()- Error Message:{0}", ex.Message);
                ExceptionHelper.LogException(ex, errorMessages);
            }
            finally
            {

            }
            return reportDrugs;
        }


        public static List<Reactions> GetReactionsByReportId(string reportId, string lang)
        {
            var items = new List<Reactions>();
            var filteredList = new List<Reactions>();
            var json = string.Empty;
            var id = reportId;
            var reactionsJsonUrl = string.Format("{0}&reportId={1}&lang={2}", ConfigurationManager.AppSettings["reactionsJsonUrl"].ToString(), id, lang);
            Debug.WriteLine("GetReactionsByReportId URL : " + reactionsJsonUrl);
            try
            {
                using (var webClient = new System.Net.WebClient())
                {
                    json = webClient.DownloadString(reactionsJsonUrl);
                    if (!string.IsNullOrWhiteSpace(json))
                    {
                        items = JsonConvert.DeserializeObject<List<Reactions>>(json);
                    }
                }
            }
            catch (Exception ex)
            {
                var errorMessages = string.Format("UtilityHelper - GetReactionsByReportId()- Error Message:{0}", ex.Message);
                ExceptionHelper.LogException(ex, errorMessages);
            }
            finally
            {

            }
            return items;
        }




    }

}

