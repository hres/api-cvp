﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using cvpWebApi.Models;

namespace cvpWebApi.Controllers
{
    public class ReportDrugIndicationController : ApiController
    {
        static readonly IReportDrugIndicationRepository databasePlaceholder = new ReportDrugIndicationRepository();

        public IEnumerable<ReportDrugIndication> GetAllReportDrugIndication()
        {

            return databasePlaceholder.GetAll();
        }


        public ReportDrugIndication GetReportDrugIndicationByID(int id)
        {
            ReportDrugIndication report = databasePlaceholder.Get(id);
            if (report == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return report;
        }
        //public IEnumerable<ReportDrugIndication> GetReportDrugIndicationByName(string drugName)
        //{
        //    return databasePlaceholder.Get(drugName);
        //}


        //public HttpResponseMessage PostReport(Report report)
        //{
        //    report = databasePlaceholder.Add(report);
        //    string apiName = App_Start.WebApiConfig.DEFAULT_ROUTE_NAME;
        //    var response =
        //        this.Request.CreateResponse<Report>(HttpStatusCode.Created, report);
        //    string uri = Url.Link(apiName, new { id = report.ReportId });
        //    response.Headers.Location = new Uri(uri);
        //    return response;
        //}


        //public bool PutReport(Report report)
        //{
        //    if (!databasePlaceholder.Update(report))
        //    {
        //        throw new HttpResponseException(HttpStatusCode.NotFound);
        //    }

        //    return true;
        //}


        //public void DeleteReport(int id)
        //{
        //    Report report = databasePlaceholder.Get(id);
        //    if (report == null)
        //    {
        //        throw new HttpResponseException(HttpStatusCode.NotFound);
        //    }
        //    databasePlaceholder.Remove(id);
        //}
    }
}