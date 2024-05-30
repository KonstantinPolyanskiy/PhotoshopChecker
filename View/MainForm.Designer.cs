namespace PhotoshopChecker.View
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
            SelectImageButton = new Button();
            ExitButton = new Button();
            ImagePictureBox = new PictureBox();
            label1 = new Label();
            ResultLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)ImagePictureBox).BeginInit();
            SuspendLayout();
            // 
            // SelectImageButton
            // 
            SelectImageButton.Location = new Point(12, 261);
            SelectImageButton.Name = "SelectImageButton";
            SelectImageButton.Size = new Size(171, 23);
            SelectImageButton.TabIndex = 0;
            SelectImageButton.Text = "Выбрать изображение";
            SelectImageButton.UseVisualStyleBackColor = true;
            SelectImageButton.Click += SelectImageButton_Click;
            // 
            // ExitButton
            // 
            ExitButton.Location = new Point(236, 261);
            ExitButton.Name = "ExitButton";
            ExitButton.Size = new Size(75, 23);
            ExitButton.TabIndex = 1;
            ExitButton.Text = "Выход";
            ExitButton.UseVisualStyleBackColor = true;
            ExitButton.Click += ExitButton_Click;
            // 
            // ImagePictureBox
            // 
            ImagePictureBox.Location = new Point(13, 14);
            ImagePictureBox.Name = "ImagePictureBox";
            ImagePictureBox.Size = new Size(301, 171);
            ImagePictureBox.TabIndex = 2;
            ImagePictureBox.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 215);
            label1.Name = "label1";
            label1.Size = new Size(63, 15);
            label1.TabIndex = 3;
            label1.Text = "Результат:";
            // 
            // ResultLabel
            // 
            ResultLabel.AutoSize = true;
            ResultLabel.Location = new Point(82, 215);
            ResultLabel.Name = "ResultLabel";
            ResultLabel.Size = new Size(0, 15);
            ResultLabel.TabIndex = 4;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(333, 296);
            Controls.Add(ResultLabel);
            Controls.Add(label1);
            Controls.Add(ImagePictureBox);
            Controls.Add(ExitButton);
            Controls.Add(SelectImageButton);
            Name = "MainForm";
            Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)ImagePictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button SelectImageButton;
        private Button ExitButton;
        private PictureBox ImagePictureBox;
        private Label label1;
        private Label ResultLabel;
    }
}