using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Drawing;
using GeomObjects.Points;
using GeomObjects.Lines;
using GeomObjects.EquationsSysCalc;
using GeomObjects.Plans;

namespace DrawG
{
    /// <summary>
    /// Класс содержит инструменты обработки графических объектов (добавления, выделения, удаления, перекраски и др.)
    /// </summary>
    class CollectionGraphicsObjectsTools
    {
        /// <summary>
        /// Определяет объект коллекции графических объектов ObjectGraphics_Collection, на который указывает курсор
        /// </summary>
        /// <param name="CursorPoint">Точка, определяющая текущее положение курсора</param>
        /// <param name="Distance_CursorToObject">Расстояние от курсора до объектра, определяющее чувствительность наведения курсора на объект</param>
        /// <param name="ObjectsGraphicsCollection_Source">Заданная коллекция, содержащая графические объекты</param>
        /// <returns>Возвращает объект коллекции, который является ближайшим к курсору</returns>
        public static object ObjectG_DetermineOfCollection(Point CursorPoint, double Distance_CursorToObject, Collection<object> ObjectsGraphicsCollection_Source)
        {
            object Object_Var = null;
            double len;
            if (ObjectsGraphicsCollection_Source.Count == 0) // Контроль существования объектов в заданной коллекции
            {
                return Object_Var;
            }
            for (int i = 0; i < ObjectsGraphicsCollection_Source.Count; i++)
            {
                if (ObjectsGraphicsCollection_Source[i] is Point) // Определение типа объекта - Point
                {
                    Point temp = (Point)ObjectsGraphicsCollection_Source[i];
                    len = Math.Sqrt((CursorPoint.X - temp.X) * (CursorPoint.X - temp.X) + (CursorPoint.Y - temp.Y) * (CursorPoint.Y - temp.Y));
                    if (len < Distance_CursorToObject)
                    {
                        Object_Var = ObjectsGraphicsCollection_Source[i];
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
                // Далее к проверке следующего типа объектов
                if (ObjectsGraphicsCollection_Source[i] is Point3D)
                {
                    var temp = (Point3D)ObjectsGraphicsCollection_Source[i];
                    Point PointProectionToScreen_Var = PropertyPoint3D.Draw_Point3D_Var.PointPositionCorrection(temp.Point3DDraw.PointPlan1X0Y_PositionByPicture, 0, DrawOperations.GridDraw_Var.GridCenter);
                    len = Math.Sqrt((CursorPoint.X - PointProectionToScreen_Var.X) ^ 2 + (CursorPoint.Y - PointProectionToScreen_Var.Y) ^ 2);
                    if (len < Distance_CursorToObject)
                    {
                        Object_Var = temp.PointOfPlan1X0Y;
                        break;
                    }
                    PointProectionToScreen_Var = PropertyPoint3D.Draw_Point3D_Var.PointPositionCorrection(temp.Point3DDraw.PointPlan2X0Z_PositionByPicture, 0, DrawOperations.GridDraw_Var.GridCenter);
                    len = Math.Sqrt((CursorPoint.X - PointProectionToScreen_Var.X) ^ 2 + (CursorPoint.Y - PointProectionToScreen_Var.Y) ^ 2);
                    if (len < Distance_CursorToObject)
                    {
                        Object_Var = temp.PointOfPlan2X0Z;
                        break;
                    }
                    PointProectionToScreen_Var = PropertyPoint3D.Draw_Point3D_Var.PointPositionCorrection(temp.Point3DDraw.PointPlan3Y0Z_PositionByPicture, 0, DrawOperations.GridDraw_Var.GridCenter);
                    len = Math.Sqrt((CursorPoint.X - PointProectionToScreen_Var.X) ^ 2 + (CursorPoint.Y - PointProectionToScreen_Var.Y) ^ 2);
                    if (len < Distance_CursorToObject)
                    {
                        Object_Var = temp.PointOfPlan3Y0Z;
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
                if (ObjectsGraphicsCollection_Source[i] is PointOfPlan1X0Y)
                {
                    var temp = (PointOfPlan1X0Y)ObjectsGraphicsCollection_Source[i];
                    Point PointProectionToScreen_Var = PropertyPoint3D.Draw_Point3D_Var.PointPositionCorrection(temp.Point3D_Draw.PointPlan1X0Y_PositionByPicture, 0, DrawOperations.GridDraw_Var.GridCenter);
                    len = Math.Sqrt((CursorPoint.X - PointProectionToScreen_Var.X) ^ 2 + (CursorPoint.Y - PointProectionToScreen_Var.Y) ^ 2);
                    if (len < Distance_CursorToObject)
                    {
                        Object_Var = ObjectsGraphicsCollection_Source[i];
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
                if (ObjectsGraphicsCollection_Source[i] is PointOfPlan2X0Z)
                {
                    PointOfPlan2X0Z temp = (PointOfPlan2X0Z)ObjectsGraphicsCollection_Source[i];
                    Point PointProectionToScreen_Var = PropertyPoint3D.Draw_Point3D_Var.PointPositionCorrection(temp.Point3D_Draw.PointPlan2X0Z_PositionByPicture, 0, DrawOperations.GridDraw_Var.GridCenter);
                    len = Math.Sqrt((CursorPoint.X - PointProectionToScreen_Var.X) ^ 2 + (CursorPoint.Y - PointProectionToScreen_Var.Y) ^ 2);
                    if (len < Distance_CursorToObject)
                    {
                        Object_Var = ObjectsGraphicsCollection_Source[i];
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
                if (ObjectsGraphicsCollection_Source[i] is PointOfPlan3Y0Z)
                {
                    PointOfPlan3Y0Z temp = (PointOfPlan3Y0Z)ObjectsGraphicsCollection_Source[i];
                    Point PointProectionToScreen_Var = PropertyPoint3D.Draw_Point3D_Var.PointPositionCorrection(temp.Point3D_Draw.PointPlan3Y0Z_PositionByPicture, 0, DrawOperations.GridDraw_Var.GridCenter);
                    len = Math.Sqrt((CursorPoint.X - PointProectionToScreen_Var.X) ^ 2 + (CursorPoint.Y - PointProectionToScreen_Var.Y) ^ 2);
                    if (len < Distance_CursorToObject)
                    {
                        Object_Var = ObjectsGraphicsCollection_Source[i];
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            return Object_Var;
        }
        /// <summary>
        /// Определяет объект коллекции графических объектов "ObjectsGraphics_Collection" (проекцию точки), на который указывает курсор
        /// </summary>
        /// <param name="CursorPoint">Точка, определяющая текущее положение корсора</param>
        /// <param name="Distance_CursorToPointOfPlane">Расстояние от курсора до проекции точки, определяющее чувствительность наведения курсора на объект</param>
        /// <param name="ObjectsGraphicsCollection_Source">Заданная коллекция, содержащая графические объекты</param>
        /// <returns>Возвращает объект коллекции, который является ближайши к курсору</returns>
        public static object ObjectG_DetermineOfCollectionPointOfPlan(Point CursorPoint, double Distance_CursorToPointOfPlane, Collection<object> ObjectsGraphicsCollection_Source)
        {
            object Object_Var = new object();
            double len;
            if (ObjectsGraphicsCollection_Source.Count == 0)
            {
                return Object_Var;
            }

            for (int i = 0; i < ObjectsGraphicsCollection_Source.Count; i++)
            {
                if (ObjectsGraphicsCollection_Source[i] is PointOfPlan1X0Y)
                {
                    PointOfPlan1X0Y temp = (PointOfPlan1X0Y)ObjectsGraphicsCollection_Source[i];
                    Point PointProectionToScreen_Var = PropertyPoint3D.Draw_Point3D_Var.PointPositionCorrection(temp.Point3D_Draw.PointPlan1X0Y_PositionByPicture, 0, DrawOperations.GridDraw_Var.GridCenter);
                    len = Math.Sqrt((CursorPoint.X - PointProectionToScreen_Var.X) ^ 2 + (CursorPoint.Y - PointProectionToScreen_Var.Y) ^ 2);
                    if (len < Distance_CursorToPointOfPlane)
                    {
                        Object_Var = ObjectsGraphicsCollection_Source[i];
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
                if (ObjectsGraphicsCollection_Source[i] is PointOfPlan2X0Z)
                {
                    PointOfPlan2X0Z temp = (PointOfPlan2X0Z)ObjectsGraphicsCollection_Source[i];
                    Point PointProectionToScreen_Var = PropertyPoint3D.Draw_Point3D_Var.PointPositionCorrection(temp.Point3D_Draw.PointPlan2X0Z_PositionByPicture, 0, DrawOperations.GridDraw_Var.GridCenter);
                    len = Math.Sqrt((CursorPoint.X - PointProectionToScreen_Var.X) ^ 2 + (CursorPoint.Y - PointProectionToScreen_Var.Y) ^ 2);
                    if (len < Distance_CursorToPointOfPlane)
                    {
                        Object_Var = ObjectsGraphicsCollection_Source[i];
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
                if (ObjectsGraphicsCollection_Source[i] is PointOfPlan3Y0Z)
                {
                    PointOfPlan3Y0Z temp = (PointOfPlan3Y0Z)ObjectsGraphicsCollection_Source[i];
                    Point PointProectionToScreen_Var = PropertyPoint3D.Draw_Point3D_Var.PointPositionCorrection(temp.Point3D_Draw.PointPlan3Y0Z_PositionByPicture, 0, DrawOperations.GridDraw_Var.GridCenter);
                    len = Math.Sqrt((CursorPoint.X - PointProectionToScreen_Var.X) ^ 2 + (CursorPoint.Y - PointProectionToScreen_Var.Y) ^ 2);
                    if (len < Distance_CursorToPointOfPlane)
                    {
                        Object_Var = ObjectsGraphicsCollection_Source[i];
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            return Object_Var;
        }
        /// <summary>
        /// Добавляет указанный объект в коллекцию выбора графических объектов
        /// </summary>
        /// <param name="CursorPoint">Точка, определяющая текущее положение корсора</param>
        /// <param name="Distance_CursorToObject">Расстояние от курсора до объекта, определяющее чувствительность наведения курсора на объект</param>
        public static void ObjectG_SelectToCollection(Point CursorPoint, double Distance_CursorToObject)
        {
            object Object_Var = null;
            object ObjectCollectionSelect_Var = new object();
            bool Flag_Var = false; // Метка существования заданного объекта в коллекции выбранных графических объектов
            Object_Var = ObjectG_DetermineOfCollection(CursorPoint, Distance_CursorToObject, CollectionGraphicsObjects.GraphicsObjectsCollection);
            if (Object_Var == null) // Контроль существования объекта
            {
                return;
            }
            if (CollectionGraphicsObjects.GraphicsObjectsSelect.Count == 0) // Контроль существования коллекции выбранных графических объектов
            {
                CollectionGraphicsObjects.GraphicsObjectsSelect.Add(Object_Var); // Добавление найденных объектов в коллекцию выбранных графических объектов
                Flag_Var = true;
                return;
            }
            for (int i = 0; i < CollectionGraphicsObjects.GraphicsObjectsSelect.Count; i++)
            {
                // Определяем тип, затем сравниваем объекты
                if ((CollectionGraphicsObjects.GraphicsObjectsSelect[i] is Point) && (Object_Var is Point)) // Определение типа объекта - Point
                {
                    if (Object_Var == CollectionGraphicsObjects.GraphicsObjectsSelect[i]) // Контроль существования заданного объекта в коллекции выбранных графических объектов
                    {
                        Flag_Var = true; // Объект существует
                        break;
                    }
                }
                else if ((CollectionGraphicsObjects.GraphicsObjectsSelect[i] is Point2D) && (Object_Var is Point2D)) // Определение типа объекта - Point2D
                {
                    if (PropertyPoint3D.PointsPositionControl_Var.PointsIsPoints((Point2D)Object_Var, (Point2D)CollectionGraphicsObjects.GraphicsObjectsSelect[i]) == true) // Контроль существования заданного объекта в коллекции выбранных графических объектов
                    {
                        Flag_Var = true; // Объект существует
                        break;
                    }
                }
                else if ((CollectionGraphicsObjects.GraphicsObjectsSelect[i] is Point3D) && (Object_Var is Point3D)) // Определение типа объекта - Point3D
                {
                    if (PropertyPoint3D.PointsPositionControl_Var.PointsIsPoints((Point3D)Object_Var, (Point3D)CollectionGraphicsObjects.GraphicsObjectsSelect[i]) == true) // Контроль существования заданного объекта в коллекции выбранных графических объектов
                    {
                        Flag_Var = true; // Объект существует
                        break;
                    }
                }
                else if ((CollectionGraphicsObjects.GraphicsObjectsSelect[i] is PointOfPlan1X0Y) && (Object_Var is PointOfPlan1X0Y)) // Определение типа объекта - PointOfPlan1_X0Y
                {
                    if (PropertyPoint3D.PointsPositionControl_Var.PointsIsPoints((PointOfPlan1X0Y)Object_Var, (PointOfPlan1X0Y)CollectionGraphicsObjects.GraphicsObjectsSelect[i]) == true) // Контроль существования заданного объекта в коллекции выбранных графических объектов
                    {
                        Flag_Var = true; // Объект существует
                        break;
                    }
                }
                else if ((CollectionGraphicsObjects.GraphicsObjectsSelect[i] is PointOfPlan2X0Z) && (Object_Var is PointOfPlan2X0Z)) // Определение типа объекта - PointOfPlan2_X0Z
                {
                    if (PropertyPoint3D.PointsPositionControl_Var.PointsIsPoints((PointOfPlan2X0Z)Object_Var, (PointOfPlan2X0Z)CollectionGraphicsObjects.GraphicsObjectsSelect[i]) == true) // Контроль существования заданного объекта в коллекции выбранных графических объектов
                    {
                        Flag_Var = true; // Объект существует
                        break;
                    }
                }
                else if ((CollectionGraphicsObjects.GraphicsObjectsSelect[i] is PointOfPlan3Y0Z) && (Object_Var is PointOfPlan3Y0Z)) // Определение типа объекта - PointOfPlan3_Y0Z
                {
                    if (PropertyPoint3D.PointsPositionControl_Var.PointsIsPoints((PointOfPlan3Y0Z)Object_Var, (PointOfPlan3Y0Z)CollectionGraphicsObjects.GraphicsObjectsSelect[i]) == true) // Контроль существования заданного объекта в коллекции выбранных графических объектов
                    {
                        Flag_Var = true; // Объект существует
                        break;
                    }
                }
            }
            if (!Flag_Var)
            {
                CollectionGraphicsObjects.GraphicsObjectsSelect.Add(Object_Var);
            }
        }
        /// <summary>
        /// Добавляет указанный объект в коллекцию выбора проекций точек
        /// </summary>
        /// <param name="CursorPoint">Точка, определяющая текущее положение корсора</param>
        /// <param name="Distance_CursorToPointOfPlane">Расстояние от курсора до проекции точки, определяющее чувствительность наведения курсора на объект</param>
        public static void ObjectG_SelectToCollectionPointOfPlane(Point CursorPoint, double Distance_CursorToPointOfPlane)
        {
            object Object_Var = new object();
            object ObjectOfCollectionSelect_Var = new object();
            bool Flag_Var = false;
            Object_Var = CollectionGraphicsObjectsTools.ObjectG_DetermineOfCollectionPointOfPlan(CursorPoint, Distance_CursorToPointOfPlane, CollectionGraphicsObjects.GraphicsObjectsCollection);
            if (Object_Var == null)
            {
                return;
            }

            if (CollectionGraphicsObjects.GraphicsObjectsSelectPointsOfPlane.Count == 0)
            {
                CollectionGraphicsObjects.GraphicsObjectsSelectPointsOfPlane.Add(Object_Var);
                Flag_Var = true;
            }
            for (int i = 0; i < CollectionGraphicsObjects.GraphicsObjectsSelectPointsOfPlane.Count; i++)
            {
                if (CollectionGraphicsObjects.GraphicsObjectsSelectPointsOfPlane[i] is PointOfPlan1X0Y && Object_Var is PointOfPlan1X0Y)
                {
                    if (PropertyPoint3D.PointsPositionControl_Var.PointsIsPoints((PointOfPlan1X0Y)Object_Var, (PointOfPlan1X0Y)CollectionGraphicsObjects.GraphicsObjectsSelectPointsOfPlane[i]))
                    {
                        Flag_Var = true;
                    }
                }
                else if (CollectionGraphicsObjects.GraphicsObjectsSelectPointsOfPlane[i] is PointOfPlan2X0Z && Object_Var is PointOfPlan2X0Z)
                {
                    if (PropertyPoint3D.PointsPositionControl_Var.PointsIsPoints((PointOfPlan2X0Z)Object_Var, (PointOfPlan2X0Z)CollectionGraphicsObjects.GraphicsObjectsSelectPointsOfPlane[i]))
                    {
                        Flag_Var = true;
                    }
                }
                else if (CollectionGraphicsObjects.GraphicsObjectsSelectPointsOfPlane[i] is PointOfPlan3Y0Z && Object_Var is PointOfPlan3Y0Z)
                {
                    if (PropertyPoint3D.PointsPositionControl_Var.PointsIsPoints((PointOfPlan3Y0Z)Object_Var, (PointOfPlan3Y0Z)CollectionGraphicsObjects.GraphicsObjectsSelectPointsOfPlane[i]))
                    {
                        Flag_Var = true;
                    }
                }
            }
            if (!Flag_Var)
            {
                CollectionGraphicsObjects.GraphicsObjectsSelectPointsOfPlane.Add(Object_Var);
            }
        }
        /// <summary>
        /// Удаляет объекты заданной коллекции "CollectionSelect_Source" из заданной коллекции "ObjectsGraphicsCollection_Source"
        /// </summary>
        /// <param name="CollectionSelect_Source">Коллекция выбранных объектов для удаления</param>
        /// <param name="CollectionDelete_Source">Коллекция удаляемых объектов (для возможного восстановления)</param>
        /// <param name="ObjectsGraphicsCollection_Source">Коллекция графических объектов</param>
        /// <remarks>Объекты коллекции CollectionSelect_Source копируются в коллекцию CollectionDelete_Source.
        /// Коллекция ObjectsGraphics_Select после удаления объектов очищается.</remarks>
        public static void ObjectG_DeleteFromCollection(Collection<object> CollectionSelect_Source, Collection<object> CollectionDelete_Source, Collection<object> ObjectsGraphicsCollection_Source)
        {
            //Удаление из коллекции ObjectsGraphics_Collection объектов коллекции ObjectsGraphics_Select
            for (int i = 0; i < CollectionSelect_Source.Count; i++)
            {
                for (int j = 0; j < ObjectsGraphicsCollection_Source.Count; j++)
                {
                    //---------- Тип объекта - точка (System.Drawing.Point) ---
                    if ((CollectionSelect_Source[i] is Point) && (ObjectsGraphicsCollection_Source[j] is Point)) //Определение типа объекта - Point
                    {
                        if (CollectionSelect_Source[i] == ObjectsGraphicsCollection_Source[j]) //Контроль существования заданного объекта в коллекции выбранных графических объектов 
                        {
                            CollectionDelete_Source.Add(CollectionSelect_Source[i]); //Копирование удаляемых объектов в коллекцию CollectionDelete_Source
                            ObjectsGraphicsCollection_Source.RemoveAt(j); //Удаление точки из коллекции графических объектов
                        }
                    }
                    //---------- Тип объекта - ПРОЕКЦИИ как часть Point3D ---
                    else if ((CollectionSelect_Source[i] is PointOfPlan1X0Y) && (ObjectsGraphicsCollection_Source[j] is Point3D))
                    {
                        Point3D temp = (Point3D)ObjectsGraphicsCollection_Source[j];
                        if (PropertyPoint3D.PointsPositionControl_Var.PointsIsPoints((PointOfPlan1X0Y)CollectionSelect_Source[i], temp.PointOfPlan1X0Y))
                        {
                            CollectionDelete_Source.Add(CollectionSelect_Source[i]);
                            temp.Point3DDraw.FlagDraw_PointPlan1X0Y = false;
                            if (temp.Point3DDraw.FlagDraw_PointPlan2X0Z && temp.Point3DDraw.FlagDraw_PointPlan3Y0Z == false)
                            {
                                ObjectsGraphicsCollection_Source.Add(temp.PointOfPlan2X0Z);
                                ObjectsGraphicsCollection_Source.RemoveAt(j);
                            }
                            else if (temp.Point3DDraw.FlagDraw_PointPlan2X0Z == false && temp.Point3DDraw.FlagDraw_PointPlan3Y0Z == true)
                            {
                                ObjectsGraphicsCollection_Source.Add(temp.PointOfPlan3Y0Z);
                                ObjectsGraphicsCollection_Source.RemoveAt(j);
                            }
                            else if (temp.Point3DDraw.FlagDraw_PointPlan2X0Z == false && temp.Point3DDraw.FlagDraw_PointPlan3Y0Z == false)
                            {
                                ObjectsGraphicsCollection_Source.RemoveAt(j);
                            }
                        }
                    }

                    else if ((CollectionSelect_Source[i] is PointOfPlan2X0Z) && (ObjectsGraphicsCollection_Source[j] is Point3D))
                    {
                        Point3D temp = (Point3D)ObjectsGraphicsCollection_Source[j];
                        if (PropertyPoint3D.PointsPositionControl_Var.PointsIsPoints((PointOfPlan2X0Z)CollectionSelect_Source[i], temp.PointOfPlan2X0Z))
                        {
                            CollectionDelete_Source.Add(CollectionSelect_Source[i]);
                            temp.Point3DDraw.FlagDraw_PointPlan2X0Z = false;
                            if (temp.Point3DDraw.FlagDraw_PointPlan1X0Y && temp.Point3DDraw.FlagDraw_PointPlan3Y0Z == false)
                            {
                                ObjectsGraphicsCollection_Source.Add(temp.PointOfPlan1X0Y);
                                ObjectsGraphicsCollection_Source.RemoveAt(j);
                            }
                            else if (temp.Point3DDraw.FlagDraw_PointPlan1X0Y == false && temp.Point3DDraw.FlagDraw_PointPlan3Y0Z == true)
                            {
                                ObjectsGraphicsCollection_Source.Add(temp.PointOfPlan3Y0Z);
                                ObjectsGraphicsCollection_Source.RemoveAt(j);
                            }
                            else if (temp.Point3DDraw.FlagDraw_PointPlan1X0Y == false && temp.Point3DDraw.FlagDraw_PointPlan3Y0Z == false)
                            {
                                ObjectsGraphicsCollection_Source.RemoveAt(j);
                            }
                        }
                    }

                    else if ((CollectionSelect_Source[i] is PointOfPlan3Y0Z) && (ObjectsGraphicsCollection_Source[j] is Point3D))
                    {
                        Point3D temp = (Point3D)ObjectsGraphicsCollection_Source[j];
                        if (PropertyPoint3D.PointsPositionControl_Var.PointsIsPoints((PointOfPlan3Y0Z)CollectionSelect_Source[i], temp.PointOfPlan3Y0Z))
                        {
                            CollectionDelete_Source.Add(CollectionSelect_Source[i]);
                            temp.Point3DDraw.FlagDraw_PointPlan3Y0Z = false;
                            if (temp.Point3DDraw.FlagDraw_PointPlan1X0Y && temp.Point3DDraw.FlagDraw_PointPlan2X0Z == false)
                            {
                                ObjectsGraphicsCollection_Source.Add(temp.PointOfPlan1X0Y);
                                ObjectsGraphicsCollection_Source.RemoveAt(j);
                            }
                            else if (temp.Point3DDraw.FlagDraw_PointPlan1X0Y == false && temp.Point3DDraw.FlagDraw_PointPlan2X0Z == true)
                            {
                                ObjectsGraphicsCollection_Source.Add(temp.PointOfPlan2X0Z);
                                ObjectsGraphicsCollection_Source.RemoveAt(j);
                            }
                            else if (temp.Point3DDraw.FlagDraw_PointPlan1X0Y == false && temp.Point3DDraw.FlagDraw_PointPlan2X0Z == false)
                            {
                                ObjectsGraphicsCollection_Source.RemoveAt(j);
                            }
                        }
                    }
                    //---------- Тип объекта - ПРОЕКЦИИ как самостоятельные объекты ---
                    else if (CollectionSelect_Source[i] is PointOfPlan1X0Y && ObjectsGraphicsCollection_Source[j] is PointOfPlan1X0Y)
                    {
                        if (PropertyPoint3D.PointsPositionControl_Var.PointsIsPoints((PointOfPlan1X0Y)CollectionSelect_Source[i], (PointOfPlan1X0Y)ObjectsGraphicsCollection_Source[j]))
                        {
                            CollectionDelete_Source.Add(CollectionSelect_Source[i]);
                            ObjectsGraphicsCollection_Source.RemoveAt(j);
                        }
                    }
                    else if (CollectionSelect_Source[i] is PointOfPlan2X0Z && ObjectsGraphicsCollection_Source[j] is PointOfPlan2X0Z)
                    {
                        if (PropertyPoint3D.PointsPositionControl_Var.PointsIsPoints((PointOfPlan2X0Z)CollectionSelect_Source[i], (PointOfPlan2X0Z)ObjectsGraphicsCollection_Source[j]))
                        {
                            CollectionDelete_Source.Add(CollectionSelect_Source[i]);
                            ObjectsGraphicsCollection_Source.RemoveAt(j);
                        }
                    }
                    else if (CollectionSelect_Source[i] is PointOfPlan3Y0Z && ObjectsGraphicsCollection_Source[j] is PointOfPlan3Y0Z)
                    {
                        if (PropertyPoint3D.PointsPositionControl_Var.PointsIsPoints((PointOfPlan3Y0Z)CollectionSelect_Source[i], (PointOfPlan3Y0Z)ObjectsGraphicsCollection_Source[j]))
                        {
                            CollectionDelete_Source.Add(CollectionSelect_Source[i]);
                            ObjectsGraphicsCollection_Source.RemoveAt(j);
                        }
                    }
                }
            }
            CollectionSelect_Source.Clear();
            CollectionDelete_Source.Clear();
        }

    }
}
