using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeometryObjects;

namespace Point3DCntrl
{
    public class PointsProectionsControl
    {

        //private Point2D Point2D_Val = new Point2D();
        //private GeometryObjects.Point3D Point3D_Val = new GeometryObjects.Point3D();
        //private GeometryObjects.PointOfPlan1X0Y PointOfPlan1X0Y_Val = new GeometryObjects.PointOfPlan1X0Y();
        //private GeometryObjects.PointOfPlan2X0Z PointOfPlan2X0Z_Val = new GeometryObjects.PointOfPlan2X0Z();
        //private GeometryObjects.PointOfPlan3Y0Z PointOfPlan3Y0Z_Val = new GeometryObjects.PointOfPlan3Y0Z();
        //private GeometryObjects.PointsPositionControl PointsPositionControl_Val = new GeometryObjects.PointsPositionControl();

        /// <summary>
        /// Контролирует существование значения координаты X
        /// </summary>
        /// <param name="InitialParams">Входные параметры (не используются)</param>
        /// <param name="UserParams">Параметры, введенные пользователем: значение координаты X.</param>
        /// <param name="SolveParams">Параметры решения (не добавляются)</param>
        /// <param name="CommentsTrue">Комментарии правильного решения</param>
        /// <param name="CommentsFalse">Комментарии неправильно решения</param>
        /// <returns>Возвращает "True", если значение координаты X существует</returns>
        /// <remarks>Комментарии правильного решения: ключи: "InputX_t_1" - "Значение координаты X задано";
        ///          Комментарии ложного решения: ключи: "InputX_f_1" - "Не задано значение координаты X".</remarks>
        public bool Input_X(Dictionary<string, object> InitialParams, Dictionary<string, object> UserParams, ref Dictionary<string, object> SolveParams, ref Dictionary<string, string> CommentsTrue, ref Dictionary<string, string> CommentsFalse)
        {
            if (UserParams.Count != 0) //Контроль существования объектов в заданном словаре
            {
                object Object_Val = 0;//Переменная для извлечения объектов        
                UserParams.TryGetValue(nameof(Point3D), out Object_Val);
                var point3D = (Point3D)Object_Val;
                if (point3D != null) //Контроль существования извлеченного объекта
                {
                    CommentsTrue.Add("InputX_t_1", "Значение координаты X задано");
                    return true;
                }
                else { CommentsFalse.Add("InputX_f_1", "Не задано значение координаты X"); return false; }
            }
            else { CommentsFalse.Add("InputX_f_1", "Не задано значение координаты X"); return false; }
        }

        /// <summary>
        /// Контролирует существование значения координаты Y
        /// </summary>
        /// <param name="InitialParams">Входные параметры (не используются)</param>
        /// <param name="UserParams">Параметры, введенные пользователем: значение координаты Y.</param>
        /// <param name="SolveParams">Параметры решения (не добавляются)</param>
        /// <param name="CommentsTrue">Комментарии правильного решения</param>
        /// <param name="CommentsFalse">Комментарии неправильно решения</param>
        /// <returns>Возвращает "True", если значение координаты Y существует</returns>
        /// <remarks>Комментарии правильного решения: ключи: "InputY_t_1" - "Значение координаты Y задано";
        ///          Комментарии ложного решения: ключи: "InputY_f_1" - "Не задано значение координаты Y".</remarks>
        public bool Input_Y(Dictionary<string, object> InitialParams, Dictionary<string, object> UserParams, ref Dictionary<string, object> SolveParams, ref Dictionary<string, string> CommentsTrue, ref Dictionary<string, string> CommentsFalse)
        {
            if (UserParams.Count != 0) //Контроль существования объектов в заданном словаре
            {
                object Object_Val = 0;//Переменная для извлечения объектов        
                UserParams.TryGetValue(nameof(Point3D), out Object_Val);
                if (Object_Val != null) //Контроль существования извлеченного объекта
                {
                    CommentsTrue.Add("InputY_t_1", "Значение координаты Y задано"); return true;
                }
                else { CommentsFalse.Add("InputY_f_1", "Не задано значение координаты Y"); return false; }
            }
            else { CommentsFalse.Add("InputY_f_1", "Не задано значение координаты Y"); return false; }
        }

        /// <summary>
        /// Контролирует существование значения координаты Z
        /// </summary>
        /// <param name="InitialParams">Входные параметры (не используются)</param>
        /// <param name="UserParams">Параметры, введенные пользователем: значение координаты Z.</param>
        /// <param name="SolveParams">Параметры решения (не добавляются)</param>
        /// <param name="CommentsTrue">Комментарии правильного решения</param>
        /// <param name="CommentsFalse">Комментарии неправильно решения</param>
        /// <returns>Возвращает "True", если значение координаты Z существует</returns>
        /// <remarks>Комментарии правильного решения: ключи: "InputZ_t_1" - "Значение координаты Z задано";
        ///          Комментарии ложного решения: ключи: "InputZ_f_1" - "Не задано значение координаты Z".</remarks>
        public bool Input_Z(Dictionary<string, object> InitialParams, Dictionary<string, object> UserParams, ref Dictionary<string, object> SolveParams, ref Dictionary<string, string> CommentsTrue, ref Dictionary<string, string> CommentsFalse)
        {
            if (UserParams.Count != 0) //Контроль существования объектов в заданном словаре
            {
                object Object_Val = 0;//Переменная для извлечения объектов        
                UserParams.TryGetValue(nameof(Point3D), out Object_Val);
                if (Object_Val != null) //Контроль существования извлеченного объекта
                {
                    CommentsTrue.Add("InputZ_t_1", "Значение координаты Z задано"); return true;
                }
                else { CommentsFalse.Add("InputZ_f_1", "Не задано значение координаты Z"); return false; }
            }
            else { CommentsFalse.Add("InputZ_f_1", "Не задано значение координаты Z"); return false; }
        }

        /// <summary>
        /// Контролирует отсутсвие отрицательных значений координат X, Y, Z
        /// </summary>
        /// <param name="InitialParams">Входные параметры (не используются)</param>
        /// <param name="UserParams">Параметры, введенные пользователем: значения координат X, Y, Z или объект "Point3D".</param>
        /// <param name="SolveParams">Параметры решения</param>
        /// <param name="CommentsTrue">Комментарии правильного решения</param>
        /// <param name="CommentsFalse">Комментарии неправильно решения</param>
        /// <returns>Возвращает "True", если значения координат X, Y, Z положительные</returns>
        /// <remarks>Добавляет объект "Point3D" в SolveParams, если значения координат X, Y, Z положительные.
        ///          Комментарии правильного решения: ключи: "PointMinus_t_1" - "Заданные координаты имеют положительные значения";
        ///          Комментарии ложного решения: ключи: "PointMinus_f_1" - "Координаты: ... имеют отрицательные значения";
        ///                                              "PointMinus_f_2" - "Тип заданного объекта, не соответсвует типу 'Point3D'" (системная ошибка);
        ///                                              "PointMinus_f_3" - "Объект 'Point3D' не существует" (системная ошибка);
        ///                                              "PointMinus_f_4" - "Отсутствуют введенные пользователем данные" (системная ошибка).</remarks>
        public bool PointMinus(Dictionary<string, object> InitialParams, Dictionary<string, object> UserParams, ref Dictionary<string, object> SolveParams, ref Dictionary<string, string> CommentsTrue, ref Dictionary<string, string> CommentsFalse)
        {
            bool Solve = true;//Значение "True", т.к. при обнаружении отрицательного значения PointsPositionControl_Val.PointMinus(Point3D_Solve, GeometryObjects.PointsPositionControl.Coordinate_Value) возвращает "True"
            string SolveCommet_1 = "Координаты:";
            Point3D Point3D = new Point3D();
            PointsPositionControl PointsPositionControl = new PointsPositionControl();
            if (UserParams.Count != 0) //Контроль существования объектов в заданном словаре
            {
                object Object_Val = 0;//Переменная для извлечения объектов              

                if (UserParams.ContainsKey(typeof(Point3D).ToString()))
                {
                    UserParams.TryGetValue("Point3D", out Object_Val);//Извлечение объекта из словаря
                    if (Object_Val != null && !Object_Val.Equals(""))//Контроль существования извлеченного объекта "Point3D"
                    {
                        //Point3D_Val = (GeometryObjects.Point3D)InitialParams["Point3D"];
                        if (Object_Val.GetType().Name == "Point3D")//Контроль типа объекта, извлеченного из словаря
                        {
                            Point3D = (GeometryObjects.Point3D)UserParams["Point3D"]; //Запись объекта в экземпляр класса
                            //Solve = PointsPositionControl.PointMinus(Point3D, PointsPositionControl.Coordinate_Value);//Анализ отрицательности
                            if (!Solve)
                            {
                                SolveParams.Add("Point3D", Point3D);//Добавление экземпляра 3D точки в словарь решений
                                CommentsTrue.Add("PointMinus_t_1", "Заданные координаты имеют положительные значения"); //Добавление комментария положительного решения                                                           
                            }
                            else { /*SolveCommet_1 += PointsPositionControl.Coordinate_Value;*/ CommentsFalse.Add("PointMinus_f_1", SolveCommet_1 += "имеют отрицательные значения"); }//Добавление комментария отрицательного решения
                            return !Solve;
                        }
                        else { CommentsFalse.Add("PointMinus_f_2", "Тип заданного объекта, не соответсвует типу 'Point3D'"); return false; }
                    }
                    else { CommentsFalse.Add("PointMinus_f_3", "Объект 'Point3D' не существует"); return false; }
                }

                if (UserParams.ContainsKey("X") || UserParams.ContainsKey("Y") || UserParams.ContainsKey("Z"))
                {
                    UserParams.TryGetValue("X", out Object_Val);
                    if (Object_Val != null && !Object_Val.Equals(""))//Контроль существования извлеченного объекта "X" //Не требуется!!!
                    {
                        Point3D.X = Convert.ToDouble(Object_Val);
                    }
                    //else { CommentsFalse.Add("PointMinus_f_4", "Не задано значение координаты X"); return !Solve; } //Не требуется!!!
                    UserParams.TryGetValue("Y", out Object_Val);
                    if (Object_Val != null && !Object_Val.Equals(""))//Контроль существования извлеченного объекта "Y"
                    {
                        Point3D.Y = Convert.ToDouble(Object_Val);
                    }
                    //else { CommentsFalse.Add("PointMinus_f_5", "Не задано значение координаты Y"); return !Solve; }
                    UserParams.TryGetValue("Z", out Object_Val);
                    if (Object_Val != null && !Object_Val.Equals(""))//Контроль существования извлеченного объекта "Z" //Не требуется!!!
                    {
                        Point3D.Z = Convert.ToDouble(Object_Val);
                    }
                    //else { CommentsFalse.Add("PointMinus_f_6", "Не задано значение координаты Z"); return !Solve; }
                    //Solve = PointsPositionControl.PointMinus(Point3D, GeometryObjects.PointsPositionControl.Coordinate_Value);// Анализ отрицательности
                    if (!Solve)
                    {
                        SolveParams.Add("Point3D", Point3D);//Добавление экземпляра решения в словарь решений
                        CommentsTrue.Add("PointMinus_t_1", "Заданные координаты имеют положительные значения");//Добавление комментария положительного решения
                    }
                    else { /*SolveCommet_1 += PointsPositionControl.Coordinate_Value;*/ CommentsFalse.Add("PointMinus_f_1", SolveCommet_1 += "имеют отрицательные значения"); }// Добавление комментария отрицательного решения
                    return !Solve;
                }
                else { return !Solve; }
            }
            else { CommentsFalse.Add("PointMinus_f_4", "Отсутствуют введенные пользователем данные"); return !Solve; }
        }

