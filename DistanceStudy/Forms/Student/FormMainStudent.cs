using DbRepository.Context;
using Service.HandlerUI;
using Service.Services;
using Service.Services.Solver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DistanceStudy.Forms.Student
{
    public partial class FormMainStudent : Form
    {
        // Объект класса работы с деревом
        private WorkTree _wt;
        // Сервис для работы с задачей
        private TaskSolver _solver;
        public FormMainStudent()
        {
            InitializeComponent();
        }

        private void FormMainStudent_Load(object sender, EventArgs e)
        {
            _wt = new WorkTree(treeView_thema);
            _solver = new TaskSolver();
            _wt.FillTree();
            treeView_thema.ExpandAll();
            this.IsMdiContainer = true;
        }

        private void FormMainStudent_FormClosed(object sender, FormClosedEventArgs e)
        {
            DeallocMemory();
        }

        /// <summary>
        /// Закрыть приложение и освободиться ресурсы
        /// </summary>
        private void DeallocMemory()
        {
            GC.Collect();
            Application.Exit();
        }

        private void treeView_thema_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            _wt.SelectedNode = e.Node;
            var obj = _wt.GetObjectBySelectedNode();
            textBoxDesc.Text = obj.Description;
            textBoxName.Text = obj.Name;
            toolStripButtonSolve.Enabled = e.Node.Parent?.Parent != null;
        }

        private void toolStripButtonSolve_Click(object sender, EventArgs e)
        {
            var form = new GraphicsModule.MainForm();
            form.MdiParent = this;
            form.Show();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.WindowState = FormWindowState.Maximized;
            groupBoxTheory.Visible = false;
            toolStripButtonCheckTask.Visible = true;
            toolStripButtonSolve.Enabled = false;
            treeView_thema.Enabled = false;
        }

        private void toolStripButtonCheckTask_Click(object sender, EventArgs e)
        {
            _solver.StartCheckTask(_wt.GetObjectBySelectedNode());
        }
    }
}
