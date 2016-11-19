using System;
using System.Windows.Forms;
using GraphicsModule.Form;
using Service.HandlerUI;
using Service.Services.Solver;
using Formatter;

namespace DistanceStudy.Forms.Student
{
    public partial class FormMainStudent : Form
    {
        // Объект класса работы с деревом
        private WorkTree _wt;
        // Сервис для работы с задачей
        private TaskSolver _solver;
        // Форма для решения
        private FormGraphicsControl _graphForm;
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
            _graphForm = new FormGraphicsControl();
            _graphForm.MdiParent = this;
            _graphForm.Load += (s, ev) =>
            {
                var obj = _wt.GetObjectBySelectedNode();
                var coll = JsonFormatter.GetObjectsForTaskFromJson(obj.TaskId);
                _graphForm.Import(coll);
            };
            _graphForm.Show();
            _graphForm.StartPosition = FormStartPosition.CenterScreen;
            _graphForm.WindowState = FormWindowState.Maximized;
            groupBoxTheory.Visible = false;
            toolStripButtonCheckTask.Visible = true;
            toolStripButtonSolve.Enabled = false;
            treeView_thema.Enabled = false;
        }

        private void toolStripButtonCheckTask_Click(object sender, EventArgs e)
        {
            MessageBox.Show(_solver.StartCheckTask(_wt.GetObjectBySelectedNode(), _graphForm.Export()));
            _graphForm.Dispose();
            groupBoxTheory.Visible = true;
            toolStripButtonCheckTask.Visible = false;
            toolStripButtonSolve.Enabled = true;
            treeView_thema.Enabled = true;
        }
    }
}