        /// <summary>
        /// Контроль задания координат горизонтальной проекции точки (P1).
        /// </summary>
        /// <param name="InitialParams">Входные параметры (не используются)</param>
        /// <param name="UserParams">Параметры, введенные пользователем: значения координат X, Y или X, Y, Z.</param>
        /// <param name="SolveParams">Параметры решения</param>
        /// <param name="CommentsTrue">Комментарии правильного решения</param>
        /// <param name="CommentsFalse">Комментарии неправильно решения</param>
        /// <returns>Возвращает "True", если заданы значения координат X, Y и не задано значение координаты Z.</returns>
        /// <remarks>Добавляет объект "PointOfPlan1X0Y" в SolveParams, если заданы значения координат X, Y и не задано значение координаты Z.
        ///          Комментарии правильного решения: ключи: "PointOfPlan1X0Y_ByXY_t_1" - "Задано значение координаты 'X' горизонтальной проекции точки";
        ///                                                  "PointOfPlan1X0Y_ByXY_t_2" - "Задано значение координаты 'Y' горизонтальной проекции точки";
        ///                                                  "PointOfPlan1X0Y_ByXY_t_3" - "Координаты горизонтальной проекции точки заданы верно".
        ///          Комментарии ложного решения: ключи: "PointOfPlan1X0Y_ByXY_f_1" - "Не задано значение координаты 'X' горизонтальной проекции точки";
        ///                                              "PointOfPlan1X0Y_ByXY_f_2" - "Не задано значение координаты 'Y' горизонтальной проекции точки";
        ///                                              "PointOfPlan1X0Y_ByXY_f_3" - "Неверно заданы координаты горизонтальной проекции точки";
        ///                                              "PointOfPlan1X0Y_ByXY_f_4" - "Отсутствуют введенные пользователем данные" (системная ошибка).</remarks>
        public bool PointOfPlan1X0Y_ByXY(Dictionary<string, object> InitialParams, Dictionary<string, object> UserParams, ref Dictionary<string, object> SolveParams, ref Dictionary<string, string> CommentsTrue, ref Dictionary<string, string> CommentsFalse)
        {
            bool Solve = false;
            //string SolveCommet_1 = ""
            PointOfPlan1X0Y PointOfPlan1X0Y = new PointOfPlan1X0Y();

            if (UserParams.Count != 0) //Контроль существования объектов в заданном словаре
            {
                object Object_Val = 0;//Переменная для извлечения объектов 
                if (UserParams.ContainsKey("Z"))
                {
                    UserParams.TryGetValue("Z", out Object_Val);
                    if (Object_Val != null && !Object_Val.Equals(""))//Контроль существования извлеченного объекта "Z"
                    {
                        CommentsFalse.Add("PointOfPlan1X0Y_ByXY_f_3", "Неверно заданы координаты горизонтальной проекции точки"); return Solve;
                    }
                }

                if (UserParams.ContainsKey("X"))
                {
                    UserParams.TryGetValue("X", out Object_Val);
                    if (Object_Val != null && !Object_Val.Equals(""))//Контроль существования извлеченного объекта "X"
                    {
                        PointOfPlan1X0Y.X = Convert.ToDouble(Object_Val); Solve = true;
                        CommentsTrue.Add("PointOfPlan1X0Y_ByXY_t_1", "Задано значение координаты 'X' горизонтальной проекции точки");
                    }
                    else { CommentsFalse.Add("PointOfPlan1X0Y_ByXY_f_1", "Не задано значение координаты 'X' горизонтальной проекции точки"); }//Добавление комментария отрицательного решения  
                }
                else { CommentsFalse.Add("PointOfPlan1X0Y_ByXY_f_1", "Не задано значение координаты 'X' горизонтальной проекции точки"); }//Добавление комментария отрицательного решения  

                if (UserParams.ContainsKey("Y"))
                {
                    UserParams.TryGetValue("Y", out Object_Val);
                    if (Object_Val != null && !Object_Val.Equals(""))//Контроль существования извлеченного объекта "Y"
                    {
                        PointOfPlan1X0Y.Y = Convert.ToDouble(Object_Val); // Не устанавливается "Solve = true;", т.к. это значение устанавливается при существующем значении координаты X
                        CommentsTrue.Add("PointOfPlan1X0Y_ByXY_t_2", "Задано значение координаты 'Y' горизонтальной проекции точки");
                    }
                    else { CommentsFalse.Add("PointOfPlan1X0Y_ByXY_f_2", "Не задано значение координаты 'Y' горизонтальной проекции точки"); Solve = false; }//Добавление комментария отрицательного решения  
                }
                else { CommentsFalse.Add("PointOfPlan1X0Y_ByXY_f_2", "Не задано значение координаты 'Y' горизонтальной проекции точки"); Solve = false; }//Добавление комментария отрицательного решения                
            }
            else { CommentsFalse.Add("PointOfPlan1X0Y_ByXY_f_4", "Отсутствуют введенные пользователем данные"); return Solve; }
            if (Solve == true)
            {
                SolveParams.Add("PointOfPlan1X0Y", PointOfPlan1X0Y);//Добавление экземпляра решения в словарь решений
                CommentsTrue.Add("PointOfPlan1X0Y_ByXY_t_3", "Координаты горизонтальной проекции точки заданы верно");
            }
            else { CommentsFalse.Add("PointOfPlan1X0Y_ByXY_f_3", "Неверно заданы координаты горизонтальной проекции точки"); }
            return Solve;
        }

        /// <summary>
        /// Контроль задания координат фронтальной проекции точки (P2).
        /// </summary>
        /// <param name="InitialParams">Входные параметры (не используются)</param>
        /// <param name="UserParams">Параметры, введенные пользователем: значения координат X, Z или X, Y, Z.</param>
        /// <param name="SolveParams">Параметры решения</param>
        /// <param name="CommentsTrue">Комментарии правильного решения</param>
        /// <param name="CommentsFalse">Комментарии неправильно решения</param>
        /// <returns>Возвращает "True", если заданы значения координат X, Z и не задано значение координаты Y.</returns>
        /// <remarks>Добавляет объект "PointOfPlan1X0Y" в SolveParams, если заданы значения координат X, Z и не задано значение координаты Y.
        ///          Комментарии правильного решения: ключи: "PointOfPlan2X0Z_ByXZ_t_1" - "Задано значение координаты 'X' фронтальной проекции точки";
        ///                                                  "PointOfPlan2X0Z_ByXZ_t_2" - "Задано значение координаты 'Z' фронтальной проекции точки";
        ///                                                  "PointOfPlan2X0Z_ByXZ_t_3" - "Координаты фронтальной проекции точки заданы верно".
        ///          Комментарии ложного решения: ключи: "PointOfPlan2X0Z_ByXZ_f_1" - "Не задано значение координаты 'X'";
        ///                                              "PointOfPlan2X0Z_ByXZ_f_2" - "Не задано значение координаты 'Z' фронтальной проекции точки";
        ///                                              "PointOfPlan2X0Z_ByXZ_f_3" - "Неверно заданы координаты фронтальной проекции точки";
        ///                                              "PointOfPlan2X0Z_ByXZ_f_4" - "Отсутствуют введенные пользователем данные" (системная ошибка).</remarks>
        public bool PointOfPlan2X0Z_ByXZ(Dictionary<string, object> InitialParams, Dictionary<string, object> UserParams, ref Dictionary<string, object> SolveParams, ref Dictionary<string, string> CommentsTrue, ref Dictionary<string, string> CommentsFalse)
        {
            bool Solve = false;
            PointOfPlan2X0Z PointOfPlan2X0Z = new PointOfPlan2X0Z();
            if (UserParams.Count != 0) //Контроль существования объектов в заданном словаре
            {
                object Object_Val = 0;//Переменная для извлечения объектов 
                if (UserParams.ContainsKey("Y"))
                {
                    UserParams.TryGetValue("Y", out Object_Val);
                    if (Object_Val != null && !Object_Val.Equals(""))//Контроль существования извлеченного объекта "Y"
                    {
                        CommentsFalse.Add("PointOfPlan2X0Z_ByXZ_f_3", "Неверно заданы координаты фронтальной проекции точки"); return Solve;
                    }
                }
                if (UserParams.ContainsKey("X"))
                {
                    UserParams.TryGetValue("X", out Object_Val);
                    if (Object_Val != null && !Object_Val.Equals(""))//Контроль существования извлеченного объекта "X"
                    {
                        PointOfPlan2X0Z.X = Convert.ToDouble(Object_Val); Solve = true;
                        CommentsTrue.Add("PointOfPlan2X0Z_ByXZ_t_1", "Задано значение координаты 'X' фронтальной проекции точки");
                    }
                    else { CommentsFalse.Add("PointOfPlan2X0Z_ByXZ_f_1", "Не задано значение координаты 'X' фронтальной проекции точки"); }//Добавление комментария отрицательного решения  
                }
                else { CommentsFalse.Add("PointOfPlan2X0Z_ByXZ_f_1", "Не задано значение координаты 'X' фронтальной проекции точки"); }//Добавление комментария отрицательного решения  

                if (UserParams.ContainsKey("Z"))
                {
                    UserParams.TryGetValue("Z", out Object_Val);
                    if (Object_Val != null && !Object_Val.Equals(""))//Контроль существования извлеченного объекта "Z"
                    {
                        PointOfPlan2X0Z.Z = Convert.ToDouble(Object_Val); // Не устанавливается "Solve = true;", т.к. это значение устанавливается при существующем значении координаты X
                        CommentsTrue.Add("PointOfPlan2X0Z_ByXZ_t_2", "Задано значение координаты 'Z' фронтальной проекции точки");
                    }
                    else { CommentsFalse.Add("PointOfPlan2X0Z_ByXZ_f_2", "Не задано значение координаты 'Z' фронтальной проекции точки"); Solve = false; }//Добавление комментария отрицательного решения  
                }
                else { CommentsFalse.Add("PointOfPlan2X0Z_ByXZ_f_2", "Не задано значение координаты 'Z' фронтальной проекции точки"); Solve = false; }//Добавление комментария отрицательного решения                
            }
            else { CommentsFalse.Add("PointOfPlan2X0Z_ByXZ_f_4", "Отсутствуют введенные пользователем данные"); return Solve; }
            if (Solve == true)
            {
                SolveParams.Add("PointOfPlan2X0Z", PointOfPlan2X0Z);//Добавление экземпляра решения в словарь решений
                CommentsTrue.Add("PointOfPlan2X0Z_ByXZ_t_3", "Координаты фронтальной проекции точки заданы верно");
            }
            else { CommentsFalse.Add("PointOfPlan2X0Z_ByXZ_f_3", "Неверно заданы координаты фронтальной проекции точки"); }
            return Solve;
        }

