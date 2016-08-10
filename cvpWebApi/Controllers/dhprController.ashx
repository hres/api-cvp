<%@ WebHandler Language="C#" Class="cvp.dhprController" %>

using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using cvp;
using cvpWebApi.Models;
using System.Diagnostics;


namespace cvp
{
    public class dhprController : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json; charset=utf-8";
            context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            context.Response.AppendHeader("Access-Control-Allow-Origin", "*");

            DBConnection dbConnection = new DBConnection("en");

            try
            {
                var jsonResult = string.Empty;
                var lang = string.IsNullOrEmpty(context.Request.QueryString.GetLang().Trim()) ? "en" : context.Request.QueryString.GetLang().Trim();
                if (lang == "en")
                {
                    UtilityHelper.SetDefaultCulture("en");
                }
                else
                {
                    UtilityHelper.SetDefaultCulture("fr");
                }

                //Get All the QueryStrings
                var term  = context.Request.QueryString.GetSearchTerm().ToLower().Trim();
                //var pType = string.IsNullOrEmpty(context.Request.QueryString.GetProgramType().Trim()) ? programType.dhpr : (programType)Enum.Parse(typeof(programType), context.Request.QueryString.GetProgramType().Trim());
                //var linkId = string.IsNullOrWhiteSpace(context.Request.QueryString.GetLinkID().Trim())? string.Empty: context.Request.QueryString.GetLinkID().Trim();
                var linkId = string.IsNullOrWhiteSpace(context.Request.QueryString.GetLinkID().Trim())? string.Empty: context.Request.QueryString.GetLinkID().Trim();
                var drugsReportId = string.IsNullOrWhiteSpace(context.Request.QueryString.GetDrugsReportID().Trim())? string.Empty: context.Request.QueryString.GetDrugsReportID().Trim();
                var reactionsReportId = string.IsNullOrWhiteSpace(context.Request.QueryString.GetReactionsReportID().Trim())? string.Empty: context.Request.QueryString.GetReactionsReportID().Trim();

                if( !string.IsNullOrWhiteSpace(linkId) || !string.IsNullOrWhiteSpace(drugsReportId) || !string.IsNullOrWhiteSpace(reactionsReportId) )
                {

                    if (!string.IsNullOrWhiteSpace(linkId))
                    {
                        var adverseReport = new Report();
                        //adverseReport = UtilityHelper.GetReportById(linkId, lang);
                        if (!string.IsNullOrWhiteSpace(adverseReport.ReportNo))
                        {
                            jsonResult = JsonHelper.JsonSerializer<Report>(adverseReport);
                            context.Response.Write(jsonResult);

                        } else
                        {
                            context.Response.Write("{\"id\":\"\"}");
                        }
                    } else if (!string.IsNullOrWhiteSpace(drugsReportId))
                    {
                        Debug.WriteLine("reportDrugsId is not null");
                        List<ReportDrug> reportDrugs = new List<ReportDrug>();
                        reportDrugs = dbConnection.GetReportDrugsByReportId(drugsReportId, lang);

                        if (reportDrugs != null && reportDrugs.Count > 0)
                        {
                            jsonResult = JsonHelper.JsonSerializer<List<ReportDrug>>(reportDrugs);
                            jsonResult = "{\"data\":" + jsonResult + "}";
                            Debug.WriteLine(jsonResult);
                            context.Response.Write(jsonResult);
                        }
                        else
                        {
                            context.Response.Write("{\"data\":[]}");
                        }

                    } else
                    {
                        Debug.WriteLine("reactionsReportId is not null");
                        List<Reactions> reactions = new List<Reactions>();
                        reactions = dbConnection.GetReactionsByReportId(drugsReportId, lang);

                        if (reactions != null && reactions.Count > 0)
                        {
                            jsonResult = JsonHelper.JsonSerializer<List<Reactions>>(reactions);
                            jsonResult = "{\"data\":" + jsonResult + "}";
                            Debug.WriteLine(jsonResult);
                            context.Response.Write(jsonResult);
                        }
                        else
                        {
                            context.Response.Write("{\"data\":[]}");
                        }
                    }
                }
                else
                {
                    List<Report> reports = new List<Report>();
                    reports = UtilityHelper.GetReportByCriteria(lang, term);
                    if (reports != null && reports.Count > 0)
                    {
                        jsonResult = JsonHelper.JsonSerializer<List<Report>>(reports);
                        jsonResult = "{\"data\":" + jsonResult + "}";
                        Debug.WriteLine(jsonResult);
                        context.Response.Write(jsonResult);
                    }
                    else
                    {
                        context.Response.Write("{\"data\":[]}");
                    }
                }


            }
            catch (Exception ex)
            {
                ExceptionHelper.LogException(ex, "dhprController.ashx");
                context.Response.Write("{\"data\":[]}");
            }
        }


        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}