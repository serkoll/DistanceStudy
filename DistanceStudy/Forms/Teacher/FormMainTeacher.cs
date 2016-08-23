using System;
using System.Windows.Forms;
using DistanceStudy.Classes;
using Service.HandlerUI;

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
            FormController.CreateFormByType(_wt.GetTypeForCreatingFormForCreate(), _wt).ShowDialog();
        }

        private void FormMainTeacher_FormClosed(object sender, FormClosedEventArgs e)
        {
            GC.Collect();
            Application.Exit();
        }

        private void edittoolStripButton_Click(object sender, EventArgs e)
        {
            var obj = _wt.GetObjectBySelectedNode();
            FormController.CreateFormByType(_wt.GetTypeForCreatingFormForEdit(), _wt, obj).ShowDialog();
        }

        private void treeView_thema_KeyPress(object sender, KeyPressEventArgs e)
        {
            const int escapeKeyCode = 27;
            if (e.KeyChar == escapeKeyCode)
            {
                SetButtonAndNodeProperties(null);
            }
        }

        private void treeView_thema_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            MouseEventArgs me = e;
            if (me.Button.Equals(MouseButtons.Left))
            {
                SetButtonAndNodeProperties(e.Node, true, true, true);
            }
            if (me.Button.Equals(MouseButtons.Left) && treeView_thema.SelectedNode.Parent?.Parent != null)
            {
                SetButtonAndNodeProperties(e.Node, true, true, true, false);
            }
        }

        private void SetButtonAndNodeProperties(TreeNode treeNode, bool edit = false, bool delete = false, bool copy = false, bool create = true)
        {
            _wt.SelectedNode = treeNode;
            treeView_thema.SelectedNode = treeNode;
            edittoolStripButton.Enabled = edit;
            deletetoolStripButton.Enabled = delete;
            copyToolStripButton.Enabled = copy;
            CreateButton.Enabled = create;
        }

        private void deletetoolStripButton_Click(object sender, EventArgs e)
        {
            var objId = 0;
            var method = _wt.GetMethodForDeleteNeededObject(out objId);
            method(objId);
            _wt.UpdateTree();
        }

        private void copyToolStripButton_Click(object sender, EventArgs e)
        {
            if(copyToolStripButton.Text == "Вставить")
            {
                copyToolStripButton.Text = "Копировать";
                //TODO: implement feature for adding copy with thema - all subthemas and tasks and etc.
            }
            else
            {
                copyToolStripButton.Text = "Вставить";
                //_wt.SetNodeToCopy(treeView_thema.SelectedNode);
            }
        }
    }
}
