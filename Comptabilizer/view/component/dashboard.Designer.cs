namespace Comptabilizer.view.component
{
    partial class dashboard
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.rightPanelContainer = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.dashMenuBarPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.Logo = new System.Windows.Forms.PictureBox();
            this.ToolMenuPanel = new System.Windows.Forms.Panel();
            this.ToolPanel = new System.Windows.Forms.Panel();
            this.addFactureButton = new System.Windows.Forms.PictureBox();
            this.settingsButton = new System.Windows.Forms.PictureBox();
            this.NomUtilisateur = new System.Windows.Forms.Label();
            this.Avatar = new System.Windows.Forms.PictureBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.FacContainerPanel = new System.Windows.Forms.Panel();
            this.rightPanelContainer.SuspendLayout();
            this.dashMenuBarPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).BeginInit();
            this.ToolMenuPanel.SuspendLayout();
            this.ToolPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.addFactureButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.settingsButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Avatar)).BeginInit();
            this.SuspendLayout();
            // 
            // rightPanelContainer
            // 
            this.rightPanelContainer.Controls.Add(this.panel1);
            this.rightPanelContainer.Controls.Add(this.flowLayoutPanel1);
            this.rightPanelContainer.Controls.Add(this.dashMenuBarPanel);
            this.rightPanelContainer.Dock = System.Windows.Forms.DockStyle.Left;
            this.rightPanelContainer.Location = new System.Drawing.Point(0, 0);
            this.rightPanelContainer.Name = "rightPanelContainer";
            this.rightPanelContainer.Size = new System.Drawing.Size(360, 720);
            this.rightPanelContainer.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSlateGray;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 678);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(360, 42);
            this.panel1.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.PaleVioletRed;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 117);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(360, 603);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // dashMenuBarPanel
            // 
            this.dashMenuBarPanel.BackColor = System.Drawing.Color.Crimson;
            this.dashMenuBarPanel.Controls.Add(this.label1);
            this.dashMenuBarPanel.Controls.Add(this.Logo);
            this.dashMenuBarPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.dashMenuBarPanel.Location = new System.Drawing.Point(0, 0);
            this.dashMenuBarPanel.Name = "dashMenuBarPanel";
            this.dashMenuBarPanel.Size = new System.Drawing.Size(360, 117);
            this.dashMenuBarPanel.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe Script", 14F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(123, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 46);
            this.label1.TabIndex = 1;
            this.label1.Text = "Comptabilizer";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Logo
            // 
            this.Logo.Dock = System.Windows.Forms.DockStyle.Left;
            this.Logo.Image = global::Comptabilizer.Properties.Resources.moneyBag;
            this.Logo.Location = new System.Drawing.Point(0, 0);
            this.Logo.Name = "Logo";
            this.Logo.Padding = new System.Windows.Forms.Padding(10);
            this.Logo.Size = new System.Drawing.Size(117, 117);
            this.Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Logo.TabIndex = 0;
            this.Logo.TabStop = false;
            // 
            // ToolMenuPanel
            // 
            this.ToolMenuPanel.Controls.Add(this.ToolPanel);
            this.ToolMenuPanel.Controls.Add(this.NomUtilisateur);
            this.ToolMenuPanel.Controls.Add(this.Avatar);
            this.ToolMenuPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ToolMenuPanel.Location = new System.Drawing.Point(360, 0);
            this.ToolMenuPanel.Name = "ToolMenuPanel";
            this.ToolMenuPanel.Size = new System.Drawing.Size(920, 117);
            this.ToolMenuPanel.TabIndex = 1;
            // 
            // ToolPanel
            // 
            this.ToolPanel.Controls.Add(this.addFactureButton);
            this.ToolPanel.Controls.Add(this.settingsButton);
            this.ToolPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.ToolPanel.Location = new System.Drawing.Point(553, 0);
            this.ToolPanel.Name = "ToolPanel";
            this.ToolPanel.Size = new System.Drawing.Size(367, 117);
            this.ToolPanel.TabIndex = 2;
            // 
            // addFactureButton
            // 
            this.addFactureButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.addFactureButton.Image = global::Comptabilizer.Properties.Resources.add;
            this.addFactureButton.Location = new System.Drawing.Point(133, 0);
            this.addFactureButton.Name = "addFactureButton";
            this.addFactureButton.Padding = new System.Windows.Forms.Padding(20);
            this.addFactureButton.Size = new System.Drawing.Size(117, 117);
            this.addFactureButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.addFactureButton.TabIndex = 1;
            this.addFactureButton.TabStop = false;
            // 
            // settingsButton
            // 
            this.settingsButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.settingsButton.Image = global::Comptabilizer.Properties.Resources.settings;
            this.settingsButton.Location = new System.Drawing.Point(250, 0);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Padding = new System.Windows.Forms.Padding(20);
            this.settingsButton.Size = new System.Drawing.Size(117, 117);
            this.settingsButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.settingsButton.TabIndex = 0;
            this.settingsButton.TabStop = false;
            // 
            // NomUtilisateur
            // 
            this.NomUtilisateur.AutoSize = true;
            this.NomUtilisateur.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NomUtilisateur.Location = new System.Drawing.Point(123, 44);
            this.NomUtilisateur.Name = "NomUtilisateur";
            this.NomUtilisateur.Size = new System.Drawing.Size(211, 38);
            this.NomUtilisateur.TabIndex = 1;
            this.NomUtilisateur.Text = "Nom Utilisateur";
            // 
            // Avatar
            // 
            this.Avatar.Dock = System.Windows.Forms.DockStyle.Left;
            this.Avatar.Image = global::Comptabilizer.Properties.Resources.user;
            this.Avatar.Location = new System.Drawing.Point(0, 0);
            this.Avatar.Name = "Avatar";
            this.Avatar.Padding = new System.Windows.Forms.Padding(10);
            this.Avatar.Size = new System.Drawing.Size(117, 117);
            this.Avatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Avatar.TabIndex = 0;
            this.Avatar.TabStop = false;
            // 
            // FacContainerPanel
            // 
            this.FacContainerPanel.AutoScroll = true;
            this.FacContainerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FacContainerPanel.Location = new System.Drawing.Point(360, 117);
            this.FacContainerPanel.Name = "FacContainerPanel";
            this.FacContainerPanel.Size = new System.Drawing.Size(920, 603);
            this.FacContainerPanel.TabIndex = 2;
            // 
            // dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.FacContainerPanel);
            this.Controls.Add(this.ToolMenuPanel);
            this.Controls.Add(this.rightPanelContainer);
            this.Name = "dashboard";
            this.Size = new System.Drawing.Size(1280, 720);
            this.rightPanelContainer.ResumeLayout(false);
            this.dashMenuBarPanel.ResumeLayout(false);
            this.dashMenuBarPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).EndInit();
            this.ToolMenuPanel.ResumeLayout(false);
            this.ToolMenuPanel.PerformLayout();
            this.ToolPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.addFactureButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.settingsButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Avatar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel rightPanelContainer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel dashMenuBarPanel;
        private System.Windows.Forms.PictureBox Logo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel ToolMenuPanel;
        private System.Windows.Forms.PictureBox Avatar;
        private System.Windows.Forms.Panel ToolPanel;
        private System.Windows.Forms.PictureBox addFactureButton;
        private System.Windows.Forms.PictureBox settingsButton;
        private System.Windows.Forms.Label NomUtilisateur;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel FacContainerPanel;
    }
}
