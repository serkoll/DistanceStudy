using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ControlTask;
//using DrawG;
//using GeomObjects.Points;

namespace DistanceStudy.Forms.Admin
{
    public partial class FormAdminPanel : Form
    {
        public FormAdminPanel()
        {
            InitializeComponent();
        }

        private void FormAdminPanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }

        private void FormAdminPanel_Load(object sender, EventArgs e)
        {
            //textBoxNameTask.Text = DbRepositoryFake.NameTask + Environment.NewLine + $"X:Y:Z" + Environment.NewLine;
            //var point3D = (Point3D)DbRepositoryFake.InputParam[0];
            //textBoxNameTask.Text += $"{point3D.X}:{point3D.Y}:{point3D.Z}";
            //textBoxDescription.Text = DbRepositoryFake.Description;
        }

        private void buttonCreateForm_Click(object sender, EventArgs e)
        {
            //CollectionGraphicsObjects.GraphicsObjectsCollection.Clear();
            //DrawG.MainForm mForm = new MainForm();
            //mForm.Show();
        }

        private void buttonCheck_Click(object sender, EventArgs e)
        {
            //List<object> listOut = new List<object>();
            //foreach (var item in CollectionGraphicsObjects.GraphicsObjectsCollection)
            //{
            //    var point3D = (Point3D)item;
            //    listOut.Add(point3D);
            //}
            //bool flag;
            //TaskChecker.ControlTask(DbRepositoryFake.AlghoritmCode, DbRepositoryFake.SubgroupNumber.ToString(), DbRepositoryFake.InputParam.ToList(), listOut, out flag);
            //if (!flag)
            //{
            //    foreach (var item in TaskChecker.ErrorMessages)
            //    {
            //        MessageBox.Show(item);
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Решено без ошибок!");
            //}
        }
    }
}
