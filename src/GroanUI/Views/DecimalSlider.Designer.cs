
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
            this.TrackBar = new System.Windows.Forms.TrackBar();
            this.Caption = new System.Windows.Forms.Label();
            this.ValueLabel = new System.Windows.Forms.Label();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.TrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // TrackBar
            // 
            this.TrackBar.AutoSize = false;
            this.TrackBar.LargeChange = 100;
            this.TrackBar.Location = new System.Drawing.Point(114, -1);
            this.TrackBar.Name = "TrackBar";
            this.TrackBar.Size = new System.Drawing.Size(204, 18);
            this.TrackBar.SmallChange = 10;
            this.TrackBar.TabIndex = 24;
            this.TrackBar.TickFrequency = 100;
            this.TrackBar.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.TrackBar.Scroll += new System.EventHandler(this.TrackBar_Scroll);
            // 
            // Caption
            // 
            this.Caption.AutoSize = true;
            this.Caption.Location = new System.Drawing.Point(0, 2);
            this.Caption.Name = "Label";
            this.Caption.Size = new System.Drawing.Size(79, 15);
            this.Caption.TabIndex = 26;
            this.Caption.Text = "DecimalSlider";
            // 
            // ValueLabel
            // 
            this.ValueLabel.AutoSize = true;
            this.ValueLabel.Location = new System.Drawing.Point(80, 2);
            this.ValueLabel.Name = "ValueLabel";
            this.ValueLabel.Size = new System.Drawing.Size(28, 15);
            this.ValueLabel.TabIndex = 25;
            this.ValueLabel.Text = "1.00";
            // 
            // DecimalSlider
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.TrackBar);
            this.Controls.Add(this.Caption);
            this.Controls.Add(this.ValueLabel);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "DecimalSlider";
            this.Size = new System.Drawing.Size(321, 20);
            ((System.ComponentModel.ISupportInitialize)(this.TrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar TrackBar;
        private System.Windows.Forms.Label Caption;
        private System.Windows.Forms.Label ValueLabel;
        private System.Windows.Forms.ToolTip ToolTip;
    }
}
