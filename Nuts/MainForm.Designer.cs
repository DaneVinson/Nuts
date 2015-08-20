namespace Nuts
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.resetButton = new System.Windows.Forms.Button();
            this.debuggerButton = new System.Windows.Forms.Button();
            this.assembliesButton = new System.Windows.Forms.Button();
            this.updateButton = new System.Windows.Forms.Button();
            this.checkButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.messageArea = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.resetButton);
            this.panel1.Controls.Add(this.debuggerButton);
            this.panel1.Controls.Add(this.assembliesButton);
            this.panel1.Controls.Add(this.updateButton);
            this.panel1.Controls.Add(this.checkButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(784, 50);
            this.panel1.TabIndex = 0;
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(381, 12);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(117, 23);
            this.resetButton.TabIndex = 3;
            this.resetButton.Text = "Clear Messages";
            this.resetButton.UseVisualStyleBackColor = true;
            // 
            // debuggerButton
            // 
            this.debuggerButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.debuggerButton.Location = new System.Drawing.Point(655, 12);
            this.debuggerButton.Name = "debuggerButton";
            this.debuggerButton.Size = new System.Drawing.Size(117, 23);
            this.debuggerButton.TabIndex = 4;
            this.debuggerButton.Text = "Debugger";
            this.debuggerButton.UseVisualStyleBackColor = true;
            // 
            // assembliesButton
            // 
            this.assembliesButton.Location = new System.Drawing.Point(258, 12);
            this.assembliesButton.Name = "assembliesButton";
            this.assembliesButton.Size = new System.Drawing.Size(117, 23);
            this.assembliesButton.TabIndex = 2;
            this.assembliesButton.Text = "List Versions";
            this.assembliesButton.UseVisualStyleBackColor = true;
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(135, 12);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(117, 23);
            this.updateButton.TabIndex = 1;
            this.updateButton.Text = "Update Nuts";
            this.updateButton.UseVisualStyleBackColor = true;
            // 
            // checkButton
            // 
            this.checkButton.Location = new System.Drawing.Point(12, 12);
            this.checkButton.Name = "checkButton";
            this.checkButton.Size = new System.Drawing.Size(117, 23);
            this.checkButton.TabIndex = 0;
            this.checkButton.Text = "Check Nuts";
            this.checkButton.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.messageArea);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 50);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(784, 511);
            this.panel2.TabIndex = 1;
            // 
            // messageArea
            // 
            this.messageArea.AcceptsTab = true;
            this.messageArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.messageArea.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messageArea.Location = new System.Drawing.Point(0, 0);
            this.messageArea.Multiline = true;
            this.messageArea.Name = "messageArea";
            this.messageArea.ReadOnly = true;
            this.messageArea.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.messageArea.Size = new System.Drawing.Size(784, 511);
            this.messageArea.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainForm";
            this.Text = "Squirrel\'s Nuts";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button checkButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox messageArea;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Button assembliesButton;
        private System.Windows.Forms.Button debuggerButton;
        private System.Windows.Forms.Button resetButton;
    }
}