        /// <summary>
        /// Контроль задания координат профильной проекции точки (P3).
        /// </summary>
        /// <param name="InitialParams">Входные параметры (не используются)</param>
        /// <param name="UserParams">Параметры, введенные пользователем: значения координат Y, Z или X, Y, Z.</param>
        /// <param name="SolveParams">Параметры решения</param>
        /// <param name="CommentsTrue">Комментарии правильного решения</param>
        /// <param name="CommentsFalse">Комментарии неправильно решения</param>
        /// <returns>Возвращает "True", если заданы значения координат Y, Z и не задано значение координаты X.</returns>
        /// <remarks>Добавляет объект "PointOfPlan1X0Y" в SolveParams, если заданы значения координат Y, Z и не задано значение координаты X.
        ///          Комментарии правильного решения: ключи: "PointOfPlan3Y0Z_ByYZ_t_1" - "Задано значение координаты 'Y' профильной проекции точки";
        ///                                                  "PointOfPlan3Y0Z_ByYZ_t_2" - "Задано значение координаты 'Z' профильной проекции точки";
        ///                                                  "PointOfPlan3Y0Z_ByYZ_t_3" - "Координаты горизонтальной проекции точки заданы верно".
        ///          Комментарии ложного решения: ключи: "PointOfPlan3Y0Z_ByYZ_f_1" - "Не задано значение координаты 'Y'";
        ///                                              "PointOfPlan3Y0Z_ByYZ_f_2" - "Не задано значение координаты 'Z' профильной проекции точки";
        ///                                              "PointOfPlan3Y0Z_ByYZ_f_3" - "Неверно заданы координаты профильной проекции точки";
        ///                                              "PointOfPlan3Y0Z_ByYZ_f_4" - "Отсутствуют введенные пользователем данные" (системная ошибка).</remarks>
        public bool PointOfPlan3Y0Z_ByYZ(Dictionary<string, object> InitialParams, Dictionary<string, object> UserParams, ref Dictionary<string, object> SolveParams, ref Dictionary<string, string> CommentsTrue, ref Dictionary<string, string> CommentsFalse)
        {
            bool Solve = false;
            PointOfPlan3Y0Z PointOfPlan3Y0Z = new PointOfPlan3Y0Z();
            if (UserParams.Count != 0) //Контроль существования объектов в заданном словаре
            {
                object Object_Val = 0;//Переменная для извлечения объектов 
                if (UserParams.ContainsKey("X"))
                {
                    UserParams.TryGetValue("X", out Object_Val);
                    if (Object_Val != null && !Object_Val.Equals(""))//Контроль существования извлеченного объекта "X"
                    {
                        CommentsFalse.Add("PointOfPlan3Y0Z_ByYZ_f_3", "Неверно заданы координаты профильной проекции точки"); return Solve;
                    }
                }
                if (UserParams.ContainsKey("Y"))
                {
                    UserParams.TryGetValue("Y", out Object_Val);
                    if (Object_Val != null && !Object_Val.Equals(""))//Контроль существования извлеченного объекта "X"
                    {
                        PointOfPlan3Y0Z.Y = Convert.ToDouble(Object_Val); Solve = true;
                        CommentsTrue.Add("PointOfPlan3Y0Z_ByYZ_t_1", "Задано значение координаты 'Y' профильной проекции точки");
                    }
                    else { CommentsFalse.Add("PointOfPlan3Y0Z_ByYZ_f_1", "Не задано значение координаты 'Y' профильной проекции точки"); }//Добавление комментария отрицательного решения  
                }
                else { CommentsFalse.Add("PointOfPlan3Y0Z_ByYZ_f_1", "Не задано значение координаты 'Y' профильной проекции точки"); }//Добавление комментария отрицательного решения  

                if (UserParams.ContainsKey("Z"))
                {
                    UserParams.TryGetValue("Z", out Object_Val);
                    if (Object_Val != null && !Object_Val.Equals(""))//Контроль существования извлеченного объекта "Z"
                    {
                        PointOfPlan3Y0Z.Z = Convert.ToDouble(Object_Val); // Не устанавливается "Solve = true;", т.к. это значение устанавливается при существующем значении координаты X
                        CommentsTrue.Add("PointOfPlan3Y0Z_ByYZ_t_2", "Задано значение координаты 'Z' профильной проекции точки");
                    }
                    else { CommentsFalse.Add("PointOfPlan3Y0Z_ByYZ_f_2", "Не задано значение координаты 'Z' профильной проекции точки"); Solve = false; }//Добавление комментария отрицательного решения  
                }
                else { CommentsFalse.Add("PointOfPlan3Y0Z_ByYZ_f_2", "Не задано значение координаты 'Z' профильной проекции точки"); Solve = false; }//Добавление комментария отрицательного решения                
            }
            else { CommentsFalse.Add("PointOfPlan3Y0Z_ByYZ_f_4", "Отсутствуют введенные пользователем данные"); return Solve; }
            if (Solve == true)
            {
                SolveParams.Add("PointOfPlan3Y0Z", PointOfPlan3Y0Z);//Добавление экземпляра решения в словарь решений
                CommentsTrue.Add("PointOfPlan3Y0Z_ByYZ_t_3", "Координаты профильной проекции точки заданы верно");
            }
            else { CommentsFalse.Add("PointOfPlan3Y0Z_ByYZ_f_3", "Неверно заданы координаты профильной проекции точки"); }
            return Solve;
        }

        /// <summary>
        /// Контроль соответсвия координат горизонтальной и фронтальной проекций точки (P1, P2).
        /// </summary>
        /// <param name="InitialParams">Входные параметры (не используются)</param>
        /// <param name="UserParams">Параметры, введенные пользователем: объекты "PointOfPlan1X0Y" и "PointOfPlan2X0Z".</param>
        /// <param name="SolveParams">Параметры решения: добавляется объект "Point3D".</param>
        /// <param name="CommentsTrue">Комментарии правильного решения</param>
        /// <param name="CommentsFalse">Комментарии неправильно решения</param>
        /// <returns>Возвращает "True", если значение координаты X объекта "PointOfPlan1X0Y" равно значению координаты X объекта "PointOfPlan2X0Z".</returns>
        /// <remarks>Добавляет объект "Point3D" в SolveParams, если значение координаты X объекта "PointOfPlan1X0Y" равно значению координаты X объекта "PointOfPlan2X0Z".
        ///          Комментарии правильного решения: ключи: "PointOfPlans_1X0Y_2X0Z_t_1" - "Заданы значения координат горизонтальной проекции точки";
        ///                                                  "PointOfPlans_1X0Y_2X0Z_t_2" - "Заданы значения координат фронтальной проекции точки";
        ///                                                  "PointOfPlans_1X0Y_2X0Z_t_3" - "Координаты горизонтальной и фронтальной проекций точки заданы верно".
        ///          Комментарии ложного решения: ключи: "PointOfPlans_1X0Y_2X0Z_f_1" - "Не заданы значения координат горизонтальной проекции точки";
        ///                                              "PointOfPlans_1X0Y_2X0Z_f_2" - "Не заданы значения координат фронтальной проекции точки";
        ///                                              "PointOfPlans_1X0Y_2X0Z_f_3" - "Неверно заданы координаты горизонтальной и фронтальной проекций точки";
        ///                                              "PointOfPlans_1X0Y_2X0Z_f_4" - "Отсутствуют введенные пользователем данные" (системная ошибка).</remarks>
        public bool Point3D_ByP1P2(Dictionary<string, object> InitialParams, Dictionary<string, object> UserParams, ref Dictionary<string, object> SolveParams, ref Dictionary<string, string> CommentsTrue, ref Dictionary<string, string> CommentsFalse)
        {
            bool Solve = false;
            //string SolveCommet_1 = "";
            Point3D Point3D = new Point3D();
            PointOfPlan1X0Y PointOfPlan1X0Y = new PointOfPlan1X0Y();
            PointOfPlan2X0Z PointOfPlan2X0Z = new PointOfPlan2X0Z();
            ErrObject ErrorPoint3D = new ErrObject();
            if (UserParams.Count != 0) //Контроль существования объектов в заданном словаре
            {
                object Object_Val = 0;//Переменная для извлечения объектов                
                if (UserParams.ContainsKey("PointOfPlan1X0Y"))
                {
                    UserParams.TryGetValue("PointOfPlan1X0Y", out Object_Val);
                    if (Object_Val != null && !Object_Val.Equals(""))//Контроль существования извлеченного объекта "X"
                    {
                        PointOfPlan1X0Y = (PointOfPlan1X0Y)UserParams["PointOfPlan1X0Y"]; Solve = true; //Запись объекта в экземпляр класса
                        CommentsTrue.Add("PointOfPlans_1X0Y_2X0Z_t_1", "Заданы значения координат горизонтальной проекции точки");
                    }
                    else { CommentsFalse.Add("PointOfPlans_1X0Y_2X0Z_f_1", "Не заданы значения координат горизонтальной проекции точки"); }//Добавление комментария отрицательного решения  
                }
                else { CommentsFalse.Add("PointOfPlans_1X0Y_2X0Z_f_1", "Не заданы значения координат горизонтальной проекции точки"); }//Добавление комментария отрицательного решения  

                if (UserParams.ContainsKey("PointOfPlan2X0Z"))
                {
                    UserParams.TryGetValue("PointOfPlan2X0Z", out Object_Val);
                    if (Object_Val != null && !Object_Val.Equals(""))//Контроль существования извлеченного объекта "Y"
                    {
                        PointOfPlan2X0Z = (PointOfPlan2X0Z)UserParams["PointOfPlan2X0Z"]; //Запись объекта в экземпляр класса
                        CommentsTrue.Add("PointOfPlans_1X0Y_2X0Z_t_2", "Заданы значения координат фронтальной проекции точки");
                    }
                    else { CommentsFalse.Add("PointOfPlans_1X0Y_2X0Z_f_2", "Не заданы значения координат фронтальной проекции точки"); Solve = false; }//Добавление комментария отрицательного решения  
                }
                else { CommentsFalse.Add("PointOfPlans_1X0Y_2X0Z_f_2", "Не заданы значения координат фронтальной проекции точки"); Solve = false; }//Добавление комментария отрицательного решения                
            }
            else { CommentsFalse.Add("PointOfPlans_1X0Y_2X0Z_f_4", "Отсутствуют введенные пользователем данные"); return Solve; }
            if (Solve == true)
            {
                Solve = Equals(PointOfPlan1X0Y.X, PointOfPlan2X0Z.X);//Анализ соответсвия
                if (Solve == true)
                {
                    Point3D = Point3D.CreatePoint3DBy2Proections12(PointOfPlan1X0Y, PointOfPlan2X0Z, ref ErrorPoint3D, false);//Создание экземпляра объекта 'Point3D'
                    SolveParams.Add("Point3D", Point3D);//Добавление экземпляра решения в словарь решений
                    CommentsTrue.Add("PointOfPlans_1X0Y_2X0Z_t_3", "Координаты горизонтальной и фронтальной проекций точки заданы верно");
                }
                else { CommentsFalse.Add("PointOfPlans_1X0Y_2X0Z_f_3", "Неверно заданы координаты горизонтальной и фронтальной проекций точки"); }
            }
            else { CommentsFalse.Add("PointOfPlans_1X0Y_2X0Z_f_3", "Неверно заданы координаты горизонтальной и фронтальной проекций точки"); }
            return Solve;
        }

