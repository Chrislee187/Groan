
namespace GroanUI.Views
{
    partial class DecimalSlider
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.slider = new System.Windows.Forms.TrackBar();
            this.label = new System.Windows.Forms.Label();
            this.valueLabel = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.slider)).BeginInit();
            this.SuspendLayout();
            // 
            // slider
            // 
            this.slider.AutoSize = false;
            this.slider.LargeChange = 100;
            this.slider.Location = new System.Drawing.Point(114, -1);
            this.slider.Name = "slider";
            this.slider.Size = new System.Drawing.Size(204, 18);
            this.slider.SmallChange = 10;
            this.slider.TabIndex = 24;
            this.slider.TickFrequency = 100;
            this.slider.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.slider.Scroll += new System.EventHandler(this.trackbar_Scroll);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(0, 2);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(79, 15);
            this.label.TabIndex = 26;
            this.label.Text = "DecimalSlider";
            // 
            // valueLabel
            // 
            this.valueLabel.AutoSize = true;
            this.valueLabel.Location = new System.Drawing.Point(80, 2);
            this.valueLabel.Name = "valueLabel";
            this.valueLabel.Size = new System.Drawing.Size(28, 15);
            this.valueLabel.TabIndex = 25;
            this.valueLabel.Text = "1.00";
            // 
            // DecimalSlider
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.slider);
            this.Controls.Add(this.label);
            this.Controls.Add(this.valueLabel);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "DecimalSlider";
            this.Size = new System.Drawing.Size(321, 20);
            ((System.ComponentModel.ISupportInitialize)(this.slider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar slider;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label valueLabel;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
