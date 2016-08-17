using Point3DCntrl;
using Service.HandlerUI;
using System;
using System.Reflection;
using System.Windows.Forms;

namespace DistanceStudy.Forms.Teacher
{
    public partial class FormCreateAlgorithm : Form
    {
        // Объект для работы с задачей
        private WorkTask _taskWorker;
        public FormCreateAlgorithm(WorkTask taskWorker)
        {
            _taskWorker = taskWorker;
            InitializeComponent();
            FillListBoxByCntrlAssembly();
        }

        private void FillListBoxByCntrlAssembly()
        {
            PointsProectionsControl pointsPrtcCntrl = new PointsProectionsControl();
            Type t = pointsPrtcCntrl.GetType();
            MethodInfo[] mi = t.GetMethods();
            foreach (MethodInfo m in mi)
            {
                checkedListBoxProectionsControls.Items.Add(m.Name);
            }
        }


        private void button_Clear_Click(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
        }
    }
}
