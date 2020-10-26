namespace WindowsFormsApp1
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.rotateYplus = new System.Windows.Forms.Button();
            this.rotateYmin = new System.Windows.Forms.Button();
            this.forward = new System.Windows.Forms.Button();
            this.left = new System.Windows.Forms.Button();
            this.right = new System.Windows.Forms.Button();
            this.backwaerd = new System.Windows.Forms.Button();
            this.Timer1 = new System.Windows.Forms.Timer(this.components);
            this.boxCanvas = new System.Windows.Forms.PictureBox();
            this.Timer2 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.boxCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // rotateYplus
            // 
            this.rotateYplus.Location = new System.Drawing.Point(105, 120);
            this.rotateYplus.Name = "rotateYplus";
            this.rotateYplus.Size = new System.Drawing.Size(75, 23);
            this.rotateYplus.TabIndex = 4;
            this.rotateYplus.Text = "Rotate-(Y+)";
            this.rotateYplus.UseVisualStyleBackColor = true;
            this.rotateYplus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rotateYplus_MouseDown);
            this.rotateYplus.MouseUp += new System.Windows.Forms.MouseEventHandler(this.rotateYplus_MouseUp);
            // 
            // rotateYmin
            // 
            this.rotateYmin.Location = new System.Drawing.Point(535, 120);
            this.rotateYmin.Name = "rotateYmin";
            this.rotateYmin.Size = new System.Drawing.Size(75, 23);
            this.rotateYmin.TabIndex = 5;
            this.rotateYmin.Text = "Rotate-(Y-)";
            this.rotateYmin.UseVisualStyleBackColor = true;
            this.rotateYmin.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rotateMin_MouseDown);
            this.rotateYmin.MouseUp += new System.Windows.Forms.MouseEventHandler(this.RotateMin_MouseUp);
            // 
            // forward
            // 
            this.forward.Location = new System.Drawing.Point(330, 36);
            this.forward.Name = "forward";
            this.forward.Size = new System.Drawing.Size(75, 23);
            this.forward.TabIndex = 7;
            this.forward.Text = "Forward";
            this.forward.UseVisualStyleBackColor = true;
            this.forward.MouseDown += new System.Windows.Forms.MouseEventHandler(this.forward_MouseDown);
            this.forward.MouseUp += new System.Windows.Forms.MouseEventHandler(this.forward_MouseUp);
            // 
            // left
            // 
            this.left.Location = new System.Drawing.Point(105, 226);
            this.left.Name = "left";
            this.left.Size = new System.Drawing.Size(75, 23);
            this.left.TabIndex = 8;
            this.left.Text = "Left";
            this.left.UseVisualStyleBackColor = true;
            this.left.MouseDown += new System.Windows.Forms.MouseEventHandler(this.left_MouseDown);
            this.left.MouseUp += new System.Windows.Forms.MouseEventHandler(this.left_MouseUp);
            // 
            // right
            // 
            this.right.Location = new System.Drawing.Point(535, 226);
            this.right.Name = "right";
            this.right.Size = new System.Drawing.Size(75, 23);
            this.right.TabIndex = 9;
            this.right.Text = "Right";
            this.right.UseVisualStyleBackColor = true;
            this.right.MouseDown += new System.Windows.Forms.MouseEventHandler(this.right_MouseDown);
            this.right.MouseUp += new System.Windows.Forms.MouseEventHandler(this.right_MouseUp);
            // 
            // backwaerd
            // 
            this.backwaerd.Location = new System.Drawing.Point(330, 371);
            this.backwaerd.Name = "backwaerd";
            this.backwaerd.Size = new System.Drawing.Size(75, 23);
            this.backwaerd.TabIndex = 10;
            this.backwaerd.Text = "Backward";
            this.backwaerd.UseVisualStyleBackColor = true;
            this.backwaerd.MouseDown += new System.Windows.Forms.MouseEventHandler(this.backward_MouseDown);
            this.backwaerd.MouseUp += new System.Windows.Forms.MouseEventHandler(this.backward_MouseUp);
            // 
            // boxCanvas
            // 
            this.boxCanvas.Image = ((System.Drawing.Image)(resources.GetObject("boxCanvas.Image")));
            this.boxCanvas.Location = new System.Drawing.Point(214, 65);
            this.boxCanvas.Name = "boxCanvas";
            this.boxCanvas.Size = new System.Drawing.Size(300, 300);
            this.boxCanvas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.boxCanvas.TabIndex = 6;
            this.boxCanvas.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 450);
            this.Controls.Add(this.backwaerd);
            this.Controls.Add(this.right);
            this.Controls.Add(this.left);
            this.Controls.Add(this.forward);
            this.Controls.Add(this.boxCanvas);
            this.Controls.Add(this.rotateYmin);
            this.Controls.Add(this.rotateYplus);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.boxCanvas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button rotateYplus;
        private System.Windows.Forms.Button rotateYmin;
        private System.Windows.Forms.Button forward;
        private System.Windows.Forms.Button left;
        private System.Windows.Forms.Button right;
        private System.Windows.Forms.Button backwaerd;
        private System.Windows.Forms.Timer Timer1;
        private System.Windows.Forms.PictureBox boxCanvas;
        private System.Windows.Forms.Timer Timer2;
    }
}

