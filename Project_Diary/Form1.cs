using System;
using System.Windows.Forms;

namespace Project_Diary
{
    public partial class Form1 : Form
    {

        public Dictionary<DateTime, DiaryProperties> diaryPropertiesDictionary = new Dictionary<DateTime, DiaryProperties>();
        public DateTime selectedDate { get; set; }

        public class DiaryProperties
        {
            public string? Mood { get; set; }
            public string? NotesList { get; set; }
            public string? ShoppingList { get; set; }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            selectedDate = monthCalendar1.SelectionStart;

            Form2 secondForm = new Form2(diaryPropertiesDictionary, selectedDate);
            secondForm.ShowDialog();
        
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}
