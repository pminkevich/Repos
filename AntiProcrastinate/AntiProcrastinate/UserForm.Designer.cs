namespace AntiProcrastinate
{
    partial class UserForm
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserForm));
            this.Reproductor = new System.Windows.Forms.WebBrowser();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblComienza = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblDesafio = new System.Windows.Forms.Label();
            this.lblSeg = new System.Windows.Forms.Label();
            this.lblTiempo = new System.Windows.Forms.Label();
            this.TimerPanel = new System.Windows.Forms.Timer(this.components);
            this.TimerVideo = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Reproductor
            // 
            this.Reproductor.AllowNavigation = false;
            this.Reproductor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Reproductor.Location = new System.Drawing.Point(0, 0);
            this.Reproductor.MinimumSize = new System.Drawing.Size(20, 20);
            this.Reproductor.Name = "Reproductor";
            this.Reproductor.Size = new System.Drawing.Size(592, 450);
            this.Reproductor.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.lblSeg);
            this.panel1.Controls.Add(this.lblComienza);
            this.panel1.Controls.Add(this.lblTitulo);
            this.panel1.Controls.Add(this.lblTiempo);
            this.panel1.Controls.Add(this.lblDesafio);
            this.panel1.Location = new System.Drawing.Point(0, 175);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(592, 167);
            this.panel1.TabIndex = 2;
            this.panel1.Visible = false;
            // 
            // lblComienza
            // 
            this.lblComienza.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lblComienza.AutoSize = true;
            this.lblComienza.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComienza.ForeColor = System.Drawing.Color.Black;
            this.lblComienza.Location = new System.Drawing.Point(196, 123);
            this.lblComienza.Name = "lblComienza";
            this.lblComienza.Size = new System.Drawing.Size(133, 24);
            this.lblComienza.TabIndex = 0;
            this.lblComienza.Text = "Comienza en";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.Black;
            this.lblTitulo.Location = new System.Drawing.Point(3, 59);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(104, 20);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "titulo video";
            // 
            // lblDesafio
            // 
            this.lblDesafio.AutoSize = true;
            this.lblDesafio.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesafio.ForeColor = System.Drawing.Color.Red;
            this.lblDesafio.Location = new System.Drawing.Point(12, 12);
            this.lblDesafio.Name = "lblDesafio";
            this.lblDesafio.Size = new System.Drawing.Size(150, 24);
            this.lblDesafio.TabIndex = 0;
            this.lblDesafio.Text = "Nuevo Desafio";
            // 
            // lblSeg
            // 
            this.lblSeg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lblSeg.AutoSize = true;
            this.lblSeg.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeg.ForeColor = System.Drawing.Color.Black;
            this.lblSeg.Location = new System.Drawing.Point(335, 123);
            this.lblSeg.Name = "lblSeg";
            this.lblSeg.Size = new System.Drawing.Size(22, 24);
            this.lblSeg.TabIndex = 0;
            this.lblSeg.Text = "3";
            // 
            // lblTiempo
            // 
            this.lblTiempo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTiempo.AutoSize = true;
            this.lblTiempo.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTiempo.ForeColor = System.Drawing.Color.Red;
            this.lblTiempo.Location = new System.Drawing.Point(537, 12);
            this.lblTiempo.Name = "lblTiempo";
            this.lblTiempo.Size = new System.Drawing.Size(22, 24);
            this.lblTiempo.TabIndex = 0;
            this.lblTiempo.Text = "0";
            // 
            // TimerPanel
            // 
            this.TimerPanel.Interval = 1000;
            this.TimerPanel.Tick += new System.EventHandler(this.TimerPanel_Tick);
            // 
            // TimerVideo
            // 
            this.TimerVideo.Interval = 1000;
            this.TimerVideo.Tick += new System.EventHandler(this.TimerVideo_Tick);
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 450);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Reproductor);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UserForm";
            this.Text = "Anti Procrastine";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.UserForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.WebBrowser Reproductor;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblDesafio;
        private System.Windows.Forms.Label lblComienza;
        private System.Windows.Forms.Label lblSeg;
        private System.Windows.Forms.Label lblTiempo;
        private System.Windows.Forms.Timer TimerPanel;
        private System.Windows.Forms.Timer TimerVideo;
    }
}

