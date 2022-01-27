namespace BusinessLayer.Contracts.Models
{
    /// <summary>
    /// Студия разработчик. Транспортный объект.
    /// </summary>
    public class DeveloperStudioDto
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Наименование студии разработчика
        /// </summary>
        public string Name { get; set; }
    }
}
