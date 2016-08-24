using DbRepository.Context;
using DistanceStudy.Classes;
using Service.HandlerUI;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

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

        public FormCreateTask(WorkTree wt, Task item)
        {
            _wt = wt;
            _edited = item;
            _taskWorker = new WorkTask(item);
            InitializeComponent();
            SetProperties(textBoxName, Color.Gray, item.Name);
            SetProperties(textBoxDescription, Color.Gray, item.Description);
            SetProperties(textBoxFilePath, Color.Gray, "Путь к графическому описанию задачи...");
            InitialFormParams();
        }

        private void buttonAddAlgorithm_Click(object sender, EventArgs e)
        {
            FormController.CreateFormByType(typeof(FormCreateAlgorithm), _taskWorker).ShowDialog();
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            //DrawG.MainForm mainForm = new MainForm();
            //mainForm.Show();
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            if(_taskWorker == null)
            {
                _wt.DoOperationWithTaskByCall(ref _taskWorker, _wt.CreateTask, textBoxName.Text, textBoxDescription.Text, (Bitmap)pictureBoxImageTask.Image);
            }
            else
            {
                _wt.DoOperationWithTaskByCall(ref _taskWorker, _taskWorker.UpdateCurrentTask, textBoxName.Text, textBoxDescription.Text, (Bitmap)pictureBoxImageTask.Image);
            }
            ActivateButtonAddAlg();
            #region old XML formatting
            //DbRepositoryFake.NameTask = textBoxName.Text;
            //DbRepositoryFake.Description = textBoxDescription.Text;
            //int i = 0;
            //foreach (var item in CollectionGraphicsObjects.GraphicsObjectsCollection)
            //{
            //    var point3D = (Point3D) item;
            //    DbRepositoryFake.InputParam[i] = point3D;
            //    break;
            //}
            //var xml = new XMLFormatter.XmlFormatter();
            //var result = xml.WriteObject2Xml(CollectionGraphicsObjects.GraphicsObjectsCollection.ToList());
            //DbRepositoryFake.OuterXml = result;
            //DbHelper.AddTaskAlgorithmXml(result);
            //Dispose();
            #endregion
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
            }
            else
            {
                buttonSave.Enabled = true;
            }
        }

        #endregion

        private void InitialFormParams()
        {
            this.MinimumSize = new Size(600, 500);
            // Кнопка создать неактивна по умолчанию
            buttonAddAlgorithm.Enabled = false;
        }

        private void ActivateButtonAddAlg()
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
    }
}
