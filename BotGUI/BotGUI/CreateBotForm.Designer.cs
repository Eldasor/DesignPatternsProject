namespace BotGUI
{
    partial class CreateBotForm
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
            botNameTextBox = new TextBox();
            label1 = new Label();
            botInitialCashBox = new NumericUpDown();
            label2 = new Label();
            button1 = new Button();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)botInitialCashBox).BeginInit();
            SuspendLayout();
            // 
            // botNameTextBox
            // 
            botNameTextBox.Location = new Point(79, 6);
            botNameTextBox.Name = "botNameTextBox";
            botNameTextBox.Size = new Size(146, 23);
            botNameTextBox.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(61, 15);
            label1.TabIndex = 1;
            label1.Text = "Bot name:";
            // 
            // botInitialCashBox
            // 
            botInitialCashBox.DecimalPlaces = 2;
            botInitialCashBox.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            botInitialCashBox.Location = new Point(99, 35);
            botInitialCashBox.Maximum = new decimal(new int[] { -1530494976, 232830, 0, 0 });
            botInitialCashBox.Name = "botInitialCashBox";
            botInitialCashBox.Size = new Size(126, 23);
            botInitialCashBox.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 37);
            label2.Name = "label2";
            label2.Size = new Size(81, 15);
            label2.TabIndex = 3;
            label2.Text = "Starting cash: ";
            // 
            // button1
            // 
            button1.Location = new Point(116, 64);
            button1.Name = "button1";
            button1.Size = new Size(109, 37);
            button1.TabIndex = 4;
            button1.Text = "Create";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(12, 64);
            button2.Name = "button2";
            button2.Size = new Size(98, 37);
            button2.TabIndex = 5;
            button2.Text = "Cancel";
            button2.UseVisualStyleBackColor = true;
            // 
            // CreateBotForm
            // 
            AcceptButton = button1;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = button2;
            ClientSize = new Size(237, 113);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(botInitialCashBox);
            Controls.Add(label1);
            Controls.Add(botNameTextBox);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CreateBotForm";
            Text = "Create Bot";
            TopMost = true;
            ((System.ComponentModel.ISupportInitialize)botInitialCashBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox botNameTextBox;
        private Label label1;
        private NumericUpDown botInitialCashBox;
        private Label label2;
        private Button button1;
        private Button button2;
    }
}