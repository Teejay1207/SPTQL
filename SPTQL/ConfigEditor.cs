using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SPTQL
{
    public partial class ConfigEditor : Form
    {
        private JObject _jsonObject;
        private readonly Dictionary<string, Control> _controls;

        public ConfigEditor()
        {
            InitializeComponent();
            _controls = new Dictionary<string, Control>();
            InitializeRawDataTextBox();
        }

        private void InitializeRawDataTextBox()
        {
            foreach (Control control in RawDataForm.Controls)
            {
                if (control is TextBox)
                {
                    textBoxRawData = (TextBox)control;
                    textBoxRawData.TextChanged += TextBoxRawData_TextChanged;
                    break;
                }
            }
        }

        private void BtnLoadJson_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "JSON files (*.json, *.jsonc)|*.json;*.jsonc|All files (*.*)|*.*"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var filePath = openFileDialog.FileName;
                var fileContent = File.ReadAllText(filePath);
                var json = filePath.ToLower().EndsWith(".jsonc") ? RemoveCommentsFromJson(fileContent) : fileContent;

                try
                {
                    _jsonObject = JObject.Parse(json);
                    textBoxRawData.Text = json;
                    GenerateControls();

                    // Display the file name in label1
                    label1.Text = Path.GetFileName(filePath);
                }
                catch (JsonReaderException ex)
                {
                    MessageBox.Show($"Error parsing JSON: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnSaveJson_Click(object sender, EventArgs e)
        {
            SaveDataFromUI();

            if (_jsonObject != null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "JSON files (*.json, *.jsonc)|*.json;*.jsonc|All files (*.*)|*.*"
                };
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var saveFilePath = saveFileDialog.FileName;
                    var jsonContent = JsonConvert.SerializeObject(_jsonObject, Newtonsoft.Json.Formatting.Indented);

                    if (saveFilePath.ToLower().EndsWith(".jsonc"))
                    {
                        jsonContent = AddCommentsToJsonC(jsonContent);
                    }

                    File.WriteAllText(saveFilePath, jsonContent);
                    MessageBox.Show("JSON file saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void TextBoxRawData_TextChanged(object sender, EventArgs e)
        {
            var rawJson = textBoxRawData.Text;
            try
            {
                _jsonObject = JObject.Parse(rawJson);
                GenerateControls();
            }
            catch (JsonReaderException ex)
            {
                MessageBox.Show($"Error parsing JSON: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string RemoveCommentsFromJson(string jsonC)
        {
            jsonC = Regex.Replace(jsonC, @"/\*.*?\*/", string.Empty, RegexOptions.Singleline);
            jsonC = Regex.Replace(jsonC, @"//.*(?=\r?\n)", string.Empty);
            return jsonC;
        }

        private void GenerateControls()
        {
            panelContainer.Controls.Clear();
            _controls.Clear();
            var yOffset = 10;
            var panelWidth = panelContainer.Width - 30;
            var labelWidth = 160; // Fixed label width
            var spacing = 10; // Spacing between controls

            foreach (var property in _jsonObject.Properties())
            {
                System.Windows.Forms.Label label = new System.Windows.Forms.Label
                {
                    Text = property.Name,
                    Location = new Point(10, yOffset),
                    AutoSize = true,
                    Width = labelWidth
                };
                panelContainer.Controls.Add(label);

                Control control = null;

                switch (property.Value.Type)
                {
                    case JTokenType.Boolean:
                        control = new CheckBox
                        {
                            Checked = (bool)property.Value,
                            Location = new Point(labelWidth + 100, yOffset)
                        };
                        yOffset += control.Height + spacing;
                        break;

                    case JTokenType.Integer:
                        control = new NumericUpDown
                        {
                            Minimum = int.MinValue,
                            Maximum = int.MaxValue,
                            Value = (int)property.Value,
                            Location = new Point(labelWidth + 100, yOffset),
                            Width = 100
                        };
                        yOffset += control.Height + spacing;
                        break;

                    case JTokenType.Float:
                        control = new NumericUpDown
                        {
                            DecimalPlaces = 2,
                            Minimum = decimal.MinValue,
                            Maximum = decimal.MaxValue,
                            Value = (decimal)property.Value,
                            Location = new Point(labelWidth + 100, yOffset),
                            Width = 100
                        };
                        yOffset += control.Height + spacing;
                        break;

                    case JTokenType.String:
                        control = new TextBox
                        {
                            Text = (string)property.Value,
                            Location = new Point(labelWidth + 100, yOffset),
                            Width = panelWidth - labelWidth - 30
                        };
                        yOffset += control.Height + spacing;
                        break;

                    case JTokenType.Array:
                        control = new TextBox
                        {
                            Text = string.Join(", ", property.Value.Select(v => v.ToString())),
                            Location = new Point(labelWidth + 100, yOffset),
                            Width = panelWidth - labelWidth - 30,
                            Multiline = true,
                            Height = 60,
                            ScrollBars = ScrollBars.Vertical
                        };
                        yOffset += control.Height + spacing;
                        break;

                    case JTokenType.Object:
                        control = new TextBox
                        {
                            Text = property.Value.ToString(),
                            Location = new Point(labelWidth + 100, yOffset),
                            Width = panelWidth - labelWidth - 30,
                            Multiline = true,
                            Height = 60,
                            ScrollBars = ScrollBars.Vertical
                        };
                        yOffset += control.Height + spacing;
                        break;

                    default:
                        control = new TextBox
                        {
                            Text = property.Value.ToString(),
                            Location = new Point(labelWidth + 100, yOffset),
                            Width = panelWidth - labelWidth - 30
                        };
                        yOffset += control.Height + spacing;
                        break;
                }

                if (control != null)
                {
                    control.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                    panelContainer.Controls.Add(control);
                    _controls.Add(property.Name, control);
                }
            }

            panelContainer.AutoScroll = true;
            panelContainer.Dock = DockStyle.Fill;
        }

        private void SaveDataFromUI()
        {
            foreach (var property in _jsonObject.Properties())
            {
                if (_controls.ContainsKey(property.Name))
                {
                    var control = _controls[property.Name];
                    switch (property.Value.Type)
                    {
                        case JTokenType.Boolean:
                            property.Value = ((CheckBox)control).Checked;
                            break;
                        case JTokenType.Integer:
                            property.Value = (int)((NumericUpDown)control).Value;
                            break;
                        case JTokenType.Float:
                            property.Value = (decimal)((NumericUpDown)control).Value;
                            break;
                        case JTokenType.String:
                            property.Value = control.Text;
                            break;
                        case JTokenType.Array:
                            property.Value = JArray.FromObject(control.Text.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(v => v.Trim()).ToList());
                            break;
                        case JTokenType.Object:
                            property.Value = JObject.Parse(control.Text);
                            break;
                        default:
                            property.Value = control.Text;
                            break;
                    }
                }
            }
        }

        private string AddCommentsToJsonC(string json)
        {
            return "// JSONC format\n" + json;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to save changes before closing?", "Save Changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                BtnSaveJson_Click(sender, e);
            }
            else if (result == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Replace the URL with the actual link you want to open
            string url = "https://hub.sp-tarkov.com/user/54025-teejaymerks/";

            // Open the URL in the default browser
            Process.Start(url);
        }

    }
}
