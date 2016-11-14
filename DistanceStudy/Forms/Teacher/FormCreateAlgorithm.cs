using System;
using System.Windows.Forms;
using Service.HandlerUI;

namespace DistanceStudy.Forms.Teacher
{
    public partial class FormCreateAlgorithm : Form
    {
        // Объект для работы с задачей
        private readonly WorkTask _taskWorker;

        public FormCreateAlgorithm(WorkTask taskWorker)
        {
            _taskWorker = taskWorker;
            InitializeComponent();
            _taskWorker?.FillListBoxByCntrlAssembly(checkedListBoxProectionsControls);
            _taskWorker?.FillComboBoxByCntrlAssembly(comboBoxInputParam);
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

        private void button_Clear_Click(object sender, EventArgs e)
        {
            _taskWorker?.UncheckAllItems(checkedListBoxProectionsControls);
        }

        private void checkedListBoxProectionsControls_SelectedIndexChanged(object sender, EventArgs e)
        {
            _taskWorker?.ChangeInfoAboutSelectedItem(checkedListBoxProectionsControls.SelectedItem.ToString(), textBoxDesc, listBoxUserParams, listBoxInitialParams, listBoxSolveParmas);
        }

        private void checkedListBoxProectionsControls_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.CurrentValue.Equals(CheckState.Unchecked) && _taskWorker.CheckItemOnInitialParams(checkedListBoxProectionsControls.SelectedItem.ToString(), listBoxInitialParams))
                ChangeVisibleControlsComboLabelBtn(buttonAcceptRefMethod, labelEnterInputParam, comboBoxInputParam, checkedListBoxProectionsControls, true, true, true, false);
            else
                ChangeVisibleControlsComboLabelBtn(buttonAcceptRefMethod, labelEnterInputParam, comboBoxInputParam, checkedListBoxProectionsControls, false, false, false, true);
        }

        private void ChangeVisibleControlsComboLabelBtn(Button btn, Label label, ComboBox cmbBox, CheckedListBox checkedlistBox, bool btnVis, bool labelVis, bool cmbBoxVis, bool listBoxEnabled)
        {
            btn.Visible = btnVis;
            label.Visible = labelVis;
            cmbBox.Visible = cmbBoxVis;
            checkedlistBox.Enabled = listBoxEnabled;
        }

        private void buttonAcceptRefMethod_Click(object sender, EventArgs e)
        {
            _taskWorker.AddReferenceToinitialMethod(checkedListBoxProectionsControls.SelectedItem?.ToString(), comboBoxInputParam.SelectedItem?.ToString(), listBoxInitialParams.SelectedItem?.ToString());
            ChangeVisibleControlsComboLabelBtn(buttonAcceptRefMethod, labelEnterInputParam, comboBoxInputParam, checkedListBoxProectionsControls, false, false, false, true);
        }
    }
}
