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

        public static List<rdsSearchItem> GetRegulatoryDecisionList(string lang, string term)
        {
            // CertifySSL.EnableTrustedHosts();
            var items = new List<rdsSearchItem>();
            var filteredList = new List<rdsSearchItem>();
            var json = string.Empty;
           // var postData = new Dictionary<string, string>();
            var rdsJsonUrl = ConfigurationManager.AppSettings["rdsJsonUrl"].ToString();

            try
            {
                using (var webClient = new System.Net.WebClient())
                {
                    json = webClient.DownloadString(rdsJsonUrl + string.Format("&lang={0}", lang));
                    if (!string.IsNullOrWhiteSpace(json))
                    {
                        items = JsonConvert.DeserializeObject<List<rdsSearchItem>>(json);

                        if (items != null && items.Count > 0)
                        {
                          //Filter list depends on language -- I may not need it.
                            if( string.IsNullOrWhiteSpace(term))
                            {
                               items.OrderBy(c => c.DateDecision);
                               filteredList = items;                             
                            }
                            else
                            {
                                if (term.Equals("whatsnew"))
                                {
                                    var newDate = DateTime.Now.AddDays(-30); // issue date <= 30 days.
                                    items.OrderBy(c => c.DateDecision);
                                    filteredList = items.Where(c => c.DateDecision > newDate).ToList();
                                }
                                else
                                {
                                    filteredList = items.Where(c => c.Drugname.ToLower().Contains(term) || c.MedicalIngredient.ToLower().Contains(term) || c.Manufacture.ToLower().Contains(term)).ToList();
                                }
                            }
                        }
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
            return filteredList;
        }

        public static regulatoryDecisionItem GetRdsByID(string rdsID, string lang)
        {
            // CertifySSL.EnableTrustedHosts();
            var item = new regulatoryDecisionItem();
            var json = string.Empty;
            var postData = new Dictionary<string, string>();
            var rdsJsonUrlbyID = string.Format("{0}&id={1}&lang={2}", ConfigurationManager.AppSettings["rdsJsonUrl"].ToString(), rdsID, lang);

            try
            {
                using (var webClient = new System.Net.WebClient())
                {
                    json = webClient.DownloadString(rdsJsonUrlbyID);
                    if (!string.IsNullOrWhiteSpace(json))
                    {
                        item = JsonConvert.DeserializeObject<regulatoryDecisionItem>(json);
                    }
                }
            }
            catch (Exception ex)
            {
                var errorMessages = string.Format("UtilityHelper - GetRdsByID()- Error Message:{0}", ex.Message);
                ExceptionHelper.LogException(ex, errorMessages);
            }
            finally
            {

            }
            return item;
        }

        public static List<ssrSearchItem> GetSummarySafetyList(string lang, string term)
        {
            // CertifySSL.EnableTrustedHosts();
            var items = new List<ssrSearchItem>();
            var filteredList = new List<ssrSearchItem>();
            var json = string.Empty;
            // var postData = new Dictionary<string, string>();
            var ssrJsonUrl = ConfigurationManager.AppSettings["ssrJsonUrl"].ToString();

            try
            {
                using (var webClient = new System.Net.WebClient())
                {
                    json = webClient.DownloadString(ssrJsonUrl + string.Format("&lang={0}", lang));
                    if (!string.IsNullOrWhiteSpace(json))
                    {
                        items = JsonConvert.DeserializeObject<List<ssrSearchItem>>(json);

                        if (items != null && items.Count > 0)
                        {
                            //Filter list depends on language -- I may not need it.
                            if (string.IsNullOrWhiteSpace(term))
                            {
                                items.OrderBy(c => c.CreatedDate);
                                filteredList = items;
                            }
                            else
                            {
                                if (term.Equals("whatsnew"))
                                {
                                    var newDate = DateTime.Now.AddDays(-30); // issue date <= 30 days.
                                    items.OrderBy(c => c.CreatedDate);
                                    filteredList = items.Where(c => c.CreatedDate > newDate).ToList();
                                }
                                else
                                {
                                    filteredList = items.Where(c => c.Drugname.ToLower().Contains(term) || c.Safetyissue.ToLower().Contains(term)).ToList();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var errorMessages = string.Format("UtilityHelper - GetSummarySafetyList()- Error Message:{0}", ex.Message);
                ExceptionHelper.LogException(ex, errorMessages);
            }
            finally
            {

            }
            return filteredList;
        }


        public static summarySafetyItem GetSsrByID(string ssrID, string lang)
        {
            // CertifySSL.EnableTrustedHosts();
            var item = new summarySafetyItem();
            var json = string.Empty;
            var postData = new Dictionary<string, string>();
            var ssrJsonUrlbyID = string.Format("{0}&id={1}&lang={2}", ConfigurationManager.AppSettings["ssrJsonUrl"].ToString(), ssrID, lang);

            try
            {
                using (var webClient = new System.Net.WebClient())
                {
                    json = webClient.DownloadString(ssrJsonUrlbyID);
                    if (!string.IsNullOrWhiteSpace(json))
                    {
                        item = JsonConvert.DeserializeObject<summarySafetyItem>(json);
                    }
                }
            }
            catch (Exception ex)
            {
                var errorMessages = string.Format("UtilityHelper - GetSsrByID()- Error Message:{0}", ex.Message);
                ExceptionHelper.LogException(ex, errorMessages);
            }
            finally
            {

            }
            return item;
        }
    }
  
}