        /// <summary>
        /// Контроль соответсвия координат горизонтальной и профильной проекций точки (P1, P3).
        /// </summary>
        /// <param name="InitialParams">Входные параметры (не используются)</param>
        /// <param name="UserParams">Параметры, введенные пользователем: объекты "PointOfPlan1X0Y" и "PointOfPlan3Y0Z".</param>
        /// <param name="SolveParams">Параметры решения: добавляется объект "Point3D".</param>
        /// <param name="CommentsTrue">Комментарии правильного решения</param>
        /// <param name="CommentsFalse">Комментарии неправильно решения</param>
        /// <returns>Возвращает "True", если значение координаты Y объекта "PointOfPlan1X0Y" равно значению координаты Y объекта "PointOfPlan3Y0Z".</returns>
        /// <remarks>Добавляет объект "Point3D" в SolveParams, если значение координаты Y объекта "PointOfPlan1X0Y" равно значению координаты Y объекта "PointOfPlan3Y0Z".
        ///          Комментарии правильного решения: ключи: "PointOfPlans_1X0Y_3Y0Z_t_1" - "Заданы значения координат горизонтальной проекции точки";
        ///                                                  "PointOfPlans_1X0Y_3Y0Z_t_2" - "Заданы значения координат профильной проекции точки";
        ///                                                  "PointOfPlans_1X0Y_3Y0Z_t_3" - "Координаты горизонтальной и профильной проекций точки заданы верно".
        ///          Комментарии ложного решения: ключи: "PointOfPlans_1X0Y_3Y0Z_f_1" - "Не заданы значения координат горизонтальной проекции точки";
        ///                                              "PointOfPlans_1X0Y_3Y0Z_f_2" - "Не заданы значения координат профильной проекции точки";
        ///                                              "PointOfPlans_1X0Y_3Y0Z_f_3" - "Неверно заданы координаты горизонтальной и профильной проекций точки";
        ///                                              "PointOfPlans_1X0Y_3Y0Z_f_4" - "Отсутствуют введенные пользователем данные" (системная ошибка).</remarks>
        public bool Point3D_ByP1P3(Dictionary<string, object> InitialParams, Dictionary<string, object> UserParams, ref Dictionary<string, object> SolveParams, ref Dictionary<string, string> CommentsTrue, ref Dictionary<string, string> CommentsFalse)
        {
            bool Solve = false;
            Point3D Point3D = new Point3D();
            PointOfPlan1X0Y PointOfPlan1X0Y = new PointOfPlan1X0Y();
            PointOfPlan3Y0Z PointOfPlan3Y0Z = new PointOfPlan3Y0Z();
            ErrObject ErrorPoint3D = new ErrObject();
            if (UserParams.Count != 0) //Контроль существования объектов в заданном словаре
            {
                object Object_Val = 0;//Переменная для извлечения объектов                
                if (UserParams.ContainsKey("PointOfPlan1X0Y"))
                {
                    UserParams.TryGetValue("PointOfPlan1X0Y", out Object_Val);
                    if (Object_Val != null && !Object_Val.Equals(""))//Контроль существования извлеченного объекта
                    {
                        PointOfPlan1X0Y = (PointOfPlan1X0Y)UserParams["PointOfPlan1X0Y"]; Solve = true; //Запись объекта в экземпляр класса
                        CommentsTrue.Add("PointOfPlans_1X0Y_3Y0Z_t_1", "Заданы значения координат горизонтальной проекции точки");
                    }
                    else { CommentsFalse.Add("PointOfPlans_1X0Y_3Y0Z_f_1", "Не заданы значения координат горизонтальной проекции точки"); }//Добавление комментария отрицательного решения  
                }
                else { CommentsFalse.Add("PointOfPlans_1X0Y_3Y0Z_f_1", "Не заданы значения координат горизонтальной проекции точки"); }//Добавление комментария отрицательного решения  

                if (UserParams.ContainsKey("PointOfPlan3Y0Z"))
                {
                    UserParams.TryGetValue("PointOfPlan3Y0Z", out Object_Val);
                    if (Object_Val != null && !Object_Val.Equals(""))//Контроль существования извлеченного объекта
                    {
                        PointOfPlan3Y0Z = (PointOfPlan3Y0Z)UserParams["PointOfPlan3Y0Z"]; //Запись объекта в экземпляр класса
                        CommentsTrue.Add("PointOfPlans_1X0Y_3Y0Z_t_2", "Заданы значения координат профильной проекции точки");
                    }
                    else { CommentsFalse.Add("PointOfPlans_1X0Y_3Y0Z_f_2", "Не заданы значения координат профильной проекции точки"); Solve = false; }//Добавление комментария отрицательного решения  
                }
                else { CommentsFalse.Add("PointOfPlans_1X0Y_3Y0Z_f_2", "Не заданы значения координат профильной проекции точки"); Solve = false; }//Добавление комментария отрицательного решения                
            }
            else { CommentsFalse.Add("PointOfPlans_1X0Y_3Y0Z_f_4", "Отсутствуют введенные пользователем данные"); return Solve; }
            if (Solve == true)
            {
                Solve = Equals(PointOfPlan1X0Y.Y, PointOfPlan3Y0Z.Y);//Анализ соответсвия
                if (Solve == true)
                {
                    Point3D = Point3D.CreatePoint3DBy2Proections13(PointOfPlan1X0Y, PointOfPlan3Y0Z, ref ErrorPoint3D, false);//Создание экземпляра объекта 'Point3D'
                    SolveParams.Add("Point3D", Point3D);//Добавление экземпляра решения в словарь решений
                    CommentsTrue.Add("PointOfPlans_1X0Y_3Y0Z_t_3", "Координаты горизонтальной и профильной проекций точки заданы верно");
                }
                else { CommentsFalse.Add("PointOfPlans_1X0Y_3Y0Z_f_3", "Неверно заданы координаты горизонтальной и профильной проекций точки"); }
            }
            else { CommentsFalse.Add("PointOfPlans_1X0Y_3Y0Z_f_3", "Неверно заданы координаты горизонтальной и профильной проекций точки"); }
            return Solve;
        }

        /// <summary>
        /// Контроль соответсвия координат фронтальной и профильной проекций точки (P2, P3).
        /// </summary>
        /// <param name="InitialParams">Входные параметры (не используются)</param>
        /// <param name="UserParams">Параметры, введенные пользователем: объекты "PointOfPlan2X0Z" и "PointOfPlan3Y0Z".</param>
        /// <param name="SolveParams">Параметры решения: добавляется объект "Point3D".</param>
        /// <param name="CommentsTrue">Комментарии правильного решения</param>
        /// <param name="CommentsFalse">Комментарии неправильно решения</param>
        /// <returns>Возвращает "True", если значение координаты Z объекта "PointOfPlan2X0Z" равно значению координаты Z объекта "PointOfPlan3Y0Z".</returns>
        /// <remarks>Добавляет объект "Point3D" в SolveParams, если значение координаты Z объекта "PointOfPlan2X0Z" равно значению координаты Z объекта "PointOfPlan3Y0Z".
        ///          Комментарии правильного решения: ключи: "PointOfPlans_2X0Z_3Y0Z_t_1" - "Заданы значения координат фронтальной проекции точки";
        ///                                                  "PointOfPlans_2X0Z_3Y0Z_t_2" - "Заданы значения координат профильной проекции точки";
        ///                                                  "PointOfPlans_2X0Z_3Y0Z_t_3" - "Координаты фронтальной и профильной проекций точки заданы верно".
        ///          Комментарии ложного решения: ключи: "PointOfPlans_2X0Z_3Y0Z_f_1" - "Не заданы значения координат фронтальной проекции точки";
        ///                                              "PointOfPlans_2X0Z_3Y0Z_f_2" - "Не заданы значения координат профильной проекции точки";
        ///                                              "PointOfPlans_2X0Z_3Y0Z_f_3" - "Неверно заданы координаты фронтальной и профильной проекций точки";
        ///                                              "PointOfPlans_2X0Z_3Y0Z_f_4" - "Отсутствуют введенные пользователем данные" (системная ошибка).</remarks>
        public bool Point3D_ByP2P3(Dictionary<string, object> InitialParams, Dictionary<string, object> UserParams, ref Dictionary<string, object> SolveParams, ref Dictionary<string, string> CommentsTrue, ref Dictionary<string, string> CommentsFalse)
        {
            bool Solve = false;
            Point3D Point3D = new Point3D();
            PointOfPlan2X0Z PointOfPlan2X0Z = new PointOfPlan2X0Z();
            PointOfPlan3Y0Z PointOfPlan3Y0Z = new PointOfPlan3Y0Z();
            ErrObject ErrorPoint3D = new ErrObject();
            if (UserParams.Count != 0) //Контроль существования объектов в заданном словаре
            {
                object Object_Val = 0;//Переменная для извлечения объектов                
                if (UserParams.ContainsKey("PointOfPlan2X0Z"))
                {
                    UserParams.TryGetValue("PointOfPlan2X0Z", out Object_Val);
                    if (Object_Val != null && !Object_Val.Equals(""))//Контроль существования извлеченного объекта
                    {
                        PointOfPlan2X0Z = (PointOfPlan2X0Z)UserParams["PointOfPlan2X0Z"]; Solve = true; //Запись объекта в экземпляр класса
                        CommentsTrue.Add("PointOfPlans_2X0Z_3Y0Z_t_1", "Заданы значения координат фронтальной проекции точки");
                    }
                    else { CommentsFalse.Add("PointOfPlans_2X0Z_3Y0Z_f_1", "Не заданы значения координат фронтальной проекции точки"); }//Добавление комментария отрицательного решения  
                }
                else { CommentsFalse.Add("PointOfPlans_2X0Z_3Y0Z_f_1", "Не заданы значения координат фронтальной проекции точки"); }//Добавление комментария отрицательного решения  

                if (UserParams.ContainsKey("PointOfPlan3Y0Z"))
                {
                    UserParams.TryGetValue("PointOfPlan3Y0Z", out Object_Val);
                    if (Object_Val != null && !Object_Val.Equals(""))//Контроль существования извлеченного объекта
                    {
                        PointOfPlan3Y0Z = (PointOfPlan3Y0Z)UserParams["PointOfPlan3Y0Z"]; //Запись объекта в экземпляр класса
                        CommentsTrue.Add("PointOfPlans_2X0Z_3Y0Z_t_2", "Заданы значения координат профильной проекции точки");
                    }
                    else { CommentsFalse.Add("PointOfPlans_2X0Z_3Y0Z_f_2", "Не заданы значения координат профильной проекции точки"); Solve = false; }//Добавление комментария отрицательного решения  
                }
                else { CommentsFalse.Add("PointOfPlans_2X0Z_3Y0Z_f_2", "Не заданы значения координат профильной проекции точки"); Solve = false; }//Добавление комментария отрицательного решения                
            }
            else { CommentsFalse.Add("PointOfPlans_2X0Z_3Y0Z_f_4", "Отсутствуют введенные пользователем данные"); return Solve; }
            if (Solve == true)
            {
                Solve = Equals(PointOfPlan2X0Z.Z, PointOfPlan3Y0Z.Z);//Анализ соответсвия
                if (Solve == true)
                {
                    Point3D = Point3D.CreatePoint3DBy2Proections23(PointOfPlan2X0Z, PointOfPlan3Y0Z, ref ErrorPoint3D, false);//Создание экземпляра объекта 'Point3D'
                    SolveParams.Add("Point3D", Point3D);//Добавление экземпляра решения в словарь решений
                    CommentsTrue.Add("PointOfPlans_2X0Z_3Y0Z_t_3", "Координаты фронтальной и профильной проекций точки заданы верно");
                }
                else { CommentsFalse.Add("PointOfPlans_2X0Z_3Y0Z_f_3", "Неверно заданы координаты фронтальной и профильной проекций точки"); }
            }
            else { CommentsFalse.Add("PointOfPlans_2X0Z_3Y0Z_f_3", "Неверно заданы координаты фронтальной и профильной проекций точки"); }
            return Solve;
        }

        /// <summary>
        /// Контроль принадлежности горизонтальной плоскости проекций 3D точки, заданной фронтальной проекцией (P2).
        /// </summary>
        /// <param name="InitialParams">Входные параметры (не используются)</param>
        /// <param name="UserParams">Параметры, введенные пользователем: объект "PointOfPlan2X0Z".</param>
        /// <param name="SolveParams">Параметры решения: (не добавляется).</param>
        /// <param name="CommentsTrue">Комментарии правильного решения</param>
        /// <param name="CommentsFalse">Комментарии неправильно решения</param>
        /// <returns>Возвращает "True", если значение координаты Z объекта "PointOfPlan2X0Z" равно нулю.</returns>
        /// <remarks>Комментарии правильного решения: ключи: "PointsOfPlan1_P2_t_1" - "Задана фронтальная проекция точки";
        ///                                                  "PointsOfPlan1_P2_t_2" - "3D точка, соответсвующая заданной фронтальной проекции, принадлежит горизонтальной плоскости проекций".
        ///          Комментарии ложного решения: ключи: "PointsOfPlan1_P2_f_1" - "Не задана фронтальная проекция точки";
        ///                                              "PointsOfPlan1_P2_f_2" - "3D точка, соответсвующая заданной фронтальной проекции, не принадлежит горизонтальной плоскости проекций".
        public bool Point2_OfPlan1X0Y(Dictionary<string, object> InitialParams, Dictionary<string, object> UserParams, ref Dictionary<string, object> SolveParams, ref Dictionary<string, string> CommentsTrue, ref Dictionary<string, string> CommentsFalse)
        {
            bool Solve = false;
            if (UserParams.Count != 0) //Контроль существования объектов в заданном словаре
            {
                PointOfPlan2X0Z PointOfPlan2X0Z = new PointOfPlan2X0Z();
                object Object_Val = 0;//Переменная для извлечения объектов                
                if (UserParams.ContainsKey("PointOfPlan2X0Z"))
                {
                    UserParams.TryGetValue("PointOfPlan2X0Z", out Object_Val);
                    if (Object_Val != null && !Object_Val.Equals(""))//Контроль существования извлеченного объекта
                    {
                        PointOfPlan2X0Z = (PointOfPlan2X0Z)UserParams["PointOfPlan2X0Z"]; //Запись объекта в экземпляр класса
                        CommentsTrue.Add("PointsOfPlan1_P2_t_1", "Задана фронтальная проекция точки");
                        if (PointOfPlan2X0Z.Z == 0)
                        {
                            Solve = true; CommentsTrue.Add("PointsOfPlan1_P2_t_2", "3D точка, соответсвующая заданной фронтальной проекции, принадлежит горизонтальной плоскости проекций");
                            //SolveParams.Add("PointOfPlan2X0Z", PointOfPlan2X0Z);//Добавление экземпляра решения в словарь решений
                        }
                        else { CommentsFalse.Add("PointsOfPlan1_P2_f_2", "3D точка, соответсвующая заданной фронтальной проекции, не принадлежит горизонтальной плоскости проекций"); }//Добавление комментария отрицательного решения 
                    }
                    else { CommentsFalse.Add("PointsOfPlan1_P2_f_1", "Не задана фронтальная проекция точки"); }//Добавление комментария отрицательного решения  
                }
                else { CommentsFalse.Add("PointsOfPlan1_P2_f_1", "Не задана фронтальная проекция точки"); }//Добавление комментария отрицательного решения  
            }
            else { CommentsFalse.Add("PointsOfPlan1_P2_f_1", "Не задана фронтальная проекция точки"); }//Добавление комментария отрицательного решения  
            return Solve;
        }

