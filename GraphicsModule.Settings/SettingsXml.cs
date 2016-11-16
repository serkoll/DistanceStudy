using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;

namespace GraphicsModule.Settings
{
    public class SettingsXml
    {
        public XDocument SettingsXDocument { get; set; }
        internal string _tag;
        public string XmlPath="settings.xml";

        public SettingsXml()
        {
            SettingsXDocument = XDocument.Load(XmlPath);
        }

        public XElement GetElement(int i, string tag)
        {
            var settingsAxis = SettingsXDocument.Descendants(tag).Select(y => y);

            var xElements = settingsAxis as XElement[] ?? settingsAxis.ToArray();

            return xElements[0].Element(TagsList(tag)[i]);
        }

        private List<string> TagsList(string tag)
        {
            List<string> tags = SettingsXDocument.Elements("Settings").Elements(tag).Elements().Select(x => x.Name.LocalName).ToList();
            return tags;
        }

        public void InitializeSettingsCursor(SettingCursor settingCursor1)
        {
            _tag = "Cursor";
            for (int i = 0; i < TagsList(_tag).Count; i++)
            {
                var bitmap = new Bitmap(settingCursor1.CursorBoxes[i].Width, settingCursor1.CursorBoxes[i].Height);
                settingCursor1.ColorBase[i].BackColor = ColorTranslator.FromWin32(int.Parse(GetElement(i,_tag).Value));
                    settingCursor1.Cursors[i].Draw(settingCursor1.CursorBoxes[i].Width, settingCursor1.CursorBoxes[i].Height, settingCursor1.ColorBase[i].BackColor, Graphics.FromImage(bitmap));
                settingCursor1.CursorBoxes[i].Image = bitmap;
            }
        }

        public void InitializeSettingsBackground(SettingBackground settingBackground1)
        {
            _tag = "Background";
            settingBackground1.pictureBox1.BackColor = ColorTranslator.FromWin32(int.Parse(GetElement(0, _tag).Value));
        }

        public void InitializeSettingsLine(SettingLine settingLine1)
        {
            _tag = "Line";
            settingLine1.lineWidthUpDown.Value = decimal.Parse(GetElement(0, _tag).Value);
            settingLine1.lineColorBox.BackColor = ColorTranslator.FromWin32(int.Parse(GetElement(1, _tag).Value));
            settingLine1.checkBox1.Checked = bool.Parse(GetElement(2, _tag).Value);
            settingLine1.colorLine1stPlaneBox.BackColor = ColorTranslator.FromWin32(int.Parse(GetElement(3, _tag).Value));
            settingLine1.colorLine2ndPlaneBox.BackColor = ColorTranslator.FromWin32(int.Parse(GetElement(4, _tag).Value));
            settingLine1.colorLine3rdPlaneBox.BackColor = ColorTranslator.FromWin32(int.Parse(GetElement(5, _tag).Value));
            settingLine1.nameLine1stPlaneBox.Text= GetElement(6, _tag).Value;
            settingLine1.nameLine2ndPlaneBox.Text= GetElement(7, _tag).Value;
            settingLine1.nameLine3rdPlaneBox.Text=GetElement(8, _tag).Value;
        }

        public void InitializeSettingsLink(SettingLink settingLink1, SettingAxis settingAxis1)
        {
            _tag = "Link";
            settingLink1.linkToAxis1OnOff.Checked = bool.Parse(GetElement(0,_tag).Value);
            settingLink1.linkToAxis2OnOff.Checked = bool.Parse(GetElement(1,_tag).Value);
            settingLink1.linkToAxis3OnOff.Checked = bool.Parse(GetElement(2,_tag).Value);

            settingLink1.link1ColorBox.BackColor = ColorTranslator.FromWin32(int.Parse(GetElement(3,_tag).Value));
            settingLink1.link2ColorBox.BackColor = ColorTranslator.FromWin32(int.Parse(GetElement(4,_tag).Value));
            settingLink1.link3ColorBox.BackColor = ColorTranslator.FromWin32(int.Parse(GetElement(5,_tag).Value));

            settingLink1.linkWidth.Value = decimal.Parse(GetElement(6,_tag).Value);

            settingLink1.checkBox1.Checked = bool.Parse(GetElement(7,_tag).Value);

            if (settingLink1.checkBox1.Checked)
            {
                settingLink1.link1ColorBox.BackColor = settingAxis1.colorBox1.BackColor;
                settingLink1.link2ColorBox.BackColor = settingAxis1.colorBox2.BackColor;
                settingLink1.link3ColorBox.BackColor = settingAxis1.colorBox3.BackColor;
            }
        }

