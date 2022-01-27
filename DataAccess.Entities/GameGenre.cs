namespace DataAccess.Entities
{
    /// <summary>
    /// Развязывание связи многие ко многим через дополнительную сущность
    /// </summary>
    public class GameGenre
    {
        /// <summary>
        /// Идентификатор игры
        /// </summary>
        public long GameId { get; set; }

        /// <summary>
        /// Объект игры
        /// </summary>
        public virtual Game Game { get; set; }

        /// <summary>
        /// Идентификатор жанра
        /// </summary>
        public long GenreId { get; set; }

        /// <summary>
        /// Объект жанра
        /// </summary>
        public virtual Genre Genre{ get; set; }
    }
}