        /// <summary>
        /// Контроль принадлежности горизонтальной плоскости проекций 3D точки, заданной профильной проекцией (P3).
        /// </summary>
        /// <param name="InitialParams">Входные параметры (не используются)</param>
        /// <param name="UserParams">Параметры, введенные пользователем: объект "PointOfPlan3Y0Z".</param>
        /// <param name="SolveParams">Параметры решения: (не добавляется).</param>
        /// <param name="CommentsTrue">Комментарии правильного решения</param>
        /// <param name="CommentsFalse">Комментарии неправильно решения</param>
        /// <returns>Возвращает "True", если значение координаты Z объекта "PointOfPlan3Y0Z" равно нулю.</returns>
        /// <remarks>Комментарии правильного решения: ключи: "PointsOfPlan1_P3_t_1" - "Задана профильная проекция точки";
        ///                                                  "PointsOfPlan1_P3_t_2" - "3D точка, соответсвующая заданной профильной проекции, принадлежит горизонтальной плоскости проекций".
        ///          Комментарии ложного решения: ключи: "PointsOfPlan1_P3_f_1" - "Не задана профильная проекция точки";
        ///                                              "PointsOfPlan1_P3_f_2" - "3D точка, соответсвующая заданной профильной проекции, не принадлежит горизонтальной плоскости проекций".
        public bool Point3_OfPlan1X0Y(Dictionary<string, object> InitialParams, Dictionary<string, object> UserParams, ref Dictionary<string, object> SolveParams, ref Dictionary<string, string> CommentsTrue, ref Dictionary<string, string> CommentsFalse)
        {
            bool Solve = false;
            if (UserParams.Count != 0) //Контроль существования объектов в заданном словаре
            {
                PointOfPlan3Y0Z PointOfPlan3Y0Z = new PointOfPlan3Y0Z();
                object Object_Val = 0;//Переменная для извлечения объектов                
                if (UserParams.ContainsKey("PointOfPlan3Y0Z"))
                {
                    UserParams.TryGetValue("PointOfPlan3Y0Z", out Object_Val);
                    if (Object_Val != null && !Object_Val.Equals(""))//Контроль существования извлеченного объекта
                    {
                        PointOfPlan3Y0Z = (PointOfPlan3Y0Z)UserParams["PointOfPlan3Y0Z"]; //Запись объекта в экземпляр класса
                        CommentsTrue.Add("PointsOfPlan1_P3_t_1", "Задана профильная проекция точки");
                        if (PointOfPlan3Y0Z.Z == 0)
                        {
                            Solve = true; CommentsTrue.Add("PointsOfPlan1_P3_t_2", " точка, соответсвующая заданной профильной проекции, принадлежит горизонтальной плоскости проекций");
                            //SolveParams.Add("PointOfPlan3Y0Z", PointOfPlan3Y0Z);//Добавление экземпляра решения в словарь решений
                        }
                        else { CommentsFalse.Add("PointsOfPlan1_P3_f_2", "3D точка, соответсвующая заданной профильной проекции, не принадлежит горизонтальной плоскости проекций"); }//Добавление комментария отрицательного решения 
                    }
                    else { CommentsFalse.Add("PointsOfPlan1_P3_f_1", "Не задана профильная проекция точки"); }//Добавление комментария отрицательного решения  
                }
                else { CommentsFalse.Add("PointsOfPlan1_P3_f_1", "Не задана профильная проекция точки"); }//Добавление комментария отрицательного решения  
            }
            else { CommentsFalse.Add("PointsOfPlan1_P3_f_1", "Не задана профильная проекция точки"); }//Добавление комментария отрицательного решения  
            return Solve;
        }

        /// <summary>
        /// Контроль принадлежности фронтальной плоскости проекций 3D точки, заданной горизонтальной проекцией (P1).
        /// </summary>
        /// <param name="InitialParams">Входные параметры (не используются)</param>
        /// <param name="UserParams">Параметры, введенные пользователем: объект "PointOfPlan1X0Y".</param>
        /// <param name="SolveParams">Параметры решения: (не добавляется).</param>
        /// <param name="CommentsTrue">Комментарии правильного решения</param>
        /// <param name="CommentsFalse">Комментарии неправильно решения</param>
        /// <returns>Возвращает "True", если значение координаты Y объекта "PointOfPlan1X0Y" равно нулю.</returns>
        /// <remarks>Комментарии правильного решения: ключи: "PointsOfPlan2_P1_t_1" - "Задана горизонтальная проекция точки";
        ///                                                  "PointsOfPlan2_P1_t_2" - "3D точка, соответсвующая заданной горизонтальной проекции, принадлежит фронтальной плоскости проекций".
        ///          Комментарии ложного решения: ключи: "PointsOfPlan2_P1_f_1" - "Не задана горизонтальная проекция точки";
        ///                                              "PointsOfPlan2_P1_f_2" - "3D точка, соответсвующая заданной горизонтальной проекции, не принадлежит фронтальной плоскости проекций".
        public bool Point1_OfPlan2X0Z(Dictionary<string, object> InitialParams, Dictionary<string, object> UserParams, ref Dictionary<string, object> SolveParams, ref Dictionary<string, string> CommentsTrue, ref Dictionary<string, string> CommentsFalse)
        {
            bool Solve = false;
            if (UserParams.Count != 0) //Контроль существования объектов в заданном словаре
            {
                PointOfPlan1X0Y PointOfPlan1X0Y = new PointOfPlan1X0Y();
                object Object_Val = 0;//Переменная для извлечения объектов                
                if (UserParams.ContainsKey("PointOfPlan1X0Y"))
                {
                    UserParams.TryGetValue("PointOfPlan1X0Y", out Object_Val);
                    if (Object_Val != null && !Object_Val.Equals(""))//Контроль существования извлеченного объекта
                    {
                        PointOfPlan1X0Y = (PointOfPlan1X0Y)UserParams["PointOfPlan1X0Y"]; //Запись объекта в экземпляр класса
                        CommentsTrue.Add("PointsOfPlan2_P1_t_1", "Задана горизонтальная проекция точки");
                        if (PointOfPlan1X0Y.Y == 0)
                        {
                            Solve = true; CommentsTrue.Add("PointsOfPlan2_P1_t_2", "3D точка, соответсвующая заданной горизонтальной проекции, принадлежит фронтальной плоскости проекций");
                            //SolveParams.Add("PointOfPlan1X0Y", PointOfPlan1X0Y);//Добавление экземпляра решения в словарь решений
                        }
                        else { CommentsFalse.Add("PointsOfPlan2_P1_f_2", "3D точка, соответсвующая заданной горизонтальной проекции, не принадлежит фронтальной плоскости проекций"); }//Добавление комментария отрицательного решения 
                    }
                    else { CommentsFalse.Add("PointsOfPlan2_P1_f_1", "Не задана горизонтальная проекция точки"); }//Добавление комментария отрицательного решения  
                }
                else { CommentsFalse.Add("PointsOfPlan2_P1_f_1", "Не задана горизонтальная проекция точки"); }//Добавление комментария отрицательного решения  
            }
            else { CommentsFalse.Add("PointsOfPlan2_P1_f_1", "Не задана горизонтальная проекция точки"); }//Добавление комментария отрицательного решения  
            return Solve;
        }

        /// <summary>
        /// Контроль принадлежности фронтальной плоскости проекций 3D точки, заданной профильной проекцией (P3).
        /// </summary>
        /// <param name="InitialParams">Входные параметры (не используются)</param>
        /// <param name="UserParams">Параметры, введенные пользователем: объект "PointOfPlan1X0Y".</param>
        /// <param name="SolveParams">Параметры решения: (не добавляется).</param>
        /// <param name="CommentsTrue">Комментарии правильного решения</param>
        /// <param name="CommentsFalse">Комментарии неправильно решения</param>
        /// <returns>Возвращает "True", если значение координаты Y объекта "PointOfPlan1X0Y" равно нулю.</returns>
        /// <remarks>Комментарии правильного решения: ключи: "PointsOfPlan2_P3_t_1" - "Задана профильная проекция точки";
        ///                                                  "PointsOfPlan2_P3_t_2" - "3D точка, соответсвующая заданной профильной проекции, принадлежит фронтальной плоскости проекций".
        ///          Комментарии ложного решения: ключи: "PointsOfPlan2_P3_f_1" - "Не задана профильная проекция точки";
        ///                                              "PointsOfPlan2_P3_f_2" - "3D точка, соответсвующая заданной профильной проекции, не принадлежит фронтальной плоскости проекций".
        public bool Point3_OfPlan2X0Z(Dictionary<string, object> InitialParams, Dictionary<string, object> UserParams, ref Dictionary<string, object> SolveParams, ref Dictionary<string, string> CommentsTrue, ref Dictionary<string, string> CommentsFalse)
        {
            bool Solve = false;
            if (UserParams.Count != 0) //Контроль существования объектов в заданном словаре
            {
                PointOfPlan3Y0Z PointOfPlan3Y0Z = new PointOfPlan3Y0Z();
                object Object_Val = 0;//Переменная для извлечения объектов                
                if (UserParams.ContainsKey("PointOfPlan3Y0Z"))
                {
                    UserParams.TryGetValue("PointOfPlan3Y0Z", out Object_Val);
                    if (Object_Val != null && !Object_Val.Equals(""))//Контроль существования извлеченного объекта
                    {
                        PointOfPlan3Y0Z = (PointOfPlan3Y0Z)UserParams["PointOfPlan3Y0Z"]; //Запись объекта в экземпляр класса
                        CommentsTrue.Add("PointsOfPlan2_P3_t_1", "Задана профильная проекция точки");
                        if (PointOfPlan3Y0Z.Y == 0)
                        {
                            Solve = true; CommentsTrue.Add("PointsOfPlan2_P3_t_2", "3D точка, соответсвующая заданной профильной проекции, принадлежит фронтальной плоскости проекций");
                            //SolveParams.Add("PointOfPlan3Y0Z", PointOfPlan3Y0Z);//Добавление экземпляра решения в словарь решений
                        }
                        else { CommentsFalse.Add("PointsOfPlan2_P3_f_2", "3D точка, соответсвующая заданной профильной проекции, не принадлежит фронтальной плоскости проекций"); }//Добавление комментария отрицательного решения 
                    }
                    else { CommentsFalse.Add("PointsOfPlan2_P3_f_1", "Не задана профильная проекция точки"); }//Добавление комментария отрицательного решения  
                }
                else { CommentsFalse.Add("PointsOfPlan2_P3_f_1", "Не задана профильная проекция точки"); }//Добавление комментария отрицательного решения  
            }
            else { CommentsFalse.Add("PointsOfPlan2_P3_f_1", "Не задана профильная проекция точки"); }//Добавление комментария отрицательного решения  
            return Solve;
        }

