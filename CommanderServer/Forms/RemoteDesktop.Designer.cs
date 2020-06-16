namespace CommanderServer.Forms
{
    partial class RemoteDesktop
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
            this.remoteDesktopServer1 = new FormApp.Dialogs.RemoteDesktopServer();
            ((System.ComponentModel.ISupportInitialize)(this.remoteDesktopServer1)).BeginInit();
            this.SuspendLayout();
            // 
            // remoteDesktopServer1
            // 
            this.remoteDesktopServer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.remoteDesktopServer1.Location = new System.Drawing.Point(0, 0);
            this.remoteDesktopServer1.ManualHandling = true;
            this.remoteDesktopServer1.Name = "remoteDesktopServer1";
            this.remoteDesktopServer1.Port = 54782;
            this.remoteDesktopServer1.Size = new System.Drawing.Size(800, 450);
            this.remoteDesktopServer1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.remoteDesktopServer1.TabIndex = 0;
            this.remoteDesktopServer1.TabStop = false;
            // 
            // RemoteDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.remoteDesktopServer1);
            this.Name = "RemoteDesktop";
            this.Text = "RemoteDesktop";
            this.Load += new System.EventHandler(this.RemoteDesktop_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RemoteDesktop_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.remoteDesktopServer1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FormApp.Dialogs.RemoteDesktopServer remoteDesktopServer1;
    }
}