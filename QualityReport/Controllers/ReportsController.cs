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

namespace Reports.Controllers
{

    public class ReportsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult UserReportView(EntryViewModel vm)
        {
            var id = vm.UserToLookUp;
            string RepeatUrl = "http://vmdatabase1/reportserver?%2fQualityApp%2fQualityRepeatSummary&rs:Format=PDF";
            RepeatUrl = QueryHelpers.AddQueryString(RepeatUrl, "ProjectID", id);
                        
            WebClient Client = new WebClient(); ;
            Client.UseDefaultCredentials = true;
            byte[] myDataBuffer = Client.DownloadData(RepeatUrl);
            //var url = "C:\\PepperPepper\\Quality\\QualityReport\\QualityReport\\wwwroot\\ReportOutput\\QualityRepeatSummary"+id+ DateTime.Now.ToString("_hhmmss") + ".pdf";
            var url = "C:\\PepperPepper\\Quality\\QualityReport\\QualityReport\\wwwroot\\ReportOutput\\QualityRepeatSummary.pdf";
            System.IO.File.WriteAllBytes(url, myDataBuffer);

            var ShowPage = "https://localhost:44308/ReportOutput/QualityRepeatSummary.pdf";
            return Redirect(ShowPage);
        }

        [HttpPost]
        public ActionResult RankReportView(EntryViewModel vm)
        {
            var company = vm.Company;
            var div = vm.Div;
            var subDiv = vm.SubDiv;
            var startDate = vm.StartDate.ToString();
            var endDate = vm.EndDate.ToString();
            var report = vm.Report;
            var name1 = vm.Name1;
            var name2 = vm.Name2;
            var name3 = vm.Name3;
            var name4 = vm.Name4;
            var name5 = vm.Name5;

            //&Div=09&SubDiv=20&StartDate=2020-01-01&EndDate=2022-02-01&Company=PCC&C_name1=1086&C_name2=4172&C_name3=2091&C_name4=4236&C_name5=7&i=r
            string RankUrl = "http://vmdatabase1/reportserver/Pages/ReportViewer.aspx?%2fQualityApp%2fQualityDrillDown_all&rs:Command=Render";

            RankUrl = QueryHelpers.AddQueryString(RankUrl, "Div", div);
            RankUrl = QueryHelpers.AddQueryString(RankUrl, "SubDiv", subDiv);
            RankUrl = QueryHelpers.AddQueryString(RankUrl, "StartDate", startDate);
            RankUrl = QueryHelpers.AddQueryString(RankUrl, "EndDate", endDate);
            RankUrl = QueryHelpers.AddQueryString(RankUrl, "Company", company);
            RankUrl = QueryHelpers.AddQueryString(RankUrl, "C_name1", name1);
            RankUrl = QueryHelpers.AddQueryString(RankUrl, "C_name2", name2);
            RankUrl = QueryHelpers.AddQueryString(RankUrl, "C_name3", name3);
            RankUrl = QueryHelpers.AddQueryString(RankUrl, "C_name4", name4);
            RankUrl = QueryHelpers.AddQueryString(RankUrl, "C_name5", name5);
            RankUrl = QueryHelpers.AddQueryString(RankUrl, "i", report);

            //C_name1=1086&C_name2=4172&C_name3=2091&C_name4=4236&C_name5=7
            return Redirect(RankUrl);
        }

        public IActionResult ReportList(string project, int ID = 7) //https://localhost:44308/Reports/Quality?name=Leon&numTImes=100
        {

            //return HtmlEncoder.Default.Encode($"Hello {name}, ID: {ID}");
            ViewData["ID"] = ID;
            ViewData["Project"] = "Project Name: " + project;
            
            return View();
        }


    }
}