using System.Collections.Generic;

namespace DataAccess.Entities
{
    /// <summary>
    /// Студия разработчик
    /// </summary>
    public class DeveloperStudio
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Наименование студии
        /// </summary>
        public string Name { get; set; }
    }

}
