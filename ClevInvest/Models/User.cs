using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ClevInvest.Infrastructure;

namespace ClevInvest.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Role { get; set; }

        [Required(ErrorMessage = Validation.RequiredMessage)]
        [MinLength(5, ErrorMessage = Validation.MinLengthMessage)]
        [MaxLength(15, ErrorMessage = Validation.MaxLengthMessage)]
        [RegularExpression(Validation.LettersAndDigitsReg,
            ErrorMessage = Validation.RegularExpressionMessage)]
        public string UserName { get; set; }

        [Required(ErrorMessage = Validation.RequiredMessage)]
        [MinLength(5, ErrorMessage = Validation.MinLengthMessage)]
        [MaxLength(10, ErrorMessage = Validation.MaxLengthMessage)]
        [RegularExpression(Validation.LatinLettersAndDigitsReg,
            ErrorMessage = Validation.RegularExpressionMessage)]
        public string Login { get; set; }

        [Required(ErrorMessage = Validation.RequiredMessage)]
        [RegularExpression(Validation.LatinLettersAndDigitsReg,
            ErrorMessage = Validation.RegularExpressionMessage)]
        [MinLength(5, ErrorMessage = Validation.MinLengthMessage)]
        [MaxLength(10, ErrorMessage = Validation.MaxLengthMessage)]
        public string Password1 { get; set; }

        [NotMapped]
        [Required(ErrorMessage = Validation.RequiredMessage)]
        [Compare(nameof(Password1), ErrorMessage = "Пароли должны совпадать")]
        public string Password2 { get; set; }

        public string UserPhoto { get; set; }
        [Required(ErrorMessage = Validation.RequiredMessage)]
        [RegularExpression(Validation.DateOfBirthReg, ErrorMessage = Validation.DateBirthMessage)]
        public string BirthDate { get; set; }
    }
}