﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GeomObjects.Points;
using GeomObjects.Lines;
using GeomObjects.EquationsSysCalc;
using GeomObjects.Plans;
using System.Windows.Forms;

namespace DrawG
{
    /// <summary>
    /// Класс содержит инструменты для отрисовки внешних объектов
    /// </summary>
    class DrawExternalObjects
    {
        /// <summary>
        /// Класс содержит инструменты для отрисовки внешних объектов
        /// </summary>
        /// <param name="CollectionObjects_Source">Заданная коллекция объектов</param>
        public void CollectionObjects_ToObjectsGraphics(Collection<object> CollectionObjects_Source )
        {
            CollectionGraphicsObjects.GraphicsObjectsCollection = CollectionObjects_Source;
        }
        /// <summary>
        /// Добавление одной заданной 2D точки в коллекцию объектов для отрисовки
        /// </summary>
        /// <param name="Point_X">Координата X заданной точки</param>
        /// <param name="Point_Y">Координата Y заданной точки</param>
        /// <remarks>Начало координат от верхнего левого угла</remarks>
        public void Point2D_AddToCollection(int Point_X, int Point_Y)
        {
            Point Point_Var = new Point();
            Point_Var.X = Point_X;
            Point_Var.Y = Point_Y;
            CollectionGraphicsObjects.AddToCollection(Point_Var);
        }
        /// <summary>
        /// Добавление одной заданной точки отрисовки в коллекцию объектов для отрисовки
        /// </summary>
        /// <param name="Point_Source">Заданная точка</param>
        /// <remarks>Начало координат от верхнего левого угла</remarks>
        public void Point_AddToCollection(Point Point_Source)
        {
            CollectionGraphicsObjects.AddToCollection(Point_Source);
        }
        /// <summary>
        /// Добавление одной заданной 3D точки в коллекцию объектов для отрисовки
        /// </summary>
        /// <param name="Point3D_Source">Заданная 3D точка</param>
        /// <remarks>Начало координат от верхнего левого угла</remarks>
        public void Point3D_AddToCollection(Point3D Point3D_Source)
        {
            CollectionGraphicsObjects.AddToCollection(Point3D_Source);
        }
        /// <summary>
        /// Отрисовка коллекции объектов
        /// </summary>
        /// <param name="PictureBox_Source">Заданный PictureBox</param>
        /// <remarks>Метод создан для отрисовки графических объектов, имеющихся в предварительно заданной коллекции (коллекции внешних объектов)</remarks>
        public void Collection_Draw(PictureBox PictureBox_Source)
        {
            DrawObjectsToGraphics.ReFreshCollection(CollectionGraphicsObjects.GraphicsObjectsCollection, PropertyPoint.Color_Point, DrawObjectsToPictureBox.GraphicsActive);
            PictureBox_Source.Image = (Image)DrawObjectsToPictureBox.BitmapActive.Clone();
            PictureBox_Source.Refresh(); 
        }
    }
}
