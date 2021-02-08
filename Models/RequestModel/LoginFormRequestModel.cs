using System;
using System.ComponentModel.DataAnnotations;

namespace Client.Models
{

    public class LoginFormRequestModel
    {
        
        [Required(ErrorMessage = "Campul pentru numele de utilizator a fost omis.")]
        public string userName { get; set; }

        [Required(ErrorMessage = "Campul pentru parola a fost omis.")]
        public string password { get; set; }

    }

}