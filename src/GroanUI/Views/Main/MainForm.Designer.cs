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
            this.NoiseScale = new GroanUI.Views.DecimalSlider();
            this.MaxValue = new GroanUI.Views.DecimalSlider();
            this.MinValue = new GroanUI.Views.DecimalSlider();
            this.Grayscale = new System.Windows.Forms.CheckBox();
            this.Round = new System.Windows.Forms.CheckBox();
            this.Invert = new System.Windows.Forms.CheckBox();
            this.optionTabControl = new System.Windows.Forms.TabControl();
            this.PerlinConfigTabPage = new System.Windows.Forms.TabPage();
            this.Octaves = new GroanUI.Views.DecimalSlider();
            this.Persistance = new GroanUI.Views.DecimalSlider();
            this.Lacunarity = new GroanUI.Views.DecimalSlider();
            this.Frequency = new GroanUI.Views.DecimalSlider();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.NoiseMapPreview)).BeginInit();
            this.postProcessingGroupBox.SuspendLayout();
            this.optionTabControl.SuspendLayout();
            this.PerlinConfigTabPage.SuspendLayout();
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
            this.refreshButton.UseVisualStyleBackColor = true;
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
            this.Grayscale.UseVisualStyleBackColor = true;
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
            this.Round.UseVisualStyleBackColor = true;
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
            this.Invert.UseVisualStyleBackColor = true;
            this.Invert.CheckedChanged += new System.EventHandler(this.Invert_CheckedChanged);
            // 
            // optionTabControl
            // 
            this.optionTabControl.Controls.Add(this.PerlinConfigTabPage);
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
            this.PerlinConfigTabPage.Controls.Add(this.Octaves);
            this.PerlinConfigTabPage.Controls.Add(this.Persistance);
            this.PerlinConfigTabPage.Controls.Add(this.Lacunarity);
            this.PerlinConfigTabPage.Controls.Add(this.Frequency);
            this.PerlinConfigTabPage.Location = new System.Drawing.Point(4, 24);
            this.PerlinConfigTabPage.Name = "PerlinConfigTabPage";
            this.PerlinConfigTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.PerlinConfigTabPage.Size = new System.Drawing.Size(426, 176);
            this.PerlinConfigTabPage.TabIndex = 1;
            this.PerlinConfigTabPage.Tag = "Perlin, Billow";
            this.PerlinConfigTabPage.Text = "Perlin";
            // 
            // Octaves
            // 
            this.Octaves.AutoSize = true;
            this.Octaves.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Octaves.Label = "Octaves";
            this.Octaves.LargeChange = 100;
            this.Octaves.Location = new System.Drawing.Point(10, 74);
            this.Octaves.Margin = new System.Windows.Forms.Padding(1);
            this.Octaves.Maximum = 10;
            this.Octaves.Minimum = 0;
            this.Octaves.Name = "Octaves";
            this.Octaves.Size = new System.Drawing.Size(321, 20);
            this.Octaves.SmallChange = 10;
            this.Octaves.TabIndex = 34;
            this.Octaves.ToolTipText = "The number of octaves controls the amount of detail in the Perlin noise. The larg" +
    "er the number of octaves, the more time required to calculate the Perlin-noise v" +
    "alue.";
            this.Octaves.Scroll += new System.EventHandler<System.EventArgs>(this.Octaves_Scroll);
            // 
            // Persistance
            // 
            this.Persistance.AutoSize = true;
            this.Persistance.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Persistance.Label = "Persistance";
            this.Persistance.LargeChange = 100;
            this.Persistance.Location = new System.Drawing.Point(10, 52);
            this.Persistance.Margin = new System.Windows.Forms.Padding(1);
            this.Persistance.Maximum = 10;
            this.Persistance.Minimum = 0;
            this.Persistance.Name = "Persistance";
            this.Persistance.Size = new System.Drawing.Size(321, 20);
            this.Persistance.SmallChange = 10;
            this.Persistance.TabIndex = 33;
            this.Persistance.ToolTipText = "The persistence value controls the roughness of the Perlin noise. For best result" +
    "s, set the persistence to a number between 0.0 and 1.0.";
            this.Persistance.Scroll += new System.EventHandler<System.EventArgs>(this.Persistance_Scroll);
            // 
            // Lacunarity
            // 
            this.Lacunarity.AutoSize = true;
            this.Lacunarity.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Lacunarity.Label = "Lacunarity";
            this.Lacunarity.LargeChange = 100;
            this.Lacunarity.Location = new System.Drawing.Point(10, 30);
            this.Lacunarity.Margin = new System.Windows.Forms.Padding(1);
            this.Lacunarity.Maximum = 10;
            this.Lacunarity.Minimum = 0;
            this.Lacunarity.Name = "Lacunarity";
            this.Lacunarity.Size = new System.Drawing.Size(321, 20);
            this.Lacunarity.SmallChange = 10;
            this.Lacunarity.TabIndex = 32;
            this.Lacunarity.ToolTipText = "The lacunarity is the frequency multiplier between successive octaves. For best r" +
    "esults, set the lacunarity to a number between 1.5 and 3.5.";
            this.Lacunarity.Scroll += new System.EventHandler<System.EventArgs>(this.Lacunarity_Scroll);
            // 
            // Frequency
            // 
            this.Frequency.AutoSize = true;
            this.Frequency.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Frequency.Label = "Frequency";
            this.Frequency.LargeChange = 100;
            this.Frequency.Location = new System.Drawing.Point(10, 8);
            this.Frequency.Margin = new System.Windows.Forms.Padding(1);
            this.Frequency.Maximum = 10;
            this.Frequency.Minimum = 0;
            this.Frequency.Name = "Frequency";
            this.Frequency.Size = new System.Drawing.Size(321, 20);
            this.Frequency.SmallChange = 10;
            this.Frequency.TabIndex = 31;
            this.Frequency.ToolTipText = "The frequency of the first octave.";
            this.Frequency.Scroll += new System.EventHandler<System.EventArgs>(this.Frequency_Scroll);
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
        private DecimalSlider Frequency;
        private DecimalSlider Lacunarity;
        private DecimalSlider Persistance;
        private DecimalSlider Octaves;
        private System.Windows.Forms.CheckBox Grayscale;
        private DecimalSlider MinValue;
        private DecimalSlider MaxValue;
        private DecimalSlider NoiseScale;
    }
}

