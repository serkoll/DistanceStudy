using System;
using System.Collections.Generic;
using System.Linq;
using DbRepository.Classes.Context;
using GeomObjects.Points;

namespace ControlTask
{
    public class TaskChecker
    {
        public static List<string> ErrorMessages { get; set; }

        private static PointsPositionControl _pointsPositionControl = new PointsPositionControl();

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
            List<object> inputParams,
            List<object> outputParams,
            out bool checkTrue)
        {
            checkTrue = true;
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
                            if (!_pointsPositionControl.PointsIsPoints((Point2D)inputParams[i], (Point2D)outputParams[i]))
                            {
                                var pointIn = (Point2D) inputParams[i];
                                var pointOut = (Point2D) outputParams[i];
                                GenerateErrorMessage($"Point with coords {pointIn.X}:{pointIn.Y} not equal {pointOut}");
                            }
                        }
                        break;
                    }
                case "B.2":
                    for (int i = 0; i < outputParams.Count; i++)
                    {
                        //if (!_pointsPositionControl.PointsIsPoints((Point3D)inputParams[i], (Point3D)outputParams[i]))
                        var itemIn = (Point3D) inputParams[i];
                        var itemOut = (Point3D)outputParams.FirstOrDefault(c => c != null);
                        if (!(Math.Abs(itemIn.Z - itemOut.Z) < 0.1 && Math.Abs(itemIn.X - itemOut.X) < 0.1 && Math.Abs(itemIn.Y - itemOut.Y) < 0.1))
                        {
                            var pointIn = (Point3D)inputParams[i];
                            var pointOut = (Point3D)outputParams[i];
                            GenerateErrorMessage($"Point with coords {pointIn.X}:{pointIn.Y}:{pointIn.Z} not equal {pointOut.X}:{pointOut.Y}:{pointOut.Z}");
                            checkTrue = false;
                        }
                    }
                    break;
                case "B.3":
                    break;
            }
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
        private static void GenerateErrorMessage(string codeError)
        {
            ErrorMessagesDb errorDb = new ErrorMessagesDb();
            if (ErrorMessages == null)
                ErrorMessages = new List<string>();
            ErrorMessages.Add(errorDb.GetErrorMessageByCode(codeError));
        }
    }
}
