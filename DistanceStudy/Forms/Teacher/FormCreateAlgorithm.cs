using Point3DCntrl;
using Service.HandlerUI;
using System;
using System.Reflection;
using System.Windows.Forms;
using System.Linq;

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
            _taskWorker?.FillListBoxByCntrlAssembly(checkedListBoxProectionsControls);
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            _taskWorker?.AddAlgothm(checkedListBoxProectionsControls);
            _taskWorker?.SetTaskStatusToReady();
            Dispose();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
