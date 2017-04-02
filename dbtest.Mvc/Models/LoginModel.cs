using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;

namespace dbtest.Mvc.Models
{
    public class LoginModel
    {
        [Required]
        [Display(Name = "Usuário")]
        public string Login { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }
    }
}