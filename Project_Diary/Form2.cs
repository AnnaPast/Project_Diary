using System.Diagnostics;
using System.Text.Json;

namespace Project_Diary
{

    public partial class Form2 : Form
    {
        public Dictionary<DateTime, DiaryProperties> diaryPropertiesDictionary = new Dictionary<DateTime, DiaryProperties>();
        public class DiaryProperties
        {
            public string? Mood { get; set; }
            public string? NotesList { get; set; }
            public string? ShoppingList { get; set; }
        }
        string JsonFilePath = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "/diary_properties.json"; //возвращает директорию в  которой находится исполняемый файл текущего приложения. 
        public DateTime selectedDate;
        public Form2(DateTime selectedDate)
        {
            Debug.WriteLine("JsonFile path: " + JsonFilePath);
            ReadDictionaryFromFile(JsonFilePath);
            InitializeComponent();
            this.selectedDate = selectedDate;

            if (diaryPropertiesDictionary.ContainsKey(selectedDate) && diaryPropertiesDictionary[selectedDate].Mood != null)
            {
                string exist_mood = diaryPropertiesDictionary[selectedDate].Mood;

                System.Windows.Forms.Button buttonToChange = GetButtonObj(exist_mood);

                buttonToChange.BackColor = SelectColorByMood(buttonToChange.Text);
            }



        }
        private void ReadDictionaryFromFile(string JsonFilePathVar)
        {
            if (File.Exists(JsonFilePathVar))
            {
                string json = File.ReadAllText(JsonFilePathVar);

                diaryPropertiesDictionary = JsonSerializer.Deserialize<Dictionary<DateTime, DiaryProperties>>(json);//десириализация из json в dictionart
            }

            // Print the dictionary to the debug output
            LogoutDictionary();
        }
        private void LogoutDictionary()
        {
            Debug.WriteLine("Diary properties:");
            foreach (var element in diaryPropertiesDictionary) //перебор всех элементов dictionary
            {
                DateTime date = element.Key;
                DiaryProperties properties = element.Value;

                Debug.WriteLine($"Date: {date}. Mood: {properties.Mood}. NotesList: {properties.NotesList}. ShopingList: {properties.ShoppingList}");
            }
        }
        private void SaveDictionaryToFile(string filePath)
        {
            JsonSerializerOptions options = new JsonSerializerOptions //опция для структуризирования
            {
                WriteIndented = true
            };

            // Serialize the merged data to JSON
            string json = JsonSerializer.Serialize(diaryPropertiesDictionary, options);

            // Write the merged data to the file
            File.WriteAllText(filePath, json);
            LogoutDictionary();

        }

        private void MoodTracker(string mood)
        {

            // Create a new DiaryProperties object with the Mood parameter
            DiaryProperties newProperties;
            if (diaryPropertiesDictionary.ContainsKey(selectedDate))
            {
                newProperties = new DiaryProperties
                {
                    Mood = mood,
                    NotesList = diaryPropertiesDictionary[selectedDate].NotesList,
                    ShoppingList = diaryPropertiesDictionary[selectedDate].ShoppingList
                };
            }
            else
            {
                newProperties = new DiaryProperties
                {
                    Mood = mood,
                };
            }


            // Add the new entry to the dictionary with the selectedDate as the key
            diaryPropertiesDictionary[selectedDate] = newProperties;

            // Save the updated dictionary to the file
            SaveDictionaryToFile(JsonFilePath);
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
            MoodTracker
                (button1.Text);
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
