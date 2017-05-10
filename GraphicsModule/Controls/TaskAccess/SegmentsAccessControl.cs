using System;
using System.Windows.Forms;
using GraphicsModule.Configuration.Access.Structures;
using GraphicsModule.Forms;

namespace GraphicsModule.Controls.TaskAccess
{
    public partial class SegmentsAccessControl : UserControl
    {
        public SegmentsAccess SegmentsAccess { get; set; }

        public SegmentsAccessControl()
        {
            InitializeComponent();
            SegmentsAccess = GraphicsControlSettingsForm.CurrentSettings.PrimitivesAcces.Segments;
            accessSegmentsCheckBox.Checked = SegmentsAccess.IsSegmentsEnabled;
            AccessSegment2DCheckBox.Checked = SegmentsAccess.IsSegment2DEnabled;
            AccessSegment3DCheckBox.Checked = SegmentsAccess.IsSegment3DEnabled;
            AccessSegmentOfPlane1X0YCheckBox.Checked = SegmentsAccess.IsSegmentOfPlane1X0YEnabled;
            AccessSegmentOfPlane2X0ZCheckBox.Checked = SegmentsAccess.IsSegmentOfPlane2X0ZEnabled;
            AccessSegmentOfPlane3Y0ZCheckBox.Checked = SegmentsAccess.IsSegmentOfPlane3Y0ZEnabled;
            AccessGenerateSegment3DCheckBox.Checked = SegmentsAccess.IsGenerateSegment3DEnabled;
        }
        private void AccessSegment2DCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SegmentsAccess.IsSegment2DEnabled = AccessSegment2DCheckBox.Checked;
        }
        private void AccessSegmentOfPlane3Y0ZCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SegmentsAccess.IsSegmentOfPlane3Y0ZEnabled = AccessSegmentOfPlane3Y0ZCheckBox.Checked;
        }
        private void AccessSegmentOfPlane2X0ZCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SegmentsAccess.IsSegmentOfPlane2X0ZEnabled = AccessSegmentOfPlane2X0ZCheckBox.Checked;
        }
        private void AccessSegmentOfPlane1X0YCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SegmentsAccess.IsSegmentOfPlane1X0YEnabled = AccessSegmentOfPlane1X0YCheckBox.Checked;
        }
        private void AccessSegment3DCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SegmentsAccess.IsSegment3DEnabled = AccessSegment3DCheckBox.Checked;
        }
        private void accessSegmentsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SegmentsAccess.IsSegmentsEnabled = accessSegmentsCheckBox.Checked;
        }
        private void AccessGenerateSegment3DCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SegmentsAccess.IsGenerateSegment3DEnabled = AccessGenerateSegment3DCheckBox.Checked;
        }
    }
}
