using System.Collections.ObjectModel;
using System.Configuration;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;

namespace PrayerJournal.Models
{
    public class FileModel
    {
        public ObservableCollection<PrayerItem> CurrentItems { get; set; }
        public ObservableCollection<PrayerItem> HistoryItems { get; set; }

        public FileModel(ObservableCollection<PrayerItem> currentitems,
                            ObservableCollection<PrayerItem> historyitems)
        {
            CurrentItems = currentitems;
            HistoryItems = historyitems;
        }

        public string SaveAllItems(string filename)
        {
            string successResponse = "";
            try
            {
                List<PrayerItem> fullList = new List<PrayerItem>();
                fullList.AddRange(CurrentItems);
                fullList.AddRange(HistoryItems);

                string jsonString = JsonSerializer.Serialize(fullList);
                File.WriteAllText(filename, jsonString);

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
