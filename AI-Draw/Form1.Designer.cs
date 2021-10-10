
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
            this.ReadDataButton = new System.Windows.Forms.Button();
            this.StartLearningButton = new System.Windows.Forms.Button();
            this.GetErrorButton = new System.Windows.Forms.Button();
            this.CountTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ErrorText = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            // ReadDataButton
            // 
            this.ReadDataButton.Location = new System.Drawing.Point(682, 12);
            this.ReadDataButton.Name = "ReadDataButton";
            this.ReadDataButton.Size = new System.Drawing.Size(106, 43);
            this.ReadDataButton.TabIndex = 3;
            this.ReadDataButton.Text = "Read learning data";
            this.ReadDataButton.UseVisualStyleBackColor = true;
            this.ReadDataButton.Click += new System.EventHandler(this.ReadDataButton_Click);
            // 
            // StartLearningButton
            // 
            this.StartLearningButton.Location = new System.Drawing.Point(682, 61);
            this.StartLearningButton.Name = "StartLearningButton";
            this.StartLearningButton.Size = new System.Drawing.Size(106, 42);
            this.StartLearningButton.TabIndex = 4;
            this.StartLearningButton.Text = "Start learning";
            this.StartLearningButton.UseVisualStyleBackColor = true;
            this.StartLearningButton.Click += new System.EventHandler(this.StartLearningButton_Click);
            // 
            // GetErrorButton
            // 
            this.GetErrorButton.Location = new System.Drawing.Point(682, 109);
            this.GetErrorButton.Name = "GetErrorButton";
            this.GetErrorButton.Size = new System.Drawing.Size(106, 42);
            this.GetErrorButton.TabIndex = 5;
            this.GetErrorButton.Text = "Get training error";
            this.GetErrorButton.UseVisualStyleBackColor = true;
            this.GetErrorButton.Click += new System.EventHandler(this.GetErrorButton_Click);
            // 
            // CountTextBox
            // 
            this.CountTextBox.Location = new System.Drawing.Point(577, 81);
            this.CountTextBox.Name = "CountTextBox";
            this.CountTextBox.Size = new System.Drawing.Size(100, 22);
            this.CountTextBox.TabIndex = 6;
            this.CountTextBox.Text = "1000";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(574, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Count of cycles";
            // 
            // ErrorText
            // 
            this.ErrorText.AutoSize = true;
            this.ErrorText.Location = new System.Drawing.Point(605, 122);
            this.ErrorText.Name = "ErrorText";
            this.ErrorText.Size = new System.Drawing.Size(40, 17);
            this.ErrorText.TabIndex = 8;
            this.ErrorText.Text = "Error";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 41);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.ErrorText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CountTextBox);
            this.Controls.Add(this.GetErrorButton);
            this.Controls.Add(this.StartLearningButton);
            this.Controls.Add(this.ReadDataButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.DrawButton);
            this.Controls.Add(this.OpenButton);
            this.Name = "Form1";
            this.Text = "AI Draw";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OpenButton;
        private System.Windows.Forms.Button DrawButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button ReadDataButton;
        private System.Windows.Forms.Button StartLearningButton;
        private System.Windows.Forms.Button GetErrorButton;
        private System.Windows.Forms.TextBox CountTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label ErrorText;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

