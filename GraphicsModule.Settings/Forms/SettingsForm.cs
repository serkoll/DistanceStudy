using System;
using System.Windows.Forms;

namespace GraphicsModule.Settings.Forms
{
    public partial class SettingsForm : Form
    {
        public SettingsXml Settings=new SettingsXml();

        public SettingsForm()
        {
            InitializeComponent();

            Settings.InitializeSettingsLine(settingLine1);
            Settings.InitializeSettingsAxisControl(settingAxis1);
            Settings.InitializeSettingsGridControl(settingGrid1);
            Settings.InitializeSettings3DPoint(setting3DPoint1);
            Settings.InitializeSettingsLink(settingLink1,settingAxis1);
            Settings.InitializeSettingsPoint(settingPoint1);
            Settings.InitializeSettingsSegment(settingSegment1);
            Settings.InitializeSettingsBackground(settingBackground1);

            settingLine1.Hide();
            settingBackground1.Hide();
            settingSegment1.Hide();
            settingPoint1.Hide();
            settingGrid1.Hide();
            settingAxis1.Hide();
            setting3DPoint1.Hide();
            settingCursor1.Hide();
            settingLink1.Hide();
            textBox1.Clear();
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            switch (e.Node.Text)
            {
                case "Прямая":
                    settingLine1.Show();
                    settingGrid1.Hide();
                    settingAxis1.Hide();
                    settingSegment1.Hide();
                    settingBackground1.Hide();
                    settingLink1.Hide();
                    setting3DPoint1.Hide();
                    settingPoint1.Hide();
                    settingCursor1.Hide();
                    settingLine1.Dock = DockStyle.Fill;
                    textBox1.Text = @"Настройка прямой";
                    break;
                case "Фон":
                    settingLine1.Hide();
                    settingGrid1.Hide();
                    settingAxis1.Hide();
                    settingSegment1.Hide();
                    settingBackground1.Show();
                    settingLink1.Hide();
                    setting3DPoint1.Hide();
                    settingPoint1.Hide();
                    settingCursor1.Hide();
                    settingBackground1.Dock = DockStyle.Fill;
                    textBox1.Text = @"Настройка фона";
                    break;
                case "Курсор":
                    settingGrid1.Hide();
                    settingLine1.Hide();
                    settingAxis1.Hide();
                    settingSegment1.Hide();
                    settingBackground1.Hide();
                    settingLink1.Hide();
                    setting3DPoint1.Hide();
                    settingPoint1.Hide();
                    settingCursor1.Show();
                    settingCursor1.Dock=DockStyle.Fill;
                    textBox1.Text = @"Стиль курсоров";
                    break;
                case "Сетка":
                    settingGrid1.Show();
                    settingGrid1.Dock = DockStyle.Fill;
                    settingAxis1.Hide();
                    settingLine1.Hide();
                    settingBackground1.Hide();
                    settingLink1.Hide();
                    settingPoint1.Hide();
                    settingSegment1.Hide();
                    setting3DPoint1.Hide();
                    settingCursor1.Hide();
                    textBox1.Text = @"Настройка сетки";
                    break;
                case "Оси":
                    settingAxis1.Show();
                    settingAxis1.Dock = DockStyle.Fill;
                    settingGrid1.Hide();
                    settingBackground1.Hide();
                    setting3DPoint1.Hide();
                    settingLine1.Hide();
                    settingSegment1.Hide();
                    settingLink1.Hide();
                    settingPoint1.Hide();
                    textBox1.Text = @"Настройка осей";
                    settingCursor1.Hide();
                    break;
                case "Точка":
                    settingAxis1.Hide();
                    settingGrid1.Hide();
                    settingLink1.Hide();
                    settingBackground1.Hide();
                    setting3DPoint1.Hide();
                    settingSegment1.Hide();
                    settingLine1.Hide();
                    settingCursor1.Hide();
                    settingPoint1.Show();
                    settingPoint1.Dock=DockStyle.Fill;
                    textBox1.Text = @"Настройки точки";
                    break;
                case "3D-Точка":
                    settingAxis1.Hide();
                    settingGrid1.Hide();
                    settingSegment1.Hide();
                    settingBackground1.Hide();
                    settingLink1.Hide();
                    settingPoint1.Hide();
                    setting3DPoint1.Show();
                    setting3DPoint1.Dock = DockStyle.Fill;
                    textBox1.Text = @"Настройки 3D-точки";
                    break;
                case "Линии связи":
                    settingAxis1.Hide();
                    settingGrid1.Hide();
                    setting3DPoint1.Hide();
                    settingLine1.Hide();
                    settingCursor1.Hide();
                    settingBackground1.Hide();
                    settingLink1.Show();
                    settingSegment1.Hide();
                    settingPoint1.Hide();
                    settingLink1.Dock=DockStyle.Fill;
                    textBox1.Text = @"Настройки линий связи";
                    break;
                case "Отрезок":
                    settingAxis1.Hide();
                    settingGrid1.Hide();
                    setting3DPoint1.Hide();
                    settingCursor1.Hide();
                    settingLine1.Hide();
                    settingBackground1.Hide();
                    settingLink1.Hide();
                    settingPoint1.Hide();
                    settingSegment1.Show();
                    settingSegment1.Dock = DockStyle.Fill;
                    textBox1.Text = @"Настройки отрезка";
                    break;
                default:
                    setting3DPoint1.Hide();
                    settingAxis1.Hide();
                    settingCursor1.Hide();
                    settingBackground1.Hide();
                    settingGrid1.Hide();
                    settingLink1.Hide();
                    settingLine1.Hide();
                    settingSegment1.Hide();
                    settingPoint1.Hide();
                    textBox1.Clear();
                    break;
            }
        }

        private void Button_Ok_Click(object sender, EventArgs e)
        {
            Settings.SaveSettingsBackground(settingBackground1);
            Settings.SaveSettingsGrid(settingGrid1);
            Settings.SaveSettingsAxis(settingAxis1);
            Settings.SaveSettings3DPoint(setting3DPoint1);
            Settings.SaveSettingsCursor(settingCursor1);
            Settings.SaveSettingsLink(settingLink1);
            Settings.SaveSettingsPoint(settingPoint1);
            Settings.SaveSettingsSegment(settingSegment1);
            Settings.SettingsXDocument.Save(Settings.XmlPath);
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
