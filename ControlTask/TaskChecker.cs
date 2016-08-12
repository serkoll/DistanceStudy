using System.Collections.Generic;
using DbRepository.Classes.Context;
using GeometryObjects;

namespace ControlTask
{
    public class TaskChecker
    {
        public static List<string> ErrorMessages { get; set; }

        private static PointsPositionControl _pointsPositionControl;

        public TaskChecker(PointsPositionControl pointsPositionControl)
        {
            _pointsPositionControl = pointsPositionControl;
        }

        /// <summary>
        /// Метод для проверки задачи
        /// </summary>
        /// <param name="algorithmCode">Код алгоритма (базовый, основной, производный)</param>
        /// <param name="subgroupNumber">Подгруппа алгоритма</param>
        /// <param name="inputParams">Входные параметры заданные создателем задачи</param>
        /// <param name="outputParams">Выходные параметры - решение обучающегося</param>
        /// <param name="checkTrue">Параметр правильности решения</param>
        public static void ControlTask(string algorithmCode, string subgroupNumber,
            List<dynamic> inputParams,
            List<dynamic> outputParams,
            out bool checkTrue)
        {
            var code = string.Format("{0}.{1}", algorithmCode, subgroupNumber);
            switch (code)
            {
                case "B.0":
                    {
                        CheckNegativeCoordinates(inputParams);
                        CheckNegativeCoordinates(outputParams);
                        break;
                    }
                case "B.1":
                    {
                        for (int i = 0; i < outputParams.Count; i++)
                        {
                            if (!_pointsPositionControl.PointsIsPoints((Point2D)inputParams[i], (Point2D)inputParams[i]))
                            {
                                GenerateErrorMessage(3);
                            }
                        }
                        break;
                    }
                case "B.2":
                    break;
                case "B.3":
                    break;
            }
            checkTrue = true;
        }

        private static void CheckNegativeCoordinates(List<dynamic> paramsList)
        {
            foreach (var item in paramsList)
            {
                //if (item is IGeometric)
                //{
                //    var geomItem = item as IGeometric;
                //    if (geomItem.X < 0)
                //    {
                //        GenerateErrorMessage(1);
                //    }
                //    if (geomItem.Y < 0)
                //    {
                //        GenerateErrorMessage(2);
                //    }
                //}
            }
        }

        /// <summary>
        /// Генерация сообщения об ошибке в алгоритмах
        /// </summary>
        /// <param name="codeError">Код ошибки</param>
        private static void GenerateErrorMessage(int codeError)
        {
            ErrorMessagesDb errorDb = new ErrorMessagesDb();
            if (ErrorMessages == null)
                ErrorMessages = new List<string>();
            ErrorMessages.Add(errorDb.GetErrorMessageByCode(codeError));
        }
    }
}
