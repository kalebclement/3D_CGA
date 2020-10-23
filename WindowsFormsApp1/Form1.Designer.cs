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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.rotateYplus = new System.Windows.Forms.Button();
            this.rotateYmin = new System.Windows.Forms.Button();
            this.forward = new System.Windows.Forms.Button();
            this.left = new System.Windows.Forms.Button();
            this.right = new System.Windows.Forms.Button();
            this.backwaerd = new System.Windows.Forms.Button();
            this.Timer1 = new System.Windows.Forms.Timer(this.components);
            this.boxCanvas = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.boxCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(687, 85);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Forward";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(687, 143);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Backward";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(687, 206);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Left";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(687, 265);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "Right";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // rotateYplus
            // 
            this.rotateYplus.Location = new System.Drawing.Point(12, 143);
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
            this.rotateYmin.Location = new System.Drawing.Point(429, 143);
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
            this.forward.Location = new System.Drawing.Point(219, 12);
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
            this.left.Location = new System.Drawing.Point(12, 206);
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
            this.right.Location = new System.Drawing.Point(429, 206);
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
            this.backwaerd.Location = new System.Drawing.Point(219, 370);
            this.backwaerd.Name = "backwaerd";
            this.backwaerd.Size = new System.Drawing.Size(75, 23);
            this.backwaerd.TabIndex = 10;
            this.backwaerd.Text = "Backward";
            this.backwaerd.UseVisualStyleBackColor = true;
            this.backwaerd.MouseDown += new System.Windows.Forms.MouseEventHandler(this.backward_MouseDown);
            this.backwaerd.MouseUp += new System.Windows.Forms.MouseEventHandler(this.backward_MouseUp);
            // 
            // Timer1
            // 
            this.Timer1.Interval = 50;
            // 
            // boxCanvas
            // 
            this.boxCanvas.Image = ((System.Drawing.Image)(resources.GetObject("boxCanvas.Image")));
            this.boxCanvas.Location = new System.Drawing.Point(96, 45);
            this.boxCanvas.Name = "boxCanvas";
            this.boxCanvas.Size = new System.Drawing.Size(300, 300);
            this.boxCanvas.TabIndex = 6;
            this.boxCanvas.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.backwaerd);
            this.Controls.Add(this.right);
            this.Controls.Add(this.left);
            this.Controls.Add(this.forward);
            this.Controls.Add(this.boxCanvas);
            this.Controls.Add(this.rotateYmin);
            this.Controls.Add(this.rotateYplus);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.boxCanvas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button rotateYplus;
        private System.Windows.Forms.Button rotateYmin;
        private System.Windows.Forms.Button forward;
        private System.Windows.Forms.Button left;
        private System.Windows.Forms.Button right;
        private System.Windows.Forms.Button backwaerd;
        private System.Windows.Forms.Timer Timer1;
        private System.Windows.Forms.PictureBox boxCanvas;
    }
}

