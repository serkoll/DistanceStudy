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
        }
        /// <summary>
        /// Событие при закрытии формы - Application.Exit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void AdministratorForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                //WorkWithTree.DisposeResources();
                Application.Exit();
            }
        }

        /// <summary>
        /// Клик не по узлу в область treeView
        /// Снятие выделения с узлов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView_thema_Click(object sender, EventArgs e)
        {
            treeView_thema.SelectedNode = null;
        }

        /// <summary>
        /// Добавление темы/подтемы/задачи в текущее дерево
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            _wt.CreateFormBySelectedNode(treeView_thema.SelectedNode, 
                new FormEnterNew(treeView_thema), 
                new FormCreateTask());
        }

        /// <summary>
        /// Кнопка выхода на форму аутентификации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonExit_Click(object sender, EventArgs e)
        {
            Visible = false;
            Hide();
            Program.MainForm.Visible = true;
            Program.MainForm.textLogin.Text = string.Empty;
            Program.MainForm.textPassword.Text = string.Empty;
        }

        /// <summary>
        /// Удаление узлов в дереве темы/подтемы/задачи
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deletetoolStripButton_Click(object sender, EventArgs e)
        {
            _wt.Delete(treeView_thema.SelectedNode.Text);
            _wt.UpdateTree();
        }

        /// <summary>
        /// Метод для редактирования существующей темы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void edittoolStripButton_Click(object sender, EventArgs e)
        {
            _wt.EditThemaSubthemaByForm(treeView_thema.SelectedNode, new FormEnterNew(treeView_thema, _wt.GetThemaOrSubThemaByNode(treeView_thema.SelectedNode)));
        }
    }
}
