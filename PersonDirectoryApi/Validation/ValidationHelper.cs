namespace PersonDirectoryApi.Validation
{
    public class ValidationHelper
    {
        public static bool IsGeorgianLetter(char letter) => letter >= 'ა' && letter <= 'ჰ';

        public static bool IsLatinLetter(char letter) => letter >= 'a' && letter <= 'z' || letter >= 'A' && letter <= 'Z';

        public static bool IsLatinOrGeorgianLetter(char letter) => IsGeorgianLetter(letter) || IsLatinLetter(letter);

        public static bool HasLatinOrGeorgianLettersOnly(string text) => text.All(IsLatinOrGeorgianLetter);

        public static bool HasMixedLanguage(string text) => text.Any(IsGeorgianLetter) && text.Any(IsLatinLetter);

        public static bool HasDigitsOnly(string text) => text.All(char.IsDigit);

        //public static bool IsValidName(string text)
        //{
        //    return (text.Length >= 2)
        //        && (text.Length <= 50)
        //        && HasLatinOrGeorgianLettersOnly(text)
        //        && !HasMixedLanguage(text);
        //}

    }
}
