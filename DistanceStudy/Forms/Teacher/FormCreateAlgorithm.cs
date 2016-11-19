using System;
using System.Linq;
using System.Windows.Forms;
using DistanceStudy.Classes;
using GraphicsModule.Form;
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
            if (e.CurrentValue.Equals(CheckState.Unchecked) &&
                _taskWorker.CheckItemOnInitialParams(checkedListBoxProectionsControls.SelectedItem.ToString(),
                    listBoxInitialParams))
            {
                ChangeVisibleControlsComboLabelBtn(buttonAcceptRefMethod, labelEnterInputParam, comboBoxInputParam,
                    checkedListBoxProectionsControls, radioButtonGraphic, radioButtonMethod, true, true, true, false,
                    true, true);
            }
            else
            {
                ChangeVisibleControlsComboLabelBtn(buttonAcceptRefMethod, labelEnterInputParam, comboBoxInputParam, checkedListBoxProectionsControls, radioButtonGraphic, radioButtonMethod, false, false, false, true, false, false);
            }       
        }

        private void ChangeVisibleControlsComboLabelBtn(Button btn, Label label, ComboBox cmbBox, CheckedListBox checkedlistBox, RadioButton rbtn1, RadioButton rbtn2, bool btnVis, bool labelVis, bool cmbBoxVis, bool listBoxEnabled, bool rbtn1Visible, bool rbtn2Visible)
        {
            btn.Visible = btnVis;
            label.Visible = labelVis;
            cmbBox.Visible = cmbBoxVis;
            checkedlistBox.Enabled = listBoxEnabled;
            rbtn1.Visible = rbtn1Visible;
            rbtn2.Visible = rbtn2Visible;
        }

        private void buttonAcceptRefMethod_Click(object sender, EventArgs e)
        {
            _taskWorker.AddReferenceToinitialMethod(checkedListBoxProectionsControls.SelectedItem?.ToString(), comboBoxInputParam.SelectedItem?.ToString(), listBoxInitialParams.SelectedItem?.ToString());
            ChangeVisibleControlsComboLabelBtn(buttonAcceptRefMethod, labelEnterInputParam, comboBoxInputParam, checkedListBoxProectionsControls, radioButtonGraphic, radioButtonMethod, false, false, false, true, false, false);
        }

        private void radioButtonGraphic_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonGraphic.Checked)
            {
                var formGraphics = (FormGraphicsControl)FormController.CreateFormByType(typeof(FormGraphicsControl));
                var coll = _taskWorker.GetGraphicsObjectsFromJsonTaskRelated();
                formGraphics.Load += (s, ev) =>
                {
                    formGraphics.Import(coll);
                };
                formGraphics.FormClosing += (s, ev) =>
                {
                    var graphObj = formGraphics.ExportSelected().FirstOrDefault();
                    var jsonGraphKey = _taskWorker.GetGraphicsKeysFromJsonTaskRelated().FirstOrDefault(c => c.GraphicObject.GetType().Name.Equals(graphObj?.GetType().Name));
                    _taskWorker.AddReferenceToinitialMethod(checkedListBoxProectionsControls.SelectedItem?.ToString(), jsonGraphKey?.Guid.ToString(), listBoxInitialParams.SelectedItem?.ToString());
                    ChangeVisibleControlsComboLabelBtn(buttonAcceptRefMethod, labelEnterInputParam, comboBoxInputParam, checkedListBoxProectionsControls, radioButtonGraphic, radioButtonMethod, false, false, false, true, false, false);
                };
                formGraphics.ShowDialog();
            }
        }
    }
}
