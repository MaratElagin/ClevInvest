using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClevInvest.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Заполните это поле!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Заполните это поле!")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Заполните это поле!")]
        public string Password1 { get; set; }

        [NotMapped]
        [Compare(nameof(Password1) ,ErrorMessage = "Пароли должны совпадать")]
        public string Password2 { get; set; }
    }
}