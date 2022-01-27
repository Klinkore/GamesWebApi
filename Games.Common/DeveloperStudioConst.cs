namespace Games.Common
{
    /// <summary>
    /// Класс констант студий разработчиков
    /// </summary>
    public class DeveloperStudioConst
    {
        /// <summary>
        /// Константы названия студии разработчика
        /// </summary>
        public class Name
        {
            public static readonly int MinLength = 4;
            public static readonly int MaxLength = 256;
            public static string LengthErrorMessage
            {
                get
                {
                    return $"Name length must be between {MinLength} and {MaxLength} characters";
                }
            }
        }
    }
}