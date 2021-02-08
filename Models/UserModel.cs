using System;
using System.ComponentModel.DataAnnotations;

namespace Client.Models
{

    public class UserModel
    {
        public int id { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public string userName { get; set; }

        public string role { get; set; }

        [Required(ErrorMessage = "Campul pentru noua parola a fost omis.")]
        public string password { get; set; }

        [Required(ErrorMessage = "Campul pentru vechea parola a fost omis.")]
        public string oldPassword { get; set; }
    }
}