using System.Collections.Generic;
using System.Windows.Forms;
using GroanUI.Util;
using SharpNoise.Modules;

namespace GroanUI.Views.Main
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.NoiseMapPreview = new System.Windows.Forms.PictureBox();
            this.NoiseTypeComboBox = new System.Windows.Forms.ComboBox();
            this.CellTypeComboBox = new System.Windows.Forms.ComboBox();
            this.refreshButton = new System.Windows.Forms.Button();
            this.postProcessingGroupBox = new System.Windows.Forms.GroupBox();
            this.NoiseScale = new GroanUI.Views.DecimalSlider();
            this.MaxValue = new GroanUI.Views.DecimalSlider();
            this.MinValue = new GroanUI.Views.DecimalSlider();
            this.Grayscale = new System.Windows.Forms.CheckBox();
            this.Round = new System.Windows.Forms.CheckBox();
            this.Invert = new System.Windows.Forms.CheckBox();
            this.optionTabControl = new System.Windows.Forms.TabControl();
            this.PerlinConfigTabPage = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.PerlinQuality = new System.Windows.Forms.ComboBox();
            this.PerlinOctaves = new GroanUI.Views.DecimalSlider();
            this.PerlinPersistance = new GroanUI.Views.DecimalSlider();
            this.PerlinLacunarity = new GroanUI.Views.DecimalSlider();
            this.PerlinFrequency = new GroanUI.Views.DecimalSlider();
            this.BillowConfigTabPage = new System.Windows.Forms.TabPage();
            this.BillowOctaves = new GroanUI.Views.DecimalSlider();
            this.BillowPersistance = new GroanUI.Views.DecimalSlider();
            this.BillowLacunarity = new GroanUI.Views.DecimalSlider();
            this.BillowFrequency = new GroanUI.Views.DecimalSlider();
            this.label2 = new System.Windows.Forms.Label();
            this.BillowQuality = new System.Windows.Forms.ComboBox();
            this.CylinderConfigTabPage = new System.Windows.Forms.TabPage();
            this.CylinderFrequency = new GroanUI.Views.DecimalSlider();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.CellConfigTabPage = new System.Windows.Forms.TabPage();
            this.CellDisplacement = new GroanUI.Views.DecimalSlider();
            this.CellFrequency = new GroanUI.Views.DecimalSlider();
            ((System.ComponentModel.ISupportInitialize)(this.NoiseMapPreview)).BeginInit();
            this.postProcessingGroupBox.SuspendLayout();
            this.optionTabControl.SuspendLayout();
            this.PerlinConfigTabPage.SuspendLayout();
            this.BillowConfigTabPage.SuspendLayout();
            this.CylinderConfigTabPage.SuspendLayout();
            this.CellConfigTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // NoiseMapPreview
            // 
            this.NoiseMapPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NoiseMapPreview.Location = new System.Drawing.Point(22, 41);
            this.NoiseMapPreview.Name = "NoiseMapPreview";
            this.NoiseMapPreview.Size = new System.Drawing.Size(400, 400);
            this.NoiseMapPreview.TabIndex = 0;
            this.NoiseMapPreview.TabStop = false;
            this.toolTip1.SetToolTip(this.NoiseMapPreview, "Click to generate a new seed");
            this.NoiseMapPreview.Click += new System.EventHandler(this.NoiseMapPreview_Click);
            // 
            // NoiseTypeComboBox
            // 
            this.NoiseTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.NoiseTypeComboBox.FormattingEnabled = true;
            this.NoiseTypeComboBox.Location = new System.Drawing.Point(22, 12);
            this.NoiseTypeComboBox.Name = "NoiseTypeComboBox";
            this.NoiseTypeComboBox.Size = new System.Drawing.Size(400, 23);
            this.NoiseTypeComboBox.TabIndex = 1;
            this.NoiseTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.NoiseTypeComboBox_SelectedIndexChanged);
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(786, 414);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(90, 27);
            this.refreshButton.TabIndex = 2;
            this.refreshButton.Text = "button1";
            // 
            // postProcessingGroupBox
            // 
            this.postProcessingGroupBox.Controls.Add(this.NoiseScale);
            this.postProcessingGroupBox.Controls.Add(this.MaxValue);
            this.postProcessingGroupBox.Controls.Add(this.MinValue);
            this.postProcessingGroupBox.Controls.Add(this.Grayscale);
            this.postProcessingGroupBox.Controls.Add(this.Round);
            this.postProcessingGroupBox.Controls.Add(this.Invert);
            this.postProcessingGroupBox.Location = new System.Drawing.Point(444, 12);
            this.postProcessingGroupBox.Name = "postProcessingGroupBox";
            this.postProcessingGroupBox.Size = new System.Drawing.Size(433, 154);
            this.postProcessingGroupBox.TabIndex = 5;
            this.postProcessingGroupBox.TabStop = false;
            this.postProcessingGroupBox.Text = "Common options";
            // 
            // NoiseScale
            // 
            this.NoiseScale.AutoSize = true;
            this.NoiseScale.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.NoiseScale.Label = "Scale";
            this.NoiseScale.LargeChange = 100;
            this.NoiseScale.Location = new System.Drawing.Point(21, 92);
            this.NoiseScale.Margin = new System.Windows.Forms.Padding(1);
            this.NoiseScale.Maximum = 10;
            this.NoiseScale.Minimum = 0;
            this.NoiseScale.Name = "NoiseScale";
            this.NoiseScale.Size = new System.Drawing.Size(321, 20);
            this.NoiseScale.SmallChange = 10;
            this.NoiseScale.TabIndex = 16;
            this.NoiseScale.ToolTipText = "";
            this.NoiseScale.Scroll += new System.EventHandler<System.EventArgs>(this.NoiseScale_Scroll);
            // 
            // MaxValue
            // 
            this.MaxValue.AutoSize = true;
            this.MaxValue.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.MaxValue.Label = "Max Value";
            this.MaxValue.LargeChange = 100;
            this.MaxValue.Location = new System.Drawing.Point(21, 70);
            this.MaxValue.Margin = new System.Windows.Forms.Padding(1);
            this.MaxValue.Maximum = 10;
            this.MaxValue.Minimum = 0;
            this.MaxValue.Name = "MaxValue";
            this.MaxValue.Size = new System.Drawing.Size(321, 20);
            this.MaxValue.SmallChange = 10;
            this.MaxValue.TabIndex = 15;
            this.MaxValue.ToolTipText = "";
            this.MaxValue.Scroll += new System.EventHandler<System.EventArgs>(this.MaxValue_Scroll);
            // 
            // MinValue
            // 
            this.MinValue.AutoSize = true;
            this.MinValue.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.MinValue.Label = "Min Value";
            this.MinValue.LargeChange = 100;
            this.MinValue.Location = new System.Drawing.Point(21, 48);
            this.MinValue.Margin = new System.Windows.Forms.Padding(1);
            this.MinValue.Maximum = 10;
            this.MinValue.Minimum = 0;
            this.MinValue.Name = "MinValue";
            this.MinValue.Size = new System.Drawing.Size(321, 20);
            this.MinValue.SmallChange = 10;
            this.MinValue.TabIndex = 14;
            this.MinValue.ToolTipText = "";
            this.MinValue.Scroll += new System.EventHandler<System.EventArgs>(this.MinValue_Scroll);
            // 
            // Grayscale
            // 
            this.Grayscale.AutoSize = true;
            this.Grayscale.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Grayscale.Location = new System.Drawing.Point(150, 129);
            this.Grayscale.Name = "Grayscale";
            this.Grayscale.Size = new System.Drawing.Size(76, 19);
            this.Grayscale.TabIndex = 13;
            this.Grayscale.Text = "Grayscale";
            this.toolTip1.SetToolTip(this.Grayscale, "Invert the plot value before converting to Color");
            this.Grayscale.CheckedChanged += new System.EventHandler(this.Grayscale_CheckedChanged);
            // 
            // Round
            // 
            this.Round.AutoSize = true;
            this.Round.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Round.Location = new System.Drawing.Point(21, 129);
            this.Round.Name = "Round";
            this.Round.Size = new System.Drawing.Size(61, 19);
            this.Round.TabIndex = 12;
            this.Round.Text = "Round";
            this.toolTip1.SetToolTip(this.Round, "Make the value 0 or 1 before converting to a Color");
            this.Round.CheckedChanged += new System.EventHandler(this.RoundCheckBox_CheckedChanged);
            // 
            // Invert
            // 
            this.Invert.AutoSize = true;
            this.Invert.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Invert.Location = new System.Drawing.Point(88, 129);
            this.Invert.Name = "Invert";
            this.Invert.Size = new System.Drawing.Size(56, 19);
            this.Invert.TabIndex = 4;
            this.Invert.Text = "Invert";
            this.toolTip1.SetToolTip(this.Invert, "Invert the plot value before converting to Color");
            this.Invert.CheckedChanged += new System.EventHandler(this.Invert_CheckedChanged);
            // 
            // optionTabControl
            // 
            this.optionTabControl.Controls.Add(this.PerlinConfigTabPage);
            this.optionTabControl.Controls.Add(this.BillowConfigTabPage);
            this.optionTabControl.Controls.Add(this.CylinderConfigTabPage);
            this.optionTabControl.Controls.Add(this.CellConfigTabPage);
            this.optionTabControl.Location = new System.Drawing.Point(444, 187);
            this.optionTabControl.Name = "optionTabControl";
            this.optionTabControl.SelectedIndex = 0;
            this.optionTabControl.Size = new System.Drawing.Size(434, 204);
            this.optionTabControl.TabIndex = 6;
            this.toolTip1.SetToolTip(this.optionTabControl, "Double click sliders to reset.");
            this.optionTabControl.SelectedIndexChanged += new System.EventHandler(this.OptionTabControl_SelectedIndexChanged);
            // 
            // PerlinConfigTabPage
            // 
            this.PerlinConfigTabPage.BackColor = System.Drawing.SystemColors.Control;
            this.PerlinConfigTabPage.Controls.Add(this.label1);
            this.PerlinConfigTabPage.Controls.Add(this.PerlinQuality);
            this.PerlinConfigTabPage.Controls.Add(this.PerlinOctaves);
            this.PerlinConfigTabPage.Controls.Add(this.PerlinPersistance);
            this.PerlinConfigTabPage.Controls.Add(this.PerlinLacunarity);
            this.PerlinConfigTabPage.Controls.Add(this.PerlinFrequency);
            this.PerlinConfigTabPage.Location = new System.Drawing.Point(4, 24);
            this.PerlinConfigTabPage.Name = "PerlinConfigTabPage";
            this.PerlinConfigTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.PerlinConfigTabPage.Size = new System.Drawing.Size(426, 176);
            this.PerlinConfigTabPage.TabIndex = 1;
            this.PerlinConfigTabPage.Tag = "Perlin";
            this.PerlinConfigTabPage.Text = "Perlin";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 15);
            this.label1.TabIndex = 36;
            this.label1.Text = "Quality";
            // 
            // PerlinQuality
            // 
            this.PerlinQuality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PerlinQuality.FormattingEnabled = true;
            this.PerlinQuality.Location = new System.Drawing.Point(90, 98);
            this.PerlinQuality.Name = "PerlinQuality";
            this.PerlinQuality.Size = new System.Drawing.Size(121, 23);
            this.PerlinQuality.TabIndex = 35;
            this.PerlinQuality.SelectedIndexChanged += new System.EventHandler(this.PerlinQuality_SelectedIndexChanged);
            // 
            // PerlinOctaves
            // 
            this.PerlinOctaves.AutoSize = true;
            this.PerlinOctaves.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.PerlinOctaves.Label = "Octaves";
            this.PerlinOctaves.LargeChange = 100;
            this.PerlinOctaves.Location = new System.Drawing.Point(10, 74);
            this.PerlinOctaves.Margin = new System.Windows.Forms.Padding(1);
            this.PerlinOctaves.Maximum = 10;
            this.PerlinOctaves.Minimum = 0;
            this.PerlinOctaves.Name = "PerlinOctaves";
            this.PerlinOctaves.Size = new System.Drawing.Size(321, 20);
            this.PerlinOctaves.SmallChange = 10;
            this.PerlinOctaves.TabIndex = 34;
            this.PerlinOctaves.ToolTipText = "The number of octaves controls the amount of detail in the Perlin noise. The larg" +
    "er the number of octaves, the more time required to calculate the Perlin-noise v" +
    "alue.";
            this.PerlinOctaves.Scroll += new System.EventHandler<System.EventArgs>(this.PerlinOctaves_Scroll);
            // 
            // PerlinPersistance
            // 
            this.PerlinPersistance.AutoSize = true;
            this.PerlinPersistance.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.PerlinPersistance.Label = "Persistance";
            this.PerlinPersistance.LargeChange = 100;
            this.PerlinPersistance.Location = new System.Drawing.Point(10, 52);
            this.PerlinPersistance.Margin = new System.Windows.Forms.Padding(1);
            this.PerlinPersistance.Maximum = 10;
            this.PerlinPersistance.Minimum = 0;
            this.PerlinPersistance.Name = "PerlinPersistance";
            this.PerlinPersistance.Size = new System.Drawing.Size(321, 20);
            this.PerlinPersistance.SmallChange = 10;
            this.PerlinPersistance.TabIndex = 33;
            this.PerlinPersistance.ToolTipText = "The persistence value controls the roughness of the Perlin noise. For best result" +
    "s, set the persistence to a number between 0.0 and 1.0.";
            this.PerlinPersistance.Scroll += new System.EventHandler<System.EventArgs>(this.PerlinPersistance_Scroll);
            // 
            // PerlinLacunarity
            // 
            this.PerlinLacunarity.AutoSize = true;
            this.PerlinLacunarity.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.PerlinLacunarity.Label = "Lacunarity";
            this.PerlinLacunarity.LargeChange = 100;
            this.PerlinLacunarity.Location = new System.Drawing.Point(10, 30);
            this.PerlinLacunarity.Margin = new System.Windows.Forms.Padding(1);
            this.PerlinLacunarity.Maximum = 10;
            this.PerlinLacunarity.Minimum = 0;
            this.PerlinLacunarity.Name = "PerlinLacunarity";
            this.PerlinLacunarity.Size = new System.Drawing.Size(321, 20);
            this.PerlinLacunarity.SmallChange = 10;
            this.PerlinLacunarity.TabIndex = 32;
            this.PerlinLacunarity.ToolTipText = "The lacunarity is the frequency multiplier between successive octaves. For best r" +
    "esults, set the lacunarity to a number between 1.5 and 3.5.";
            this.PerlinLacunarity.Scroll += new System.EventHandler<System.EventArgs>(this.PerlinLacunarity_Scroll);
            // 
            // PerlinFrequency
            // 
            this.PerlinFrequency.AutoSize = true;
            this.PerlinFrequency.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.PerlinFrequency.Label = "Frequency";
            this.PerlinFrequency.LargeChange = 100;
            this.PerlinFrequency.Location = new System.Drawing.Point(10, 8);
            this.PerlinFrequency.Margin = new System.Windows.Forms.Padding(1);
            this.PerlinFrequency.Maximum = 10;
            this.PerlinFrequency.Minimum = 0;
            this.PerlinFrequency.Name = "PerlinFrequency";
            this.PerlinFrequency.Size = new System.Drawing.Size(321, 20);
            this.PerlinFrequency.SmallChange = 10;
            this.PerlinFrequency.TabIndex = 31;
            this.PerlinFrequency.ToolTipText = "The frequency of the first octave.";
            this.PerlinFrequency.Scroll += new System.EventHandler<System.EventArgs>(this.PerlinFrequency_Scroll);
            // 
            // BillowConfigTabPage
            // 
            this.BillowConfigTabPage.Controls.Add(this.BillowOctaves);
            this.BillowConfigTabPage.Controls.Add(this.BillowPersistance);
            this.BillowConfigTabPage.Controls.Add(this.BillowLacunarity);
            this.BillowConfigTabPage.Controls.Add(this.BillowFrequency);
            this.BillowConfigTabPage.Controls.Add(this.label2);
            this.BillowConfigTabPage.Controls.Add(this.BillowQuality);
            this.BillowConfigTabPage.Location = new System.Drawing.Point(4, 24);
            this.BillowConfigTabPage.Name = "BillowConfigTabPage";
            this.BillowConfigTabPage.Size = new System.Drawing.Size(426, 176);
            this.BillowConfigTabPage.TabIndex = 3;
            this.BillowConfigTabPage.Tag = "Billow";
            this.BillowConfigTabPage.Text = "Billow";
            // 
            // BillowOctaves
            // 
            this.BillowOctaves.AutoSize = true;
            this.BillowOctaves.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BillowOctaves.Label = "Octaves";
            this.BillowOctaves.LargeChange = 100;
            this.BillowOctaves.Location = new System.Drawing.Point(10, 74);
            this.BillowOctaves.Margin = new System.Windows.Forms.Padding(1);
            this.BillowOctaves.Maximum = 10;
            this.BillowOctaves.Minimum = 0;
            this.BillowOctaves.Name = "BillowOctaves";
            this.BillowOctaves.Size = new System.Drawing.Size(321, 20);
            this.BillowOctaves.SmallChange = 10;
            this.BillowOctaves.TabIndex = 38;
            this.BillowOctaves.ToolTipText = "The number of octaves controls the amount of detail in the Perlin noise. The larg" +
    "er the number of octaves, the more time required to calculate the Perlin-noise v" +
    "alue.";
            this.BillowOctaves.Scroll += new System.EventHandler<System.EventArgs>(this.BillowOctaves_Scroll);
            // 
            // BillowPersistance
            // 
            this.BillowPersistance.AutoSize = true;
            this.BillowPersistance.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BillowPersistance.Label = "Persistance";
            this.BillowPersistance.LargeChange = 100;
            this.BillowPersistance.Location = new System.Drawing.Point(10, 52);
            this.BillowPersistance.Margin = new System.Windows.Forms.Padding(1);
            this.BillowPersistance.Maximum = 10;
            this.BillowPersistance.Minimum = 0;
            this.BillowPersistance.Name = "BillowPersistance";
            this.BillowPersistance.Size = new System.Drawing.Size(321, 20);
            this.BillowPersistance.SmallChange = 10;
            this.BillowPersistance.TabIndex = 37;
            this.BillowPersistance.ToolTipText = "The persistence value controls the roughness of the Perlin noise. For best result" +
    "s, set the persistence to a number between 0.0 and 1.0.";
            this.BillowPersistance.Scroll += new System.EventHandler<System.EventArgs>(this.BillowPersistance_Scroll);
            // 
            // BillowLacunarity
            // 
            this.BillowLacunarity.AutoSize = true;
            this.BillowLacunarity.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BillowLacunarity.Label = "Lacunarity";
            this.BillowLacunarity.LargeChange = 100;
            this.BillowLacunarity.Location = new System.Drawing.Point(10, 30);
            this.BillowLacunarity.Margin = new System.Windows.Forms.Padding(1);
            this.BillowLacunarity.Maximum = 10;
            this.BillowLacunarity.Minimum = 0;
            this.BillowLacunarity.Name = "BillowLacunarity";
            this.BillowLacunarity.Size = new System.Drawing.Size(321, 20);
            this.BillowLacunarity.SmallChange = 10;
            this.BillowLacunarity.TabIndex = 36;
            this.BillowLacunarity.ToolTipText = "The lacunarity is the frequency multiplier between successive octaves. For best r" +
    "esults, set the lacunarity to a number between 1.5 and 3.5.";
            this.BillowLacunarity.Scroll += new System.EventHandler<System.EventArgs>(this.BillowLacunarity_Scroll);
            // 
            // BillowFrequency
            // 
            this.BillowFrequency.AutoSize = true;
            this.BillowFrequency.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BillowFrequency.Label = "Frequency";
            this.BillowFrequency.LargeChange = 100;
            this.BillowFrequency.Location = new System.Drawing.Point(10, 8);
            this.BillowFrequency.Margin = new System.Windows.Forms.Padding(1);
            this.BillowFrequency.Maximum = 10;
            this.BillowFrequency.Minimum = 0;
            this.BillowFrequency.Name = "BillowFrequency";
            this.BillowFrequency.Size = new System.Drawing.Size(321, 20);
            this.BillowFrequency.SmallChange = 10;
            this.BillowFrequency.TabIndex = 35;
            this.BillowFrequency.ToolTipText = "The frequency of the first octave.";
            this.BillowFrequency.Scroll += new System.EventHandler<System.EventArgs>(this.BillowFrequency_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 15);
            this.label2.TabIndex = 36;
            this.label2.Text = "Quality";
            // 
            // BillowQuality
            // 
            this.BillowQuality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BillowQuality.FormattingEnabled = true;
            this.BillowQuality.Location = new System.Drawing.Point(90, 98);
            this.BillowQuality.Name = "BillowQuality";
            this.BillowQuality.Size = new System.Drawing.Size(121, 23);
            this.BillowQuality.TabIndex = 35;
            this.BillowQuality.SelectedIndexChanged += new System.EventHandler(this.BillowQuality_SelectedIndexChanged);
            // 
            // CylinderConfigTabPage
            // 
            this.CylinderConfigTabPage.Controls.Add(this.CylinderFrequency);
            this.CylinderConfigTabPage.Location = new System.Drawing.Point(4, 24);
            this.CylinderConfigTabPage.Name = "CylinderConfigTabPage";
            this.CylinderConfigTabPage.Size = new System.Drawing.Size(426, 176);
            this.CylinderConfigTabPage.TabIndex = 2;
            this.CylinderConfigTabPage.Tag = "Cylinder";
            this.CylinderConfigTabPage.Text = "Cylinder";
            // 
            // CylinderFrequency
            // 
            this.CylinderFrequency.AutoSize = true;
            this.CylinderFrequency.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CylinderFrequency.Label = "Frequency";
            this.CylinderFrequency.LargeChange = 100;
            this.CylinderFrequency.Location = new System.Drawing.Point(13, 9);
            this.CylinderFrequency.Margin = new System.Windows.Forms.Padding(1);
            this.CylinderFrequency.Maximum = 10;
            this.CylinderFrequency.Minimum = 0;
            this.CylinderFrequency.Name = "CylinderFrequency";
            this.CylinderFrequency.Size = new System.Drawing.Size(321, 20);
            this.CylinderFrequency.SmallChange = 10;
            this.CylinderFrequency.TabIndex = 0;
            this.CylinderFrequency.ToolTipText = "";
            this.CylinderFrequency.Scroll += new System.EventHandler<System.EventArgs>(this.CylinderFrequency_Scroll);
            // 
            // CellConfigTabPage
            // 
            this.CellConfigTabPage.BackColor = System.Drawing.SystemColors.Control;
            this.CellConfigTabPage.Controls.Add(this.CellDisplacement);
            this.CellConfigTabPage.Controls.Add(this.CellFrequency);
            this.CellConfigTabPage.Controls.Add(this.CellTypeComboBox);
            this.CellConfigTabPage.Location = new System.Drawing.Point(4, 24);
            this.CellConfigTabPage.Name = "CellConfigTabPage";
            this.CellConfigTabPage.Size = new System.Drawing.Size(426, 176);
            this.CellConfigTabPage.TabIndex = 4;
            this.CellConfigTabPage.Text = "Cell";
            this.CellConfigTabPage.Tag = "Cell";

            // 
            // CellDisplacement
            // 
            this.CellDisplacement.AutoSize = true;
            this.CellDisplacement.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CellDisplacement.Label = "Lacunarity";
            this.CellDisplacement.LargeChange = 100;
            this.CellDisplacement.Location = new System.Drawing.Point(10, 30);
            this.CellDisplacement.Margin = new System.Windows.Forms.Padding(1);
            this.CellDisplacement.Maximum = 10;
            this.CellDisplacement.Minimum = 0;
            this.CellDisplacement.Name = "CellDisplacement";
            this.CellDisplacement.Size = new System.Drawing.Size(321, 20);
            this.CellDisplacement.SmallChange = 10;
            this.CellDisplacement.TabIndex = 34;
            this.CellDisplacement.ToolTipText = "The lacunarity is the frequency multiplier between successive octaves. For best r" +
    "esults, set the lacunarity to a number between 1.5 and 3.5.";
            this.CellDisplacement.Scroll += new System.EventHandler<System.EventArgs>(this.CellDisplacement_Scroll);

            // 
            // CellFrequency
            // 
            this.CellFrequency.AutoSize = true;
            this.CellFrequency.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CellFrequency.Label = "Frequency";
            this.CellFrequency.LargeChange = 100;
            this.CellFrequency.Location = new System.Drawing.Point(10, 8);
            this.CellFrequency.Margin = new System.Windows.Forms.Padding(1);
            this.CellFrequency.Maximum = 10;
            this.CellFrequency.Minimum = 0;
            this.CellFrequency.Name = "CellFrequency";
            this.CellFrequency.Size = new System.Drawing.Size(321, 20);
            this.CellFrequency.SmallChange = 10;
            this.CellFrequency.TabIndex = 33;
            this.CellFrequency.ToolTipText = "The frequency of the first octave.";
            this.CellFrequency.Scroll += new System.EventHandler<System.EventArgs>(this.CellFrequency_Scroll);

            // 
            // CellTypeComboBox
            // 
            this.CellTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CellTypeComboBox.FormattingEnabled = true;
            this.CellTypeComboBox.Location = new System.Drawing.Point(10, 52);
            this.CellTypeComboBox.Name = "CellTypeComboBox";
            this.CellTypeComboBox.Size = new System.Drawing.Size(400, 23);
            this.CellTypeComboBox.TabIndex = 1;
            this.CellTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.CellTypeComboBox_SelectedIndexChanged);

            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 455);
            this.Controls.Add(this.optionTabControl);
            this.Controls.Add(this.postProcessingGroupBox);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.NoiseTypeComboBox);
            this.Controls.Add(this.NoiseMapPreview);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.NoiseMapPreview)).EndInit();
            this.postProcessingGroupBox.ResumeLayout(false);
            this.postProcessingGroupBox.PerformLayout();
            this.optionTabControl.ResumeLayout(false);
            this.PerlinConfigTabPage.ResumeLayout(false);
            this.PerlinConfigTabPage.PerformLayout();
            this.BillowConfigTabPage.ResumeLayout(false);
            this.BillowConfigTabPage.PerformLayout();
            this.CylinderConfigTabPage.ResumeLayout(false);
            this.CylinderConfigTabPage.PerformLayout();
            this.CellConfigTabPage.ResumeLayout(false);
            this.CellConfigTabPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox NoiseMapPreview;
        private System.Windows.Forms.ComboBox NoiseTypeComboBox;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.GroupBox postProcessingGroupBox;
        private System.Windows.Forms.CheckBox Invert;
        private System.Windows.Forms.TabControl optionTabControl;
        private System.Windows.Forms.TabPage PerlinConfigTabPage;
        private System.Windows.Forms.CheckBox Round;
        public System.Windows.Forms.ToolTip toolTip1;
        private DecimalSlider PerlinFrequency;
        private DecimalSlider PerlinLacunarity;
        private DecimalSlider PerlinPersistance;
        private DecimalSlider PerlinOctaves;
        private System.Windows.Forms.CheckBox Grayscale;
        private DecimalSlider MinValue;
        private DecimalSlider MaxValue;
        private DecimalSlider NoiseScale;
        private System.Windows.Forms.TabPage CylinderConfigTabPage;
        private DecimalSlider CylinderFrequency;
        private System.Windows.Forms.TabPage BillowConfigTabPage;
        private DecimalSlider BillowOctaves;
        private DecimalSlider BillowPersistance;
        private DecimalSlider BillowLacunarity;
        private DecimalSlider BillowFrequency;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox PerlinQuality;
        private System.Windows.Forms.ComboBox BillowQuality;
        private System.Windows.Forms.TabPage CellConfigTabPage;
        private DecimalSlider CellDisplacement;
        private DecimalSlider CellFrequency;
        private System.Windows.Forms.ComboBox CellTypeComboBox { get; set; }
    }
}

