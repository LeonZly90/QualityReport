﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace QualityReport.Models
{
    public class EntryViewModel
    {
        //Repeat Summary
        public string RepeatProjectID { get; set; }

        //Root Cause Report
        public string RootProjectID { get; set; }

        //Comparison Report
        public string ComparisonCompany { get; set; }
        public string ComparisonTradeNo { get; set; }
        public string Company1 { get; set; }
        public string Company2 { get; set; }
        public string Company3 { get; set; }
        public string Company4 { get; set; }
        public string Company5 { get; set; }

        //Rank Report
        public string Company { get; set; }
        public string Div { get; set; }
        public string SubDiv { get; set; }

        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public string StartDate { get; set; }

        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public string EndDate { get; set; }
        public string Report { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Required(AllowEmptyStrings = true)]
        public string Name1 { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Required(AllowEmptyStrings = true)]
        public string Name2 { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Required(AllowEmptyStrings = true)]
        public string Name3 { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Required(AllowEmptyStrings = true)]
        public string Name4 { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Required(AllowEmptyStrings = true)]
        public string Name5 { get; set; }
    }
}
