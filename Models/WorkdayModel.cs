using Microsoft.Extensions.Configuration.UserSecrets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Models
{
    public class WorkdayModel
    {
        public int id { get; set; }

        public DateTime startDate { get; set; }

        public DateTime endDate { get; set; }

        public string typeCode { get; set; }

        public string wd_typeCode { get; set; }

        public int aom { get; set; }

        public int userId { get; set; }
    }
}
