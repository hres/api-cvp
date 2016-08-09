using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GoC.WebTemplate;
using cvpWebApi.Models;
using System.Diagnostics;
using cvp;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace cvpWebApi.Controllers
{
    public class HomeController : GoC.WebTemplate.WebTemplateBaseController
    {
        DBConnection dbConnection = new DBConnection("en");
        public ActionResult IndexEN()
        {
            // Page Title
            this.WebTemplateCore.HeaderTitle = "Canada Vigilance Adverse Reaction Database - APIs";

            // Breadcrumb Navigtation
            this.WebTemplateCore.Breadcrumbs.Add(new Breadcrumb("http://canada.ca/en/index.html", "Home", ""));
            this.WebTemplateCore.Breadcrumbs.Add(new Breadcrumb("http://open.canada.ca/en", "Open Government", ""));
            this.WebTemplateCore.Breadcrumbs.Add(new Breadcrumb("http://open.canada.ca/data/en/dataset?q=DPD", "Open Data", ""));
            this.WebTemplateCore.Breadcrumbs.Add(new Breadcrumb("", "CVP - API", ""));

            // Feedback
            this.WebTemplateCore.ShowFeedbackLink = true;

            // Social Media Links
            this.WebTemplateCore.ShowSharePageLink = true;
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.bitly);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.linkedin);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.blogger);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.myspace);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.delicious);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.pinterest);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.digg);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.reddit);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.diigo);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.stumbleupon);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.email);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.tumblr);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.facebook);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.twitter);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.gmail);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.yahoomail);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.googleplus);

            // Date Modified
            this.WebTemplateCore.DateModified = Convert.ToDateTime("2016-04-19");

            return View();
        }

        // Proper French translation still needed for view
        public ActionResult IndexFR()
        {
            // Page Title
            this.WebTemplateCore.HeaderTitle = "Inspections des essais cliniques - recherche d'essai clinique";

            // Breadcrumb Navigtation
            this.WebTemplateCore.Breadcrumbs.Add(new Breadcrumb("http://canada.ca/en/index.html", "Accueil", ""));
            this.WebTemplateCore.Breadcrumbs.Add(new Breadcrumb("http://open.canada.ca/fr", "Gouvernement ouvert", ""));
            this.WebTemplateCore.Breadcrumbs.Add(new Breadcrumb("http://open.canada.ca/data/fr/dataset?q=DPD", "Données ouvertes", ""));
            this.WebTemplateCore.Breadcrumbs.Add(new Breadcrumb("", "CVP APIs", ""));

            // Feedback
            this.WebTemplateCore.ShowFeedbackLink = true;

            // Social Media Links
            this.WebTemplateCore.ShowSharePageLink = true;
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.bitly);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.linkedin);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.blogger);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.myspace);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.delicious);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.pinterest);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.digg);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.reddit);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.diigo);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.stumbleupon);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.email);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.tumblr);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.facebook);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.twitter);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.gmail);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.yahoomail);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.googleplus);

            this.WebTemplateCore.DateModified = Convert.ToDateTime("2016-04-19");

            return View();
        }

        //View Responsible for changing between the English and French PM
        public ActionResult LanguageControl()
        {
            // If pages other than Index are used this will need to be passed a parameter so that
            // it can change to the correct French/English version rather than just hardcoded
            if (Session["GoC.Template.Culture"].Equals("en-CA"))
            {
                Session["GoC.Template.Culture"] = "fr-CA";
                return Redirect("IndexFR");
            }
            else if (Session["GoC.Template.Culture"].Equals("fr-CA"))
            {
                Session["GoC.Template.Culture"] = "en-CA";
                return Redirect("IndexEN");
            }
            else //Default redirect to English Index
                return Redirect("IndexEN");
        }

        public ActionResult SearchReport()
        {
            // Page Title
            this.WebTemplateCore.HeaderTitle = "Canada Vigilance Adverse Reaction Database";

            // Breadcrumb Navigtation
            this.WebTemplateCore.Breadcrumbs.Add(new Breadcrumb("http://canada.ca/en/index.html", "Home", ""));
            this.WebTemplateCore.Breadcrumbs.Add(new Breadcrumb("http://open.canada.ca/en", "Open Government", ""));
            this.WebTemplateCore.Breadcrumbs.Add(new Breadcrumb("http://open.canada.ca/data/en/dataset?q=DPD", "Open Data", ""));
            this.WebTemplateCore.Breadcrumbs.Add(new Breadcrumb("", "Search Canada Vigilance Adverse Reaction Database", ""));

            // Feedback
            this.WebTemplateCore.ShowFeedbackLink = true;

            // Social Media Links
            this.WebTemplateCore.ShowSharePageLink = true;
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.bitly);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.linkedin);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.blogger);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.myspace);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.delicious);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.pinterest);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.digg);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.reddit);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.diigo);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.stumbleupon);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.email);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.tumblr);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.facebook);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.twitter);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.gmail);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.yahoomail);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.googleplus);

            // Date Modified
            this.WebTemplateCore.DateModified = Convert.ToDateTime("2016-04-13");

            return View();
        }

        [HttpGet]
        public ActionResult SearchResultEn()
        {
            Debug.WriteLine("im in the SearchResultsEn method in the HOmeController");
            string brandname = Request.QueryString["brandName"].Trim();
            string reportsString = string.Empty;

            // Page Title
            this.WebTemplateCore.HeaderTitle = "Canada Vigilance Adverse Reaction Database";

            // Breadcrumb Navigation
            this.WebTemplateCore.Breadcrumbs.Add(new Breadcrumb("http://canada.ca/en/index.html", "Home", ""));
            this.WebTemplateCore.Breadcrumbs.Add(new Breadcrumb("http://open.canada.ca/en", "Open Government", ""));
            this.WebTemplateCore.Breadcrumbs.Add(new Breadcrumb("http://open.canada.ca/data/en/dataset?q=DPD", "Open Data", ""));
            this.WebTemplateCore.Breadcrumbs.Add(new Breadcrumb("", "Search Canada Vigilance Adverse Reaction Database", ""));

            // Feedback
            this.WebTemplateCore.ShowFeedbackLink = true;

            // Social Media Links
            this.WebTemplateCore.ShowSharePageLink = true;
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.bitly);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.linkedin);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.blogger);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.myspace);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.delicious);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.pinterest);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.digg);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.reddit);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.diigo);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.stumbleupon);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.email);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.tumblr);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.facebook);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.twitter);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.gmail);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.yahoomail);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.googleplus);

            // Date Modified
            this.WebTemplateCore.DateModified = Convert.ToDateTime("2016-04-13");

            if (Request.IsAjaxRequest())
            {
                Debug.WriteLine(brandname);
                List<Report> reports = new List<Report>();
                reports = dbConnection.GetReportsByDrugName(brandname);
                Debug.WriteLine(reports.Count);

                //JavaScriptSerializer js = new JavaScriptSerializer();
                //Context.Response.Write(js.Serialize(reports));

                reportsString = JsonConvert.SerializeObject(reports);
                Debug.WriteLine(reportsString);

                //context.Response.ContentType = "application/json; charset=utf-8";
                //context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                //context.Response.AppendHeader("Access-Control-Allow-Origin", "*");
                //return Json(reportsString);
                //return View();
                return Content(reportsString, "application/json");
            }
            else
                return View();

        }

        [HttpGet]
        public void SearchResult2(HttpContext context)
        {
            Debug.WriteLine("im in the SearchResultsEn method in the HOmeController");
            string brandname = Request.QueryString["brandName"].Trim();
            string reportsString = string.Empty;

            // Page Title
            this.WebTemplateCore.HeaderTitle = "Canada Vigilance Adverse Reaction Database";

            // Breadcrumb Navigation
            this.WebTemplateCore.Breadcrumbs.Add(new Breadcrumb("http://canada.ca/en/index.html", "Home", ""));
            this.WebTemplateCore.Breadcrumbs.Add(new Breadcrumb("http://open.canada.ca/en", "Open Government", ""));
            this.WebTemplateCore.Breadcrumbs.Add(new Breadcrumb("http://open.canada.ca/data/en/dataset?q=DPD", "Open Data", ""));
            this.WebTemplateCore.Breadcrumbs.Add(new Breadcrumb("", "Search Canada Vigilance Adverse Reaction Database", ""));

            // Feedback
            this.WebTemplateCore.ShowFeedbackLink = true;

            // Social Media Links
            this.WebTemplateCore.ShowSharePageLink = true;
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.bitly);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.linkedin);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.blogger);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.myspace);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.delicious);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.pinterest);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.digg);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.reddit);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.diigo);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.stumbleupon);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.email);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.tumblr);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.facebook);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.twitter);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.gmail);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.yahoomail);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.googleplus);

            // Date Modified
            this.WebTemplateCore.DateModified = Convert.ToDateTime("2016-04-13");

            if (Request.IsAjaxRequest())
            {
                Debug.WriteLine(brandname);
                List<Report> reports = new List<Report>();
                reports = dbConnection.GetReportsByDrugName(brandname);
                Debug.WriteLine(reports.Count);

                //JavaScriptSerializer js = new JavaScriptSerializer();
                //Context.Response.Write(js.Serialize(reports));

                reportsString = JsonConvert.SerializeObject(reports);
                Debug.WriteLine(reportsString);

                context.Response.ContentType = "application/json; charset=utf-8";
                context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                context.Response.AppendHeader("Access-Control-Allow-Origin", "*");
                context.Response.Write(reportsString);
                //return View();
            }
            else
                context.Response.Write(reportsString);

        }

        public ActionResult Reference()
        {
            // Page Title
            this.WebTemplateCore.HeaderTitle = "Canada Vigilance Adverse Reaction Online Database - Reference";

            // Breadcrumb Navigtation
            this.WebTemplateCore.Breadcrumbs.Add(new Breadcrumb("http://canada.ca/en/index.html", "Home", ""));
            this.WebTemplateCore.Breadcrumbs.Add(new Breadcrumb("http://open.canada.ca/en", "Open Government", ""));
            this.WebTemplateCore.Breadcrumbs.Add(new Breadcrumb("http://open.canada.ca/data/en/dataset?q=DPD", "Open Data", ""));
            this.WebTemplateCore.Breadcrumbs.Add(new Breadcrumb("", "Search Canada Vigilance Adverse Reaction Online Database", ""));

            // Feedback
            this.WebTemplateCore.ShowFeedbackLink = true;

            // Social Media Links
            this.WebTemplateCore.ShowSharePageLink = true;
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.bitly);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.linkedin);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.blogger);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.myspace);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.delicious);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.pinterest);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.digg);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.reddit);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.diigo);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.stumbleupon);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.email);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.tumblr);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.facebook);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.twitter);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.gmail);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.yahoomail);
            this.WebTemplateCore.SharePageMediaSites.Add(GoC.WebTemplate.Core.SocialMediaSites.googleplus);

            // Date Modified
            this.WebTemplateCore.DateModified = Convert.ToDateTime("2016-06-07");
            return View();
        }
    }
}
