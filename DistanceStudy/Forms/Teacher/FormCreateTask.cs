using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BaseLibrary.StaticContext;
using DbRepository.Classes;
using DrawG;
using GeomObjects.Points;

namespace DistanceStudy.Forms.Teacher
{
    public partial class FormCreateTask : Form
    {
        private Bitmap _itemBmp;
        private FormCreateAlgorithm _formCreateAlgorithm;
        public FormCreateTask()
        {
            InitializeComponent();
            textBoxName.ForeColor = Color.Gray;
            textBoxName.Text = "Введите наименование задачи...";

            textBoxDescription.ForeColor = Color.Gray;
            textBoxDescription.Text = "Введите текстовое описание задачи...";

            textBoxFilePath.ForeColor = Color.Gray;
            textBoxFilePath.Text = "Путь к графическому описанию задачи...";
            this.MinimumSize = new Size(600, 500);
            // Изначально датагрид невидим, видно только сообщение о том, что параметры не заданы
            dataGridViewDefault.Visible = false;
            // Кнопка создать неактивна по умолчанию
            buttonAcceptTask.Enabled = false;
        }
        // Событие, срабатывающее при переходе управления к другому контролу
        private void textBoxName_Leave(object sender, EventArgs e)
        {
            if (textBoxName.Text == string.Empty)
            {
                textBoxName.ForeColor = Color.Gray;
                textBoxName.Text = "Введите наименование задачи...";
            }
        }
        // Событие активации текстового поля
        private void textBoxName_Enter(object sender, EventArgs e)
        {
            if (textBoxName.Text == "Введите наименование задачи...")
            {
                textBoxName.Text = string.Empty;
                textBoxName.ForeColor = Color.Black;
            }
        }
        // Событие активации текстового поля
        private void textBoxDescription_Enter(object sender, EventArgs e)
        {
            if (textBoxDescription.Text == "Введите текстовое описание задачи...")
            {
                textBoxDescription.Text = string.Empty;
                textBoxDescription.ForeColor = Color.Black;
            }
        }
        // Событие, срабатывающее при переходе управления к другому контролу
        private void textBoxDescription_Leave(object sender, EventArgs e)
        {
            if (textBoxDescription.Text == string.Empty)
            {
                textBoxDescription.ForeColor = Color.Gray;
                textBoxDescription.Text = "Введите текстовое описание задачи...";
            }
        }

        private void buttonOpenFile_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.OpenFileDialog dialog = new System.Windows.Forms.OpenFileDialog();
            dialog.Filter = "All files (*.bmp)|*.bmp;";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
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
        // Событие активации текстового поля
        private void textBoxFilePath_Enter(object sender, EventArgs e)
        {
            if (textBoxFilePath.Text == "Путь к графическому описанию задачи...")
            {
                textBoxFilePath.Text = string.Empty;
                textBoxFilePath.ForeColor = Color.Black;
            }
        }
        // Событие, срабатывающее при переходе управления к другому контролу
        private void textBoxFilePath_Leave(object sender, EventArgs e)
        {
            if (textBoxFilePath.Text == string.Empty)
            {
                textBoxFilePath.ForeColor = Color.Gray;
                textBoxFilePath.Text = "Путь к графическому описанию задачи...";
            }
        }
        private void buttonAcceptTask_Click(object sender, EventArgs e)
        {
            _formCreateAlgorithm = new FormCreateAlgorithm();
            _formCreateAlgorithm.Show();
        }
        /// <summary>
        /// При масштабировании основного окна - колонки также перерисовываются под новый размер
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCreateTask_Resize(object sender, EventArgs e)
        {
            dataGridViewDefault.Columns[2].Width = dataGridViewDefault.Width - dataGridViewDefault.Columns[0].Width;
        }
        /// <summary>
        /// Событие при изменении ширины колонки - масштабирование на весь элемент управления
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewDefault_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            dataGridViewDefault.Columns[2].Width = dataGridViewDefault.Width - dataGridViewDefault.Columns[1].Width;
        }
        /// <summary>
        /// Событие добавления параметров в задачу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Изменение состояния чекбоксов для статуса задачи
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButtonMain_CheckedChanged(object sender, EventArgs e)
        {
            buttonAcceptTask.Enabled = true;
        }

        /// <summary>
        /// Изменение текста в текстбоксе для названия задачи
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            if (textBoxName.Text == string.Empty || textBoxName.Text == "Введите наименование задачи...")
            {
                buttonAcceptTask.Enabled = false;
            }
            else
            {
                buttonAcceptTask.Enabled = true;
            }
        }

        private void toolStripAddGraphicCondition_Click(object sender, EventArgs e)
        {
            DrawG.MainForm mainForm = new MainForm();
            mainForm.Show();
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            DbRepositoryFake.NameTask = textBoxName.Text;
            DbRepositoryFake.Description = textBoxDescription.Text;
            int i = 0;
            foreach (var item in CollectionGraphicsObjects.GraphicsObjectsCollection)
            {
                var point3D = (Point3D) item;
                DbRepositoryFake.InputParam[i] = point3D;
                break;
            }
            var xml = new XMLFormatter.XmlFormatter();
            var result = xml.WriteObject2Xml(CollectionGraphicsObjects.GraphicsObjectsCollection.ToList());
            DbRepositoryFake.OuterXml = result;
            DbHelper.AddTaskAlgorithmXml(result);
            Dispose();
        }
    }
}
