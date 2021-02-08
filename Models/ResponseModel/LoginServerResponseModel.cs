using System;

namespace Client.Models
{

    public class LoginServerResponseModel
    {
        
        public string type { get; set; }

        public bool success { get; set; }

        public string message { get; set; }

        public int statusCode { get; set; }

        public string token { get; set; }
        
    }
}