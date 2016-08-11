using DbRepository.Classes.Context;
using DbRepository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class SubthemaService
    {
        // Репозиторий для добавление в БД тем
        private SubthemaRepository _subthemaRep = new SubthemaRepository();

        /// <summary>
        /// Добавление новой подтемы
        /// </summary>
        /// <param name="name">Название</param>
        /// <param name="description">Описание</param>
        public void Add(int id, string name, string description)
        {
            _subthemaRep.Add(new SubThema()
            {
                ThemaId = id,
                Name = name,
                Description = description
            });
        }

        /// <summary>
        /// Редактирование существующей подтемы
        /// </summary>
        /// <param name="id">ИД</param>
        /// <param name="name">Имя</param>
        /// <param name="desc">Описание</param>
        public void Update(int id, string name, string desc)
        {
            _subthemaRep.Update(new SubThema()
            {
                ThemaId = id,
                Name = name,
                Description = desc
            });
        }
    }
}
