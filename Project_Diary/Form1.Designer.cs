namespace Project_Diary
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
            monthCalendar1 = new MonthCalendar();
            button1 = new Button();
            SuspendLayout();
            // 
            // monthCalendar1
            // 
            monthCalendar1.BoldedDates = new DateTime[]
    {
    new DateTime(2024, 1, 23, 0, 0, 0, 0)
    };
            monthCalendar1.FirstDayOfWeek = Day.Monday;
            monthCalendar1.Location = new Point(19, 21);
            monthCalendar1.Margin = new Padding(10, 12, 10, 12);
            monthCalendar1.Name = "monthCalendar1";
            monthCalendar1.TabIndex = 0;
            monthCalendar1.TitleBackColor = SystemColors.ActiveCaptionText;
            monthCalendar1.TrailingForeColor = SystemColors.ControlText;
            monthCalendar1.DateChanged += monthCalendar1_DateChanged;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            button1.Location = new Point(42, 244);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(151, 44);
            button1.TabIndex = 1;
            button1.Text = "Fill the diary";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(247, 312);
            Controls.Add(button1);
            Controls.Add(monthCalendar1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Diary";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private MonthCalendar monthCalendar1;
        private Button button1;
    }
}
