namespace Weather_App
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label2 = new System.Windows.Forms.Label();
            this.TBCity = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblCondition = new System.Windows.Forms.Label();
            this.lblDetails = new System.Windows.Forms.Label();
            this.lblSunrise = new System.Windows.Forms.Label();
            this.lblSunset = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblPressure = new System.Windows.Forms.Label();
            this.lblWindSpeed = new System.Windows.Forms.Label();
            this.picIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(125, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "City:";
            // 
            // TBCity
            // 
            this.TBCity.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBCity.Location = new System.Drawing.Point(186, 117);
            this.TBCity.Name = "TBCity";
            this.TBCity.Size = new System.Drawing.Size(175, 32);
            this.TBCity.TabIndex = 2;
            this.TBCity.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSearch.Location = new System.Drawing.Point(385, 117);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(93, 32);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblCondition
            // 
            this.lblCondition.AutoSize = true;
            this.lblCondition.BackColor = System.Drawing.Color.Transparent;
            this.lblCondition.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCondition.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblCondition.Location = new System.Drawing.Point(263, 185);
            this.lblCondition.Name = "lblCondition";
            this.lblCondition.Size = new System.Drawing.Size(45, 24);
            this.lblCondition.TabIndex = 4;
            this.lblCondition.Text = "N/A";
            this.lblCondition.Click += new System.EventHandler(this.lblCondition_Click);
            // 
            // lblDetails
            // 
            this.lblDetails.AutoSize = true;
            this.lblDetails.BackColor = System.Drawing.Color.Transparent;
            this.lblDetails.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetails.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblDetails.Location = new System.Drawing.Point(263, 245);
            this.lblDetails.Name = "lblDetails";
            this.lblDetails.Size = new System.Drawing.Size(45, 24);
            this.lblDetails.TabIndex = 5;
            this.lblDetails.Text = "N/A";
            // 
            // lblSunrise
            // 
            this.lblSunrise.AutoSize = true;
            this.lblSunrise.BackColor = System.Drawing.Color.Transparent;
            this.lblSunrise.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSunrise.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblSunrise.Location = new System.Drawing.Point(263, 302);
            this.lblSunrise.Name = "lblSunrise";
            this.lblSunrise.Size = new System.Drawing.Size(45, 24);
            this.lblSunrise.TabIndex = 6;
            this.lblSunrise.Text = "N/A";
            this.lblSunrise.Click += new System.EventHandler(this.lblSunrise_Click);
            // 
            // lblSunset
            // 
            this.lblSunset.AutoSize = true;
            this.lblSunset.BackColor = System.Drawing.Color.Transparent;
            this.lblSunset.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSunset.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblSunset.Location = new System.Drawing.Point(263, 362);
            this.lblSunset.Name = "lblSunset";
            this.lblSunset.Size = new System.Drawing.Size(45, 24);
            this.lblSunset.TabIndex = 7;
            this.lblSunset.Text = "N/A";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(125, 185);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 24);
            this.label1.TabIndex = 8;
            this.label1.Text = "Condition:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(125, 245);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 24);
            this.label3.TabIndex = 9;
            this.label3.Text = "Details:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(125, 302);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 24);
            this.label4.TabIndex = 10;
            this.label4.Text = "Sunrise:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(125, 362);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 24);
            this.label5.TabIndex = 11;
            this.label5.Text = "Sunset:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(424, 245);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 24);
            this.label6.TabIndex = 15;
            this.label6.Text = "Pressure:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label7.Location = new System.Drawing.Point(424, 185);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(139, 24);
            this.label7.TabIndex = 14;
            this.label7.Text = "Wind Speed:";
            // 
            // lblPressure
            // 
            this.lblPressure.AutoSize = true;
            this.lblPressure.BackColor = System.Drawing.Color.Transparent;
            this.lblPressure.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPressure.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblPressure.Location = new System.Drawing.Point(596, 245);
            this.lblPressure.Name = "lblPressure";
            this.lblPressure.Size = new System.Drawing.Size(45, 24);
            this.lblPressure.TabIndex = 13;
            this.lblPressure.Text = "N/A";
            // 
            // lblWindSpeed
            // 
            this.lblWindSpeed.AutoSize = true;
            this.lblWindSpeed.BackColor = System.Drawing.Color.Transparent;
            this.lblWindSpeed.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWindSpeed.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblWindSpeed.Location = new System.Drawing.Point(596, 185);
            this.lblWindSpeed.Name = "lblWindSpeed";
            this.lblWindSpeed.Size = new System.Drawing.Size(45, 24);
            this.lblWindSpeed.TabIndex = 12;
            this.lblWindSpeed.Text = "N/A";
            // 
            // picIcon
            // 
            this.picIcon.BackColor = System.Drawing.Color.Transparent;
            this.picIcon.Location = new System.Drawing.Point(514, 97);
            this.picIcon.Name = "picIcon";
            this.picIcon.Size = new System.Drawing.Size(110, 65);
            this.picIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIcon.TabIndex = 16;
            this.picIcon.TabStop = false;
            this.picIcon.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1024, 575);
            this.Controls.Add(this.picIcon);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblPressure);
            this.Controls.Add(this.lblWindSpeed);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblSunset);
            this.Controls.Add(this.lblSunrise);
            this.Controls.Add(this.lblDetails);
            this.Controls.Add(this.lblCondition);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.TBCity);
            this.Controls.Add(this.label2);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TBCity;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblCondition;
        private System.Windows.Forms.Label lblDetails;
        private System.Windows.Forms.Label lblSunrise;
        private System.Windows.Forms.Label lblSunset;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblPressure;
        private System.Windows.Forms.Label lblWindSpeed;
        private System.Windows.Forms.PictureBox picIcon;
    }
}

