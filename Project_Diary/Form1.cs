using System;
using System.Diagnostics;
using System.Text.Json;
using System.Windows.Forms;

namespace Project_Diary
{
    public partial class Form1 : Form
    {

        public Dictionary<DateTime, DiaryProperties> diaryPropertiesDictionary = new Dictionary<DateTime, DiaryProperties>();
        public DateTime selectedDate { get; set; }

        string JsonFilePath = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "/diary_properties.json"; //?????????? ?????????? ?  ??????? ????????? ??????????? ???? ???????? ??????????. 


        public class DiaryProperties
        {
            public string? Mood { get; set; }
            public string? NotesList { get; set; }
            public string? ShoppingList { get; set; }
        }

        public Form1()
        {
            Debug.WriteLine("JsonFile path: " + JsonFilePath);
            ReadDictionaryFromFile(JsonFilePath);

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            selectedDate = monthCalendar1.SelectionStart;

            Form2 secondForm = new Form2(diaryPropertiesDictionary, selectedDate);
            secondForm.ShowDialog();
            SaveDictionaryToFile(JsonFilePath);
            Debug.WriteLine("done");
        
        }
        private void ReadDictionaryFromFile(string JsonFilePathVar)
        {
            if (File.Exists(JsonFilePathVar))
            {
                string json = File.ReadAllText(JsonFilePathVar);

                diaryPropertiesDictionary = JsonSerializer.Deserialize<Dictionary<DateTime, DiaryProperties>>(json);//?????????????? ?? json ? dictionart
            }

            // Print the dictionary to the debug output
            LogoutDictionary();
        }
        private void LogoutDictionary()
        {
            Debug.WriteLine("Diary properties:");
            foreach (var element in diaryPropertiesDictionary) //??????? ???? ????????? dictionary
                {
                    DateTime date = element.Key;
                    DiaryProperties properties = element.Value;

                    Debug.WriteLine($"Date: {date}. Mood: {properties.Mood}. NotesList: {properties.NotesList}. ShopingList: {properties.ShoppingList}");
                }
        }

        private void SaveDictionaryToFile(string filePath)
        {
            JsonSerializerOptions options = new JsonSerializerOptions //????? ??? ??????????????????
            {
                WriteIndented = true
            };

            // Serialize the merged data to JSON
            string json = JsonSerializer.Serialize(diaryPropertiesDictionary, options);

            // Write the merged data to the file
            File.WriteAllText(filePath, json);
            LogoutDictionary();

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}
