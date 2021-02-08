using System;
using System.Collections.Generic;

namespace Client.Models
{

    public class AuthenticationServerResponseModel
    {
        public string type { get; set; }

        public bool success { get; set; }

        public string message { get; set; }

        public int statusCode { get; set; }

        public List<UserModel> data { get; set; }
    }
}