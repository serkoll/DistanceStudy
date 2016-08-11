using DbRepository.Classes.Repository;
using DbRepository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class ThemaService
    {
        // Репозиторий для добавление в БД тем
        private ThemaRepository _themaRep = new ThemaRepository();

        /// <summary>
        /// Добавление новой темы
        /// </summary>
        /// <param name="name">Название</param>
        /// <param name="description">Описание</param>
        public void Add(int id, string name, string description)
        {
            _themaRep.Add(new Thema()
            {
                ThemaId = id,
                Name = name,
                Description = description
            });
        }

        /// <summary>
        /// Редактирование существующей темы
        /// </summary>
        /// <param name="id">ИД</param>
        /// <param name="name">Имя</param>
        /// <param name="desc">Описание</param>
        public void Update(int id, string name, string desc)
        {
            _themaRep.Update(new Thema()
            {
                ThemaId = id,
                Name = name,
                Description = desc
            });
        }
    }
}
