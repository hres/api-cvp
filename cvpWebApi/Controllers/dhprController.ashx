﻿
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
                var linkId = string.IsNullOrWhiteSpace(context.Request.QueryString.GetLinkID().Trim())? string.Empty: context.Request.QueryString.GetLinkID().Trim();
                var drugReportId = string.IsNullOrWhiteSpace(context.Request.QueryString.GetDrugsReportID().Trim())? string.Empty: context.Request.QueryString.GetDrugsReportID().Trim();
                var reactionReportId = string.IsNullOrWhiteSpace(context.Request.QueryString.GetReactionsReportID().Trim())? string.Empty: context.Request.QueryString.GetReactionsReportID().Trim();

                // Search results filters                
                var ageRange =  context.Request.QueryString.GetAgeRange().ToLower().Trim();
                var gender = context.Request.QueryString.GetGender().ToLower().Trim();
                var seriousReport = context.Request.QueryString.GetSeriousness().ToLower().Trim();
                var startDate = context.Request.QueryString.GetStartDate().Trim();
                var endDate = context.Request.QueryString.GetEndDate().Trim();
                var sourceOfReport = context.Request.QueryString.GetSourceOfReport().Trim();
                var reportOutcome = context.Request.QueryString.GetReportOutcome().Trim();



                if( !string.IsNullOrWhiteSpace(linkId) || !string.IsNullOrWhiteSpace(drugReportId) || !string.IsNullOrWhiteSpace(reactionReportId) )
                {

                    if (!string.IsNullOrWhiteSpace(linkId))
                    {
                        var adverseReport = new Report();
                        adverseReport = UtilityHelper.GetReportByID(linkId.Trim(), lang);
                        if (!string.IsNullOrWhiteSpace(adverseReport.report_no))
                        {
                            jsonResult = JsonHelper.JsonSerializer<Report>(adverseReport);
                            context.Response.Write(jsonResult);

                        } else
                        {
                            context.Response.Write("{\"id\":\"\"}");
                        }
                    } else if (!string.IsNullOrWhiteSpace(drugReportId))
                    {
                        List<ReportDrug> reportDrugs = new List<ReportDrug>();
                        reportDrugs = UtilityHelper.GetReportDrugById(drugReportId, lang);

                        if (reportDrugs != null && reportDrugs.Count > 0)
                        {
                            jsonResult = JsonHelper.JsonSerializer<List<ReportDrug>>(reportDrugs);
                            jsonResult = "{\"data\":" + jsonResult + "}";
                            //Debug.WriteLine(jsonResult);
                            context.Response.Write(jsonResult);
                        }
                        else
                        {
                            context.Response.Write("{\"data\":[]}");
                        }

                    } else
                    {
                        List<Reaction> reactions = new List<Reaction>();
                        reactions = UtilityHelper.GetReactionByReportId(reactionReportId, lang);

                        if (reactions != null && reactions.Count > 0)
                        {
                            jsonResult = JsonHelper.JsonSerializer<List<Reaction>>(reactions);
                            //jsonResult = "{\"data\":" + jsonResult + "}";
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
                    reports = UtilityHelper.GetReportByCriteria(lang, term, ageRange, gender, seriousReport, sourceOfReport, reportOutcome, startDate, endDate);
                    if (reports != null && reports.Count > 0)
                    {
                        jsonResult = JsonHelper.JsonSerializer<List<Report>>(reports);
                        jsonResult = "{\"data\":" + jsonResult + "}";
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