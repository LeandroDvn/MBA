namespace Grafico
{
    partial class ChartForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Media.SolidColorBrush solidColorBrush1 = new System.Windows.Media.SolidColorBrush();
            this.cartesianChart1 = new LiveCharts.WinForms.CartesianChart();
            this.SuspendLayout();
            // 
            // cartesianChart1
            // 
            this.cartesianChart1.BackColor = System.Drawing.SystemColors.Window;
            this.cartesianChart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cartesianChart1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cartesianChart1.Hoverable = false;
            this.cartesianChart1.Location = new System.Drawing.Point(10, 10);
            this.cartesianChart1.Margin = new System.Windows.Forms.Padding(10);
            this.cartesianChart1.Name = "cartesianChart1";
            this.cartesianChart1.Padding = new System.Windows.Forms.Padding(10);
            this.cartesianChart1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            solidColorBrush1.Color = System.Windows.Media.Color.FromArgb(((byte)(30)), ((byte)(30)), ((byte)(30)), ((byte)(30)));
            this.cartesianChart1.ScrollBarFill = solidColorBrush1;
            this.cartesianChart1.ScrollHorizontalFrom = 0D;
            this.cartesianChart1.ScrollHorizontalTo = 0D;
            this.cartesianChart1.ScrollMode = LiveCharts.ScrollMode.XY;
            this.cartesianChart1.ScrollVerticalFrom = 0D;
            this.cartesianChart1.ScrollVerticalTo = 0D;
            this.cartesianChart1.Size = new System.Drawing.Size(1256, 460);
            this.cartesianChart1.TabIndex = 0;
            this.cartesianChart1.Text = "cartesianChart1";
            this.cartesianChart1.ChildChanged += new System.EventHandler<System.Windows.Forms.Integration.ChildChangedEventArgs>(this.cartesianChart1_ChildChanged);
            // 
            // ChartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1276, 480);
            this.Controls.Add(this.cartesianChart1);
            this.MinimizeBox = false;
            this.Name = "ChartForm";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Plotagem BigData";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private LiveCharts.WinForms.CartesianChart cartesianChart1;
    }
}