        /// <summary>
        /// Контроль принадлежности горизонтальной плоскости проекций 3D точки, заданной профильной проекцией (P3).
        /// </summary>
        /// <param name="InitialParams">Входные параметры (не используются)</param>
        /// <param name="UserParams">Параметры, введенные пользователем: объект "PointOfPlan1X0Y".</param>
        /// <param name="SolveParams">Параметры решения: (не добавляется).</param>
        /// <param name="CommentsTrue">Комментарии правильного решения</param>
        /// <param name="CommentsFalse">Комментарии неправильно решения</param>
        /// <returns>Возвращает "True", если значение координаты Y объекта "PointOfPlan1X0Y" равно нулю.</returns>
        /// <remarks>Комментарии правильного решения: ключи: "PointsOfPlan3_P1_t_1" - "Задана горизонтальная проекция точки";
        ///                                                  "PointsOfPlan3_P1_t_2" - "3D точка, соответсвующая заданной горизонтальной проекции, принадлежит профильной плоскости проекций".
        ///          Комментарии ложного решения: ключи: "PointsOfPlan3_P1_f_1" - "Не задана горизонтальная проекция точки";
        ///                                              "PointsOfPlan3_P1_f_2" - "3D точка, соответсвующая заданной горизонтальной проекции, не принадлежит профильной плоскости проекций".
        public bool Point1_OfPlan3Y0Z(Dictionary<string, object> InitialParams, Dictionary<string, object> UserParams, ref Dictionary<string, object> SolveParams, ref Dictionary<string, string> CommentsTrue, ref Dictionary<string, string> CommentsFalse)
        {
            bool Solve = false;
            if (UserParams.Count != 0) //Контроль существования объектов в заданном словаре
            {
                PointOfPlan1X0Y PointOfPlan1X0Y = new PointOfPlan1X0Y();
                object Object_Val = 0;//Переменная для извлечения объектов                
                if (UserParams.ContainsKey("PointOfPlan1X0Y"))
                {
                    UserParams.TryGetValue("PointOfPlan1X0Y", out Object_Val);
                    if (Object_Val != null && !Object_Val.Equals(""))//Контроль существования извлеченного объекта
                    {
                        PointOfPlan1X0Y = (PointOfPlan1X0Y)UserParams["PointOfPlan1X0Y"]; //Запись объекта в экземпляр класса
                        CommentsTrue.Add("PointsOfPlan3_P1_t_1", "Задана горизонтальная проекция точки");
                        if (PointOfPlan1X0Y.X == 0)
                        {
                            Solve = true; CommentsTrue.Add("PointsOfPlan3_P1_t_2", "3D точка, соответсвующая заданной горизонтальной проекции, принадлежит профильной плоскости проекций");
                            //SolveParams.Add("PointOfPlan1X0Y", PointOfPlan1X0Y);//Добавление экземпляра решения в словарь решений
                        }
                        else { CommentsFalse.Add("PointsOfPlan3_P1_f_2", "3D точка, соответсвующая заданной горизонтальной проекции, не принадлежит профильной плоскости проекций"); }//Добавление комментария отрицательного решения 
                    }
                    else { CommentsFalse.Add("PointsOfPlan3_P1_f_1", "Не задана горизонтальная проекция точки"); }//Добавление комментария отрицательного решения  
                }
                else { CommentsFalse.Add("PointsOfPlan3_P1_f_1", "Не задана горизонтальная проекция точки"); }//Добавление комментария отрицательного решения  
            }
            else { CommentsFalse.Add("PointsOfPlan3_P1_f_1", "Не задана горизонтальная проекция точки"); }//Добавление комментария отрицательного решения  
            return Solve;
        }

        /// <summary>
        /// Контроль принадлежности фронтальной плоскости проекций 3D точки, заданной профильной проекцией (P3).
        /// </summary>
        /// <param name="InitialParams">Входные параметры (не используются)</param>
        /// <param name="UserParams">Параметры, введенные пользователем: объект "PointOfPlan2X0Z".</param>
        /// <param name="SolveParams">Параметры решения: (не добавляется).</param>
        /// <param name="CommentsTrue">Комментарии правильного решения</param>
        /// <param name="CommentsFalse">Комментарии неправильно решения</param>
        /// <returns>Возвращает "True", если значение координаты Y объекта "PointOfPlan2X0Z" равно нулю.</returns>
        /// <remarks>Комментарии правильного решения: ключи: "PointsOfPlan3_P2_t_1" - "Задана фронтальная проекция точки";
        ///                                                  "PointsOfPlan3_P2_t_2" - "3D точка, соответсвующая заданной фронтальной проекции, принадлежит профильной плоскости проекций".
        ///          Комментарии ложного решения: ключи: "PointsOfPlan3_P2_f_1" - "Не задана фронтальная проекция точки";
        ///                                              "PointsOfPlan3_P2_f_2" - "3D точка, соответсвующая заданной фронтальной проекции, не принадлежит профильной плоскости проекций".
        public bool Point2_OfPlan3Y0Z(Dictionary<string, object> InitialParams, Dictionary<string, object> UserParams, ref Dictionary<string, object> SolveParams, ref Dictionary<string, string> CommentsTrue, ref Dictionary<string, string> CommentsFalse)
        {
            bool Solve = false;
            if (UserParams.Count != 0) //Контроль существования объектов в заданном словаре
            {
                PointOfPlan2X0Z PointOfPlan2X0Z = new PointOfPlan2X0Z();
                object Object_Val = 0;//Переменная для извлечения объектов                
                if (UserParams.ContainsKey("PointOfPlan2X0Z"))
                {
                    UserParams.TryGetValue("PointOfPlan2X0Z", out Object_Val);
                    if (Object_Val != null && !Object_Val.Equals(""))//Контроль существования извлеченного объекта
                    {
                        PointOfPlan2X0Z = (PointOfPlan2X0Z)UserParams["PointOfPlan2X0Z"]; //Запись объекта в экземпляр класса
                        CommentsTrue.Add("PointsOfPlan3_P2_t_1", "Задана фронтальная проекция точки");
                        if (PointOfPlan2X0Z.X == 0)
                        {
                            Solve = true; CommentsTrue.Add("PointsOfPlan3_P2_t_2", "3D точка, соответсвующая заданной фронтальной проекции, принадлежит профильной плоскости проекций");
                            //SolveParams.Add("PointOfPlan2X0Z", PointOfPlan2X0Z);//Добавление экземпляра решения в словарь решений
                        }
                        else { CommentsFalse.Add("PointsOfPlan3_P2_f_2", "3D точка, соответсвующая заданной фронтальной проекции, не принадлежит профильной плоскости проекций"); }//Добавление комментария отрицательного решения 
                    }
                    else { CommentsFalse.Add("PointsOfPlan3_P3_f_1", "Не задана фронтальная проекция точки"); }//Добавление комментария отрицательного решения  
                }
                else { CommentsFalse.Add("PointsOfPlan3_P2_f_1", "Не задана фронтальная проекция точки"); }//Добавление комментария отрицательного решения  
            }
            else { CommentsFalse.Add("PointsOfPlan3_P2_f_1", "Не задана фронтальная проекция точки"); }//Добавление комментария отрицательного решения  
            return Solve;
        }

        /// <summary>
        /// Контроль принадлежности горизонтальной или фронтальной проекции (P1 или P2) оси 0Х.
        /// </summary>
        /// <param name="InitialParams">Входные параметры (не используются)</param>
        /// <param name="UserParams">Параметры, введенные пользователем: объекты: "PointOfPlan1X0Y" или "PointOfPlan2X0Z".</param>
        /// <param name="SolveParams">Параметры решения: (не добавляется).</param>
        /// <param name="CommentsTrue">Комментарии правильного решения</param>
        /// <param name="CommentsFalse">Комментарии неправильно решения</param>
        /// <returns>Возвращает "True", если значение координаты X объектов "PointOfPlan1X0Y" или "PointOfPlan2X0Z" равно нулю.</returns>
        /// <remarks>Комментарии правильного решения: ключи: "PointsP1P2_OfX_t_1" - "Задана горизонтальная проекция точки";
        ///                                                  "PointsP1P2_OfX_t_2" - "Горизонтальная проекция точки принадлежит оси 0Х";
        ///                                                  "PointsP1P2_OfX_t_3" - "Задана фронтальная проекция точки";
        ///                                                  "PointsP1P2_OfX_t_4" - "Фронтальная проекция точки принадлежит оси 0Х".
        ///          Комментарии ложного решения: ключи: "PointsP1P2_OfX_f_1" - "Не задана горизонтальная проекция точки";
        ///                                              "PointsP1P2_OfX_f_2" - "Горизонтальная проекция точки не принадлежит оси 0Х";
        ///                                              "PointsP1P2_OfX_f_3" - "Не задана фронтальная проекция точки";
        ///                                              "PointsP1P2_OfX_f_4" - "Фронтальная проекция точки не принадлежит оси 0Х".
        public bool PointsP1P2_Of0X(Dictionary<string, object> InitialParams, Dictionary<string, object> UserParams, ref Dictionary<string, object> SolveParams, ref Dictionary<string, string> CommentsTrue, ref Dictionary<string, string> CommentsFalse)
        {
            bool Solve = false;
            if (UserParams.Count != 0) //Контроль существования объектов в заданном словаре
            {
                object Object_Val = 0;//Переменная для извлечения объектов                
                if (UserParams.ContainsKey("PointOfPlan1X0Y"))
                {
                    PointOfPlan1X0Y PointOfPlan1X0Y = new PointOfPlan1X0Y();
                    UserParams.TryGetValue("PointOfPlan1X0Y", out Object_Val);
                    if (Object_Val != null && !Object_Val.Equals(""))//Контроль существования извлеченного объекта
                    {
                        PointOfPlan1X0Y = (PointOfPlan1X0Y)UserParams["PointOfPlan1X0Y"]; //Запись объекта в экземпляр класса
                        CommentsTrue.Add("PointsP1P2_OfX_t_1", "Задана горизонтальная проекция точки");
                        if (PointOfPlan1X0Y.X == 0)
                        {
                            Solve = true; CommentsTrue.Add("PointsP1P2_OfX_t_2", "Горизонтальная проекция точки принадлежит оси 0Х");
                        }
                        else { CommentsFalse.Add("PointsP1P2_OfX_f_2", "Горизонтальная проекция точки не принадлежит оси 0Х"); }//Добавление комментария отрицательного решения 
                    }
                    else { CommentsFalse.Add("PointsP1P2_OfX_f_1", "Не задана горизонтальная проекция точки"); }//Добавление комментария отрицательного решения
                }
                else if (UserParams.ContainsKey("PointOfPlan2X0Z"))
                {
                    PointOfPlan2X0Z PointOfPlan2X0Z = new PointOfPlan2X0Z();
                    UserParams.TryGetValue("PointOfPlan2X0Z", out Object_Val);
                    if (Object_Val != null && !Object_Val.Equals(""))//Контроль существования извлеченного объекта
                    {
                        PointOfPlan2X0Z = (PointOfPlan2X0Z)UserParams["PointOfPlan2X0Z"]; //Запись объекта в экземпляр класса
                        CommentsTrue.Add("PointsP1P2_OfX_t_3", "Задана фронтальная проекция точки");
                        if (PointOfPlan2X0Z.X == 0)
                        {
                            Solve = true; CommentsTrue.Add("PointsP1P2_OfX_t_4", "Фронтальная проекция точки принадлежит оси 0Х");
                        }
                        else { CommentsFalse.Add("PointsP1P2_OfX_f_3", "Фронтальная проекция точки не принадлежит оси 0Х"); }//Добавление комментария отрицательного решения 
                    }
                    else { CommentsFalse.Add("PointsP1P2_OfX_f_4", "Не задана фронтальная проекция точки"); }//Добавление комментария отрицательного решения  
                }
                else { CommentsFalse.Add("PointsP1P2_OfX_f_5", "Не задана проекция точки"); }//Добавление комментария отрицательного решения  
            }
            else { CommentsFalse.Add("PointsP1P2_OfX_f_5", "Не задана проекция точки"); }//Добавление комментария отрицательного решения  
            return Solve;
        }

