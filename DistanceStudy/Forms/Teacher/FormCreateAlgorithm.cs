using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DistanceStudy.Forms.Teacher
{
    public partial class FormCreateAlgorithm : Form
    {
        public FormCreateAlgorithm()
        {
            InitializeComponent();
            listBox1.Enabled = false;
            listBox2.Enabled = false;
            listBox3.Enabled = false;
        }

        private void checkBoxBase_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBoxBase.Checked)
            {
                listBox1.Enabled = false;
                listBox1.SelectedItem = null;
            }
            else
            {
                listBox1.Enabled = true;
            }
        }

        private void checkBoxMain_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBoxMain.Checked)
            {
                listBox2.Enabled = false;
                listBox2.SelectedItem = null;
            }
            else
            {
                listBox2.Enabled = true;
            }
        }

        private void checkBoxProizv_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBoxProizv.Checked)
            {
                listBox3.Enabled = false;
                listBox3.SelectedItem = null;
            }
            else
            {
                listBox3.Enabled = true;
            }
        }

        private void buttonAddToSelected_Click(object sender, EventArgs e)
        {
            if (checkBoxBase.Checked)
            {
                listBox4.Items.Add(listBox1.SelectedItem);
                listBox1.Items.Remove(listBox1.SelectedItem);
            }
            if (checkBoxMain.Checked)
            {
                listBox5.Items.Add(listBox2.SelectedItem);
                listBox2.Items.Remove(listBox2.SelectedItem);
            }
            if (checkBoxProizv.Checked)
            {
                listBox6.Items.Add(listBox3.SelectedItem);
                listBox3.Items.Remove(listBox3.SelectedItem);
            }
        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            listBox6.Items.Clear();
            listBox4.Items.Clear();
            listBox5.Items.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
