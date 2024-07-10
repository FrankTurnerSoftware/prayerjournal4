using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.Configuration;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;

namespace PrayerJournal.Models
{
    public class FileModel
    {
        public ObservableCollection<PrayerItem> CurrentItems { get; set; }
        public ObservableCollection<PrayerItem> HistoryItems { get; set; }
        public string FilePath {  get; set; }

        public FileModel(ObservableCollection<PrayerItem> currentitems,
                            ObservableCollection<PrayerItem> historyitems)
        {
            CurrentItems = currentitems;
            HistoryItems = historyitems;
        }

        public string OpenFile()
        {
            string returnMessage = "";
            string json;
            List<PrayerItem> fullPrayerList = null;
            try
            {
                json = OpenFileFromDialog();
                fullPrayerList = JsonSerializer.Deserialize<List<PrayerItem>>(json);
                List<PrayerItem> currentItems = fullPrayerList.Where(item => item.IsHistory == false).ToList();
                List<PrayerItem> historyItems = fullPrayerList.Where(item => item.IsHistory == true).ToList();
                CurrentItems = new ObservableCollection<PrayerItem>(currentItems);
                HistoryItems = new ObservableCollection<PrayerItem>(historyItems);

                returnMessage = "File Opened Successfully";
            }
            catch (Exception ex)
            {
                returnMessage = $"I was not able to read the file.\n\nError Details:\n{ex}";
            }
            return returnMessage;
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

                successResponse = "Saved Successfully.";
            }
            catch (Exception ex)
            {
                successResponse = $"Save Didn't Work \n\n{ex.Message}";
            }

            return successResponse;
        }
    }
}
