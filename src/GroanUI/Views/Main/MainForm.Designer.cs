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
            this.previewPictureBox = new System.Windows.Forms.PictureBox();
            this.noiseTypeComboBox = new System.Windows.Forms.ComboBox();
            this.refreshButton = new System.Windows.Forms.Button();
            this.postProcessingGroupBox = new System.Windows.Forms.GroupBox();
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
            this.perlinScaleLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.perlinFrequencyValueLabel = new System.Windows.Forms.Label();
            this.perlinFrequency = new System.Windows.Forms.HScrollBar();
            this.perlinAmplitudeValueLabel = new System.Windows.Forms.Label();
            this.perlinAmplitude = new System.Windows.Forms.HScrollBar();
            this.label6 = new System.Windows.Forms.Label();
            this.perlinScale = new System.Windows.Forms.HScrollBar();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.previewPictureBox)).BeginInit();
            this.postProcessingGroupBox.SuspendLayout();
            this.optionTabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // previewPictureBox
            // 
            this.previewPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.previewPictureBox.Location = new System.Drawing.Point(22, 41);
            this.previewPictureBox.Name = "previewPictureBox";
            this.previewPictureBox.Size = new System.Drawing.Size(400, 400);
            this.previewPictureBox.TabIndex = 0;
            this.previewPictureBox.TabStop = false;
            // 
            // noiseTypeComboBox
            // 
            this.noiseTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.noiseTypeComboBox.FormattingEnabled = true;
            this.noiseTypeComboBox.Location = new System.Drawing.Point(22, 12);
            this.noiseTypeComboBox.Name = "noiseTypeComboBox";
            this.noiseTypeComboBox.Size = new System.Drawing.Size(400, 23);
            this.noiseTypeComboBox.TabIndex = 1;
            this.noiseTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.noiseTypeComboBox_SelectedIndexChanged);
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(819, 425);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(90, 27);
            this.refreshButton.TabIndex = 2;
            this.refreshButton.Text = "button1";
            this.refreshButton.UseVisualStyleBackColor = true;
            // 
            // postProcessingGroupBox
            // 
            this.postProcessingGroupBox.Controls.Add(this.oneBitCheckBox);
            this.postProcessingGroupBox.Controls.Add(this.maxThresholdValue);
            this.postProcessingGroupBox.Controls.Add(this.minThresholdValue);
            this.postProcessingGroupBox.Controls.Add(this.label4);
            this.postProcessingGroupBox.Controls.Add(this.label3);
            this.postProcessingGroupBox.Controls.Add(this.maxThreshold);
            this.postProcessingGroupBox.Controls.Add(this.minThreshold);
            this.postProcessingGroupBox.Controls.Add(this.invertNoiseMap);
            this.postProcessingGroupBox.Location = new System.Drawing.Point(444, 314);
            this.postProcessingGroupBox.Name = "postProcessingGroupBox";
            this.postProcessingGroupBox.Size = new System.Drawing.Size(433, 105);
            this.postProcessingGroupBox.TabIndex = 5;
            this.postProcessingGroupBox.TabStop = false;
            this.postProcessingGroupBox.Text = "Post processing options";
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
            this.oneBitCheckBox.CheckedChanged += new System.EventHandler(this.oneBitCheckBox_CheckedChanged);
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
            this.maxThreshold.Scroll += new System.Windows.Forms.ScrollEventHandler(this.maxThreshold_Scroll);
            // 
            // minThreshold
            // 
            this.minThreshold.Location = new System.Drawing.Point(121, 41);
            this.minThreshold.Maximum = 1000;
            this.minThreshold.Name = "minThreshold";
            this.minThreshold.Size = new System.Drawing.Size(214, 19);
            this.minThreshold.TabIndex = 5;
            this.minThreshold.Scroll += new System.Windows.Forms.ScrollEventHandler(this.minThreshold_Scroll);
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
            this.invertNoiseMap.CheckedChanged += new System.EventHandler(this.invertNoiseMap_CheckedChanged);
            // 
            // optionTabControl
            // 
            this.optionTabControl.Controls.Add(this.tabPage1);
            this.optionTabControl.Controls.Add(this.tabPage2);
            this.optionTabControl.Location = new System.Drawing.Point(442, 9);
            this.optionTabControl.Name = "optionTabControl";
            this.optionTabControl.SelectedIndex = 0;
            this.optionTabControl.Size = new System.Drawing.Size(434, 287);
            this.optionTabControl.TabIndex = 6;
            this.optionTabControl.SelectedIndexChanged += new System.EventHandler(this.optionTabControl_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(426, 259);
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
            this.tabPage2.Controls.Add(this.perlinScaleLabel);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.perlinFrequencyValueLabel);
            this.tabPage2.Controls.Add(this.perlinFrequency);
            this.tabPage2.Controls.Add(this.perlinAmplitudeValueLabel);
            this.tabPage2.Controls.Add(this.perlinAmplitude);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.perlinScale);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(426, 259);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Tag = "Perlin";
            this.tabPage2.Text = "Perlin";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // perlinScaleLabel
            // 
            this.perlinScaleLabel.AutoSize = true;
            this.perlinScaleLabel.BackColor = System.Drawing.Color.Transparent;
            this.perlinScaleLabel.Location = new System.Drawing.Point(217, 19);
            this.perlinScaleLabel.Name = "perlinScaleLabel";
            this.perlinScaleLabel.Size = new System.Drawing.Size(34, 15);
            this.perlinScaleLabel.TabIndex = 25;
            this.perlinScaleLabel.Text = "0.001";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 68);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 15);
            this.label7.TabIndex = 23;
            this.label7.Text = "Frequency";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 15);
            this.label5.TabIndex = 13;
            this.label5.Text = "Amplitude";
            // 
            // perlinFrequencyValueLabel
            // 
            this.perlinFrequencyValueLabel.AutoSize = true;
            this.perlinFrequencyValueLabel.Location = new System.Drawing.Point(218, 68);
            this.perlinFrequencyValueLabel.Name = "perlinFrequencyValueLabel";
            this.perlinFrequencyValueLabel.Size = new System.Drawing.Size(34, 15);
            this.perlinFrequencyValueLabel.TabIndex = 22;
            this.perlinFrequencyValueLabel.Text = "0.001";
            // 
            // perlinFrequency
            // 
            this.perlinFrequency.Location = new System.Drawing.Point(122, 64);
            this.perlinFrequency.Maximum = 1001;
            this.perlinFrequency.Name = "perlinFrequency";
            this.perlinFrequency.Size = new System.Drawing.Size(214, 19);
            this.perlinFrequency.TabIndex = 21;
            this.perlinFrequency.Value = 25;
            this.perlinFrequency.Scroll += new System.Windows.Forms.ScrollEventHandler(this.perlinFrequencyHScrollBar_Scroll);
            // 
            // perlinAmplitudeValueLabel
            // 
            this.perlinAmplitudeValueLabel.AutoSize = true;
            this.perlinAmplitudeValueLabel.Location = new System.Drawing.Point(217, 44);
            this.perlinAmplitudeValueLabel.Name = "perlinAmplitudeValueLabel";
            this.perlinAmplitudeValueLabel.Size = new System.Drawing.Size(34, 15);
            this.perlinAmplitudeValueLabel.TabIndex = 20;
            this.perlinAmplitudeValueLabel.Text = "0.001";
            // 
            // perlinAmplitude
            // 
            this.perlinAmplitude.Location = new System.Drawing.Point(121, 40);
            this.perlinAmplitude.Maximum = 1001;
            this.perlinAmplitude.Name = "perlinAmplitude";
            this.perlinAmplitude.Size = new System.Drawing.Size(214, 19);
            this.perlinAmplitude.TabIndex = 19;
            this.perlinAmplitude.Value = 25;
            this.perlinAmplitude.Scroll += new System.Windows.Forms.ScrollEventHandler(this.perlinAmplitudeHScrollBar_Scroll);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 15);
            this.label6.TabIndex = 12;
            this.label6.Text = "Scale";
            // 
            // perlinScale
            // 
            this.perlinScale.Location = new System.Drawing.Point(121, 15);
            this.perlinScale.Maximum = 1000;
            this.perlinScale.Name = "perlinScale";
            this.perlinScale.Size = new System.Drawing.Size(214, 19);
            this.perlinScale.TabIndex = 11;
            this.perlinScale.Value = 25;
            this.perlinScale.Scroll += new System.Windows.Forms.ScrollEventHandler(this.perlinScale_Scroll);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 478);
            this.Controls.Add(this.optionTabControl);
            this.Controls.Add(this.postProcessingGroupBox);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.noiseTypeComboBox);
            this.Controls.Add(this.previewPictureBox);
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.previewPictureBox)).EndInit();
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

        private System.Windows.Forms.PictureBox previewPictureBox;
        private System.Windows.Forms.ComboBox noiseTypeComboBox;
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
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.HScrollBar perlinScale;
        private System.Windows.Forms.CheckBox oneBitCheckBox;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label perlinFrequencyValueLabel;
        private System.Windows.Forms.HScrollBar perlinFrequency;
        private System.Windows.Forms.Label perlinAmplitudeValueLabel;
        private System.Windows.Forms.HScrollBar perlinAmplitude;
        private System.Windows.Forms.Label perlinScaleLabel;
    }
}

