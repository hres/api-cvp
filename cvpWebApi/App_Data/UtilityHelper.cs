using cvpWebApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
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
            var cvpJsonUrl = string.Format("{0}&drugname={1}&lang={2}", ConfigurationManager.AppSettings["cvpJsonUrl"].ToString(), drugname, lang);
            try
            {
                using (var webClient = new System.Net.WebClient())
                {
                    json = webClient.DownloadString(cvpJsonUrl);
                    if (!string.IsNullOrWhiteSpace(json))
                    {
                        items = JsonConvert.DeserializeObject<List<Report>>(json);
                    }
                }
            }
            catch (Exception ex)
            {
                var errorMessages = string.Format("UtilityHelper - GetJSonDataFromRegAPI()- Error Message:{0}", ex.Message);
                ExceptionHelper.LogException(ex, errorMessages);
            }
            finally
            {

            }
            return items;
        }

        public static Report GetReportByID(string reportID, string lang)
        {
            // CertifySSL.EnableTrustedHosts();
            var item = new Report();
            var json = string.Empty;
            var postData = new Dictionary<string, string>();
            var cvpJsonUrlbyID = string.Format("{0}&id={1}&lang={2}", ConfigurationManager.AppSettings["cvpJsonUrl"].ToString(), reportID, lang);

            try
            {
                using (var webClient = new System.Net.WebClient())
                {
                    json = webClient.DownloadString(cvpJsonUrlbyID);
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

    }
  
}

