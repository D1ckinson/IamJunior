namespace VotingApp
{
    public partial class PassportForm
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
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            _confirmButton = new Button();
            _passportTextbox = new TextBox();
            _replyTextbox = new TextBox();
            _infoTextBox1 = new TextBox();
            SuspendLayout();
            // 
            // _confirmButton
            // 
            _confirmButton.Location = new Point(352, 338);
            _confirmButton.Name = "_confirmButton";
            _confirmButton.Size = new Size(118, 25);
            _confirmButton.TabIndex = 0;
            _confirmButton.Text = "Подтвердить";
            _confirmButton.UseVisualStyleBackColor = true;
            _confirmButton.Click += _confirmButton_Click;
            // 
            // _passportTextbox
            // 
            _passportTextbox.Location = new Point(240, 74);
            _passportTextbox.Name = "_passportTextbox";
            _passportTextbox.Size = new Size(342, 25);
            _passportTextbox.TabIndex = 1;
            // 
            // _textResult
            // 
            _replyTextbox.Enabled = false;
            _replyTextbox.Location = new Point(240, 246);
            _replyTextbox.Name = "_textResult";
            _replyTextbox.Size = new Size(342, 25);
            _replyTextbox.TabIndex = 2;
            // 
            // _infoTextBox1
            // 
            _infoTextBox1.Location = new Point(240, 38);
            _infoTextBox1.Name = "_infoTextBox1";
            _infoTextBox1.ReadOnly = true;
            _infoTextBox1.Size = new Size(342, 25);
            _infoTextBox1.TabIndex = 3;
            _infoTextBox1.Text = "Серия и номер паспорта";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(_infoTextBox1);
            Controls.Add(_replyTextbox);
            Controls.Add(_passportTextbox);
            Controls.Add(_confirmButton);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        private void _confirmButton_Click(object sender, EventArgs e) =>
            UserConfirmPassportIndex?.Invoke(_passportTextbox.Text);

        #endregion

        private Button _confirmButton;
        private TextBox _passportTextbox;
        private TextBox _replyTextbox;
        private TextBox _infoTextBox1;
    }
}