        public void InitializeSettingsAxisControl(SettingAxis settingAxis1)
        {
            _tag = "Axis";
            
            settingAxis1.CheckBox1_FlagDrawAxisX.Checked = bool.Parse(GetElement(0,_tag).Value);
            settingAxis1.CheckBox2_FlagDrawAxisY.Checked = bool.Parse(GetElement(1,_tag).Value);
            settingAxis1.CheckBox3_FlagDrawAxisZ.Checked = bool.Parse(GetElement(2,_tag).Value);
            settingAxis1.axis1NameBox.Text = GetElement(3,_tag).Value;
            settingAxis1.axis2NameBox.Text = GetElement(4,_tag).Value;
            settingAxis1.axis3NameBox.Text = GetElement(5,_tag).Value;
            settingAxis1.NumericUpDown2_AxisWidth.Value = decimal.Parse(GetElement(6,_tag).Value);
            settingAxis1.ListBox1_TypeArrowAxis.SelectedItem = GetElement(7,_tag).Value;
            settingAxis1.colorBox1.BackColor = ColorTranslator.FromWin32(int.Parse(GetElement(8,_tag).Value));
            settingAxis1.colorBox2.BackColor = ColorTranslator.FromWin32(int.Parse(GetElement(9,_tag).Value));
            settingAxis1.colorBox3.BackColor = ColorTranslator.FromWin32(int.Parse(GetElement(10,_tag).Value));
        }

        public void InitializeSettingsGridControl(SettingGrid settingGrid1)
        {
            _tag = "Grid";
            settingGrid1.CheckBox1_FlagDrawGrid.Checked = bool.Parse(GetElement(0,_tag).Value);
            settingGrid1.NumericUpDown2_PointsWidth.Value = decimal.Parse(GetElement(1,_tag).Value);

            settingGrid1.gridStep1Box.Text = GetElement(3,_tag).Value;
            settingGrid1.gridStep2Box.Text = GetElement(4,_tag).Value;
            
            settingGrid1.colorEdge.BackColor = ColorTranslator.FromWin32(int.Parse(GetElement(5,_tag).Value));
        }

        public void InitializeSettings3DPoint(Setting3DPoint setting3DPoint1)
        {
            _tag = "Point3D";
            
            setting3DPoint1.color1stPlaneBox.BackColor = ColorTranslator.FromWin32(int.Parse(GetElement(0,_tag).Value));
            setting3DPoint1.color2ndPlaneBox.BackColor = ColorTranslator.FromWin32(int.Parse(GetElement(1,_tag).Value));
            setting3DPoint1.color3rdPlaneBox.BackColor = ColorTranslator.FromWin32(int.Parse(GetElement(2,_tag).Value));

            setting3DPoint1.icons1stPlaneList.SelectedItem = GetElement(3,_tag).Value;
            setting3DPoint1.icons2ndPlaneList.SelectedItem = GetElement(4,_tag).Value;
            setting3DPoint1.icons3rdPlaneList.SelectedItem = GetElement(5,_tag).Value;

            setting3DPoint1.name1stPlaneBox.Text = GetElement(6,_tag).Value;
            setting3DPoint1.name2ndPlaneBox.Text = GetElement(7,_tag).Value;
            setting3DPoint1.name3rdPlaneBox.Text = GetElement(8,_tag).Value;
        }

