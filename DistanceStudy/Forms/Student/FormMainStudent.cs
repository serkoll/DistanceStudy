using Service.HandlerUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DistanceStudy.Forms.Student
{
    public partial class FormMainStudent : Form
    {
        // Объект класса работы с деревом
        private WorkTree _wt;
        public FormMainStudent()
        {
            InitializeComponent();
        }

        private void FormMainStudent_Load(object sender, EventArgs e)
        {
            _wt = new WorkTree(treeView_thema);
            _wt.FillTree();
            treeView_thema.ExpandAll();
        }

        private void treeView_thema_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            _wt.SelectedNode = treeView_thema.SelectedNode;
            var obj = _wt.GetObjectBySelectedNode();
            textBoxDesc.Text = obj.Description;
            textBoxName.Text = obj.Name;
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
    }
}
