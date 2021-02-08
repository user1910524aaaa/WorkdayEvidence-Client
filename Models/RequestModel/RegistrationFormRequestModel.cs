using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Client.Models
{

    public class RegistrationFormRequestModel
    {
        [Required(ErrorMessage = "Campul pentru prenume a fost omis.")]
        public string firstName { get; set; }

        [Required(ErrorMessage = "Campul pentru numele de familie a fost omis.")]
        public string lastName { get; set; }

        [Required(ErrorMessage = "Campul pentru numele de utilizator a fost omis.")]
        public string userName { get; set; }

        [Required(ErrorMessage = "Rolul noului utilizator nu a fost selectat.")]
        public string role { get; set; } = "";

        [Required(ErrorMessage = "Parola a fost omisa.")]
        public string password { get; set; }
    }

    public class UserRoleModel
    {
        public string admin = "admin";

        public string ordinary = "ordinary";
    }

}