        public void InitializeSettingsSegment(SettingSegment settingSegment1)
        {
            _tag = "Segment";
            settingSegment1.segmentWidth.Value = decimal.Parse(GetElement(0,_tag).Value);
            settingSegment1.endPointsOnOff.Checked = bool.Parse(GetElement(1,_tag).Value);
            settingSegment1.colorSegment1stPlaneBox.BackColor = ColorTranslator.FromWin32(int.Parse(GetElement(2,_tag).Value));
            settingSegment1.colorSegment2ndPlaneBox.BackColor = ColorTranslator.FromWin32(int.Parse(GetElement(3,_tag).Value));
            settingSegment1.colorSegment3rdPlaneBox.BackColor = ColorTranslator.FromWin32(int.Parse(GetElement(4,_tag).Value));
            settingSegment1.nameSegment1stPlaneBox.SelectedText = GetElement(5,_tag).Value;
            settingSegment1.nameSegment2ndPlaneBox.SelectedText = GetElement(6,_tag).Value;
            settingSegment1.nameSegment3rdPlaneBox.SelectedText = GetElement(7,_tag).Value;
        }

        public void InitializeSettingsPoint(SettingPoint settingPoint1)
        {
            _tag = "Point";
            settingPoint1.pointColorBox.BackColor = ColorTranslator.FromWin32(int.Parse(GetElement(0,_tag).Value));
        }

        public void SaveSettingsBackground(SettingBackground settingBackground1)
        {
            _tag = "Background";
            GetElement(0, _tag).Value = ColorTranslator.ToWin32(settingBackground1.pictureBox1.BackColor).ToString();
        }

        public void SaveSettings3DPoint(Setting3DPoint setting3DPoint1)
        {
            _tag = "Point3D";
            GetElement(0,_tag).Value = ColorTranslator.ToWin32(setting3DPoint1.color1stPlaneBox.BackColor).ToString();
            GetElement(1,_tag).Value = ColorTranslator.ToWin32(setting3DPoint1.color2ndPlaneBox.BackColor).ToString();
            GetElement(2,_tag).Value = ColorTranslator.ToWin32(setting3DPoint1.color3rdPlaneBox.BackColor).ToString();

            GetElement(3,_tag).Value = setting3DPoint1.icons1stPlaneList.SelectedItem.ToString();
            GetElement(4,_tag).Value = setting3DPoint1.icons2ndPlaneList.SelectedItem.ToString();
            GetElement(5,_tag).Value = setting3DPoint1.icons3rdPlaneList.SelectedItem.ToString();

            GetElement(6,_tag).Value = setting3DPoint1.name1stPlaneBox.Text;
            GetElement(7,_tag).Value = setting3DPoint1.name2ndPlaneBox.Text;
            GetElement(8,_tag).Value = setting3DPoint1.name3rdPlaneBox.Text;
        }

        public void SaveSettingsGrid(SettingGrid settingGrid1)
        {
            _tag = "Grid";
            GetElement(0, _tag).Value = settingGrid1.CheckBox1_FlagDrawGrid.Checked.ToString();
            GetElement(1, _tag).Value = settingGrid1.NumericUpDown2_PointsWidth.Value.ToString(CultureInfo.InvariantCulture);
            GetElement(3, _tag).Value = settingGrid1.gridStep1Box.Text;
            GetElement(4, _tag).Value = settingGrid1.gridStep2Box.Text;
            GetElement(5, _tag).Value = ColorTranslator.ToWin32(settingGrid1.colorEdge.BackColor).ToString();
        }


        public void SaveSettingsAxis(SettingAxis settingAxis1)
        {
            _tag = "Axis";
            GetElement(0,_tag).Value = settingAxis1.CheckBox1_FlagDrawAxisX.Checked.ToString();
            GetElement(1,_tag).Value = settingAxis1.CheckBox2_FlagDrawAxisY.Checked.ToString();
            GetElement(2,_tag).Value = settingAxis1.CheckBox3_FlagDrawAxisZ.Checked.ToString();

            GetElement(3,_tag).Value = settingAxis1.axis1NameBox.Text;
            GetElement(4,_tag).Value = settingAxis1.axis2NameBox.Text;
            GetElement(5,_tag).Value = settingAxis1.axis3NameBox.Text;

            GetElement(6,_tag).Value = settingAxis1.NumericUpDown2_AxisWidth.Value.ToString(CultureInfo.InvariantCulture);

            GetElement(7,_tag).Value = settingAxis1.ListBox1_TypeArrowAxis.SelectedItem.ToString();

            GetElement(8,_tag).Value = ColorTranslator.ToWin32(settingAxis1.colorBox1.BackColor).ToString();
            GetElement(9,_tag).Value = ColorTranslator.ToWin32(settingAxis1.colorBox2.BackColor).ToString();
            GetElement(10,_tag).Value = ColorTranslator.ToWin32(settingAxis1.colorBox3.BackColor).ToString();
        }