        /// <summary>
        /// Контроль принадлежности горизонтальной или профильной проекции (P1 или P3) оси 0Y.
        /// </summary>
        /// <param name="InitialParams">Входные параметры (не используются)</param>
        /// <param name="UserParams">Параметры, введенные пользователем: объекты: "PointOfPlan1X0Y" или "PointOfPlan3Y0Z".</param>
        /// <param name="SolveParams">Параметры решения: (не добавляется).</param>
        /// <param name="CommentsTrue">Комментарии правильного решения</param>
        /// <param name="CommentsFalse">Комментарии неправильно решения</param>
        /// <returns>Возвращает "True", если значение координаты Y объектов "PointOfPlan1X0Y" или "PointOfPlan3Y0Z" равно нулю.</returns>
        /// <remarks>Комментарии правильного решения: ключи: "PointsP1P3_OfY_t_1" - "Задана горизонтальная проекция точки";
        ///                                                  "PointsP1P3_OfY_t_2" - "Горизонтальная проекция точки принадлежит оси 0Y";
        ///                                                  "PointsP1P3_OfY_t_3" - "Задана профильная проекция точки";
        ///                                                  "PointsP1P3_OfY_t_4" - "Профильная проекция точки принадлежит оси 0Y".
        ///          Комментарии ложного решения: ключи: "PointsP1P3_OfY_f_1" - "Не задана горизонтальная проекция точки";
        ///                                              "PointsP1P3_OfY_f_2" - "Горизонтальная проекция точки не принадлежит оси 0Y";
        ///                                              "PointsP1P3_OfY_f_3" - "Не задана профильная проекция точки";
        ///                                              "PointsP1P3_OfY_f_4" - "Профильная проекция точки не принадлежит оси 0Y".
        public bool PointsP1P3_Of0Y(Dictionary<string, object> InitialParams, Dictionary<string, object> UserParams, ref Dictionary<string, object> SolveParams, ref Dictionary<string, string> CommentsTrue, ref Dictionary<string, string> CommentsFalse)
        {
            bool Solve = false;
            if (UserParams.Count != 0) //Контроль существования объектов в заданном словаре
            {
                object Object_Val = 0;//Переменная для извлечения объектов                
                if (UserParams.ContainsKey("PointOfPlan1X0Y"))
                {
                    PointOfPlan1X0Y PointOfPlan1X0Y = new PointOfPlan1X0Y();
                    UserParams.TryGetValue("PointOfPlan1X0Y", out Object_Val);
                    if (Object_Val != null && !Object_Val.Equals(""))//Контроль существования извлеченного объекта
                    {
                        PointOfPlan1X0Y = (PointOfPlan1X0Y)UserParams["PointOfPlan1X0Y"]; //Запись объекта в экземпляр класса
                        CommentsTrue.Add("PointsP1P3_OfY_t_1", "Задана горизонтальная проекция точки");
                        if (PointOfPlan1X0Y.Y == 0)
                        {
                            Solve = true; CommentsTrue.Add("PointsP1P3_OfY_t_2", "Горизонтальная проекция точки принадлежит оси 0Y");
                        }
                        else { CommentsFalse.Add("PointsP1P3_OfY_f_2", "Горизонтальная проекция точки не принадлежит оси 0Y"); }//Добавление комментария отрицательного решения 
                    }
                    else { CommentsFalse.Add("PointsP1P3_OfY_f_1", "Не задана горизонтальная проекция точки"); }//Добавление комментария отрицательного решения
                }
                else if (UserParams.ContainsKey("PointOfPlan3Y0Z"))
                {
                    PointOfPlan3Y0Z PointOfPlan3Y0Z = new PointOfPlan3Y0Z();
                    UserParams.TryGetValue("PointOfPlan3Y0Z", out Object_Val);
                    if (Object_Val != null && !Object_Val.Equals(""))//Контроль существования извлеченного объекта
                    {
                        PointOfPlan3Y0Z = (PointOfPlan3Y0Z)UserParams["PointOfPlan3Y0Z"]; //Запись объекта в экземпляр класса
                        CommentsTrue.Add("PointsP1P3_OfY_t_3", "Задана профильная проекция точки");
                        if (PointOfPlan3Y0Z.Y == 0)
                        {
                            Solve = true; CommentsTrue.Add("PointsP1P3_OfY_t_4", "Профильная проекция точки принадлежит оси 0Y");
                        }
                        else { CommentsFalse.Add("PointsP1P3_OfY_f_3", "Профильная проекция точки не принадлежит оси 0Y"); }//Добавление комментария отрицательного решения 
                    }
                    else { CommentsFalse.Add("PointsP1P3_OfY_f_4", "Не задана профильная проекция точки"); }//Добавление комментария отрицательного решения  
                }
                else { CommentsFalse.Add("PointsP1P3_OfY_f_5", "Не задана проекция точки"); }//Добавление комментария отрицательного решения  
            }
            else { CommentsFalse.Add("PointsP1P3_OfY_f_5", "Не задана проекция точки"); }//Добавление комментария отрицательного решения  
            return Solve;
        }

        /// <summary>
        /// Контроль принадлежности фронтальной или профильной проекции (P2 или P3) оси 0Z.
        /// </summary>
        /// <param name="InitialParams">Входные параметры (не используются)</param>
        /// <param name="UserParams">Параметры, введенные пользователем: объекты: "PointOfPlan2X0Z" или "PointOfPlan3Y0Z".</param>
        /// <param name="SolveParams">Параметры решения: (не добавляется).</param>
        /// <param name="CommentsTrue">Комментарии правильного решения</param>
        /// <param name="CommentsFalse">Комментарии неправильно решения</param>
        /// <returns>Возвращает "True", если значение координаты Z объектов "PointOfPlan2X0Z" или "PointOfPlan3Y0Z" равно нулю.</returns>
        /// <remarks>Комментарии правильного решения: ключи: "PointsP2P3_OfZ_t_1" - "Задана фронтальная проекция точки";
        ///                                                  "PointsP2P3_OfZ_t_2" - "Фронтальная проекция точки принадлежит оси 0Z";
        ///                                                  "PointsP2P3_OfZ_t_3" - "Задана профильная проекция точки";
        ///                                                  "PointsP2P3_OfZ_t_4" - "Профильная проекция точки принадлежит оси 0Z".
        ///          Комментарии ложного решения: ключи: "PointsP2P3_OfZ_f_1" - "Не задана фронтальная проекция точки";
        ///                                              "PointsP2P3_OfZ_f_2" - "Фронтальная проекция точки не принадлежит оси 0Z";
        ///                                              "PointsP2P3_OfZ_f_3" - "Не задана профильная проекция точки";
        ///                                              "PointsP2P3_OfZ_f_4" - "Профильная проекция точки не принадлежит оси 0Z".
        public bool PointsP2P3_Of0Z(Dictionary<string, object> InitialParams, Dictionary<string, object> UserParams, ref Dictionary<string, object> SolveParams, ref Dictionary<string, string> CommentsTrue, ref Dictionary<string, string> CommentsFalse)
        {
            bool Solve = false;
            if (UserParams.Count != 0) //Контроль существования объектов в заданном словаре
            {
                object Object_Val = 0;//Переменная для извлечения объектов                
                if (UserParams.ContainsKey("PointOfPlan2X0Z"))
                {
                    PointOfPlan2X0Z PointOfPlan2X0Z = new PointOfPlan2X0Z();
                    UserParams.TryGetValue("PointOfPlan2X0Z", out Object_Val);
                    if (Object_Val != null && !Object_Val.Equals(""))//Контроль существования извлеченного объекта
                    {
                        PointOfPlan2X0Z = (PointOfPlan2X0Z)UserParams["PointOfPlan2X0Z"]; //Запись объекта в экземпляр класса
                        CommentsTrue.Add("PointsP2P3_OfZ_t_1", "Задана фронтальная проекция точки");
                        if (PointOfPlan2X0Z.Z == 0)
                        {
                            Solve = true; CommentsTrue.Add("PointsP2P3_OfZ_t_2", "Фронтальная проекция точки принадлежит оси 0Z");
                        }
                        else { CommentsFalse.Add("PointsP2P3_OfZ_f_2", "Фронтальная проекция точки не принадлежит оси 0Z"); }//Добавление комментария отрицательного решения 
                    }
                    else { CommentsFalse.Add("PointsP2P3_OfZ_f_1", "Не задана фронтальная проекция точки"); }//Добавление комментария отрицательного решения
                }
                else if (UserParams.ContainsKey("PointOfPlan3Y0Z"))
                {
                    PointOfPlan3Y0Z PointOfPlan3Y0Z = new PointOfPlan3Y0Z();
                    UserParams.TryGetValue("PointOfPlan3Y0Z", out Object_Val);
                    if (Object_Val != null && !Object_Val.Equals(""))//Контроль существования извлеченного объекта
                    {
                        PointOfPlan3Y0Z = (PointOfPlan3Y0Z)UserParams["PointOfPlan3Y0Z"]; //Запись объекта в экземпляр класса
                        CommentsTrue.Add("PointsP2P3_OfZ_t_3", "Задана профильная проекция точки");
                        if (PointOfPlan3Y0Z.Z == 0)
                        {
                            Solve = true; CommentsTrue.Add("PointsP2P3_OfZ_t_4", "Профильная проекция точки принадлежит оси 0Z");
                        }
                        else { CommentsFalse.Add("PointsP2P3_OfZ_f_3", "Профильная проекция точки не принадлежит оси 0Z"); }//Добавление комментария отрицательного решения 
                    }
                    else { CommentsFalse.Add("PointsP2P3_OfZ_f_4", "Не задана профильная проекция точки"); }//Добавление комментария отрицательного решения  
                }
                else { CommentsFalse.Add("PointsP2P3_OfZ_f_5", "Не задана проекция точки"); }//Добавление комментария отрицательного решения  
            }
            else { CommentsFalse.Add("PointsP2P3_OfZ_f_5", "Не задана проекция точки"); }//Добавление комментария отрицательного решения  
            return Solve;
        }

