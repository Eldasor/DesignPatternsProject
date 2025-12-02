namespace BotGUI
{
    partial class mainForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            autoButton = new Button();
            stepButton = new Button();
            stepTimer = new System.Windows.Forms.Timer(components);
            backButton = new Button();
            addButton = new Button();
            removeButton = new Button();
            groupBox1 = new GroupBox();
            button3 = new Button();
            button1 = new Button();
            richTextBox1 = new RichTextBox();
            groupBox2 = new GroupBox();
            valueLabel = new Label();
            richTextBox2 = new RichTextBox();
            avLabel = new Label();
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            SuspendLayout();
            // 
            // autoButton
            // 
            autoButton.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            autoButton.Location = new Point(162, 384);
            autoButton.Name = "autoButton";
            autoButton.Size = new Size(131, 36);
            autoButton.TabIndex = 0;
            autoButton.Text = "Auto";
            autoButton.UseVisualStyleBackColor = true;
            autoButton.Click += autoButton_Click;
            // 
            // stepButton
            // 
            stepButton.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            stepButton.Location = new Point(299, 384);
            stepButton.Name = "stepButton";
            stepButton.Size = new Size(131, 36);
            stepButton.TabIndex = 1;
            stepButton.Text = "Step";
            stepButton.UseVisualStyleBackColor = true;
            stepButton.Click += stepButton_Click;
            // 
            // stepTimer
            // 
            stepTimer.Interval = 1000;
            stepTimer.Tick += stepTimer_Tick;
            // 
            // backButton
            // 
            backButton.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            backButton.Location = new Point(25, 384);
            backButton.Name = "backButton";
            backButton.Size = new Size(131, 36);
            backButton.TabIndex = 2;
            backButton.Text = "Back";
            backButton.UseVisualStyleBackColor = true;
            backButton.Click += backButton_Click;
            // 
            // addButton
            // 
            addButton.Location = new Point(16, 384);
            addButton.Name = "addButton";
            addButton.Size = new Size(131, 36);
            addButton.TabIndex = 3;
            addButton.Text = "Add strategy";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // removeButton
            // 
            removeButton.Location = new Point(173, 384);
            removeButton.Name = "removeButton";
            removeButton.Size = new Size(131, 36);
            removeButton.TabIndex = 4;
            removeButton.Text = "Remove strategy";
            removeButton.UseVisualStyleBackColor = true;
            removeButton.Click += removeButton_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button3);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(removeButton);
            groupBox1.Controls.Add(richTextBox1);
            groupBox1.Controls.Add(addButton);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(310, 426);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Bot descriptions";
            // 
            // button3
            // 
            button3.Location = new Point(173, 342);
            button3.Name = "button3";
            button3.Size = new Size(131, 36);
            button3.TabIndex = 9;
            button3.Text = "Remove Bot";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button1
            // 
            button1.Location = new Point(16, 342);
            button1.Name = "button1";
            button1.Size = new Size(131, 36);
            button1.TabIndex = 7;
            button1.Text = "Add Bot";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            richTextBox1.Location = new Point(16, 22);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.ScrollBars = RichTextBoxScrollBars.Vertical;
            richTextBox1.Size = new Size(288, 314);
            richTextBox1.TabIndex = 6;
            richTextBox1.Text = "";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(chart1);
            groupBox2.Controls.Add(valueLabel);
            groupBox2.Controls.Add(richTextBox2);
            groupBox2.Controls.Add(avLabel);
            groupBox2.Controls.Add(stepButton);
            groupBox2.Controls.Add(backButton);
            groupBox2.Controls.Add(autoButton);
            groupBox2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox2.Location = new Point(328, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(460, 426);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            groupBox2.Text = "Market";
            groupBox2.Enter += groupBox2_Enter;
            // 
            // valueLabel
            // 
            valueLabel.AutoSize = true;
            valueLabel.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            valueLabel.ForeColor = Color.ForestGreen;
            valueLabel.Location = new Point(270, 336);
            valueLabel.Name = "valueLabel";
            valueLabel.Size = new Size(54, 45);
            valueLabel.TabIndex = 4;
            valueLabel.Text = "$0";
            valueLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // richTextBox2
            // 
            richTextBox2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            richTextBox2.Location = new Point(6, 22);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.ReadOnly = true;
            richTextBox2.ScrollBars = RichTextBoxScrollBars.Vertical;
            richTextBox2.Size = new Size(150, 311);
            richTextBox2.TabIndex = 10;
            richTextBox2.Text = "";
            // 
            // avLabel
            // 
            avLabel.AutoSize = true;
            avLabel.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            avLabel.Location = new Point(25, 336);
            avLabel.Name = "avLabel";
            avLabel.Size = new Size(239, 45);
            avLabel.TabIndex = 3;
            avLabel.Text = "Account Value: ";
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chart1.Legends.Add(legend1);
            chart1.Location = new Point(160, 22);
            chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chart1.Series.Add(series1);
            chart1.Size = new Size(294, 311);
            chart1.TabIndex = 11;
            chart1.Text = "Total account value";
            // 
            // mainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(groupBox1);
            Controls.Add(groupBox2);
            Name = "mainForm";
            Text = "Market Bot";
            Load += mainForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button autoButton;
        private Button stepButton;
        private System.Windows.Forms.Timer stepTimer;
        private Button backButton;
        private Button addButton;
        private Button removeButton;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private RichTextBox richTextBox1;
        private Label valueLabel;
        private Label avLabel;
        private Button button3;
        private Button button1;
        private RichTextBox richTextBox2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}