        public void SaveSettingsCursor(SettingCursor settingCursor1)
        {
            _tag = "Cursor";
            for (int i = 0; i < TagsList(_tag).Count; i++)
            {
                GetElement(i,_tag).Value = ColorTranslator.ToWin32(settingCursor1.ColorBase[i].BackColor).ToString();
            }
        }

        public void SaveSettingsLink(SettingLink settingLink1)
        {
            _tag = "Link";
           
            GetElement(0,_tag).Value = settingLink1.linkToAxis1OnOff.Checked.ToString();
            GetElement(1,_tag).Value = settingLink1.linkToAxis2OnOff.Checked.ToString();
            GetElement(2,_tag).Value = settingLink1.linkToAxis3OnOff.Checked.ToString();

            GetElement(3,_tag).Value = ColorTranslator.ToWin32(settingLink1.link1ColorBox.BackColor).ToString();
            GetElement(4,_tag).Value = ColorTranslator.ToWin32(settingLink1.link2ColorBox.BackColor).ToString();
            GetElement(5,_tag).Value = ColorTranslator.ToWin32(settingLink1.link3ColorBox.BackColor).ToString();

            GetElement(6,_tag).Value = settingLink1.linkWidth.Value.ToString(CultureInfo.InvariantCulture);

            GetElement(7,_tag).Value = settingLink1.checkBox1.Checked.ToString();
        }

        public void SaveSettingsSegment(SettingSegment settingSegment1)
        {
            _tag = "Segment";
            GetElement(0,_tag).Value = settingSegment1.segmentWidth.Value.ToString(CultureInfo.InvariantCulture);
            GetElement(1,_tag).Value = settingSegment1.endPointsOnOff.Checked.ToString();
            GetElement(2,_tag).Value =
                ColorTranslator.ToWin32(settingSegment1.colorSegment1stPlaneBox.BackColor).ToString();
            GetElement(3,_tag).Value =
                ColorTranslator.ToWin32(settingSegment1.colorSegment2ndPlaneBox.BackColor).ToString();
            GetElement(4,_tag).Value =
                ColorTranslator.ToWin32(settingSegment1.colorSegment3rdPlaneBox.BackColor).ToString();
            GetElement(5,_tag).Value = settingSegment1.nameSegment1stPlaneBox.SelectedText;
            GetElement(6,_tag).Value = settingSegment1.nameSegment2ndPlaneBox.SelectedText;
            GetElement(7,_tag).Value = settingSegment1.nameSegment3rdPlaneBox.SelectedText;
        }

        public void SaveSettingsLine(SettingLine settingLine1)
        {
            _tag = "Line";
            GetElement(0, _tag).Value = settingLine1.lineWidthUpDown.Value.ToString();
            GetElement(1, _tag).Value = ColorTranslator.ToWin32(settingLine1.lineColorBox.BackColor).ToString();
            GetElement(2, _tag).Value = settingLine1.checkBox1.Checked.ToString();
            GetElement(3, _tag).Value = ColorTranslator.ToWin32(settingLine1.colorLine1stPlaneBox.BackColor).ToString();
            GetElement(4, _tag).Value = ColorTranslator.ToWin32(settingLine1.colorLine2ndPlaneBox.BackColor).ToString();
            GetElement(5, _tag).Value = ColorTranslator.ToWin32(settingLine1.colorLine3rdPlaneBox.BackColor).ToString();
            GetElement(6, _tag).Value = settingLine1.nameLine1stPlaneBox.Text;
            GetElement(7, _tag).Value = settingLine1.nameLine2ndPlaneBox.Text;
            GetElement(8, _tag).Value = settingLine1.nameLine3rdPlaneBox.Text;
        }

        public void SaveSettingsPoint(SettingPoint settingPoint1)
        {
            _tag = "Point";

            GetElement(0,_tag).Value =
                ColorTranslator.ToWin32(settingPoint1.pointColorBox.BackColor).ToString();
        }
    }
}
