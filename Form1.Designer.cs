namespace ScreenSaver {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.newShapeBtn = new System.Windows.Forms.ToolStripButton();
            this.editShapesBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newShapeBtn,
            this.editShapesBtn,
            this.toolStripLabel1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 423);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // newShapeBtn
            // 
            this.newShapeBtn.Checked = true;
            this.newShapeBtn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.newShapeBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newShapeBtn.Image = ((System.Drawing.Image)(resources.GetObject("newShapeBtn.Image")));
            this.newShapeBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newShapeBtn.Name = "newShapeBtn";
            this.newShapeBtn.Size = new System.Drawing.Size(29, 24);
            this.newShapeBtn.Text = "New Shape";
            // 
            // editShapesBtn
            // 
            this.editShapesBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.editShapesBtn.Image = ((System.Drawing.Image)(resources.GetObject("editShapesBtn.Image")));
            this.editShapesBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.editShapesBtn.Name = "editShapesBtn";
            this.editShapesBtn.Size = new System.Drawing.Size(29, 24);
            this.editShapesBtn.Text = "EditShapes";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(111, 24);
            this.toolStripLabel1.Text = "toolStripLabel1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton newShapeBtn;
        private System.Windows.Forms.ToolStripButton editShapesBtn;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
    }
}

