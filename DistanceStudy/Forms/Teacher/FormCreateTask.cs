using Service.HandlerUI;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DistanceStudy.Forms.Teacher
{
    public partial class FormCreateTask : Form
    {
        private WorkTree _wt;
        private Bitmap _itemBmp;
        private FormCreateAlgorithm _formCreateAlgorithm;
        public FormCreateTask(WorkTree wt)
        {
            _wt = wt;
            InitializeComponent();
            SetProperties(textBoxName, Color.Gray, "Введите наименование задачи...");
            SetProperties(textBoxDescription, Color.Gray, "Введите текстовое описание задачи...");
            SetProperties(textBoxFilePath, Color.Gray, "Путь к графическому описанию задачи...");
            InitialFormParams();
        }

        private void buttonAddAlgorithm_Click(object sender, EventArgs e)
        {
            _formCreateAlgorithm = new FormCreateAlgorithm();
            _formCreateAlgorithm.Show();
        }

        private void toolStripAddGraphicCondition_Click(object sender, EventArgs e)
        {
            //DrawG.MainForm mainForm = new MainForm();
            //mainForm.Show();
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
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
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "All files (*.bmp)|*.bmp;";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                dialog.Dispose();
                textBoxFilePath.Text = dialog.FileName;
                _itemBmp = new Bitmap(dialog.FileName);
                pictureBoxImageTask.Image = _itemBmp;
            }
            if (_itemBmp != null)
            {
                labelHereGraphic.Text = "";
            }
        }

        private void FormCreateTask_Resize(object sender, EventArgs e)
        {
            dataGridViewDefault.Columns[2].Width = dataGridViewDefault.Width - dataGridViewDefault.Columns[0].Width;
        }

        private void dataGridViewDefault_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            dataGridViewDefault.Columns[2].Width = dataGridViewDefault.Width - dataGridViewDefault.Columns[1].Width;
        }

        private void toolStripButtonAddParams_Click(object sender, EventArgs e)
        {
            if (labelParametrsHasNot.Visible)
            {
                labelParametrsHasNot.Visible = false;
                dataGridViewDefault.Visible = true;
                toolStripButtonAddParams.Text = "Удалить параметры";
            }
            else
            {
                labelParametrsHasNot.Visible = true;
                dataGridViewDefault.Visible = false;
                toolStripButtonAddParams.Text = "Добавить параметры";
            }
        }

        private void radioButtonMain_CheckedChanged(object sender, EventArgs e)
        {
            buttonAddAlgorithm.Enabled = true;
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            if (textBoxName.Text == string.Empty || textBoxName.Text == "Введите наименование задачи...")
            {
                buttonAddAlgorithm.Enabled = false;
                buttonAccept.Enabled = false;
            }
            else
            {
                buttonAddAlgorithm.Enabled = true;
                buttonAccept.Enabled = true;
            }
        }

        #endregion

        private void InitialFormParams()
        {
            this.MinimumSize = new Size(600, 500);
            // Изначально датагрид невидим, видно только сообщение о том, что параметры не заданы
            dataGridViewDefault.Visible = false;
            // Кнопка создать неактивна по умолчанию
            buttonAddAlgorithm.Enabled = false;
        }
    }
}
