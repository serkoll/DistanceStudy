using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeometryObjects;

namespace Point3DCntrl
{
    /// <summary>
    /// Класс содержит инструменты для выработки решения задачи
    /// </summary>
    class TaskEval_Mechanism
    {
        //public bool SolveToTrue = true; //Правильное решение соответствует значению "true"
        //public bool SolveAsFalse = false; //Правильное решение соответствует значению "false" алгоритма решения части задачи


        /// <summary>
        /// 
        /// </summary>
        /// <param name="TaskSolve">Параметр правильности решения текущего шага задачи.</param>
        /// <param name="SolveAsFalse">Параметр, указывающий на необходимость принятия ложного решения задачи в качестве правильного решения.</param>
        /// <param name="TotalSolve">Параметр правильности общего решения задачи.</param>
        /// <param name="CommentsNames">Список имен требуемых комментариев.</param>
        /// <param name="CommentsTrue">Словарь правильных комментариев.</param>
        /// <param name="CommentsFalse">Словарь ложных комментариев.</param>
        /// <param name="Object_CommentOut">Строка вывода комментария для полученного решения.</param>
        public void Solve_TrueOrFalse(ref bool TaskSolve, bool SolveAsFalse, ref bool TotalSolve, List<string> CommentsNames, ref Dictionary<string, string> CommentsTrue, ref Dictionary<string, string> CommentsFalse, ref string Object_CommentOut)
        {
            string Object_Comment;

            if (SolveAsFalse == false)//Правильное решение соответствует значению "true" алгоритма решения части задачи (обычный режим работы)
            {
                if (TaskSolve == false)//Задача решена неверно. Требуются комментарии о допущенных ошибках.
                {
                    foreach (string CommentName in CommentsNames)
                    {
                        //CommentsFalse.TryGetValue("InputX_false", out Object_Comment);                    
                        CommentsFalse.TryGetValue(CommentName, out Object_Comment);
                        Object_CommentOut += Object_Comment;
                    }
                    //TaskSolve = false; //Общее решение верно (перезадавать не требуется).
                }
                else //Задача решена верно. Комметнарии о допущенных ошибках не требуются.
                {
                    //foreach (string CommentName in CommentsNames)
                    //{
                    ////CommentsTrue.TryGetValue("InputX_true", out Object_Comment);
                    //CommentsTrue.TryGetValue(CommentName, out Object_Comment);
                    //Object_CommentOut += Object_Comment;
                    //}
                    //TaskSolve = true; //Общее решение неверно .
                }
            }
            else //Правильное решение соответствует значению "false" алгоритма решения части задачи
            {
                if (TaskSolve == false) //Задача решена верно. Комметнарии о допущенных ошибках не требуются.
                {
                    //foreach (string CommentName in CommentsNames)
                    //{
                    ////CommentsFalse.TryGetValue("InputX_false", out Object_Comment);
                    //CommentsFalse.TryGetValue(CommentName, out Object_Comment);
                    //Object_CommentOut += Object_Comment;
                    //}
                    TaskSolve = true; //Общее решение верно (перезадать требуется).
                }
                else//Задача решена неверно. Требуются комментарии о допущенных ошибках.
                {
                    foreach (string CommentName in CommentsNames)
                    {
                        //CommentsTrue.TryGetValue("InputX_true", out Object_Comment);
                        CommentsTrue.TryGetValue(CommentName, out Object_Comment);
                        Object_CommentOut += Object_Comment;
                    }
                    TaskSolve = false; //Общее решение неверно (перезадать требуется).
                }
            }
            if (TotalSolve == true)//Контроль на каждом шаге правильности решения: если хоть на одном шаге решение неверно, то общее решение всегда должно быть "false".
            {
                if (TaskSolve == false) { TotalSolve = false; }
                //if ((SolveAsFalse == false & TaskSolve == false) | (SolveAsFalse == true & TaskSolve == true))
                //{ TotalSolve = false; }
            }
        }




    }
}
