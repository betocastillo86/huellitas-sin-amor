using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoginCol.Huellitas.Web.Models
{
    public class LoginModel
    {
        [Required]
        [EmailAddress]
        public string Usuario { get; set; }

        [Required]
        public string Clave { get; set; }

        public string Error { get; set; }
    }
}