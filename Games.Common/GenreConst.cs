namespace Games.Common
{
    /// <summary>
    /// Класс констант жанров
    /// </summary>
    public class GenreConst
    {
        /// <summary>
        /// Константы названия жанра
        /// </summary>
        public class Name
        {
            public static readonly int MinLength = 2;
            public static readonly int MaxLength = 128;
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
