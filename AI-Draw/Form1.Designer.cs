
namespace AI_Draw
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.OpenButton = new System.Windows.Forms.Button();
            this.DrawButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.CreatePerceptronButton = new System.Windows.Forms.Button();
            this.StartLearningButton = new System.Windows.Forms.Button();
            this.GetErrorButton = new System.Windows.Forms.Button();
            this.CountTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ErrorText = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.ResetButton = new System.Windows.Forms.Button();
            this.LayersTextBox = new System.Windows.Forms.TextBox();
            this.LayersLabel = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.ReadDataButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // OpenButton
            // 
            this.OpenButton.Location = new System.Drawing.Point(12, 12);
            this.OpenButton.Name = "OpenButton";
            this.OpenButton.Size = new System.Drawing.Size(75, 23);
            this.OpenButton.TabIndex = 0;
            this.OpenButton.Text = "Open";
            this.OpenButton.UseVisualStyleBackColor = true;
            this.OpenButton.Click += new System.EventHandler(this.OpenButton_Click);
            // 
            // DrawButton
            // 
            this.DrawButton.Location = new System.Drawing.Point(93, 12);
            this.DrawButton.Name = "DrawButton";
            this.DrawButton.Size = new System.Drawing.Size(75, 23);
            this.DrawButton.TabIndex = 1;
            this.DrawButton.Text = "Draw";
            this.DrawButton.UseVisualStyleBackColor = true;
            this.DrawButton.Click += new System.EventHandler(this.DrawButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(174, 12);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 2;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // CreatePerceptronButton
            // 
            this.CreatePerceptronButton.Location = new System.Drawing.Point(682, 12);
            this.CreatePerceptronButton.Name = "CreatePerceptronButton";
            this.CreatePerceptronButton.Size = new System.Drawing.Size(106, 43);
            this.CreatePerceptronButton.TabIndex = 3;
            this.CreatePerceptronButton.Text = "Create perceptron";
            this.CreatePerceptronButton.UseVisualStyleBackColor = true;
            this.CreatePerceptronButton.Click += new System.EventHandler(this.CreatePerceptronButton_Click);
            // 
            // StartLearningButton
            // 
            this.StartLearningButton.Location = new System.Drawing.Point(682, 110);
            this.StartLearningButton.Name = "StartLearningButton";
            this.StartLearningButton.Size = new System.Drawing.Size(106, 42);
            this.StartLearningButton.TabIndex = 4;
            this.StartLearningButton.Text = "Start learning";
            this.StartLearningButton.UseVisualStyleBackColor = true;
            this.StartLearningButton.Click += new System.EventHandler(this.StartLearningButton_Click);
            // 
            // GetErrorButton
            // 
            this.GetErrorButton.Location = new System.Drawing.Point(682, 158);
            this.GetErrorButton.Name = "GetErrorButton";
            this.GetErrorButton.Size = new System.Drawing.Size(106, 42);
            this.GetErrorButton.TabIndex = 5;
            this.GetErrorButton.Text = "Get training error";
            this.GetErrorButton.UseVisualStyleBackColor = true;
            this.GetErrorButton.Click += new System.EventHandler(this.GetErrorButton_Click);
            // 
            // CountTextBox
            // 
            this.CountTextBox.Location = new System.Drawing.Point(797, 130);
            this.CountTextBox.Name = "CountTextBox";
            this.CountTextBox.Size = new System.Drawing.Size(100, 22);
            this.CountTextBox.TabIndex = 6;
            this.CountTextBox.Text = "10000";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(794, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Count of cycles";
            // 
            // ErrorText
            // 
            this.ErrorText.AutoSize = true;
            this.ErrorText.Location = new System.Drawing.Point(794, 171);
            this.ErrorText.Name = "ErrorText";
            this.ErrorText.Size = new System.Drawing.Size(0, 17);
            this.ErrorText.TabIndex = 8;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 41);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(259, 41);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(100, 50);
            this.pictureBox2.TabIndex = 10;
            this.pictureBox2.TabStop = false;
            // 
            // ResetButton
            // 
            this.ResetButton.Location = new System.Drawing.Point(682, 206);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(106, 34);
            this.ResetButton.TabIndex = 11;
            this.ResetButton.Text = "Reset";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // LayersTextBox
            // 
            this.LayersTextBox.Location = new System.Drawing.Point(798, 33);
            this.LayersTextBox.Name = "LayersTextBox";
            this.LayersTextBox.Size = new System.Drawing.Size(100, 22);
            this.LayersTextBox.TabIndex = 12;
            this.LayersTextBox.Text = "32";
            // 
            // LayersLabel
            // 
            this.LayersLabel.AutoSize = true;
            this.LayersLabel.Location = new System.Drawing.Point(795, 12);
            this.LayersLabel.Name = "LayersLabel";
            this.LayersLabel.Size = new System.Drawing.Size(95, 17);
            this.LayersLabel.TabIndex = 13;
            this.LayersLabel.Text = "Hidden layers";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(259, 12);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(417, 23);
            this.progressBar.TabIndex = 14;
            // 
            // ReadDataButton
            // 
            this.ReadDataButton.Location = new System.Drawing.Point(682, 61);
            this.ReadDataButton.Name = "ReadDataButton";
            this.ReadDataButton.Size = new System.Drawing.Size(106, 43);
            this.ReadDataButton.TabIndex = 15;
            this.ReadDataButton.Text = "Read learning data";
            this.ReadDataButton.UseVisualStyleBackColor = true;
            this.ReadDataButton.Click += new System.EventHandler(this.ReadDataButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 450);
            this.Controls.Add(this.ReadDataButton);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.LayersLabel);
            this.Controls.Add(this.LayersTextBox);
            this.Controls.Add(this.ResetButton);
            this.Controls.Add(this.ErrorText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CountTextBox);
            this.Controls.Add(this.GetErrorButton);
            this.Controls.Add(this.StartLearningButton);
            this.Controls.Add(this.CreatePerceptronButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.DrawButton);
            this.Controls.Add(this.OpenButton);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "AI Draw";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OpenButton;
        private System.Windows.Forms.Button DrawButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button CreatePerceptronButton;
        private System.Windows.Forms.Button StartLearningButton;
        private System.Windows.Forms.Button GetErrorButton;
        private System.Windows.Forms.TextBox CountTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label ErrorText;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.TextBox LayersTextBox;
        private System.Windows.Forms.Label LayersLabel;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button ReadDataButton;
    }
}

