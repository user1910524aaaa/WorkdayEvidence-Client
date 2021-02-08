using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Models
{
    public class FixTSignatureModel
    {
        public DateTime startDate { get; set; }

        public DateTime endDate { get; set; }

        public string wd_typeCode { get; set; }

        public string typeCode { get; set; }
    }
}
