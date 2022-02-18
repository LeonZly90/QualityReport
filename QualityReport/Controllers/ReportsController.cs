using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using QualityReport.Models;
using System.Text;
using QualityReport.Utility;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.WebUtilities;
using System.Net;
using System.Threading.Tasks;
using System.IO;
using System.IO.IsolatedStorage;
using QualityReport.Services;
using Microsoft.EntityFrameworkCore;

namespace Reports.Controllers
{

    public class ReportsController : Controller
    {
        //private readonly ProjectNameRepeatContext _db;
        //public IStoProc StoProc { get; private set; }
        //public ReportsController(ProjectNameRepeatContext db)
        //{
        //    _db = db;
        //    //StoProc = new StoProc(_db);
        //}

        //public async Task<IActionResult> ReportList()
        //{
        //    return View(await _db.Project.FromSqlRaw("select * from Project").ToListAsync());
        //}
        #region " ================== 02/14/2022 Repeat Summary ====================="

        [HttpGet]
        public IActionResult RepeatSummary()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RepeatSummary(EntryViewModel vm)
        {
            var id = vm.RepeatProjectID;
            string RepeatUrl = "http://vmdatabase1/reportserver?%2fQualityApp%2fQualityRepeatSummary&rs:Format=PDF";
            RepeatUrl = QueryHelpers.AddQueryString(RepeatUrl, "ProjectID", id);
                        
            WebClient Client = new WebClient();
            Client.UseDefaultCredentials = true;
            byte[] myDataBuffer = Client.DownloadData(RepeatUrl);
            //var url = "C:\\PepperPepper\\Quality\\QualityReport\\QualityReport\\wwwroot\\ReportOutput\\QualityRepeatSummary"+id+ DateTime.Now.ToString("_hhmmss") + ".pdf";
            var urlRepeat = "C:\\PepperPepper\\Quality\\QualityReport\\QualityReport\\wwwroot\\ReportOutput\\QualityRepeatSummary.pdf";
            System.IO.File.WriteAllBytes(urlRepeat, myDataBuffer);

            var ShowPage = "/ReportOutput/QualityRepeatSummary.pdf";
            return Redirect(ShowPage);
        }
        #endregion

        #region " ================== 02/15/2022 Root Cause Summary ====================="

        [HttpGet]
        public IActionResult RootCause()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RootCause(EntryViewModel vm)
        {
            var id = vm.RootProjectID;
            string RepeatUrl = "http://vmdatabase1/reportserver?%2fQualityApp%2fQualityRootCauseReport&rs:Format=PDF";
            RepeatUrl = QueryHelpers.AddQueryString(RepeatUrl, "ProjectID", id);

            WebClient Client = new WebClient();
            Client.UseDefaultCredentials = true;
            byte[] myDataBuffer = Client.DownloadData(RepeatUrl);
            var urlRepeat = "C:\\PepperPepper\\Quality\\QualityReport\\QualityReport\\wwwroot\\ReportOutput\\RootCauseReport.pdf";
            System.IO.File.WriteAllBytes(urlRepeat, myDataBuffer);

            var ShowPage = "/ReportOutput/RootCauseReport.pdf";
            return Redirect(ShowPage);
        }
        #endregion
       
        #region " ================== 02/16/2022 Comparison Summary ====================="

        [HttpGet]
        public IActionResult ComparisonReport()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ComparisonReport(EntryViewModel vm)
        {
            var location = vm.ComparisonCompany;
            var ComparisonTradeNo = vm.ComparisonTradeNo;
            var ProjectList = vm.CompanyList;
            //ProjectList = ProjectList.Trim(',');
            //ProjectList = Request.Form["demo"];
            //'1402148','1501256','1800092', '1500256','1601712'
            //--->'1402148,1501256,1500256,1800092,1601712'

            //var ListName = new List<string>();
            //ListName.Add(ProjectList);
            //TempData["Lists"] = ProjectList;
            //if (ProjectList != null)
            //{
            //    ProjectList += "<b>You selected:</b><br>";
            //    ProjectList = string.Join(",", ProjectList);              
            //    //ListName.Add(",");
            //    //ListName.Add(ProjectList);
            //}

            string ComparisonUrl = "http://vmdatabase1/reportserver/Pages/ReportViewer.aspx?%2fQualityApp%2fQualityCpmpareReport&rs:Format=PDF";
            ComparisonUrl = QueryHelpers.AddQueryString(ComparisonUrl, "Trade_No", ComparisonTradeNo);
            ComparisonUrl = QueryHelpers.AddQueryString(ComparisonUrl, "Company", location);
            ComparisonUrl = QueryHelpers.AddQueryString(ComparisonUrl, "ProjectID", ProjectList);

            WebClient Client = new WebClient();
            Client.UseDefaultCredentials = true;
            byte[] myDataBuffer = Client.DownloadData(ComparisonUrl);
            var urlComparison = "C:\\PepperPepper\\Quality\\QualityReport\\QualityReport\\wwwroot\\ReportOutput\\ComparisonReport.pdf";
            System.IO.File.WriteAllBytes(urlComparison, myDataBuffer);

            var ShowPage = "/ReportOutput/ComparisonReport.pdf";
            return Redirect(ShowPage);
        }


