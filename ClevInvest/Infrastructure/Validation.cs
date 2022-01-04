namespace ClevInvest.Infrastructure
{
    public class Validation
    {
        //Регулярные выражения
        public const string LatinLettersAndDigits = @"^[A-Za-z0-9_]*$";
        public const string LettersAndDigits = @"^([A-Za-z0-9_]|[А-Яа-я0-9_])*$";
        
        //Сообщения валидации
        public const string MinLengthMessage = "Введено слишком мало символов.";
        public const string MaxLengthMessage = "Превышено максимальное число символов.";
        public const string RegularExpressionMessage = "Введено некорректное значение.";
        public const string RequiredMessage = "Заполните это поле!";
    }
}