        /// <summary>
        /// Контроль принадлежности 3D точки горизонтальной плоскости проекции (Х0Y).
        /// </summary>
        /// <param name="InitialParams">Входные параметры (не используются)</param>
        /// <param name="UserParams">Параметры, введенные пользователем: объекты: "Point3D".</param>
        /// <param name="SolveParams">Параметры решения: (не добавляется).</param>
        /// <param name="CommentsTrue">Комментарии правильного решения</param>
        /// <param name="CommentsFalse">Комментарии неправильно решения</param>
        /// <returns>Возвращает "True", если значение координаты Z объекта "Point3D" равно нулю.</returns>
        /// <remarks>Комментарии правильного решения: ключи: "Point3D_OfPlan1X0Y_t_1" - "Задана 3D точка";
        ///                                                  "Point3D_OfPlan1X0Y_t_2" - "3D точка принадлежит горизонтальной плоскости проекций (Х0Y)".
        ///          Комментарии ложного решения: ключи: "Point3D_OfPlan1X0Y_f_1" - "Не задана 3D точка";
        ///                                              "Point3D_OfPlan1X0Y_f_2", "3D точка не принадлежит горизонтальной плоскости проекций (Х0Y)".
        public bool Point3D_OfPlan1X0Y(Dictionary<string, object> InitialParams, Dictionary<string, object> UserParams, ref Dictionary<string, object> SolveParams, ref Dictionary<string, string> CommentsTrue, ref Dictionary<string, string> CommentsFalse)
        {
            bool Solve = false;
            if (UserParams.Count != 0) //Контроль существования объектов в заданном словаре
            {
                object Object_Val = 0;//Переменная для извлечения объектов                
                if (UserParams.ContainsKey("Point3D"))
                {
                    Point3D Point3D = new Point3D();
                    UserParams.TryGetValue("Point3D", out Object_Val);
                    if (Object_Val != null && !Object_Val.Equals(""))//Контроль существования извлеченного объекта
                    {
                        Point3D = (Point3D)UserParams["Point3D"]; //Запись объекта в экземпляр класса
                        CommentsTrue.Add("Point3D_OfPlan1X0Y_t_1", "Задана 3D точка");
                        if (Point3D.Z == 0)
                        {
                            Solve = true; CommentsTrue.Add("Point3D_OfPlan1X0Y_t_2", "3D точка принадлежит горизонтальной плоскости проекций (Х0Y)");
                        }
                        else { CommentsFalse.Add("Point3D_OfPlan1X0Y_f_2", "3D точка не принадлежит горизонтальной плоскости проекций (Х0Y)"); }//Добавление комментария отрицательного решения 
                    }
                    else { CommentsFalse.Add("Point3D_OfPlan1X0Y_f_1", "Не задана 3D точка"); }//Добавление комментария отрицательного решения
                }
                else { CommentsFalse.Add("Point3D_OfPlan1X0Y_f_1", "Не задана 3D точка"); }//Добавление комментария отрицательного решения  
            }
            else { CommentsFalse.Add("Point3D_OfPlan1X0Y_f_1", "Не задана 3D точка"); }//Добавление комментария отрицательного решения  
            return Solve;
        }

        /// <summary>
        /// Контроль принадлежности 3D точки фронтальной плоскости проекции (Х0Z).
        /// </summary>
        /// <param name="InitialParams">Входные параметры (не используются)</param>
        /// <param name="UserParams">Параметры, введенные пользователем: объекты: "Point3D".</param>
        /// <param name="SolveParams">Параметры решения: (не добавляется).</param>
        /// <param name="CommentsTrue">Комментарии правильного решения</param>
        /// <param name="CommentsFalse">Комментарии неправильно решения</param>
        /// <returns>Возвращает "True", если значение координаты Y объекта "Point3D" равно нулю.</returns>
        /// <remarks>Комментарии правильного решения: ключи: "Point3D_OfPlan2X0Z_t_1" - "Задана 3D точка";
        ///                                                  "Point3D_OfPlan1X0Y_t_2" - "3D точка принадлежит фронтальной плоскости проекций (Х0Z)".
        ///          Комментарии ложного решения: ключи: "Point3D_OfPlan2X0Z_f_1" - "Не задана 3D точка";
        ///                                              "Point3D_OfPlan2X0Z_f_2", "3D точка не принадлежит фронтальной плоскости проекций (Х0Z)".
        public bool Point3D_OfPlan2X0Z(Dictionary<string, object> InitialParams, Dictionary<string, object> UserParams, ref Dictionary<string, object> SolveParams, ref Dictionary<string, string> CommentsTrue, ref Dictionary<string, string> CommentsFalse)
        {
            bool Solve = false;
            if (UserParams.Count != 0) //Контроль существования объектов в заданном словаре
            {
                object Object_Val = 0;//Переменная для извлечения объектов                
                if (UserParams.ContainsKey("Point3D"))
                {
                    Point3D Point3D = new Point3D();
                    UserParams.TryGetValue("Point3D", out Object_Val);
                    if (Object_Val != null && !Object_Val.Equals(""))//Контроль существования извлеченного объекта
                    {
                        Point3D = (Point3D)UserParams["Point3D"]; //Запись объекта в экземпляр класса
                        CommentsTrue.Add("Point3D_OfPlan2X0Z_t_1", "Задана 3D точка");
                        if (Point3D.Y == 0)
                        {
                            Solve = true; CommentsTrue.Add("Point3D_OfPlan2X0Z_t_2", "3D точка принадлежит фронтальной плоскости проекций (Х0Z)");
                        }
                        else { CommentsFalse.Add("Point3D_OfPlan2X0Z_f_2", "3D точка не принадлежит фронтальной плоскости проекций (Х0Z)"); }//Добавление комментария отрицательного решения 
                    }
                    else { CommentsFalse.Add("Point3D_OfPlan2X0Z_f_1", "Не задана 3D точка"); }//Добавление комментария отрицательного решения
                }
                else { CommentsFalse.Add("Point3D_OfPlan2X0Z_f_1", "Не задана 3D точка"); }//Добавление комментария отрицательного решения  
            }
            else { CommentsFalse.Add("Point3D_OfPlan2X0Z_f_1", "Не задана 3D точка"); }//Добавление комментария отрицательного решения  
            return Solve;
        }

        /// <summary>
        /// Контроль принадлежности 3D точки профильной плоскости проекции (Y0Z).
        /// </summary>
        /// <param name="InitialParams">Входные параметры (не используются)</param>
        /// <param name="UserParams">Параметры, введенные пользователем: объекты: "Point3D".</param>
        /// <param name="SolveParams">Параметры решения: (не добавляется).</param>
        /// <param name="CommentsTrue">Комментарии правильного решения</param>
        /// <param name="CommentsFalse">Комментарии неправильно решения</param>
        /// <returns>Возвращает "True", если значение координаты X объекта "Point3D" равно нулю.</returns>
        /// <remarks>Комментарии правильного решения: ключи: "Point3D_OfPlan3Y0Z_t_1" - "Задана 3D точка";
        ///                                                  "Point3D_OfPlan3Y0Z_t_2" - "3D точка принадлежит профильной плоскости проекций (Y0Z)".
        ///          Комментарии ложного решения: ключи: "Point3D_OfPlan3Y0Z_f_1" - "Не задана 3D точка";
        ///                                              "Point3D_OfPlan3Y0Z_f_2", "3D точка не принадлежит профильной плоскости проекций (Y0Z)".
        public bool Point3D_OfPlan3Y0Z(Dictionary<string, object> InitialParams, Dictionary<string, object> UserParams, ref Dictionary<string, object> SolveParams, ref Dictionary<string, string> CommentsTrue, ref Dictionary<string, string> CommentsFalse)
        {
            bool Solve = false;
            if (UserParams.Count != 0) //Контроль существования объектов в заданном словаре
            {
                object Object_Val = 0;//Переменная для извлечения объектов                
                if (UserParams.ContainsKey("Point3D"))
                {
                    Point3D Point3D = new Point3D();
                    UserParams.TryGetValue("Point3D", out Object_Val);
                    if (Object_Val != null && !Object_Val.Equals(""))//Контроль существования извлеченного объекта
                    {
                        Point3D = (Point3D)UserParams["Point3D"]; //Запись объекта в экземпляр класса
                        CommentsTrue.Add("Point3D_OfPlan3Y0Z_t_1", "Задана 3D точка");
                        if (Point3D.X == 0)
                        {
                            Solve = true; CommentsTrue.Add("Point3D_OfPlan3Y0Z_t_2", "3D точка принадлежит профильной плоскости проекций (Y0Z)");
                        }
                        else { CommentsFalse.Add("Point3D_OfPlan3Y0Z_f_2", "3D точка не принадлежит профильной плоскости проекций (Y0Z)"); }//Добавление комментария отрицательного решения 
                    }
                    else { CommentsFalse.Add("Point3D_OfPlan3Y0Z_f_1", "Не задана 3D точка"); }//Добавление комментария отрицательного решения
                }
                else { CommentsFalse.Add("Point3D_OfPlan3Y0Z_f_1", "Не задана 3D точка"); }//Добавление комментария отрицательного решения  
            }
            else { CommentsFalse.Add("Point3D_OfPlan3Y0Z_f_1", "Не задана 3D точка"); }//Добавление комментария отрицательного решения  
            return Solve;
        }

        /// <summary>
        /// Метод на выходе дает точку.
        /// </summary>
        /// <param name="InitialParams">Входные параметры (не используются)</param>
        /// <param name="UserParams">Параметры, введенные пользователем: построена ли точка.</param>
        /// <param name="SolveParams">Параметры решения Point3D</param>
        /// <param name="CommentsTrue">Комментарии правильного решения</param>
        /// <param name="CommentsFalse">Комментарии неправильно решения</param>
        /// <returns>Возвращает "True", если значение координаты X существует</returns>
        /// <remarks>Комментарии правильного решения: ключи: "InputX_t_1" - "Значение координаты X задано";
        ///          Комментарии ложного решения: ключи: "InputX_f_1" - "Не задано значение координаты X".</remarks>
        public bool Point3D_Output(Dictionary<string, object> InitialParams, Dictionary<string, object> UserParams, ref Dictionary<string, object> SolveParams, ref Dictionary<string, string> CommentsTrue, ref Dictionary<string, string> CommentsFalse)
        {
            if (UserParams.Count != 0) //Контроль существования объектов в заданном словаре
            {
                object Object_Val = 0;//Переменная для извлечения объектов        
                UserParams.TryGetValue(nameof(Point3D), out Object_Val);
                var point3D = (Point3D)Object_Val;
                if (point3D != null) //Контроль существования извлеченного объекта
                {
                    CommentsTrue.Add("Point3D_Output", "Точка построена");
                    SolveParams.Add(nameof(Point3D), point3D);
                    return true;
                }
                else { CommentsFalse.Add("Point3D_Output", "Точка не построена"); return false; }
            }
            else { CommentsFalse.Add("Point3D_Output", "Точка не построена"); return false; }
        }

        /// <summary>
        /// Метод на вход требует точку.
        /// </summary>
        /// <param name="InitialParams">Точка Point3D</param>
        /// <param name="UserParams">Точка</param>
        /// <param name="SolveParams">Параметры решения (не добавляются)</param>
        /// <param name="CommentsTrue">Комментарии правильного решения</param>
        /// <param name="CommentsFalse">Комментарии неправильно решения</param>
        /// <returns>Возвращает "True", если значение координаты X существует</returns>
        /// <remarks>Комментарии правильного решения: ключи: "InputX_t_1" - "Значение координаты X задано";
        ///          Комментарии ложного решения: ключи: "InputX_f_1" - "Не задано значение координаты X".</remarks>
        public bool Point3D_Input(Dictionary<string, object> InitialParams, Dictionary<string, object> UserParams, ref Dictionary<string, object> SolveParams, ref Dictionary<string, string> CommentsTrue, ref Dictionary<string, string> CommentsFalse)
        {
            if (UserParams.Count != 0) //Контроль существования объектов в заданном словаре
            {
                object Object_Val = 0, Object_Init = 0;//Переменная для извлечения объектов        
                UserParams.TryGetValue(nameof(Point3D), out Object_Val);
                InitialParams.TryGetValue(nameof(Point3D), out Object_Init);
                var point3D = (Point3D)Object_Val;
                var point3D_Init = (Point3D)Object_Init;
                if (point3D != null && point3D_Init != null) //Контроль существования извлеченного объекта
                {
                    CommentsTrue.Add("Point3D_Input", "Точка # 1 построена");
                    CommentsTrue.Add("Point3D_Input_1", "Точка # 2 построена");
                    return true;
                }
                else { CommentsFalse.Add("Point3D_Input_2", "Точка не построена"); return false; }
            }
            else { CommentsFalse.Add("Point3D_Input_2", "Точка не построена"); return false; }
        }

    }

    //везде добавить ошибку для первого условия
    //1. В состав входных факторов методов решения следует включить List-ы с указанием ключей, по которым надо искать объекты в словарях исходных данных и словарях параметров пользователя
    //Для добавления экземпляров решения в словарь решений надо предварительно (перед заходом в процедуру) вставить в словарь решений ключ, по которому будет записано решение
    //2. Имена правильных и неправильных комментариев сделать составными, включающими: а. Имя ключа объекта, б. Имя алгоритма задачи, в. Вид комментария и его номер (например, F1..., T1...).
    //3. Придумать механизм возвращения имен и содержания правильных и ложных комментариев без исполнения алгоритмов.
}

