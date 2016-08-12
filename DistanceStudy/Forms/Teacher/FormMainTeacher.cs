using System;
using System.Windows.Forms;
using DistanceStudy.Classes;
using BaseLibrary.Classes;

namespace DistanceStudy.Forms.Teacher
{
    public partial class FormMainTeacher : Form
    {
        // Объект класса работы с деревом
        private readonly WorkTree _wt;

        public FormMainTeacher()
        {
            InitializeComponent();
            _wt = new WorkTree(treeView_thema);
            _wt.FillTree();
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            FormController<FormEnterNew>.CreateFormByType(_wt).Show();
        }

        private void FormMainTeacher_FormClosed(object sender, FormClosedEventArgs e)
        {
            GC.Collect();
            Application.Exit();
        }

        private void edittoolStripButton_Click(object sender, EventArgs e)
        {
            FormController<FormEnterNew>.CreateFormByType(_wt).Show();
        }

        private void treeView_thema_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            edittoolStripButton.Enabled = true;
        }
    }
}