        #endregion

        #region " ================== 02/16/2022 Drill Down Report ====================="

        [HttpGet]
        public IActionResult DrillDown()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DrillDown(EntryViewModel vm)
        {
            var company = vm.Company;
            var div = vm.Div;
            var subDiv = vm.SubDiv;
            var startDate = vm.StartDate.ToString();
            var endDate = vm.EndDate.ToString();

            //http://vmdatabase1/reportserver/Pages/ReportViewer.aspx?%2fQualityApp%2fReport1&rs:Command=Render&Company=PCC&Div=05&SubDiv=20&StartDate=2020-01-01&EndDate=2022-01-01

            string DrillDownUrl = "http://vmdatabase1/reportserver/Pages/ReportViewer.aspx?%2fQualityApp%2fReport1&rs:Format=PDF";
            DrillDownUrl = QueryHelpers.AddQueryString(DrillDownUrl, "Div", div);
            DrillDownUrl = QueryHelpers.AddQueryString(DrillDownUrl, "SubDiv", subDiv);
            DrillDownUrl = QueryHelpers.AddQueryString(DrillDownUrl, "StartDate", startDate);
            DrillDownUrl = QueryHelpers.AddQueryString(DrillDownUrl, "EndDate", endDate);
            DrillDownUrl = QueryHelpers.AddQueryString(DrillDownUrl, "Company", company);

            WebClient Client = new WebClient();
            Client.UseDefaultCredentials = true;
            byte[] myDataBuffer = Client.DownloadData(DrillDownUrl);
            var urlDrillDown = "C:\\PepperPepper\\Quality\\QualityReport\\QualityReport\\wwwroot\\ReportOutput\\DrillDownReport.pdf";
            System.IO.File.WriteAllBytes(urlDrillDown, myDataBuffer);

            var ShowPage = "/ReportOutput/DrillDownReport.pdf";
            return Redirect(ShowPage);
        }
        #endregion

        #region " ================== 02/14/2022 RankReport ====================="

        [HttpGet]
        public IActionResult RankReport()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RankReport(EntryViewModel vm)
        {
            var company = vm.Company;
            var div = vm.Div;
            var subDiv = vm.SubDiv;
            var startDate = vm.StartDate.ToString();
            var endDate = vm.EndDate.ToString();
            var report = vm.Report;
            var name = vm.Name;
            //if (name1 == null)
            //{
            //    name1 = "IsNull = True";
            //}
            //var name2 = vm.Name2;
            //var name3 = vm.Name3;
            //var name4 = vm.Name4;
            //var name5 = vm.Name5;

            string RankUrl = "http://vmdatabase1/reportserver/Pages/ReportViewer.aspx?%2fQualityApp%2fQualityDrillDown_all&rs:Format=PDF";

            RankUrl = QueryHelpers.AddQueryString(RankUrl, "Div", div);
            RankUrl = QueryHelpers.AddQueryString(RankUrl, "SubDiv", subDiv);
            RankUrl = QueryHelpers.AddQueryString(RankUrl, "StartDate", startDate);
            RankUrl = QueryHelpers.AddQueryString(RankUrl, "EndDate", endDate);
            RankUrl = QueryHelpers.AddQueryString(RankUrl, "Company", company);
            RankUrl = QueryHelpers.AddQueryString(RankUrl, "C_name", name);
            //RankUrl = QueryHelpers.AddQueryString(RankUrl, "C_name2", name2);
            //RankUrl = QueryHelpers.AddQueryString(RankUrl, "C_name3", name3);
            //RankUrl = QueryHelpers.AddQueryString(RankUrl, "C_name4", name4);
            //RankUrl = QueryHelpers.AddQueryString(RankUrl, "C_name5", name5);
            RankUrl = QueryHelpers.AddQueryString(RankUrl, "i", report);

            //C_name1=1086&C_name2=4172&C_name3=2091&C_name4=4236&C_name5=7
            WebClient Client = new WebClient();
            Client.UseDefaultCredentials = true;
            byte[] myDataBuffer = Client.DownloadData(RankUrl);

            var urlRepeat = "C:\\PepperPepper\\Quality\\QualityReport\\QualityReport\\wwwroot\\ReportOutput\\DrillDownRank.pdf";
            System.IO.File.WriteAllBytes(urlRepeat, myDataBuffer);

            var ShowPage = "/ReportOutput/DrillDownRank.pdf";
            return Redirect(ShowPage);
            //return Redirect(RankUrl);
        }
        #endregion

        //public IActionResult ReportList(string project, int ID = 7) //https://localhost:44308/Reports/Quality?name=Leon&numTImes=100
        //{

        //    //return HtmlEncoder.Default.Encode($"Hello {name}, ID: {ID}");
        //    ViewData["ID"] = ID;
        //    ViewData["Project"] = "Project Name: " + project;

        //    return View();
        //}


    }
}