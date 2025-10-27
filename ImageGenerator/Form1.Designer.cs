namespace ImageGenerator
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            generateButton = new Button();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            promptInput = new TextBox();
            pictureBox3 = new PictureBox();
            pictureBox4 = new PictureBox();
            statusLabel = new Label();
            progressBar1 = new ProgressBar();
            bindingSource1 = new BindingSource(components);
            radioButtonSingleImage = new RadioButton();
            radioButton4Image = new RadioButton();
            radioButtonDetailed = new RadioButton();
            radioButtonBasic = new RadioButton();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // generateButton
            // 
            generateButton.Location = new Point(12, 105);
            generateButton.Name = "generateButton";
            generateButton.Size = new Size(185, 55);
            generateButton.TabIndex = 0;
            generateButton.Text = "Generate Image";
            generateButton.UseVisualStyleBackColor = true;
            generateButton.Click += button1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(10, 200);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(200, 200);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Location = new Point(217, 200);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(200, 200);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 3;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // promptInput
            // 
            promptInput.Font = new Font("Segoe UI", 12F);
            promptInput.Location = new Point(12, 12);
            promptInput.Multiline = true;
            promptInput.Name = "promptInput";
            promptInput.Size = new Size(758, 75);
            promptInput.TabIndex = 4;
            promptInput.TextChanged += textBox1_TextChanged;
            // 
            // pictureBox3
            // 
            pictureBox3.Location = new Point(427, 200);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(200, 200);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 5;
            pictureBox3.TabStop = false;
            pictureBox3.Click += pictureBox3_Click;
            // 
            // pictureBox4
            // 
            pictureBox4.Location = new Point(637, 200);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(200, 200);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 6;
            pictureBox4.TabStop = false;
            pictureBox4.Click += pictureBox4_Click;
            // 
            // statusLabel
            // 
            statusLabel.AutoSize = true;
            statusLabel.Font = new Font("Segoe UI", 12F);
            statusLabel.Location = new Point(217, 132);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(106, 28);
            statusLabel.TabIndex = 7;
            statusLabel.Text = "Status: Idle";
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(465, 132);
            progressBar1.MarqueeAnimationSpeed = 30;
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(224, 29);
            progressBar1.Style = ProgressBarStyle.Marquee;
            progressBar1.TabIndex = 8;
            progressBar1.Visible = false;
            progressBar1.Click += progressBar1_Click;
            // 
            // radioButtonSingleImage
            // 
            radioButtonSingleImage.AutoSize = true;
            radioButtonSingleImage.Checked = true;
            radioButtonSingleImage.Location = new Point(227, 93);
            radioButtonSingleImage.Name = "radioButtonSingleImage";
            radioButtonSingleImage.Size = new Size(117, 24);
            radioButtonSingleImage.TabIndex = 9;
            radioButtonSingleImage.TabStop = true;
            radioButtonSingleImage.Text = "Single Image";
            radioButtonSingleImage.UseVisualStyleBackColor = true;
            radioButtonSingleImage.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // radioButton4Image
            // 
            radioButton4Image.AutoSize = true;
            radioButton4Image.Location = new Point(350, 93);
            radioButton4Image.Name = "radioButton4Image";
            radioButton4Image.Size = new Size(84, 24);
            radioButton4Image.TabIndex = 10;
            radioButton4Image.Text = "4 Image";
            radioButton4Image.UseVisualStyleBackColor = true;
            // 
            // radioButtonDetailed
            // 
            radioButtonDetailed.AutoSize = true;
            radioButtonDetailed.Location = new Point(87, 3);
            radioButtonDetailed.Name = "radioButtonDetailed";
            radioButtonDetailed.Size = new Size(87, 24);
            radioButtonDetailed.TabIndex = 1;
            radioButtonDetailed.Text = "Detailed";
            radioButtonDetailed.UseVisualStyleBackColor = true;
            // 
            // radioButtonBasic
            // 
            radioButtonBasic.AutoSize = true;
            radioButtonBasic.Checked = true;
            radioButtonBasic.Location = new Point(17, 3);
            radioButtonBasic.Name = "radioButtonBasic";
            radioButtonBasic.Size = new Size(64, 24);
            radioButtonBasic.TabIndex = 0;
            radioButtonBasic.TabStop = true;
            radioButtonBasic.Text = "Basic";
            radioButtonBasic.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(radioButtonDetailed);
            panel1.Controls.Add(radioButtonBasic);
            panel1.Location = new Point(479, 92);
            panel1.Name = "panel1";
            panel1.Size = new Size(250, 34);
            panel1.TabIndex = 12;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(842, 553);
            Controls.Add(panel1);
            Controls.Add(radioButton4Image);
            Controls.Add(radioButtonSingleImage);
            Controls.Add(progressBar1);
            Controls.Add(statusLabel);
            Controls.Add(pictureBox4);
            Controls.Add(pictureBox3);
            Controls.Add(promptInput);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(generateButton);
            Name = "Form1";
            Text = "Image Generator";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button generateButton;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private TextBox promptInput;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private Label statusLabel;
        private ProgressBar progressBar1;
        private BindingSource bindingSource1;
        private RadioButton radioButtonSingleImage;
        private RadioButton radioButton4Image;
        private RadioButton radioButtonDetailed;
        private RadioButton radioButtonBasic;
        private Panel panel1;
    }
}
