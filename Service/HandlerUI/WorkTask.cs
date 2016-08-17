using DbRepository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service.HandlerUI
{
    /// <summary>
    /// Класс для работы с задачей
    /// </summary>
    public class WorkTask
    {
        // Активная задача
        private Task _task;
        public WorkTask(Task task)
        {
            _task = task;
        }
    }
}
