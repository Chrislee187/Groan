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
            this.refreshButton = new System.Windows.Forms.Button();
            this.postProcessingGroupBox = new System.Windows.Forms.GroupBox();
            this.scaleLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.noiseScale = new System.Windows.Forms.HScrollBar();
            this.oneBitCheckBox = new System.Windows.Forms.CheckBox();
            this.maxThresholdValue = new System.Windows.Forms.Label();
            this.minThresholdValue = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.maxThreshold = new System.Windows.Forms.HScrollBar();
            this.minThreshold = new System.Windows.Forms.HScrollBar();
            this.invertNoiseMap = new System.Windows.Forms.CheckBox();
            this.optionTabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lacunaritySlider = new GroanUI.Views.DecimalSlider();
            this.perlinFrequency = new GroanUI.Views.DecimalSlider();
            this.yOffsetLabel = new System.Windows.Forms.Label();
            this.yOffset = new System.Windows.Forms.HScrollBar();
            this.label2 = new System.Windows.Forms.Label();
            this.xOffsetLabel = new System.Windows.Forms.Label();
            this.xOffset = new System.Windows.Forms.HScrollBar();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.NoiseMapPreview)).BeginInit();
            this.postProcessingGroupBox.SuspendLayout();
            this.optionTabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
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
            this.refreshButton.UseVisualStyleBackColor = true;
            // 
            // postProcessingGroupBox
            // 
            this.postProcessingGroupBox.Controls.Add(this.scaleLabel);
            this.postProcessingGroupBox.Controls.Add(this.label6);
            this.postProcessingGroupBox.Controls.Add(this.noiseScale);
            this.postProcessingGroupBox.Controls.Add(this.oneBitCheckBox);
            this.postProcessingGroupBox.Controls.Add(this.maxThresholdValue);
            this.postProcessingGroupBox.Controls.Add(this.minThresholdValue);
            this.postProcessingGroupBox.Controls.Add(this.label4);
            this.postProcessingGroupBox.Controls.Add(this.label3);
            this.postProcessingGroupBox.Controls.Add(this.maxThreshold);
            this.postProcessingGroupBox.Controls.Add(this.minThreshold);
            this.postProcessingGroupBox.Controls.Add(this.invertNoiseMap);
            this.postProcessingGroupBox.Location = new System.Drawing.Point(442, 219);
            this.postProcessingGroupBox.Name = "postProcessingGroupBox";
            this.postProcessingGroupBox.Size = new System.Drawing.Size(433, 189);
            this.postProcessingGroupBox.TabIndex = 5;
            this.postProcessingGroupBox.TabStop = false;
            this.postProcessingGroupBox.Text = "Post processing options";
            // 
            // scaleLabel
            // 
            this.scaleLabel.AutoSize = true;
            this.scaleLabel.BackColor = System.Drawing.Color.Transparent;
            this.scaleLabel.Location = new System.Drawing.Point(219, 97);
            this.scaleLabel.Name = "scaleLabel";
            this.scaleLabel.Size = new System.Drawing.Size(34, 15);
            this.scaleLabel.TabIndex = 28;
            this.scaleLabel.Text = "0.001";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 97);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 15);
            this.label6.TabIndex = 27;
            this.label6.Text = "NoiseScale";
            // 
            // noiseScale
            // 
            this.noiseScale.Location = new System.Drawing.Point(121, 93);
            this.noiseScale.Maximum = 100000;
            this.noiseScale.Minimum = 1;
            this.noiseScale.Name = "noiseScale";
            this.noiseScale.Size = new System.Drawing.Size(214, 19);
            this.noiseScale.TabIndex = 26;
            this.noiseScale.Value = 25;
            // 
            // oneBitCheckBox
            // 
            this.oneBitCheckBox.AutoSize = true;
            this.oneBitCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.oneBitCheckBox.Location = new System.Drawing.Point(68, 22);
            this.oneBitCheckBox.Name = "oneBitCheckBox";
            this.oneBitCheckBox.Size = new System.Drawing.Size(67, 19);
            this.oneBitCheckBox.TabIndex = 12;
            this.oneBitCheckBox.Text = "One-bit";
            this.toolTip1.SetToolTip(this.oneBitCheckBox, "Make the value 0 or 1 before converting to a Color");
            this.oneBitCheckBox.UseVisualStyleBackColor = true;
            this.oneBitCheckBox.CheckedChanged += new System.EventHandler(this.OneBitCheckBox_CheckedChanged);
            // 
            // maxThresholdValue
            // 
            this.maxThresholdValue.AutoSize = true;
            this.maxThresholdValue.Location = new System.Drawing.Point(219, 68);
            this.maxThresholdValue.Name = "maxThresholdValue";
            this.maxThresholdValue.Size = new System.Drawing.Size(34, 15);
            this.maxThresholdValue.TabIndex = 11;
            this.maxThresholdValue.Text = "1.000";
            // 
            // minThresholdValue
            // 
            this.minThresholdValue.AutoSize = true;
            this.minThresholdValue.Location = new System.Drawing.Point(219, 45);
            this.minThresholdValue.Name = "minThresholdValue";
            this.minThresholdValue.Size = new System.Drawing.Size(34, 15);
            this.minThresholdValue.TabIndex = 10;
            this.minThresholdValue.Text = "0.001";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Maxium Threshold";
            this.toolTip1.SetToolTip(this.label4, "Values above this will be set to 1 for the plot");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Minium Threshold";
            this.toolTip1.SetToolTip(this.label3, "Values below this will be set to zero for the plot");
            // 
            // maxThreshold
            // 
            this.maxThreshold.Location = new System.Drawing.Point(121, 64);
            this.maxThreshold.Maximum = 1000;
            this.maxThreshold.Name = "maxThreshold";
            this.maxThreshold.Size = new System.Drawing.Size(214, 19);
            this.maxThreshold.TabIndex = 6;
            this.maxThreshold.Value = 1000;
            this.maxThreshold.Scroll += new System.Windows.Forms.ScrollEventHandler(this.MaxThreshold_Scroll);
            // 
            // minThreshold
            // 
            this.minThreshold.Location = new System.Drawing.Point(121, 41);
            this.minThreshold.Maximum = 1000;
            this.minThreshold.Name = "minThreshold";
            this.minThreshold.Size = new System.Drawing.Size(214, 19);
            this.minThreshold.TabIndex = 5;
            this.minThreshold.Scroll += new System.Windows.Forms.ScrollEventHandler(this.MinThreshold_Scroll);
            // 
            // invertNoiseMap
            // 
            this.invertNoiseMap.AutoSize = true;
            this.invertNoiseMap.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.invertNoiseMap.Location = new System.Drawing.Point(6, 22);
            this.invertNoiseMap.Name = "invertNoiseMap";
            this.invertNoiseMap.Size = new System.Drawing.Size(56, 19);
            this.invertNoiseMap.TabIndex = 4;
            this.invertNoiseMap.Text = "Invert";
            this.toolTip1.SetToolTip(this.invertNoiseMap, "Invert the plot value before converting to Color");
            this.invertNoiseMap.UseVisualStyleBackColor = true;
            this.invertNoiseMap.CheckedChanged += new System.EventHandler(this.InvertNoiseMap_CheckedChanged);
            // 
            // optionTabControl
            // 
            this.optionTabControl.Controls.Add(this.tabPage1);
            this.optionTabControl.Controls.Add(this.tabPage2);
            this.optionTabControl.Location = new System.Drawing.Point(442, 9);
            this.optionTabControl.Name = "optionTabControl";
            this.optionTabControl.SelectedIndex = 0;
            this.optionTabControl.Size = new System.Drawing.Size(434, 204);
            this.optionTabControl.TabIndex = 6;
            this.optionTabControl.SelectedIndexChanged += new System.EventHandler(this.OptionTabControl_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(426, 176);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Default";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(119, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "No additional options";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.lacunaritySlider);
            this.tabPage2.Controls.Add(this.perlinFrequency);
            this.tabPage2.Controls.Add(this.yOffsetLabel);
            this.tabPage2.Controls.Add(this.yOffset);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.xOffsetLabel);
            this.tabPage2.Controls.Add(this.xOffset);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(426, 176);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Tag = "Perlin";
            this.tabPage2.Text = "Perlin";
            // 
            // lacunaritySlider
            // 
            this.lacunaritySlider.AutoSize = true;
            this.lacunaritySlider.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.lacunaritySlider.Label = "Lacunarity";
            this.lacunaritySlider.LargeChange = 100;
            this.lacunaritySlider.Location = new System.Drawing.Point(10, 30);
            this.lacunaritySlider.Margin = new System.Windows.Forms.Padding(1);
            this.lacunaritySlider.Maximum = 10;
            this.lacunaritySlider.Minimum = 0;
            this.lacunaritySlider.Name = "lacunaritySlider";
            this.lacunaritySlider.Size = new System.Drawing.Size(321, 20);
            this.lacunaritySlider.SmallChange = 10;
            this.lacunaritySlider.TabIndex = 32;
            this.toolTip1.SetToolTip(this.lacunaritySlider, "asdasd");
            this.lacunaritySlider.ToolTipText = "The lacunarity is the frequency multiplier between successive octaves. For best r" +
    "esults, set the lacunarity to a number between 1.5 and 3.5.";
            this.lacunaritySlider.Scroll += new System.EventHandler<System.EventArgs>(this.LacunaritySlider_Scroll);
            // 
            // perlinFrequency
            // 
            this.perlinFrequency.AutoSize = true;
            this.perlinFrequency.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.perlinFrequency.Label = "Frequency";
            this.perlinFrequency.LargeChange = 100;
            this.perlinFrequency.Location = new System.Drawing.Point(10, 8);
            this.perlinFrequency.Margin = new System.Windows.Forms.Padding(1);
            this.perlinFrequency.Maximum = 10;
            this.perlinFrequency.Minimum = 0;
            this.perlinFrequency.Name = "perlinFrequency";
            this.perlinFrequency.Size = new System.Drawing.Size(321, 20);
            this.perlinFrequency.SmallChange = 10;
            this.perlinFrequency.TabIndex = 31;
            this.perlinFrequency.ToolTipText = "Gets or sets the frequency of the first octave.";
            this.perlinFrequency.Scroll += new System.EventHandler<System.EventArgs>(this.PerlinFrequency_Scroll);
            // 
            // yOffsetLabel
            // 
            this.yOffsetLabel.AutoSize = true;
            this.yOffsetLabel.Location = new System.Drawing.Point(288, 147);
            this.yOffsetLabel.Name = "yOffsetLabel";
            this.yOffsetLabel.Size = new System.Drawing.Size(34, 15);
            this.yOffsetLabel.TabIndex = 30;
            this.yOffsetLabel.Text = "0.001";
            // 
            // yOffset
            // 
            this.yOffset.Location = new System.Drawing.Point(243, 143);
            this.yOffset.Maximum = 1001;
            this.yOffset.Name = "yOffset";
            this.yOffset.Size = new System.Drawing.Size(105, 19);
            this.yOffset.TabIndex = 29;
            this.yOffset.Value = 25;
            this.yOffset.Scroll += new System.Windows.Forms.ScrollEventHandler(this.YOffset_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 15);
            this.label2.TabIndex = 28;
            this.label2.Text = "Offset";
            // 
            // xOffsetLabel
            // 
            this.xOffsetLabel.AutoSize = true;
            this.xOffsetLabel.Location = new System.Drawing.Point(179, 147);
            this.xOffsetLabel.Name = "xOffsetLabel";
            this.xOffsetLabel.Size = new System.Drawing.Size(34, 15);
            this.xOffsetLabel.TabIndex = 27;
            this.xOffsetLabel.Text = "0.001";
            // 
            // xOffset
            // 
            this.xOffset.Location = new System.Drawing.Point(134, 143);
            this.xOffset.Maximum = 1001;
            this.xOffset.Name = "xOffset";
            this.xOffset.Size = new System.Drawing.Size(105, 19);
            this.xOffset.TabIndex = 26;
            this.xOffset.Value = 25;
            this.xOffset.Scroll += new System.Windows.Forms.ScrollEventHandler(this.XOffset_Scroll);
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
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox NoiseMapPreview;
        private System.Windows.Forms.ComboBox NoiseTypeComboBox;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.GroupBox postProcessingGroupBox;
        private System.Windows.Forms.CheckBox invertNoiseMap;
        private System.Windows.Forms.TabControl optionTabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.HScrollBar minThreshold;
        private System.Windows.Forms.HScrollBar maxThreshold;
        private System.Windows.Forms.Label minThresholdValue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label maxThresholdValue;
        private System.Windows.Forms.CheckBox oneBitCheckBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label xOffsetLabel;
        private System.Windows.Forms.HScrollBar xOffset;
        private System.Windows.Forms.Label yOffsetLabel;
        private System.Windows.Forms.HScrollBar yOffset;
        private System.Windows.Forms.Label scaleLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.HScrollBar noiseScale;
        private DecimalSlider perlinFrequency;
        public System.Windows.Forms.ToolTip toolTip1;
        private DecimalSlider lacunaritySlider;
    }
}

