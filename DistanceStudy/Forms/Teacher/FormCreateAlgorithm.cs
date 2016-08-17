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

        /// <summary>
        /// Заполнить листбокс названиями методов из сборки с методами контроля (Point3DCntrl)
        /// </summary>
        private void FillListBoxByCntrlAssembly()
        {
            PointsProectionsControl pointsPrtcCntrl = new PointsProectionsControl();
            Type t = pointsPrtcCntrl.GetType();
            MethodInfo[] mi = t.GetMethods();
            foreach (MethodInfo m in mi)
            {
                if (m.DeclaringType.Name.Equals("PointsProectionsControl"))
                    checkedListBoxProectionsControls.Items.Add(m.Name);
            }
        }
    }
}
