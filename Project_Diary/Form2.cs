using System.Diagnostics;
using System.Text.Json;

namespace Project_Diary
{

    public partial class Form2 : Form
    {

        private Dictionary<DateTime, Form1.DiaryProperties> diaryDictionary;
        private DateTime selectedDate;

        public Form2(Dictionary<DateTime, Form1.DiaryProperties> diaryPropertiesDictionary, DateTime selectedDate)
        {
            this.diaryDictionary = diaryPropertiesDictionary;
            this.selectedDate = selectedDate;


            InitializeComponent();

            if (diaryPropertiesDictionary.ContainsKey(selectedDate) && diaryPropertiesDictionary[selectedDate].Mood != null)
            {
                string exist_mood = diaryPropertiesDictionary[selectedDate].Mood;

                System.Windows.Forms.Button buttonToChange = GetButtonObj(exist_mood);

                buttonToChange.BackColor = SelectColorByMood(buttonToChange.Text);
            }



        }
        private void LogoutDictionary()
        {
            Debug.WriteLine("Diary properties:");
            foreach (var element in this.diaryDictionary) //перебор всех элементов dictionary
            {
                DateTime date = element.Key;
                Form1.DiaryProperties properties = element.Value;

                Debug.WriteLine($"Date: {date}. Mood: {properties.Mood}. NotesList: {properties.NotesList}. ShopingList: {properties.ShoppingList}");
            }
        }

        private void MoodTracker(string mood)
        {

            // Create a new DiaryProperties object with the Mood parameter
            Form1.DiaryProperties newProperties;
            if (this.diaryDictionary.ContainsKey(selectedDate))
            {
                newProperties = new Form1.DiaryProperties
                {
                    Mood = mood,
                    NotesList = this.diaryDictionary[selectedDate].NotesList,
                    ShoppingList = this.diaryDictionary[selectedDate].ShoppingList
                };
            }
            else
            {
                newProperties = new Form1.DiaryProperties
                {
                    Mood = mood,
                };
            }


            // Add the new entry to the dictionary with the selectedDate as the key
            this.diaryDictionary[selectedDate] = newProperties;
            LogoutDictionary();
            // Save the updated dictionary to the file
        }

        private Color SelectColorByMood(string mood)
        {
            if (mood == "Happy")
            {
                return Color.Yellow;
            }
            else if (mood == "Sad")
            {
                return Color.Blue;
            }
            else if (mood == "Angry")
            {
                return Color.Red;
            }
            else if (mood == "Anxious")
            {
                return Color.Violet;
            }
            else return Color.White;

        }
        private System.Windows.Forms.Button GetButtonObj(string mood)
        {
            if (mood == "Happy")
            {
                return button1;
            }
            else if (mood == "Sad")
            {
                return button2;
            }
            else if (mood == "Angry")
            {
                return button3;
            }
            else if (mood == "Anxious")
            {
                return button4;
            }
            else return null;

        }
        private void Form2_Load(object sender, EventArgs e)
        {
            // label2.Text = selectedDate.ToShortDateString();
        }
        private void label1_Click(object sender, EventArgs e)
        { }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void ResetButtonColor()
        {
            button1.BackColor = Color.White;
            button2.BackColor = Color.White;
            button3.BackColor = Color.White;
            button4.BackColor = Color.White;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ResetButtonColor();
            MoodTracker(button1.Text);
            button1.BackColor = SelectColorByMood(button1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ResetButtonColor();
            MoodTracker(button2.Text);
            button2.BackColor = SelectColorByMood(button2.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ResetButtonColor();
            MoodTracker(button3.Text);
            button3.BackColor = SelectColorByMood(button3.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ResetButtonColor();
            MoodTracker(button4.Text);
            button4.BackColor = SelectColorByMood(button4.Text);
        }
    }
}
