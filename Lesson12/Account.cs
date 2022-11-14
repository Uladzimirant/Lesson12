namespace Lesson12
{
    public static class Account
    {
        public static readonly int MaxLoginLen;
        public static readonly char[] ForbidenLoginChars;
        public static readonly int MaxPasswordLen;
        public static readonly char[] ForbidenPasswordChars;
        public static readonly bool IsNumberInPasswordRequired;

        static Account()
        {
            //Представим, что гипотетический сервев/программа/что-то тут считывает из каких-нибудь
            //файлов параметры, а так - хардкод!
            MaxLoginLen = 20;
            ForbidenLoginChars = new char[] { ' ' };
            MaxPasswordLen = 20;
            ForbidenPasswordChars = new char[] { ' ' };
            IsNumberInPasswordRequired = true;

        }

        private static void DoCheck(string what, string name, int maxLen, char[] wrongChars, Func<string, AccountException> exceptionFactory)
        {
            if (what.Length > maxLen)
                throw exceptionFactory($"{name} must not be longer than {maxLen}");
            if (what.IndexOfAny(wrongChars) != -1)
                throw exceptionFactory(
                    $"{name} must not containg those symbols: {string.Join(",", wrongChars.Select(c => $"\'{c}\'"))}");
        }
        public static bool Register(string login, string password, string confirmPassword)
        {
            try
            {
                if (string.IsNullOrEmpty(login))
                    throw new WrongLoginException("Login must not be empty");
                DoCheck(login, "Login", MaxLoginLen, ForbidenLoginChars, message => new WrongLoginException(message));

                DoCheck(password, "Password", MaxPasswordLen, ForbidenPasswordChars, message => new WrongPasswordException(message));
                if (!password.Equals(confirmPassword))
                    throw new WrongPasswordException("Password and confirm password are not equal");
                if (!password.Any(char.IsDigit))
                    throw new WrongPasswordException("Password must contain at least one number");

                return true;
            }
            catch (AccountException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}