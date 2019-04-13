using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainModel.Entities
{
    public enum DocType
    {
        Permission = 1,
        Ticket = 2,
        Not = 3
    }

    public enum TemplateLoadStatus
    {
        /// <summary>
        /// Актуальный шаблон уже загружен клиентом ранее
        /// </summary>
        AlreadyLoaded,

        /// <summary>
        /// Шаблон был обновлен
        /// </summary>
        Updated
    }
}
