namespace LSBAlgorithm
{
    partial class LSBAlgorithm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LSBAlgorithm));
            this.label6 = new System.Windows.Forms.Label();
            this.decodeImage = new System.Windows.Forms.PictureBox();
            this.Encode = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.encodeMessage = new System.Windows.Forms.TextBox();
            this.encodeOpenFile = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.encodeImage2 = new System.Windows.Forms.PictureBox();
            this.decode = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.decodeMessage = new System.Windows.Forms.TextBox();
            this.decodeOpenFile = new System.Windows.Forms.Button();
            this.encodeInputImage = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.encodeImage1 = new System.Windows.Forms.PictureBox();
            this.decodeInputImage = new System.Windows.Forms.TextBox();
            this.encodeTab = new System.Windows.Forms.TabPage();
            this.decodeTab = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            ((System.ComponentModel.ISupportInitialize)(this.decodeImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.encodeImage2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.encodeImage1)).BeginInit();
            this.encodeTab.SuspendLayout();
            this.decodeTab.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 419);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 24);
            this.label6.TabIndex = 11;
            this.label6.Text = "Input image:";
            // 
            // decodeImage
            // 
            this.decodeImage.BackgroundImage = global::LSBAlgorithm.Properties.Resources.noimage;
            this.decodeImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.decodeImage.Location = new System.Drawing.Point(208, 25);
            this.decodeImage.Name = "decodeImage";
            this.decodeImage.Size = new System.Drawing.Size(360, 360);
            this.decodeImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.decodeImage.TabIndex = 1;
            this.decodeImage.TabStop = false;
            // 
            // Encode
            // 
            this.Encode.Location = new System.Drawing.Point(633, 462);
            this.Encode.Name = "Encode";
            this.Encode.Size = new System.Drawing.Size(122, 32);
            this.Encode.TabIndex = 9;
            this.Encode.Text = "Encode";
            this.Encode.UseVisualStyleBackColor = true;
            this.Encode.Click += new System.EventHandler(this.Encode_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 465);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 24);
            this.label4.TabIndex = 8;
            this.label4.Text = "Your message:";
            // 
            // encodeMessage
            // 
            this.encodeMessage.BackColor = System.Drawing.SystemColors.HighlightText;
            this.encodeMessage.Location = new System.Drawing.Point(154, 462);
            this.encodeMessage.Name = "encodeMessage";
            this.encodeMessage.Size = new System.Drawing.Size(466, 32);
            this.encodeMessage.TabIndex = 7;
            // 
            // encodeOpenFile
            // 
            this.encodeOpenFile.Location = new System.Drawing.Point(633, 415);
            this.encodeOpenFile.Name = "encodeOpenFile";
            this.encodeOpenFile.Size = new System.Drawing.Size(122, 32);
            this.encodeOpenFile.TabIndex = 6;
            this.encodeOpenFile.Text = "Open file";
            this.encodeOpenFile.UseVisualStyleBackColor = true;
            this.encodeOpenFile.Click += new System.EventHandler(this.encodeOpenFile_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 418);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "Input image:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(391, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "After";
            // 
            // encodeImage2
            // 
            this.encodeImage2.BackgroundImage = global::LSBAlgorithm.Properties.Resources.noimage;
            this.encodeImage2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.encodeImage2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.encodeImage2.Location = new System.Drawing.Point(395, 39);
            this.encodeImage2.Name = "encodeImage2";
            this.encodeImage2.Size = new System.Drawing.Size(360, 360);
            this.encodeImage2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.encodeImage2.TabIndex = 3;
            this.encodeImage2.TabStop = false;
            // 
            // decode
            // 
            this.decode.Location = new System.Drawing.Point(633, 463);
            this.decode.Name = "decode";
            this.decode.Size = new System.Drawing.Size(122, 32);
            this.decode.TabIndex = 15;
            this.decode.Text = "Decode";
            this.decode.UseVisualStyleBackColor = true;
            this.decode.Click += new System.EventHandler(this.decode_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 466);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(151, 24);
            this.label5.TabIndex = 14;
            this.label5.Text = "Hidden message:";
            // 
            // decodeMessage
            // 
            this.decodeMessage.BackColor = System.Drawing.SystemColors.HighlightText;
            this.decodeMessage.Location = new System.Drawing.Point(178, 463);
            this.decodeMessage.Name = "decodeMessage";
            this.decodeMessage.Size = new System.Drawing.Size(443, 32);
            this.decodeMessage.TabIndex = 13;
            // 
            // decodeOpenFile
            // 
            this.decodeOpenFile.Location = new System.Drawing.Point(633, 416);
            this.decodeOpenFile.Name = "decodeOpenFile";
            this.decodeOpenFile.Size = new System.Drawing.Size(122, 32);
            this.decodeOpenFile.TabIndex = 12;
            this.decodeOpenFile.Text = "Open file";
            this.decodeOpenFile.UseVisualStyleBackColor = true;
            this.decodeOpenFile.Click += new System.EventHandler(this.decodeOpenFile_Click);
            // 
            // encodeInputImage
            // 
            this.encodeInputImage.BackColor = System.Drawing.SystemColors.HighlightText;
            this.encodeInputImage.Enabled = false;
            this.encodeInputImage.Location = new System.Drawing.Point(154, 415);
            this.encodeInputImage.Name = "encodeInputImage";
            this.encodeInputImage.Size = new System.Drawing.Size(466, 32);
            this.encodeInputImage.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Before";
            // 
            // encodeImage1
            // 
            this.encodeImage1.BackgroundImage = global::LSBAlgorithm.Properties.Resources.noimage;
            this.encodeImage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.encodeImage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.encodeImage1.Location = new System.Drawing.Point(15, 39);
            this.encodeImage1.Name = "encodeImage1";
            this.encodeImage1.Size = new System.Drawing.Size(360, 360);
            this.encodeImage1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.encodeImage1.TabIndex = 0;
            this.encodeImage1.TabStop = false;
            // 
            // decodeInputImage
            // 
            this.decodeInputImage.BackColor = System.Drawing.SystemColors.HighlightText;
            this.decodeInputImage.Enabled = false;
            this.decodeInputImage.Location = new System.Drawing.Point(178, 416);
            this.decodeInputImage.Name = "decodeInputImage";
            this.decodeInputImage.Size = new System.Drawing.Size(443, 32);
            this.decodeInputImage.TabIndex = 10;
            // 
            // encodeTab
            // 
            this.encodeTab.Controls.Add(this.Encode);
            this.encodeTab.Controls.Add(this.label4);
            this.encodeTab.Controls.Add(this.encodeMessage);
            this.encodeTab.Controls.Add(this.encodeOpenFile);
            this.encodeTab.Controls.Add(this.label3);
            this.encodeTab.Controls.Add(this.label2);
            this.encodeTab.Controls.Add(this.encodeImage2);
            this.encodeTab.Controls.Add(this.encodeInputImage);
            this.encodeTab.Controls.Add(this.label1);
            this.encodeTab.Controls.Add(this.encodeImage1);
            this.encodeTab.Location = new System.Drawing.Point(4, 33);
            this.encodeTab.Name = "encodeTab";
            this.encodeTab.Padding = new System.Windows.Forms.Padding(3);
            this.encodeTab.Size = new System.Drawing.Size(770, 509);
            this.encodeTab.TabIndex = 0;
            this.encodeTab.Text = "Encode";
            this.encodeTab.UseVisualStyleBackColor = true;
            // 
            // decodeTab
            // 
            this.decodeTab.Controls.Add(this.decode);
            this.decodeTab.Controls.Add(this.label5);
            this.decodeTab.Controls.Add(this.decodeMessage);
            this.decodeTab.Controls.Add(this.decodeOpenFile);
            this.decodeTab.Controls.Add(this.label6);
            this.decodeTab.Controls.Add(this.decodeInputImage);
            this.decodeTab.Controls.Add(this.decodeImage);
            this.decodeTab.Location = new System.Drawing.Point(4, 33);
            this.decodeTab.Name = "decodeTab";
            this.decodeTab.Padding = new System.Windows.Forms.Padding(3);
            this.decodeTab.Size = new System.Drawing.Size(770, 509);
            this.decodeTab.TabIndex = 1;
            this.decodeTab.Text = "Decode";
            this.decodeTab.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.encodeTab);
            this.tabControl1.Controls.Add(this.decodeTab);
            this.tabControl1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(778, 546);
            this.tabControl1.TabIndex = 1;
            // 
            // LSBAlgorithm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 567);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LSBAlgorithm";
            this.Text = "LSB Algorithm | Crypto_Lab12";
            ((System.ComponentModel.ISupportInitialize)(this.decodeImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.encodeImage2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.encodeImage1)).EndInit();
            this.encodeTab.ResumeLayout(false);
            this.encodeTab.PerformLayout();
            this.decodeTab.ResumeLayout(false);
            this.decodeTab.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox decodeImage;
        private System.Windows.Forms.Button Encode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox encodeMessage;
        private System.Windows.Forms.Button encodeOpenFile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox encodeImage2;
        private System.Windows.Forms.Button decode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox decodeMessage;
        private System.Windows.Forms.Button decodeOpenFile;
        private System.Windows.Forms.TextBox encodeInputImage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox encodeImage1;
        private System.Windows.Forms.TextBox decodeInputImage;
        private System.Windows.Forms.TabPage encodeTab;
        private System.Windows.Forms.TabPage decodeTab;
        private System.Windows.Forms.TabControl tabControl1;
    }
}