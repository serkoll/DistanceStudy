using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;
using GraphicsModule.Settings.Controls;

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

        public void InitializeSettingsCursor(SettingsCursor settingsCursor1)
        {
            _tag = "Cursor";
            for (int i = 0; i < TagsList(_tag).Count; i++)
            {
                var bitmap = new Bitmap(settingsCursor1.CursorBoxes[i].Width, settingsCursor1.CursorBoxes[i].Height);
                settingsCursor1.ColorBase[i].BackColor = ColorTranslator.FromWin32(int.Parse(GetElement(i,_tag).Value));
                    settingsCursor1.Cursors[i].Draw(settingsCursor1.CursorBoxes[i].Width, settingsCursor1.CursorBoxes[i].Height, settingsCursor1.ColorBase[i].BackColor, Graphics.FromImage(bitmap));
                settingsCursor1.CursorBoxes[i].Image = bitmap;
            }
        }

        public void InitializeSettingsBackground(SettingsBackground settingsBackground1)
        {
            _tag = "Background";
            settingsBackground1.pictureBox1.BackColor = ColorTranslator.FromWin32(int.Parse(GetElement(0, _tag).Value));
        }

        public void InitializeSettingsLine(SettingsLine settingsLine1)
        {
            _tag = "Line";
            settingsLine1.lineWidthUpDown.Value = decimal.Parse(GetElement(0, _tag).Value);
            settingsLine1.lineColorBox.BackColor = ColorTranslator.FromWin32(int.Parse(GetElement(1, _tag).Value));
            settingsLine1.checkBox1.Checked = bool.Parse(GetElement(2, _tag).Value);
            settingsLine1.colorLine1stPlaneBox.BackColor = ColorTranslator.FromWin32(int.Parse(GetElement(3, _tag).Value));
            settingsLine1.colorLine2ndPlaneBox.BackColor = ColorTranslator.FromWin32(int.Parse(GetElement(4, _tag).Value));
            settingsLine1.colorLine3rdPlaneBox.BackColor = ColorTranslator.FromWin32(int.Parse(GetElement(5, _tag).Value));
            settingsLine1.nameLine1stPlaneBox.Text= GetElement(6, _tag).Value;
            settingsLine1.nameLine2ndPlaneBox.Text= GetElement(7, _tag).Value;
            settingsLine1.nameLine3rdPlaneBox.Text=GetElement(8, _tag).Value;
        }

        public void InitializeSettingsLink(SettingsLink settingsLink1, SettingsAxis settingsAxis1)
        {
            _tag = "Link";
            settingsLink1.linkToAxis1OnOff.Checked = bool.Parse(GetElement(0,_tag).Value);
            settingsLink1.linkToAxis2OnOff.Checked = bool.Parse(GetElement(1,_tag).Value);
            settingsLink1.linkToAxis3OnOff.Checked = bool.Parse(GetElement(2,_tag).Value);

            settingsLink1.link1ColorBox.BackColor = ColorTranslator.FromWin32(int.Parse(GetElement(3,_tag).Value));
            settingsLink1.link2ColorBox.BackColor = ColorTranslator.FromWin32(int.Parse(GetElement(4,_tag).Value));
            settingsLink1.link3ColorBox.BackColor = ColorTranslator.FromWin32(int.Parse(GetElement(5,_tag).Value));

            settingsLink1.linkWidth.Value = decimal.Parse(GetElement(6,_tag).Value);

            settingsLink1.checkBox1.Checked = bool.Parse(GetElement(7,_tag).Value);

            if (settingsLink1.checkBox1.Checked)
            {
                settingsLink1.link1ColorBox.BackColor = settingsAxis1.colorBox1.BackColor;
                settingsLink1.link2ColorBox.BackColor = settingsAxis1.colorBox2.BackColor;
                settingsLink1.link3ColorBox.BackColor = settingsAxis1.colorBox3.BackColor;
            }
        }

        public void InitializeSettingsAxisControl(SettingsAxis settingsAxis1)
        {
            _tag = "Axis";
            
            settingsAxis1.CheckBox1_FlagDrawAxisX.Checked = bool.Parse(GetElement(0,_tag).Value);
            settingsAxis1.CheckBox2_FlagDrawAxisY.Checked = bool.Parse(GetElement(1,_tag).Value);
            settingsAxis1.CheckBox3_FlagDrawAxisZ.Checked = bool.Parse(GetElement(2,_tag).Value);
            settingsAxis1.axis1NameBox.Text = GetElement(3,_tag).Value;
            settingsAxis1.axis2NameBox.Text = GetElement(4,_tag).Value;
            settingsAxis1.axis3NameBox.Text = GetElement(5,_tag).Value;
            settingsAxis1.NumericUpDown2_AxisWidth.Value = decimal.Parse(GetElement(6,_tag).Value);
            //settingsAxis1.ListBox1_TypeArrowAxis.SelectedItem = GetElement(7,_tag).Value;
            settingsAxis1.colorBox1.BackColor = ColorTranslator.FromWin32(int.Parse(GetElement(8,_tag).Value));
            settingsAxis1.colorBox2.BackColor = ColorTranslator.FromWin32(int.Parse(GetElement(9,_tag).Value));
            settingsAxis1.colorBox3.BackColor = ColorTranslator.FromWin32(int.Parse(GetElement(10,_tag).Value));
        }

        public void InitializeSettingsGridControl(SettingsGrid settingsGrid1)
        {
            _tag = "Grid";
            settingsGrid1.CheckBox1_FlagDrawGrid.Checked = bool.Parse(GetElement(0,_tag).Value);
            settingsGrid1.NumericUpDown2_PointsWidth.Value = decimal.Parse(GetElement(1,_tag).Value);

            settingsGrid1.gridStep1Box.Text = GetElement(3,_tag).Value;
            settingsGrid1.gridStep2Box.Text = GetElement(4,_tag).Value;
            
            settingsGrid1.colorEdge.BackColor = ColorTranslator.FromWin32(int.Parse(GetElement(5,_tag).Value));
        }


        public void InitializeSettingsSegment(SettingsSegment settingsSegment1)
        {
            _tag = "Segment";
            settingsSegment1.segmentWidth.Value = decimal.Parse(GetElement(0,_tag).Value);
            settingsSegment1.endPointsOnOff.Checked = bool.Parse(GetElement(1,_tag).Value);
            settingsSegment1.colorSegment1stPlaneBox.BackColor = ColorTranslator.FromWin32(int.Parse(GetElement(2,_tag).Value));
            settingsSegment1.colorSegment2ndPlaneBox.BackColor = ColorTranslator.FromWin32(int.Parse(GetElement(3,_tag).Value));
            settingsSegment1.colorSegment3rdPlaneBox.BackColor = ColorTranslator.FromWin32(int.Parse(GetElement(4,_tag).Value));
            settingsSegment1.nameSegment1stPlaneBox.SelectedText = GetElement(5,_tag).Value;
            settingsSegment1.nameSegment2ndPlaneBox.SelectedText = GetElement(6,_tag).Value;
            settingsSegment1.nameSegment3rdPlaneBox.SelectedText = GetElement(7,_tag).Value;
        }

        public void InitializeSettingsPoint(SettingsPoint settingsPoint1)
        {
            _tag = "Point";
            settingsPoint1.pointColorBox.BackColor = ColorTranslator.FromWin32(int.Parse(GetElement(0,_tag).Value));
        }

        public void SaveSettingsBackground(SettingsBackground settingsBackground1)
        {
            _tag = "Background";
            GetElement(0, _tag).Value = ColorTranslator.ToWin32(settingsBackground1.pictureBox1.BackColor).ToString();
        }



        public void SaveSettingsGrid(SettingsGrid settingsGrid1)
        {
            _tag = "Grid";
            GetElement(0, _tag).Value = settingsGrid1.CheckBox1_FlagDrawGrid.Checked.ToString();
            GetElement(1, _tag).Value = settingsGrid1.NumericUpDown2_PointsWidth.Value.ToString(CultureInfo.InvariantCulture);
            GetElement(3, _tag).Value = settingsGrid1.gridStep1Box.Text;
            GetElement(4, _tag).Value = settingsGrid1.gridStep2Box.Text;
            GetElement(5, _tag).Value = ColorTranslator.ToWin32(settingsGrid1.colorEdge.BackColor).ToString();
        }


        public void SaveSettingsAxis(SettingsAxis settingsAxis1)
        {
            _tag = "Axis";
            GetElement(0,_tag).Value = settingsAxis1.CheckBox1_FlagDrawAxisX.Checked.ToString();
            GetElement(1,_tag).Value = settingsAxis1.CheckBox2_FlagDrawAxisY.Checked.ToString();
            GetElement(2,_tag).Value = settingsAxis1.CheckBox3_FlagDrawAxisZ.Checked.ToString();

            GetElement(3,_tag).Value = settingsAxis1.axis1NameBox.Text;
            GetElement(4,_tag).Value = settingsAxis1.axis2NameBox.Text;
            GetElement(5,_tag).Value = settingsAxis1.axis3NameBox.Text;

            GetElement(6,_tag).Value = settingsAxis1.NumericUpDown2_AxisWidth.Value.ToString(CultureInfo.InvariantCulture);

            //GetElement(7,_tag).Value = settingsAxis1.ListBox1_TypeArrowAxis.SelectedItem.ToString();

            GetElement(8,_tag).Value = ColorTranslator.ToWin32(settingsAxis1.colorBox1.BackColor).ToString();
            GetElement(9,_tag).Value = ColorTranslator.ToWin32(settingsAxis1.colorBox2.BackColor).ToString();
            GetElement(10,_tag).Value = ColorTranslator.ToWin32(settingsAxis1.colorBox3.BackColor).ToString();
        }

        public void SaveSettingsCursor(SettingsCursor settingsCursor1)
        {
            _tag = "Cursor";
            for (int i = 0; i < TagsList(_tag).Count; i++)
            {
                GetElement(i,_tag).Value = ColorTranslator.ToWin32(settingsCursor1.ColorBase[i].BackColor).ToString();
            }
        }

        public void SaveSettingsLink(SettingsLink settingsLink1)
        {
            _tag = "Link";
           
            GetElement(0,_tag).Value = settingsLink1.linkToAxis1OnOff.Checked.ToString();
            GetElement(1,_tag).Value = settingsLink1.linkToAxis2OnOff.Checked.ToString();
            GetElement(2,_tag).Value = settingsLink1.linkToAxis3OnOff.Checked.ToString();

            GetElement(3,_tag).Value = ColorTranslator.ToWin32(settingsLink1.link1ColorBox.BackColor).ToString();
            GetElement(4,_tag).Value = ColorTranslator.ToWin32(settingsLink1.link2ColorBox.BackColor).ToString();
            GetElement(5,_tag).Value = ColorTranslator.ToWin32(settingsLink1.link3ColorBox.BackColor).ToString();

            GetElement(6,_tag).Value = settingsLink1.linkWidth.Value.ToString(CultureInfo.InvariantCulture);

            GetElement(7,_tag).Value = settingsLink1.checkBox1.Checked.ToString();
        }

        public void SaveSettingsSegment(SettingsSegment settingsSegment1)
        {
            _tag = "Segment";
            GetElement(0,_tag).Value = settingsSegment1.segmentWidth.Value.ToString(CultureInfo.InvariantCulture);
            GetElement(1,_tag).Value = settingsSegment1.endPointsOnOff.Checked.ToString();
            GetElement(2,_tag).Value =
                ColorTranslator.ToWin32(settingsSegment1.colorSegment1stPlaneBox.BackColor).ToString();
            GetElement(3,_tag).Value =
                ColorTranslator.ToWin32(settingsSegment1.colorSegment2ndPlaneBox.BackColor).ToString();
            GetElement(4,_tag).Value =
                ColorTranslator.ToWin32(settingsSegment1.colorSegment3rdPlaneBox.BackColor).ToString();
            GetElement(5,_tag).Value = settingsSegment1.nameSegment1stPlaneBox.SelectedText;
            GetElement(6,_tag).Value = settingsSegment1.nameSegment2ndPlaneBox.SelectedText;
            GetElement(7,_tag).Value = settingsSegment1.nameSegment3rdPlaneBox.SelectedText;
        }

        public void SaveSettingsLine(SettingsLine settingsLine1)
        {
            _tag = "Line";
            GetElement(0, _tag).Value = settingsLine1.lineWidthUpDown.Value.ToString();
            GetElement(1, _tag).Value = ColorTranslator.ToWin32(settingsLine1.lineColorBox.BackColor).ToString();
            GetElement(2, _tag).Value = settingsLine1.checkBox1.Checked.ToString();
            GetElement(3, _tag).Value = ColorTranslator.ToWin32(settingsLine1.colorLine1stPlaneBox.BackColor).ToString();
            GetElement(4, _tag).Value = ColorTranslator.ToWin32(settingsLine1.colorLine2ndPlaneBox.BackColor).ToString();
            GetElement(5, _tag).Value = ColorTranslator.ToWin32(settingsLine1.colorLine3rdPlaneBox.BackColor).ToString();
            GetElement(6, _tag).Value = settingsLine1.nameLine1stPlaneBox.Text;
            GetElement(7, _tag).Value = settingsLine1.nameLine2ndPlaneBox.Text;
            GetElement(8, _tag).Value = settingsLine1.nameLine3rdPlaneBox.Text;
        }

        public void SaveSettingsPoint(SettingsPoint settingsPoint1)
        {
            _tag = "Point";

            GetElement(0,_tag).Value =
                ColorTranslator.ToWin32(settingsPoint1.pointColorBox.BackColor).ToString();
        }
    }
}
