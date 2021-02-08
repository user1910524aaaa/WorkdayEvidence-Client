﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Models
{
    public class GetUsersResponse
    {
        public string type { get; set; }

        public bool success { get; set; }

        public string message { get; set; }

        public int statusCode { get; set; }

        public List<UserModel> data { set; get; }
    }
}
