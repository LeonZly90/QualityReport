using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace QualityReport.Models
{
    public class EntryViewModel
    {
        //public string CurrentUser { get; set; }
        public string UserToLookUp { get; set; }

        //rank Report
        public string Company { get; set; }
        public string Div { get; set; }
        public string SubDiv { get; set; }

        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public string StartDate { get; set; }

        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public string EndDate { get; set; }
        public string Report { get; set; }
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        public string Name3 { get; set; }
        public string Name4 { get; set; }
        public string Name5 { get; set; }
    }
}
