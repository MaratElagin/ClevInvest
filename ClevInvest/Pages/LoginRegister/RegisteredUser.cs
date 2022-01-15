using System.ComponentModel.DataAnnotations;
using ClevInvest.Infrastructure;

namespace ClevInvest.Pages.LoginRegister
{
    public class RegisteredUser
    {
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
        public string Password { get; set; }
    }
}