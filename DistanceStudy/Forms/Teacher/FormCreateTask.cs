using DistanceStudy.Classes;
using GraphicsModule.Form;
using Service.HandlerUI;
using System;
using System.Drawing;
using System.Windows.Forms;
using DbRepository.Context;

namespace DistanceStudy.Forms.Teacher
{
    public partial class FormCreateTask : Form
    {
        // Объект для работы с задачами и деревом объектов
        private WorkTree _wt;
        // Объект для работы с задачами после создания
        private WorkTask _taskWorker;
        public FormCreateTask(WorkTree wt)
        {
            _wt = wt;
            InitializeComponent();
            SetProperties(textBoxName, Color.Gray, "Введите наименование задачи...");
            SetProperties(textBoxDescription, Color.Gray, "Введите текстовое описание задачи...");
            SetProperties(textBoxFilePath, Color.Gray, "Путь к графическому описанию задачи...");
            InitialFormParams();
        }

        public FormCreateTask(WorkTree wt, Task task)
        {
            _wt = wt;
            _taskWorker = new WorkTask(task);
            InitializeComponent();
            SetProperties(textBoxName, Color.Black, task.Name);
            SetProperties(textBoxDescription, Color.Black, task.Description);
            SetProperties(textBoxFilePath, Color.Gray, "Путь к графическому описанию задачи...");
            InitialFormParams();
        }

        private void buttonAddAlgorithm_Click(object sender, EventArgs e)
        {
            FormController.CreateFormByType(typeof(FormCreateAlgorithm), _taskWorker).ShowDialog();
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            InitTask();
        }

        private void InitTask()
        {
            if (_taskWorker == null)
            {
                _wt.DoOperationWithTaskByCall(ref _taskWorker, _wt.CreateTask, textBoxName.Text, textBoxDescription.Text,
                    (Bitmap) pictureBoxImageTask.Image);
            }
            else
            {
                _wt.DoOperationWithTaskByCall(ref _taskWorker, _taskWorker.UpdateCurrentTask, textBoxName.Text,
                    textBoxDescription.Text, (Bitmap) pictureBoxImageTask.Image);
            }
            ActivateButtonAddAlgAndGraphicParam();
        }

        #region Появление и исчезновение подсказок при переходе на текстовые поля

        private void textBoxName_Leave(object sender, EventArgs e)
        {
            SetProperties(textBoxName, Color.Gray, "Введите наименование задачи...", string.Empty);
        }

        private void textBoxName_Enter(object sender, EventArgs e)
        {
            SetProperties(textBoxName, Color.Black, string.Empty, "Введите наименование задачи...");
        }

        private void textBoxDescription_Enter(object sender, EventArgs e)
        {
            SetProperties(textBoxDescription, Color.Black, string.Empty, "Введите текстовое описание задачи...");
        }

        private void textBoxDescription_Leave(object sender, EventArgs e)
        {
            SetProperties(textBoxDescription, Color.Gray, "Введите текстовое описание задачи...", string.Empty);
        }

        private void textBoxFilePath_Enter(object sender, EventArgs e)
        {
            SetProperties(textBoxFilePath, Color.Black, string.Empty, "Путь к графическому описанию задачи...");
        }

        private void textBoxFilePath_Leave(object sender, EventArgs e)
        {
            SetProperties(textBoxFilePath, Color.Gray, "Путь к графическому описанию задачи...", string.Empty);
        }

        private void SetProperties(TextBox txtBox, Color color, string text, string compareTxt = "")
        {
            if (txtBox.Text == compareTxt)
            {
                txtBox.Text = text;
                txtBox.ForeColor = color;
            }
        }

        #endregion

        #region События изменения размера формы, ввода текста и другие назнчительные UI events

        private void buttonOpenFile_Click(object sender, EventArgs e)
        {
            //OpenFileDialog dialog = new OpenFileDialog();
            //dialog.Filter = "All files (*.bmp)|*.bmp;";
            //if (dialog.ShowDialog() == DialogResult.OK)
            //{
            //    dialog.Dispose();
            //    textBoxFilePath.Text = dialog.FileName;
            //    _itemBmp = new Bitmap(dialog.FileName);
            //    pictureBoxImageTask.Image = _itemBmp;
            //}
            //if (_itemBmp != null)
            //{
            //    labelHereGraphic.Text = "";
            //}
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            if (textBoxName.Text == string.Empty || textBoxName.Text == "Введите наименование задачи...")
            {
                buttonSave.Enabled = false;
                toolStripAddGraphicCondition.Enabled = false;
            }
            else
            {
                buttonSave.Enabled = true;
                toolStripAddGraphicCondition.Enabled = true;
            }
        }

        #endregion

        private void InitialFormParams()
        {
            this.MinimumSize = new Size(600, 500);
            // Кнопка создать неактивна по умолчанию
            buttonAddAlgorithm.Enabled = false;
        }

        private void ActivateButtonAddAlgAndGraphicParam()
        {
            buttonAddAlgorithm.Enabled = true;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void FormCreateTask_FormClosing(object sender, FormClosingEventArgs e)
        {
            _wt.UpdateTree();
        }

        private void toolStripAddGraphicCondition_Click(object sender, EventArgs e)
        {
            InitTask();
            var formGraphics = (FormGraphicsControl)FormController.CreateFormByType(typeof(FormGraphicsControl));
            var coll = _taskWorker.GetGraphicsObjectsFromJsonTaskRelated();
            formGraphics.Load += (s, ev) =>
            {
                formGraphics.Import(coll);
            };
            formGraphics.FormClosing += (s, ev) =>
            {
                var collGraphObj = formGraphics.Export();
                _taskWorker?.AddGraphicsObjectsToJsonTaskRelated(collGraphObj);
            };
            formGraphics.ShowDialog();
        }
    }
}
