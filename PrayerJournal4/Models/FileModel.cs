using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;

namespace PrayerJournal.Models
{
    public class FileModel
    {
        public ObservableCollection<PrayerItem> CurrentItems { get; set; }
        public ObservableCollection<PrayerItem> HistoryItems { get; set; }
        public string FilePath { get; set; }

        public FileModel(ObservableCollection<PrayerItem> currentitems,
                            ObservableCollection<PrayerItem> historyitems)
        {
            CurrentItems = currentitems;
            HistoryItems = historyitems;
        }

        private string OpenFileFromDialog()
        {
            string returnJSON = "";

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Prayer List File (*.json)|*.json|All files (*.*)|*.*";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (openFileDialog.ShowDialog() == true)
            {
                string filename = openFileDialog.FileName;
                returnJSON = File.ReadAllText(filename);
                FilePath = filename;
            }

            return returnJSON;
        }

        public void OpenFile(string jsonContent)
        {
            List<PrayerItem> fullPrayerList;
            fullPrayerList = JsonSerializer.Deserialize<List<PrayerItem>>(jsonContent);

            List<PrayerItem> currentItems = fullPrayerList.Where(item => item.IsHistory == false).ToList();
            List<PrayerItem> historyItems = fullPrayerList.Where(item => item.IsHistory == true).ToList();

            CurrentItems = new ObservableCollection<PrayerItem>(currentItems);
            HistoryItems = new ObservableCollection<PrayerItem>(historyItems);
        }
        
        public string OpenFileWithDialog()
        {
            string returnMessage = "";
            string jsonFile;

            try
            {
                jsonFile = OpenFileFromDialog();
                OpenFile(jsonFile);

                returnMessage = "File opened successfully.";
            }
            catch (Exception ex)
            {
                returnMessage = $"I was not able to read the file.\n\nError Details:\n{ex}";
            }
            return returnMessage;
        }

        public string SaveAllItems(string path)
        {
            string successResponse = "";
            try
            {
                List<PrayerItem> fullList = new List<PrayerItem>();
                fullList.AddRange(CurrentItems);
                fullList.AddRange(HistoryItems);

                string jsonString = JsonSerializer.Serialize(fullList);
                File.WriteAllText(path, jsonString);

                successResponse = "Save successful.";
            }
            catch (Exception ex)
            {
                successResponse = $"Save unsuccessful.\n\n{ex.Message}";
            }

            return successResponse;
        }
    }
}
