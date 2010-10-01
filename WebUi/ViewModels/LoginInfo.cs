using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;


namespace WebUi.ViewModels
{
    public class LoginInfo
    {
        //[Required]
        public string UserName { get; set; }


        //[Required]
        //[DataType(DataType.Password)]
        public string Password { get; set; }


        //[Required]
        //[DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        public bool RememberMe { get; set; }
    }
}