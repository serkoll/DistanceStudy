using System;
using System.Collections.ObjectModel;
using System.Drawing;
using GeometryObjects;

namespace GraphicsModule
{
    /// <summary>
    /// Класс содержит инструменты обработки графических объектов (добавления, выделения, удаления, перекраски и др.)
    /// </summary>
    class CollectionGraphicsObjectsTools
    {
        /// <summary>
        /// Определяет объект коллекции графических объектов ObjectGraphics_Collection, на который указывает курсор
        /// </summary>
        /// <param name="cursorPoint">Точка, определяющая текущее положение курсора</param>
        /// <param name="maxDistanceToObject">Расстояние от курсора до объектра, определяющее чувствительность наведения курсора на объект</param>
        /// <param name="collectionSource">Заданная коллекция, содержащая графические объекты</param>
        /// <returns>Возвращает объект коллекции, который является ближайшим к курсору</returns>
        public static object DetermineObjectOfCollection(Point cursorPoint, double maxDistanceToObject, Collection<object> collectionSource)
        {
            double len;
            if (collectionSource.Count == 0) // Контроль существования объектов в заданной коллекции
            {
                return null;
            }
            for (int i = 0; i < collectionSource.Count; i++)
            {
                if (collectionSource[i].GetType().Name == "Point") // Определение типа объекта - Point
                {
                    var temp = (Point)collectionSource[i];
                    len = Math.Sqrt((cursorPoint.X - temp.X) * (cursorPoint.X - temp.X) + (cursorPoint.Y - temp.Y) * (cursorPoint.Y - temp.Y));
                    if (len < maxDistanceToObject)
                    {
                        return collectionSource[i];
                    }
                    else
                    {
                        continue;
                    }
                }
                // Далее к проверке следующего типа объектов
                if (collectionSource[i].GetType().Name ==  "Point3D")
                {
                    var temp = (Point3D)collectionSource[i];
                    Point pointProectionToScreen = PropertyPoint3D.Draw_Point3D_Var.PointPositionCorrection(temp.Point3DDraw.PointPlan1X0Y_PositionByPicture, 0, DrawOperations.GridDraw_Var.GridCenter);
                    len = Math.Sqrt((cursorPoint.X - pointProectionToScreen.X) ^ 2 + (cursorPoint.Y - pointProectionToScreen.Y) ^ 2);
                    if (len < maxDistanceToObject)
                    {
                        return temp.PointOfPlan1X0Y;
                    }
                    pointProectionToScreen = PropertyPoint3D.Draw_Point3D_Var.PointPositionCorrection(temp.Point3DDraw.PointPlan2X0Z_PositionByPicture, 0, DrawOperations.GridDraw_Var.GridCenter);
                    len = Math.Sqrt((cursorPoint.X - pointProectionToScreen.X) ^ 2 + (cursorPoint.Y - pointProectionToScreen.Y) ^ 2);
                    if (len < maxDistanceToObject)
                    {
                        return temp.PointOfPlan2X0Z;
                    }
                    pointProectionToScreen = PropertyPoint3D.Draw_Point3D_Var.PointPositionCorrection(temp.Point3DDraw.PointPlan3Y0Z_PositionByPicture, 0, DrawOperations.GridDraw_Var.GridCenter);
                    len = Math.Sqrt((cursorPoint.X - pointProectionToScreen.X) ^ 2 + (cursorPoint.Y - pointProectionToScreen.Y) ^ 2);
                    if (len < maxDistanceToObject)
                    {
                        return temp.PointOfPlan3Y0Z;
                    }
                    else
                    {
                        continue;
                    }
                }
                if (collectionSource[i].GetType().Name == "PointOfPlan1X0Y")
                {
                    var temp = (PointOfPlan1X0Y)collectionSource[i];
                    Point PointProectionToScreen_Var = PropertyPoint3D.Draw_Point3D_Var.PointPositionCorrection(temp.Point3D_Draw.PointPlan1X0Y_PositionByPicture, 0, DrawOperations.GridDraw_Var.GridCenter);
                    len = Math.Sqrt((cursorPoint.X - PointProectionToScreen_Var.X) ^ 2 + (cursorPoint.Y - PointProectionToScreen_Var.Y) ^ 2);
                    if (len < maxDistanceToObject)
                    {
                        return collectionSource[i];
                    }
                    else
                    {
                        continue;
                    }
                }
                if (collectionSource[i].GetType().Name == "PointOfPlan2X0Z")
                {
                    var temp = (PointOfPlan2X0Z)collectionSource[i];
                    Point PointProectionToScreen_Var = PropertyPoint3D.Draw_Point3D_Var.PointPositionCorrection(temp.Point3D_Draw.PointPlan2X0Z_PositionByPicture, 0, DrawOperations.GridDraw_Var.GridCenter);
                    len = Math.Sqrt((cursorPoint.X - PointProectionToScreen_Var.X) ^ 2 + (cursorPoint.Y - PointProectionToScreen_Var.Y) ^ 2);
                    if (len < maxDistanceToObject)
                    {
                        return collectionSource[i];
                    }
                    else
                    {
                        continue;
                    }
                }
                if (collectionSource[i].GetType().Name == "PointOfPlan3Y0Z")
                {
                    PointOfPlan3Y0Z temp = (PointOfPlan3Y0Z)collectionSource[i];
                    Point PointProectionToScreen_Var = PropertyPoint3D.Draw_Point3D_Var.PointPositionCorrection(temp.Point3D_Draw.PointPlan3Y0Z_PositionByPicture, 0, DrawOperations.GridDraw_Var.GridCenter);
                    len = Math.Sqrt((cursorPoint.X - PointProectionToScreen_Var.X) ^ 2 + (cursorPoint.Y - PointProectionToScreen_Var.Y) ^ 2);
                    if (len < maxDistanceToObject)
                    {
                        return collectionSource[i];
                    }
                    else
                    {
                        continue;
                    }
                }
                if (collectionSource[i].GetType().Name == "Line2D")
                {
                    var temp = (Line2D)collectionSource[i];
                    double len0 = Math.Sqrt((cursorPoint.X - temp.Point_0.X) * (cursorPoint.X - temp.Point_0.X) + (cursorPoint.Y - temp.Point_0.Y) * (cursorPoint.Y - temp.Point_0.Y));
                    double len1 = Math.Sqrt((cursorPoint.X - temp.Point_1.X) * (cursorPoint.X - temp.Point_1.X) + (cursorPoint.Y - temp.Point_1.Y) * (cursorPoint.Y - temp.Point_1.Y));
                    if ((len0 < maxDistanceToObject) || (len1 < maxDistanceToObject))
                    {
                        return collectionSource[i];
                    }
                    else if(LinePositionControl.PointOfLine(new Point2D(cursorPoint.X, cursorPoint.Y), temp) == true)
                    {
                        return collectionSource[i];
                    }
                    else
                    {
                        continue;
                    }

                }
                if (collectionSource[i].GetType().Name == "LineOfPlan1X0Y")
                {
                    var temp = (LineOfPlan1X0Y)collectionSource[i];



                    Point Point0ProectionToScreen_Var = temp.Line_Draw.PointDraw.CnvPoint2D_ToPoint(temp.Line_Draw.LineOfPlan1X0YPositionByFrame.Point_0);
                    Point Point1ProectionToScreen_Var = temp.Line_Draw.PointDraw.CnvPoint2D_ToPoint(temp.Line_Draw.LineOfPlan1X0YPositionByFrame.Point_1);

                    double len0 = Math.Sqrt((cursorPoint.X - Point0ProectionToScreen_Var.X) ^ 2 + (cursorPoint.Y - Point0ProectionToScreen_Var.Y) ^ 2);
                    double len1 = Math.Sqrt((cursorPoint.X - Point1ProectionToScreen_Var.X) ^ 2 + (cursorPoint.Y - Point1ProectionToScreen_Var.Y) ^ 2);

                    if ((len0 < maxDistanceToObject) || (len1 < maxDistanceToObject))
                    {
                        return collectionSource[i];
                    }
                    else if (LinePositionControl.PointOfLine(new Point2D(cursorPoint.X, cursorPoint.Y), temp.CnvLine2D(temp)) == true)
                    {
                        return collectionSource[i];
                    }
                    else
                    {
                        continue;
                    }
                }
                if (collectionSource[i].GetType().Name == "LineOfPlan2X0Z")
                {
                    var temp = (LineOfPlan2X0Z)collectionSource[i];

                    Point Point0ProectionToScreen_Var = temp.Line_Draw.PointDraw.CnvPoint2D_ToPoint(temp.Line_Draw.LineOfPlan2X0ZPositionByFrame.Point_0);
                    Point Point1ProectionToScreen_Var = temp.Line_Draw.PointDraw.CnvPoint2D_ToPoint(temp.Line_Draw.LineOfPlan2X0ZPositionByFrame.Point_1);

                    double len0 = Math.Sqrt((cursorPoint.X - Point0ProectionToScreen_Var.X) ^ 2 + (cursorPoint.Y - Point0ProectionToScreen_Var.Y) ^ 2);
                    double len1 = Math.Sqrt((cursorPoint.X - Point1ProectionToScreen_Var.X) ^ 2 + (cursorPoint.Y - Point1ProectionToScreen_Var.Y) ^ 2);

                    if ((len0 < maxDistanceToObject) || (len1 < maxDistanceToObject))
                    {
                        return collectionSource[i];
                    }
                    else if (LinePositionControl.PointOfLine(new Point2D(cursorPoint.X, cursorPoint.Y), temp.CnvLine2D(temp)) == true)
                    {
                        return collectionSource[i];
                    }
                    else
                    {
                        continue;
                    }
                }
                if (collectionSource[i].GetType().Name == "LineOfPlan3Y0Z")
                {
                    var temp = (LineOfPlan3Y0Z)collectionSource[i];

                    Point Point0ProectionToScreen_Var = temp.Line_Draw.PointDraw.CnvPoint2D_ToPoint(temp.Line_Draw.LineOfPlan3Y0ZPositionByFrame.Point_0);
                    Point Point1ProectionToScreen_Var = temp.Line_Draw.PointDraw.CnvPoint2D_ToPoint(temp.Line_Draw.LineOfPlan3Y0ZPositionByFrame.Point_1);

                    double len0 = Math.Sqrt((cursorPoint.X - Point0ProectionToScreen_Var.X) ^ 2 + (cursorPoint.Y - Point0ProectionToScreen_Var.Y) ^ 2);
                    double len1 = Math.Sqrt((cursorPoint.X - Point1ProectionToScreen_Var.X) ^ 2 + (cursorPoint.Y - Point1ProectionToScreen_Var.Y) ^ 2);

                    if ((len0 < maxDistanceToObject) || (len1 < maxDistanceToObject))
                    {
                        return collectionSource[i];
                    }
                    else if (LinePositionControl.PointOfLine(new Point2D(cursorPoint.X, cursorPoint.Y), temp.CnvLine2D(temp)) == true)
                    {
                        return collectionSource[i];
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            return null;
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
        /// <param name="cursorPoint">Точка, определяющая текущее положение корсора</param>
        /// <param name="MaxDistanceToObject">Расстояние от курсора до объекта, определяющее чувствительность наведения курсора на объект</param>
        public static void SelectObjectToCollection(Point cursorPoint, double MaxDistanceToObject)
        {
            object selectedObject = null;
            object collectionOfSelectedObjects = new object();
            bool Flag_Var = false; // Метка существования заданного объекта в коллекции выбранных графических объектов
            selectedObject = DetermineObjectOfCollection(cursorPoint, MaxDistanceToObject, CollectionsGraphicsObjects.GraphicsObjectsCollection);
            if (selectedObject == null) // Контроль существования объекта
            {
                return;
            }
            if (CollectionsGraphicsObjects.GraphicsObjectsSelect.Count == 0) // Контроль существования коллекции выбранных графических объектов
            {
                CollectionsGraphicsObjects.GraphicsObjectsSelect.Add(selectedObject); // Добавление найденных объектов в коллекцию выбранных графических объектов
                Flag_Var = true;
                return;
            }
            for (int i = 0; i < CollectionsGraphicsObjects.GraphicsObjectsSelect.Count; i++)
            {
                // Определяем тип, затем сравниваем объекты
                if ((CollectionsGraphicsObjects.GraphicsObjectsSelect[i] is Point) && (selectedObject is Point)) // Определение типа объекта - Point
                {
                    if (selectedObject == CollectionsGraphicsObjects.GraphicsObjectsSelect[i]) // Контроль существования заданного объекта в коллекции выбранных графических объектов
                    {
                        Flag_Var = true; // Объект существует
                        break;
                    }
                }
                else if ((CollectionsGraphicsObjects.GraphicsObjectsSelect[i] is Point2D) && (selectedObject is Point2D)) // Определение типа объекта - Point2D
                {
                    if (PropertyPoint3D.PointsPositionControl_Var.PointsIsPoints((Point2D)selectedObject, (Point2D)CollectionsGraphicsObjects.GraphicsObjectsSelect[i]) == true) // Контроль существования заданного объекта в коллекции выбранных графических объектов
                    {
                        Flag_Var = true; // Объект существует
                        break;
                    }
                }
                else if ((CollectionsGraphicsObjects.GraphicsObjectsSelect[i] is Point3D) && (selectedObject is Point3D)) // Определение типа объекта - Point3D
                {
                    if (PropertyPoint3D.PointsPositionControl_Var.PointsIsPoints((Point3D)selectedObject, (Point3D)CollectionsGraphicsObjects.GraphicsObjectsSelect[i]) == true) // Контроль существования заданного объекта в коллекции выбранных графических объектов
                    {
                        Flag_Var = true; // Объект существует
                        break;
                    }
                }
                else if ((CollectionsGraphicsObjects.GraphicsObjectsSelect[i] is PointOfPlan1X0Y) && (selectedObject is PointOfPlan1X0Y)) // Определение типа объекта - PointOfPlan1_X0Y
                {
                    if (PropertyPoint3D.PointsPositionControl_Var.PointsIsPoints((PointOfPlan1X0Y)selectedObject, (PointOfPlan1X0Y)CollectionsGraphicsObjects.GraphicsObjectsSelect[i]) == true) // Контроль существования заданного объекта в коллекции выбранных графических объектов
                    {
                        Flag_Var = true; // Объект существует
                        break;
                    }
                }
                else if ((CollectionsGraphicsObjects.GraphicsObjectsSelect[i] is PointOfPlan2X0Z) && (selectedObject is PointOfPlan2X0Z)) // Определение типа объекта - PointOfPlan2_X0Z
                {
                    if (PropertyPoint3D.PointsPositionControl_Var.PointsIsPoints((PointOfPlan2X0Z)selectedObject, (PointOfPlan2X0Z)CollectionsGraphicsObjects.GraphicsObjectsSelect[i]) == true) // Контроль существования заданного объекта в коллекции выбранных графических объектов
                    {
                        Flag_Var = true; // Объект существует
                        break;
                    }
                }
                else if ((CollectionsGraphicsObjects.GraphicsObjectsSelect[i] is PointOfPlan3Y0Z) && (selectedObject is PointOfPlan3Y0Z)) // Определение типа объекта - PointOfPlan3_Y0Z
                {
                    if (PropertyPoint3D.PointsPositionControl_Var.PointsIsPoints((PointOfPlan3Y0Z)selectedObject, (PointOfPlan3Y0Z)CollectionsGraphicsObjects.GraphicsObjectsSelect[i]) == true) // Контроль существования заданного объекта в коллекции выбранных графических объектов
                    {
                        Flag_Var = true; // Объект существует
                        break;
                    }
                }
                else if ((CollectionsGraphicsObjects.GraphicsObjectsSelect[i].GetType().Name == "Line2D") && (selectedObject.GetType().Name == "Line2D")) // Определение типа объекта - PointOfPlan3_Y0Z
                {
                   
                    if (LinePositionControl.LinesIsLines((Line2D)selectedObject, (Line2D)CollectionsGraphicsObjects.GraphicsObjectsSelect[i]) == true) // Контроль существования заданного объекта в коллекции выбранных графических объектов
                    {
                        Flag_Var = true; // Объект существует
                        break;
                    }
                }
                else if ((CollectionsGraphicsObjects.GraphicsObjectsSelect[i].GetType().Name == "LineOfPlan1X0Y") && (selectedObject.GetType().Name == "LineOfPlan1X0Y")) // Определение типа объекта - PointOfPlan3_Y0Z
                {

                    if (LinePositionControl.LinesIsLines((LineOfPlan1X0Y)selectedObject, (LineOfPlan1X0Y)CollectionsGraphicsObjects.GraphicsObjectsSelect[i]) == true) // Контроль существования заданного объекта в коллекции выбранных графических объектов
                    {
                        Flag_Var = true; // Объект существует
                        break;
                    }
                }
                else if ((CollectionsGraphicsObjects.GraphicsObjectsSelect[i].GetType().Name == "LineOfPlan2X0Z") && (selectedObject.GetType().Name == "LineOfPlan2X0Z")) // Определение типа объекта - PointOfPlan3_Y0Z
                {

                    if (LinePositionControl.LinesIsLines((LineOfPlan2X0Z)selectedObject, (LineOfPlan2X0Z)CollectionsGraphicsObjects.GraphicsObjectsSelect[i]) == true) // Контроль существования заданного объекта в коллекции выбранных графических объектов
                    {
                        Flag_Var = true; // Объект существует
                        break;
                    }
                }
                else if ((CollectionsGraphicsObjects.GraphicsObjectsSelect[i].GetType().Name == "LineOfPlan3Y0Z") && (selectedObject.GetType().Name == "LineOfPlan3Y0Z")) // Определение типа объекта - PointOfPlan3_Y0Z
                {

                    if (LinePositionControl.LinesIsLines((LineOfPlan3Y0Z)selectedObject, (LineOfPlan3Y0Z)CollectionsGraphicsObjects.GraphicsObjectsSelect[i]) == true) // Контроль существования заданного объекта в коллекции выбранных графических объектов
                    {
                        Flag_Var = true; // Объект существует
                        break;
                    }
                }
            }
            if (!Flag_Var)
            {
                CollectionsGraphicsObjects.GraphicsObjectsSelect.Add(selectedObject);
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
            Object_Var = CollectionGraphicsObjectsTools.ObjectG_DetermineOfCollectionPointOfPlan(CursorPoint, Distance_CursorToPointOfPlane, CollectionsGraphicsObjects.GraphicsObjectsCollection);
            if (Object_Var == null)
            {
                return;
            }

            if (CollectionsGraphicsObjects.GraphicsObjectsSelectPointsOfPlane.Count == 0)
            {
                CollectionsGraphicsObjects.GraphicsObjectsSelectPointsOfPlane.Add(Object_Var);
                Flag_Var = true;
            }
            for (int i = 0; i < CollectionsGraphicsObjects.GraphicsObjectsSelectPointsOfPlane.Count; i++)
            {
                if (CollectionsGraphicsObjects.GraphicsObjectsSelectPointsOfPlane[i] is PointOfPlan1X0Y && Object_Var is PointOfPlan1X0Y)
                {
                    if (PropertyPoint3D.PointsPositionControl_Var.PointsIsPoints((PointOfPlan1X0Y)Object_Var, (PointOfPlan1X0Y)CollectionsGraphicsObjects.GraphicsObjectsSelectPointsOfPlane[i]))
                    {
                        Flag_Var = true;
                    }
                }
                else if (CollectionsGraphicsObjects.GraphicsObjectsSelectPointsOfPlane[i] is PointOfPlan2X0Z && Object_Var is PointOfPlan2X0Z)
                {
                    if (PropertyPoint3D.PointsPositionControl_Var.PointsIsPoints((PointOfPlan2X0Z)Object_Var, (PointOfPlan2X0Z)CollectionsGraphicsObjects.GraphicsObjectsSelectPointsOfPlane[i]))
                    {
                        Flag_Var = true;
                    }
                }
                else if (CollectionsGraphicsObjects.GraphicsObjectsSelectPointsOfPlane[i] is PointOfPlan3Y0Z && Object_Var is PointOfPlan3Y0Z)
                {
                    if (PropertyPoint3D.PointsPositionControl_Var.PointsIsPoints((PointOfPlan3Y0Z)Object_Var, (PointOfPlan3Y0Z)CollectionsGraphicsObjects.GraphicsObjectsSelectPointsOfPlane[i]))
                    {
                        Flag_Var = true;
                    }
                }
            }
            if (!Flag_Var)
            {
                CollectionsGraphicsObjects.GraphicsObjectsSelectPointsOfPlane.Add(Object_Var);
            }
        }
        /// <summary>
        /// Удаляет объекты заданной коллекции "CollectionSelect_Source" из заданной коллекции "ObjectsGraphicsCollection_Source"
        /// </summary>
        /// <param name="collectionSelectSource">Коллекция выбранных объектов для удаления</param>
        /// <param name="collectionDeleteSource">Коллекция удаляемых объектов (для возможного восстановления)</param>
        /// <param name="collectionObjectsSource">Коллекция графических объектов</param>
        /// <remarks>Объекты коллекции CollectionSelect_Source копируются в коллекцию CollectionDelete_Source.
        /// Коллекция ObjectsGraphics_Select после удаления объектов очищается.</remarks>
        public static void DeleteObjectsFromCollection(Collection<object> collectionSelectSource, Collection<object> collectionDeleteSource, Collection<object> collectionObjectsSource)
        {
            //Удаление из коллекции ObjectsGraphics_Collection объектов коллекции ObjectsGraphics_Select
            for (int i = 0; i < collectionSelectSource.Count; i++)
            {
                for (int j = 0; j < collectionObjectsSource.Count; j++)
                {
                    //---------- Тип объекта - точка (System.Drawing.Point) ---
                    if ((collectionSelectSource[i] is Point) && (collectionObjectsSource[j] is Point)) //Определение типа объекта - Point
                    {
                        if (collectionSelectSource[i] == collectionObjectsSource[j]) //Контроль существования заданного объекта в коллекции выбранных графических объектов 
                        {
                            collectionDeleteSource.Add(collectionSelectSource[i]); //Копирование удаляемых объектов в коллекцию CollectionDelete_Source
                            collectionObjectsSource.RemoveAt(j); //Удаление точки из коллекции графических объектов
                        }
                    }
                    //---------- Тип объекта - ПРОЕКЦИИ как часть Point3D ---
                    else if ((collectionSelectSource[i] is PointOfPlan1X0Y) && (collectionObjectsSource[j] is Point3D))
                    {
                        Point3D temp = (Point3D)collectionObjectsSource[j];
                        if (PropertyPoint3D.PointsPositionControl_Var.PointsIsPoints((PointOfPlan1X0Y)collectionSelectSource[i], temp.PointOfPlan1X0Y))
                        {
                            collectionDeleteSource.Add(collectionSelectSource[i]);
                            temp.Point3DDraw.FlagDraw_PointPlan1X0Y = false;
                            if (temp.Point3DDraw.FlagDraw_PointPlan2X0Z && temp.Point3DDraw.FlagDraw_PointPlan3Y0Z == false)
                            {
                                collectionObjectsSource.Add(temp.PointOfPlan2X0Z);
                                collectionObjectsSource.RemoveAt(j);
                            }
                            else if (temp.Point3DDraw.FlagDraw_PointPlan2X0Z == false && temp.Point3DDraw.FlagDraw_PointPlan3Y0Z == true)
                            {
                                collectionObjectsSource.Add(temp.PointOfPlan3Y0Z);
                                collectionObjectsSource.RemoveAt(j);
                            }
                            else if (temp.Point3DDraw.FlagDraw_PointPlan2X0Z == false && temp.Point3DDraw.FlagDraw_PointPlan3Y0Z == false)
                            {
                                collectionObjectsSource.RemoveAt(j);
                            }
                        }
                    }

                    else if ((collectionSelectSource[i] is PointOfPlan2X0Z) && (collectionObjectsSource[j] is Point3D))
                    {
                        Point3D temp = (Point3D)collectionObjectsSource[j];
                        if (PropertyPoint3D.PointsPositionControl_Var.PointsIsPoints((PointOfPlan2X0Z)collectionSelectSource[i], temp.PointOfPlan2X0Z))
                        {
                            collectionDeleteSource.Add(collectionSelectSource[i]);
                            temp.Point3DDraw.FlagDraw_PointPlan2X0Z = false;
                            if (temp.Point3DDraw.FlagDraw_PointPlan1X0Y && temp.Point3DDraw.FlagDraw_PointPlan3Y0Z == false)
                            {
                                collectionObjectsSource.Add(temp.PointOfPlan1X0Y);
                                collectionObjectsSource.RemoveAt(j);
                            }
                            else if (temp.Point3DDraw.FlagDraw_PointPlan1X0Y == false && temp.Point3DDraw.FlagDraw_PointPlan3Y0Z == true)
                            {
                                collectionObjectsSource.Add(temp.PointOfPlan3Y0Z);
                                collectionObjectsSource.RemoveAt(j);
                            }
                            else if (temp.Point3DDraw.FlagDraw_PointPlan1X0Y == false && temp.Point3DDraw.FlagDraw_PointPlan3Y0Z == false)
                            {
                                collectionObjectsSource.RemoveAt(j);
                            }
                        }
                    }

                    else if ((collectionSelectSource[i] is PointOfPlan3Y0Z) && (collectionObjectsSource[j] is Point3D))
                    {
                        Point3D temp = (Point3D)collectionObjectsSource[j];
                        if (PropertyPoint3D.PointsPositionControl_Var.PointsIsPoints((PointOfPlan3Y0Z)collectionSelectSource[i], temp.PointOfPlan3Y0Z))
                        {
                            collectionDeleteSource.Add(collectionSelectSource[i]);
                            temp.Point3DDraw.FlagDraw_PointPlan3Y0Z = false;
                            if (temp.Point3DDraw.FlagDraw_PointPlan1X0Y && temp.Point3DDraw.FlagDraw_PointPlan2X0Z == false)
                            {
                                collectionObjectsSource.Add(temp.PointOfPlan1X0Y);
                                collectionObjectsSource.RemoveAt(j);
                            }
                            else if (temp.Point3DDraw.FlagDraw_PointPlan1X0Y == false && temp.Point3DDraw.FlagDraw_PointPlan2X0Z == true)
                            {
                                collectionObjectsSource.Add(temp.PointOfPlan2X0Z);
                                collectionObjectsSource.RemoveAt(j);
                            }
                            else if (temp.Point3DDraw.FlagDraw_PointPlan1X0Y == false && temp.Point3DDraw.FlagDraw_PointPlan2X0Z == false)
                            {
                                collectionObjectsSource.RemoveAt(j);
                            }
                        }
                    }
                    //---------- Тип объекта - ПРОЕКЦИИ как самостоятельные объекты ---
                    else if (collectionSelectSource[i] is PointOfPlan1X0Y && collectionObjectsSource[j] is PointOfPlan1X0Y)
                    {
                        if (PropertyPoint3D.PointsPositionControl_Var.PointsIsPoints((PointOfPlan1X0Y)collectionSelectSource[i], (PointOfPlan1X0Y)collectionObjectsSource[j]))
                        {
                            collectionDeleteSource.Add(collectionSelectSource[i]);
                            collectionObjectsSource.RemoveAt(j);
                        }
                    }
                    else if (collectionSelectSource[i] is PointOfPlan2X0Z && collectionObjectsSource[j] is PointOfPlan2X0Z)
                    {
                        if (PropertyPoint3D.PointsPositionControl_Var.PointsIsPoints((PointOfPlan2X0Z)collectionSelectSource[i], (PointOfPlan2X0Z)collectionObjectsSource[j]))
                        {
                            collectionDeleteSource.Add(collectionSelectSource[i]);
                            collectionObjectsSource.RemoveAt(j);
                        }
                    }
                    else if (collectionSelectSource[i] is PointOfPlan3Y0Z && collectionObjectsSource[j] is PointOfPlan3Y0Z)
                    {
                        if (PropertyPoint3D.PointsPositionControl_Var.PointsIsPoints((PointOfPlan3Y0Z)collectionSelectSource[i], (PointOfPlan3Y0Z)collectionObjectsSource[j]))
                        {
                            collectionDeleteSource.Add(collectionSelectSource[i]);
                            collectionObjectsSource.RemoveAt(j);
                        }
                    }
                    else if ((collectionSelectSource[i].GetType().Name == "Line2D") && (collectionObjectsSource[j].GetType().Name == "Line2D"))
                    {
                        if (LinePositionControl.LinesIsLines((Line2D)collectionSelectSource[i], (Line2D)collectionObjectsSource[j]) == true)
                        {
                            collectionDeleteSource.Add(collectionSelectSource[i]);
                            collectionObjectsSource.RemoveAt(j);
                        }
                    }
                    else if ((collectionSelectSource[i].GetType().Name == "LineOfPlan1X0Y") && (collectionObjectsSource[j].GetType().Name == "LineOfPlan1X0Y"))
                    {
                        if (LinePositionControl.LinesIsLines((LineOfPlan1X0Y)collectionSelectSource[i], (LineOfPlan1X0Y)collectionObjectsSource[j]) == true)
                        {
                            collectionDeleteSource.Add(collectionSelectSource[i]);
                            collectionObjectsSource.RemoveAt(j);
                        }
                    }
                    else if ((collectionSelectSource[i].GetType().Name == "LineOfPlan2X0Z") && (collectionObjectsSource[j].GetType().Name == "LineOfPlan2X0Z"))
                    {
                        if (LinePositionControl.LinesIsLines((LineOfPlan2X0Z)collectionSelectSource[i], (LineOfPlan2X0Z)collectionObjectsSource[j]) == true)
                        {
                            collectionDeleteSource.Add(collectionSelectSource[i]);
                            collectionObjectsSource.RemoveAt(j);
                        }
                    }
                    else if ((collectionSelectSource[i].GetType().Name == "LineOfPlan3Y0Z") && (collectionObjectsSource[j].GetType().Name == "LineOfPlan3Y0Z"))
                    {
                        if (LinePositionControl.LinesIsLines((LineOfPlan3Y0Z)collectionSelectSource[i], (LineOfPlan3Y0Z)collectionObjectsSource[j]) == true)
                        {
                            collectionDeleteSource.Add(collectionSelectSource[i]);
                            collectionObjectsSource.RemoveAt(j);
                        }
                    }
                }
            }
            collectionSelectSource.Clear();
            collectionDeleteSource.Clear();
        }

    }
}
