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
            FormController<FormEnterNew>.CreateFormByType(_wt).Show();
        }

        private void FormMainTeacher_FormClosed(object sender, FormClosedEventArgs e)
        {
            GC.Collect();
            Application.Exit();
        }

        private void edittoolStripButton_Click(object sender, EventArgs e)
        {
            var obj = _wt.GetObjectBySelectedNode();
            FormController<FormEnterNew>.CreateFormByType(_wt, obj).Show();
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
        }

        private void SetButtonAndNodeProperties(TreeNode treeNode, bool edit = false, bool delete = false, bool copy = false)
        {
            treeView_thema.SelectedNode = treeNode;
            edittoolStripButton.Enabled = edit;
            deletetoolStripButton.Enabled = delete;
            copyToolStripButton.Enabled = copy;
        }

        private void deletetoolStripButton_Click(object sender, EventArgs e)
        {
            var objId = 0;
            var method = _wt.GetMethodForDeleteNeededObject(out objId);
            method(objId);
            _wt.UpdateTree();
        }
    }
}
