using System;

namespace Client.Models
{

    public class RegistrationServerResponseModel
    {
        
        public String type { get; set; }

        public Boolean success { get; set; }

        public String message { get; set; }

        public Int32 statusCode { get; set; }

        public dynamic data { get; set; }
        
    }
}