using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Models
{
    public class ClockInClockOutFlxTSignature
    {
        public string wd_typeCode { get; set; } = "ZI";

        public string typeCode { get; set; } = "FLX";

        public bool finish { get; set; } = false;
    }
}
