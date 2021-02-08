using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Models
{
    public class ClockInFixTSignatureModel
    {

        //[Range(typeof(DateTime), "1/1/1900 01:00:00", "1/1/1900 23:00:00", ErrorMessage = "Ora pentru inceput a fost omisa")]
        public DateTime? startDate { get; set; }

        //[Range(typeof(DateTime), "1/1/1900 01:00:00", "1/1/1900 23:00:00", ErrorMessage = "Ora pentru sfarsit a fost omisa")]
        public DateTime? endDate { get; set; }

        [Required(ErrorMessage = "Tipul de prezenta a fost omis")]
        public string wd_typeCode { get; set; }

        public string typeCode { get; set; } = "FIX";

        public bool fullDay { get; set; } = false;

    }



}
