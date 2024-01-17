using System;
using System.Windows.Forms;

namespace Project_Diary
{
    public partial class Form1 : Form
    {
       
 

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = monthCalendar1.SelectionStart;

            using (Form2 secondForm = new Form2(selectedDate))
            {
                secondForm.ShowDialog();
            }           
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}
