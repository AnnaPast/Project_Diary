using System;
using System.Diagnostics;
using System.Text.Json;
using System.Windows.Forms;

namespace Project_Diary
{
    public partial class Form1 : Form
    {
        // inicializuojam dictionary tam kad sauguoti properties
        public Dictionary<DateTime, DiaryProperties> diaryPropertiesDictionary = new Dictionary<DateTime, DiaryProperties>();
        
        public DateTime selectedDate { get; set; } //saugojam išsirinkta data su galimibe ja modifikuoti už klases

        // failo kelias
        string JsonFilePath = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "/diary_properties.json"; 


        public class DiaryProperties
        {
            public string? Mood { get; set; }
            public string? NotesList { get; set; }
            public string? ShoppingList { get; set; }
        }

        public Form1()
        {
            Debug.WriteLine("JsonFile path: " + JsonFilePath);
            ReadDictionaryFromFile(JsonFilePath); //skaitom jau turinčius properties iš Json

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            selectedDate = monthCalendar1.SelectionStart; //priskiriam selectedDate data iš kalendoriaus

            Form2 secondForm = new Form2(diaryPropertiesDictionary, selectedDate);
            secondForm.ShowDialog();

            SaveDictionaryToFile(JsonFilePath); //saugojam naujas properties i dictionary po form2 uzdarymo
        
        }
        private void ReadDictionaryFromFile(string JsonFilePathVar) //metodas propertis skaitimui iš Json
        {
            if (File.Exists(JsonFilePathVar))
            {
                string json = File.ReadAllText(JsonFilePathVar); //skaitom ka turime file ir idedam i json

                diaryPropertiesDictionary = JsonSerializer.Deserialize<Dictionary<DateTime, DiaryProperties>>(json); //idedam desirealizota informacija i diaryPropertiesDictionary
            }

            LogoutDictionary(); 
        }
        private void LogoutDictionary() //debugingui
        {
            Debug.WriteLine("Diary properties:");
            foreach (var element in diaryPropertiesDictionary)
            {
                DateTime date = element.Key;
                DiaryProperties properties = element.Value;

                Debug.WriteLine($"Date: {date}. Mood: {properties.Mood}. NotesList: {properties.NotesList}. ShopingList: {properties.ShoppingList}");
            }
        }

        private void SaveDictionaryToFile(string filePath) //metodas informacijos saugojimui json file
        {
            JsonSerializerOptions options = new JsonSerializerOptions //nauduojau iš interneto
            {
                WriteIndented = true
            };

            string json = JsonSerializer.Serialize(diaryPropertiesDictionary, options); //serializuoja duomenis

            File.WriteAllText(filePath, json); //irašom i file
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
