namespace Games.Common
{
    /// <summary>
    /// Класс констант игры
    /// </summary>
    public static class GameConst
    {
        /// <summary>
        /// Константы названия
        /// </summary>
        public class Name
        {
            public static readonly int MinLength = 3;
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