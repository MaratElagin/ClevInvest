namespace ClevInvest.Infrastructure
{
    public class Validation
    {
        //Регулярные выражения
        public const string LatinLettersAndDigitsReg = @"^[A-Za-z0-9_]*$";
        public const string LettersAndDigitsReg = @"^([A-Za-z0-9_]|[А-Яа-я0-9_])*$";

        public const string DateOfBirthReg =
            "^((0[1-9]|[12][0-9]|3[01])[.](0[1-9]|1[0-2])[.]\\d{4})|((0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[0-2])/\\d{4})$";
        
        //Сообщения валидации
        public const string MinLengthMessage = "Введено слишком мало символов.";
        public const string MaxLengthMessage = "Превышено максимальное число символов.";
        public const string RegularExpressionMessage = "Введено некорректное значение.";
        public const string RequiredMessage = "Заполните это поле!";
        public const string DateBirthMessage = "Формат даты: ДД.ММ.ГГГГ или ДД/ММ/ГГГГ";
    }
}