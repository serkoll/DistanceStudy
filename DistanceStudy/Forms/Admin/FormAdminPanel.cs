using System;
using System.Windows.Forms;
using DrawG;

namespace DistanceStudy.Forms.Admin
{
    public partial class FormAdminPanel : Form
    {
        public FormAdminPanel()
        {
            InitializeComponent();
        }

        private void FormAdminPanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }

        private void FormAdminPanel_Load(object sender, EventArgs e)
        {
            DrawG.MainForm mForm = new MainForm();
            mForm.Show();
        }
    }
}
