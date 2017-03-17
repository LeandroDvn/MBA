namespace Grafico
{
    partial class LoadingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoadingForm));
            this.painel = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblCarregando = new System.Windows.Forms.Label();
            this.painel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // painel
            // 
            this.painel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.painel.Controls.Add(this.pictureBox1);
            this.painel.Controls.Add(this.lblCarregando);
            this.painel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.painel.Location = new System.Drawing.Point(0, 0);
            this.painel.Name = "painel";
            this.painel.Size = new System.Drawing.Size(185, 148);
            this.painel.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(4, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(179, 104);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // lblCarregando
            // 
            this.lblCarregando.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblCarregando.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblCarregando.Location = new System.Drawing.Point(0, 104);
            this.lblCarregando.Name = "lblCarregando";
            this.lblCarregando.Size = new System.Drawing.Size(185, 44);
            this.lblCarregando.TabIndex = 1;
            this.lblCarregando.Text = "Carregando";
            this.lblCarregando.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCarregando.Click += new System.EventHandler(this.lblCarregando_Click);
            // 
            // LoadingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(185, 148);
            this.Controls.Add(this.painel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoadingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Carregando Gráfico";
            this.painel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel painel;
        public System.Windows.Forms.Label lblCarregando;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}